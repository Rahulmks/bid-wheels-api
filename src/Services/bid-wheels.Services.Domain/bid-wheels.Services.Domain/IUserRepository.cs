using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bid_wheels.Services.Domain.Model;

namespace bid_wheels.Services.Domain
{
	public interface IUserRepository
	{
		public bool AddOrder(OrderBase order);

		//public int GetUserIdByName(string name);

		public OrderDetailInfo GetOrderDetailsByOrderId(int orderId);
		public OrderDTO GetCurrentOrderStatusByOrderId(int orderId);


		//public IEnumerable<Bid> GetAllBidsByOrderId(int orderId);
	}
}
