using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bid_wheels.Services.Domain.Model
{
	public class Person
	{
		public int PersonId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Password { get; set; }
		public int feedback { get; set; }
	}
}
