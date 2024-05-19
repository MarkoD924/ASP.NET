namespace Menu.Models
{
	public class Sastojak
	{
		public int Id { get; set; }

		public string Ime { get; set; }

		public List<SastojakJela>? SastojakJela { get; set; }


	}
}
