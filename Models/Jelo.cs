namespace Menu.Models
{
	public class Jelo
	{
		public int Id { get; set; }

		public string Ime { get; set; }

		public string ImageUrl { get; set; }

		public double Cena { get; set; }

		public List<SastojakJela>? SastojakJela { get; set; }
	}
}
