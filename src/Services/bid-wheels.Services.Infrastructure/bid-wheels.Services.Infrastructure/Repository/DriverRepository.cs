using bid_wheels.Services.Domain;
using bid_wheels.Services.Domain.Model;

namespace bid_wheels.Services.Infrastructure.Repository
{
	public class DriverRepository: IDriverRepository
	{
		public DatabaseContext dbContext;

		public DriverRepository(DatabaseContext context)
		{
			dbContext = context;
		}

		public async Task AddBidAsync(Bid bid)
		{
			await using var transaction = await dbContext.Database.BeginTransactionAsync();
			try
			{
				dbContext.Database.CreateExecutionStrategy();

				await dbContext.AddAsync(bid);

				await transaction.CommitAsync();
			}
			catch(Exception ex)
			{
				await transaction.RollbackAsync();
				throw;
			}
		}

		public async Task UpdateBidAsync(Bid bid)
		{
			await using var transaction = await dbContext.Database.BeginTransactionAsync();
			try
			{
				var existingBid = await dbContext.Bids.FindAsync(bid.BidId);
				if (existingBid != null)
				{
					existingBid.Price = bid.Price;
					existingBid.ServiceDays = bid.ServiceDays;
					existingBid.LastModifiedDate = DateTime.UtcNow;

					dbContext.Bids.Update(existingBid);
					await dbContext.SaveChangesAsync();
					await transaction.CommitAsync();
				}
				else
				{
					throw new Exception("Bid not found");
				}
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				throw;
			}
		}

		public List<OrderBase> GetOrders(int driverId)
		{
			var driver = dbContext.Drivers.Where(driver => driver.DriverId == driverId)
				.Select(driver => driver).First();

			var vehicle = dbContext.Vehicles.Where(v => v.VehicleId == driver.VehicleId).First();

			var result = dbContext.Orders.Where(orders => orders.VehicleType == vehicle.VehicleType)
				.Select(orders => new OrderBase
				{ Source = orders.Source,
				  Destination = orders.Destination,
				  SourceGPSCoordinates = orders.SourceGPSCoordinates,
				  DestinationGPSCoordinates = orders.DestinationGPSCoordinates,
				  ProductType = orders.ProductType,
				  PreferredTime = orders.PreferredTime
				   }).ToList();

			return result;
		}
	}
}
