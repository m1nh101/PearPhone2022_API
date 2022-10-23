using Core.Entities.Orders;
using Microsoft.EntityFrameworkCore;

namespace Core.Helpers.Extensions;

public static class OrderExtension
{
	public static async Task<Order> CurrentOrder(this DbSet<Order> orders, string userId)
	{
		var order = await orders
      .Include(e => e.Items)
      .Where(e => e.UserId == userId)
      .Where(e => e.Status == Shared.Enums.Status.None)
      .Take(1)
      .FirstAsync();

		if(order == null)
			throw new NullReferenceException();

		return order;
	}
}