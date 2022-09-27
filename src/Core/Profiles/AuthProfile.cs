using AutoMapper;
using Core.CQRS.Auth.Requests;
using Core.CQRS.Auth.Responses;
using Core.Entities.Users;

namespace Core.Profiles;

public class AuthProfile : Profile
{
	public AuthProfile()
	{
		CreateMap<RegisterNewUser, User>();

		CreateMap<User, UserResponse>()
			.ForMember(e => e.Fullname, d => d.MapFrom(x => x.GetFullName()));
	}
}