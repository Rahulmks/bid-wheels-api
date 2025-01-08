namespace bid_wheels.Services.Domain.Model
{
	public class User
	{
		public int PersonId { get; set; }
		public int UserId { get; set; }

		public virtual Person Persons { get; set; } = null!;
		public ICollection<Order> Orders { get; set; } = new List<Order>();
	}
}
