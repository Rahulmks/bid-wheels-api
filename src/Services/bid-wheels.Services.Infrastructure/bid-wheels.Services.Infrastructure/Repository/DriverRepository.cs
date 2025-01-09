using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bid_wheels.Services.Domain;
using bid_wheels.Services.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

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
	}
}
