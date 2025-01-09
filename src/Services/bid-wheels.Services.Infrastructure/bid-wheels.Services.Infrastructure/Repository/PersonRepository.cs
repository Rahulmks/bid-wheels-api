using bid_wheels.Services.Domain;
using bid_wheels.Services.Domain.Model;

namespace bid_wheels.Services.Infrastructure.Repository
{
	public class PersonRepository : IPersonRepository
	{
		public DatabaseContext _context;

		public PersonRepository(DatabaseContext context)
		{
			_context = context;
		}

		public Person GetPerson()
		{
			var person = _context.Persons.Where(X => X.PersonId == 2)
				.Select(person => person).First();

			return person;
		}
		public List<OrderDTO> GetAllOrdersByPersonId(int personId)
		{
			var result = (from oi in _context.OrderInvoices
			join o in _context.Orders on oi.OrderId equals o.OrderId
			join u in _context.Users on o.UserId equals u.UserId
			join p in _context.Persons on u.PersonId equals p.PersonId
			where p.PersonId == personId
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

			}).ToList();

			return result;
		}
	}
}
