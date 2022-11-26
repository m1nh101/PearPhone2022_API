using Core.CQRS.ShippingAddresses.Add;
using Core.CQRS.ShippingAddresses.Update;
using FluentValidation;

namespace Core.Validations;

public class ShippingAddressValidation : AbstractValidator<AddShippingAddressRequest>
{
  public ShippingAddressValidation()
  {
    RuleFor(e => e.Address).NotEmpty().WithMessage("Không được để trống");
  }
}

public class UpdateShippingAddressValidation : AbstractValidator<UpdateShippingAddressRequest>
{
  public UpdateShippingAddressValidation()
  {
    RuleFor(e => e.Address).NotEmpty().WithMessage("Không được để trống");
  }
}