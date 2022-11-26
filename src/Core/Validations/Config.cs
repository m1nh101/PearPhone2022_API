using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using FluentValidation;
using MediatR;

namespace Core.Validations;

public class Config<TRequest, TReponse>
  : IPipelineBehavior<TRequest, TReponse>
  where TRequest : IRequest<TReponse>
  where TReponse : ActionResponse
{
  private readonly IEnumerable<IValidator<TRequest>> _validators;

  public Config(IEnumerable<IValidator<TRequest>> validators)
  {
    _validators = validators;
  }

  public async Task<TReponse> Handle(TRequest request,
    CancellationToken cancellationToken,
    RequestHandlerDelegate<TReponse> next)
  {
    if (!_validators.Any())
      return await next();

    List<object> errors = new();

    foreach(var validator in _validators)
    {
      var validateResult = await validator.ValidateAsync(request);

      if (validateResult.IsValid)
        continue;

      var error = validateResult.Errors
     .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });

      errors.AddRange(error);
    }

    if (errors.Count == 0)
      return await next();

    var response = new ActionResponse(System.Net.HttpStatusCode.BadRequest, "Không thành công").WithError(errors);

    return (dynamic) response;
  }
}