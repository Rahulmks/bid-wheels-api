using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bid_wheels.Services.Domain.Model;

namespace bid_wheels.Services.Domain
{
	public interface IPersonRepository
	{
		public Person GetPerson();
	}
}
