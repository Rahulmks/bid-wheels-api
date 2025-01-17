﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bid_wheels.Services.Domain.Model;

namespace bid_wheels.Services.Domain
{
	public interface IDriverRepository
	{
		public Task AddBidAsync(Bid bid);

		public List<DriverOrderResponse> GetOrders(int driverId);

		public Task UpdateBidAsync(Bid bid);
	}
}
