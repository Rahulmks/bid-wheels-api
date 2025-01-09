namespace bid_wheels.Services.Domain.Model
{
	public class Person
	{
		public int PersonId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Password { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? LastModifiedDate { get; set; }
		public string UserType { get; set; }
		public int No_of_Reviews { get; set; }
		
		public int AggreagateFeedback { get; set; }
	}
}
