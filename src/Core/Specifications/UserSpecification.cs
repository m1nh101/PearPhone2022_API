using Core.Entities.Users;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Specifications;

public class UserSpecification : Specification<User>
{
  public UserSpecification(string id)
    :base(e => e.Id == id)
  {
    AddInclude(e => e.Include(d => d.Addresses));
  }
}