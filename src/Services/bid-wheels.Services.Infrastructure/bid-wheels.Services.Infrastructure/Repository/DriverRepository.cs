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

		public List<DriverOrderResponse> GetOrders(int driverId)
		{
			var driver = dbContext.Drivers
				.Where(d => d.DriverId == driverId)
				.Select(d => d)
				.FirstOrDefault();

			if (driver == null)
			{
				throw new Exception("Driver not found");
			}

			var vehicle = dbContext.Vehicles
				.Where(v => v.VehicleId == driver.VehicleId)
				.FirstOrDefault();

			if (vehicle == null)
			{
				throw new Exception("Vehicle not found");
			}

			var driverBids = dbContext.Bids
				.Where(b => b.DriverId == driverId)
				.Select(b => b.OrderId)
				.ToHashSet();

			var result = dbContext.Orders
				.Where(o => o.VehicleType == vehicle.VehicleType)
				.Select(o => new DriverOrderResponse
				{
					OrderId = o.OrderId, 
					UserId = o.UserId,
					Source = o.Source,
					Destination = o.Destination,
					SourceGPSCoordinates = o.SourceGPSCoordinates,
					DestinationGPSCoordinates = o.DestinationGPSCoordinates,
					ProductType = o.ProductType,
					PreferredTime = o.PreferredTime,
					EstimatedCost = 1233,
					AlreadyBidded = driverBids.Contains(o.OrderId)
				})
				.ToList();

			return result;
		}
	}
}
