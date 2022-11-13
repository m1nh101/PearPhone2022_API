using Core.CQRS.Phones.Add;
using Core.Entities.Phones;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CQRS.Phones.Update
{
    public sealed record UpdateNewPhoneRequest(
        int PhoneId,
        string Name,
        string CPU,
        IEnumerable<StockPayload> Stocks
    ) : IRequest<ActionResponse>;
    
    public sealed class UpdateNewPhoneRequestHandler : 
        IRequestHandler<UpdateNewPhoneRequest , ActionResponse>
    {
        private readonly IAppDbContext _context;

        public UpdateNewPhoneRequestHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResponse> Handle(UpdateNewPhoneRequest request, CancellationToken cancellationToken)
        {
            var phoneId = await _context.Phones.FirstOrDefaultAsync(c => c.Id == request.PhoneId);
            if(phoneId == null) throw new NullReferenceException();

            _context.Phones.Update(phoneId);
            await _context.Commit();
            return new ActionResponse(System.Net.HttpStatusCode.OK, "Sửa thành công", phoneId,
            default);
        }
    }
}
