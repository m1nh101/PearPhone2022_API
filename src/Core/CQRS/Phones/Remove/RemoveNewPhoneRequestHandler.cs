using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Phones.Remove;

public sealed record RemoveNewPhoneRequest(
    int phoneId
) : IRequest<ActionResponse>;
public sealed class RemoveNewPhoneRequestHandler : IRequestHandler<RemoveNewPhoneRequest, ActionResponse>
{
    private readonly IAppDbContext _context;
    public RemoveNewPhoneRequestHandler(IAppDbContext context)
    {
        _context = context;
    }
    public async Task<ActionResponse> Handle(RemoveNewPhoneRequest request, CancellationToken cancellationToken)
    {
        var phone = await _context.Phones.FirstOrDefaultAsync(c => c.Id == request.phoneId);
        if (phone == null) throw new NullReferenceException();

        phone.DeleteStock();
        _context.Phones.Update(phone);
        _context.Commit();
        return new ActionResponse(System.Net.HttpStatusCode.OK, "Xóa thành công", phone,
            default);
    }
}