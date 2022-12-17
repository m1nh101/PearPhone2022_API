using Core.Entities;
using Core.Interfaces;

namespace Core.Specifications;

public class SaleSpecification : Specification<Sale>
{
	public SaleSpecification(int id)
		:base(e => e.Id == id)
	{
	}
}