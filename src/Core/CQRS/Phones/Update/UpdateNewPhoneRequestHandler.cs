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
        IEnumerable<StockPayload> Stocks,
        DetailPayload Detail
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
            var phone = await _context.Phones.FirstOrDefaultAsync(c => c.Id == request.PhoneId);
            if(phone == null) throw new NullReferenceException();

            var detail = new PhoneDetail(request.Detail.Battery, request.Detail.Screen, request.Detail.OS,
                request.Detail.Charger, request.Detail.Camera, request.Detail.Audio, request.Detail.Security);
            var stocks = request.Stocks
                .Select(e => new Stock(e.Quantity, e.Price, e.RAM, e.Capacity, new Color(e.Color.Name, e.Color.RGB), detail));

            phone.UpdateStock(stocks);

            _context.Phones.Update(phone);
            await _context.Commit();
            return new ActionResponse(System.Net.HttpStatusCode.OK, "Sửa thành công", phone,
            default);
        }
    }
}
