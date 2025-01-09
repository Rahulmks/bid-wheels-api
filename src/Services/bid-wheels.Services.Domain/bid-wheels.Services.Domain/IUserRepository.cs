using bid_wheels.Services.Domain.Model;

namespace bid_wheels.Services.Domain
{
	public interface IUserRepository
	{
		public Task AddOrder(OrderBase order);
		public OrderDetailInfo GetOrderDetailsByOrderId(int orderId);
		public OrderDTO GetCurrentOrderStatusByOrderId(int orderId);
		public List<OrderDTO> GetAllOrdersByUserId(int userId);
		public Task SelectBid(int orderId, int bidId);

		public Task AddFeedback(int driverId, int ratings);
	}
}
