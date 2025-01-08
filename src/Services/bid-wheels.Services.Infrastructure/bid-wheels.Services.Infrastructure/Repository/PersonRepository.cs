using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bid_wheels.Services.Domain;
using bid_wheels.Services.Domain.Model;

namespace bid_wheels.Services.Infrastructure.Repository
{
	public class PersonRepository:IPersonRepository
	{
		public DatabaseContext _context;

		public PersonRepository(DatabaseContext context)
		{
			_context = context;
		}

		public Person GetPerson()
		{
			var person = _context.Person.Where(X => X.PersonId == 1)
				.Select(person => person).First();

			return person;
		}
	}
}
