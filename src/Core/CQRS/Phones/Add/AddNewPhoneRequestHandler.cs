﻿using Core.Entities.Phones;
using Core.Interfaces;
using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Phones.Add;
public sealed record ColorPayload(
    int Id,
    string RGB,
    string Name
);

public sealed record DetailPayload(
    string Bettery,
    string Screen,
    string OS,
    string Charger,
    string Camera,
    string Audio,
    string Security
);
public sealed record StockPayload(
    ColorPayload Color,
    int RAM,
    int Quantity,
    double Price,
    int Capacity
);

public sealed record AddNewPhoneRequest(
    string Name,
    string CPU,
    IEnumerable<StockPayload> Stocks,
    DetailPayload Detail,
    IEnumerable<string> Images
) : IRequest<ActionResponse>;

public sealed class AddNewPhoneRequestHandler:IRequestHandler<AddNewPhoneRequest, ActionResponse>
{
    private readonly IAppDbContext _context;

    public AddNewPhoneRequestHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<ActionResponse> Handle(AddNewPhoneRequest request, CancellationToken cancellationToken)
    {
        var detail = new PhoneDetail(request.Detail.Bettery, request.Detail.Screen, request.Detail.OS,
            request.Detail.Charger, request.Detail.Camera, request.Detail.Audio, request.Detail.Security);
        var stocks = request.Stocks.Select(e => new Stock(e.Quantity, e.Price, e.RAM, e.Capacity, new Color(e.Color.Name, e.Color.RGB), detail));

        var phone = new Phone
        {
            Name = request.Name
        }.AddStock(stocks).AddImage(request.Images);

        await _context.Phones.AddAsync(phone);

        await _context.Commit();

        return new ActionResponse(System.Net.HttpStatusCode.OK, "Thêm thành công", phone,
            default);
    }
}