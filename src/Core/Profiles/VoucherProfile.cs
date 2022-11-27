using AutoMapper;
using Core.CQRS.Vouchers.Create;
using Core.Entities.Payments;

namespace Core.Profiles;

public class VoucherProfile : Profile
{ 
  public VoucherProfile()
  {
    CreateMap<Voucher, CreatedVoucherResponse>();
  }
}