using MediatR;

namespace Core.CQRS.Cart.ExportReceipt;

public sealed record ExportReceiptRequest(
  int OrderId
) : IRequest<MemoryStream>;