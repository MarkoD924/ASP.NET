namespace Menu.Models
{
	public class SastojakJela
	{
		public int JelaId { get; set; }

		public Jelo Jelo { get; set; }

		public int SastojciId { get; set; }
		public Sastojak Sastojak { get; set; }
	}
}
