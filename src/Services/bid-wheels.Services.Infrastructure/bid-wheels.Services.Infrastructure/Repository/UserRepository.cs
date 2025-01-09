﻿using bid_wheels.Services.Domain;
using bid_wheels.Services.Domain.Model;

namespace bid_wheels.Services.Infrastructure.Repository
{
	public class UserRepository : IUserRepository
	{
		public DatabaseContext _context;

		public UserRepository(DatabaseContext context)
		{
			_context = context;
		}
		public OrderDetailInfo GetOrderDetailsByOrderId(int orderId)
		{
			var result = from o in _context.Orders
						 join oi in _context.OrderInvoices on o.OrderId equals oi.OrderId into ois
						 from oi in ois.DefaultIfEmpty()
						 join u in _context.Users on o.UserId equals u.UserId into us
						 from u in us.DefaultIfEmpty()
						 join p in _context.Persons on u.PersonId equals p.PersonId into ps
						 from p in ps.DefaultIfEmpty()
						 join b in _context.Bids on oi.BidId equals b.BidId into bs
						 from b in bs.DefaultIfEmpty()
						 join d in _context.Drivers on b.DriverId equals d.DriverId into ds
						 from d in ds.DefaultIfEmpty()
						 join person in _context.Persons on d.PersonId equals person.PersonId into persons
						 from person in persons.DefaultIfEmpty()
						 join os in _context.OrderStatuses on oi.OrderStatusId equals os.OrderStatusId into oss
						 from os in oss.DefaultIfEmpty()
						 where o.OrderId == orderId
						 select new OrderDetailInfo()
						 {
							 OrderId = o.OrderId,
							 UserPersonId = u.PersonId,
							 DriverPersonId = person.PersonId,
							 UserName = p.Name,
							 UserId = o.UserId,
							 Source = o.Source,
							 Destination = o.Destination,
							 ProductType = o.ProductType,
							 SourceGPSCoordinates = o.SourceGPSCoordinates,
							 DestinationGPSCoordinates = o.DestinationGPSCoordinates,
							 VehicleType = o.VehicleType,
							 PreferredTime = o.PreferredTime,
							 Status = o.Status,
							 CreatedDate = o.CreatedDate,
							 LastModifiedDate = o.LastModifiedDate,
							 BidId = oi.BidId,
							 DriverId = b.DriverId,
							 DriverName = person.Name,
							 Price = b.Price,
							 ServiceDays = b.ServiceDays,
							 BidCreatedDate = b.CreatedDate,
							 BidLastModifiedDate = b.LastModifiedDate,
							 OrderInvoiceId = oi.OrderInvoiceId,
							 PickUpDate = oi.PickUpDate,
							 InTransitDate = oi.InTransitDate,
							 DeliveryDate = oi.DeliveryDate,
							 DeliverStatus = os.Status,
							 OrderStatusId = os.OrderStatusId
						 };
			return result.FirstOrDefault();
		}

		public bool AddOrder(OrderBase order)
		{
			var newOrder = new Order()
			{
				UserId = order.UserId,
				Source = order.Source,
				Destination = order.Destination,
				ProductType = order.ProductType,
				SourceGPSCoordinates = order.SourceGPSCoordinates,
				DestinationGPSCoordinates = order.DestinationGPSCoordinates,
				VehicleType = order.VehicleType,
				PreferredTime = order.PreferredTime,
				Status = "Pending",
				CreatedDate = DateTime.Now,
				LastModifiedDate = DateTime.Now
			};
			_context.Orders.Add(newOrder);
			_context.SaveChanges();
			return true;

		}

		public OrderDTO GetCurrentOrderStatusByOrderId(int orderId)
		{
			var result = (from oi in _context.OrderInvoices
						  join o in _context.Orders on oi.OrderId equals o.OrderId
						  join u in _context.Users on o.UserId equals u.UserId
						  join p in _context.Persons on u.PersonId equals p.PersonId
						  where o.OrderId == orderId
						  select new OrderDTO()
						  {
							  OrderId = o.OrderId,
							  UserId = o.UserId,
							  Source = o.Source,
							  Destination = o.Destination,
							  ProductType = o.ProductType,
							  SourceGPSCoordinates = o.SourceGPSCoordinates,
							  DestinationGPSCoordinates = o.DestinationGPSCoordinates,
							  VehicleType = o.VehicleType,
							  PreferredTime = o.PreferredTime,
							  Status = o.Status,
							  CreatedDate = o.CreatedDate
						  }).FirstOrDefault();
			return result;
		}
	}
}
