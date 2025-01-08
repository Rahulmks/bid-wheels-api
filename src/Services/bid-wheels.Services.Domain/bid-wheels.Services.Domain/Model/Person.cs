namespace bid_wheels.Services.Domain.Model
{
	public class Person
	{
		public int PersonId { get; set; }
		public string Name { get; set; }
		public string? MailId { get; set; }
		public string PhoneNumber { get; set; }
		public string Password { get; set; }
		public int Feedback { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? LastModifiedDate { get; set; }
		public string UserType { get; set; }

		public ICollection<User> Users { get; set; } = new List<User>();
		public ICollection<Driver> Drivers { get; set; } = new List<Driver>();
	}
}
