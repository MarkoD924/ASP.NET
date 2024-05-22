using Microsoft.EntityFrameworkCore;
using Menu.Models;
using Azure;

namespace Menu.Data
{
	public class MenuContekst : DbContext
	{
		public MenuContekst(DbContextOptions<MenuContekst> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SastojakJela>().HasKey(di => new
			{						  
				di.JelaId,			  
				di.SastojciId		  
			});						  
			modelBuilder.Entity<SastojakJela>().HasOne(j => j.Jelo).WithMany(di => di.SastojakJela).HasForeignKey(d => d.JelaId);
			modelBuilder.Entity<SastojakJela>().HasOne(s => s.Sastojak).WithMany(di => di.SastojakJela).HasForeignKey(d => d.JelaId);

			modelBuilder.Entity<Jelo>().HasData(
				new Jelo { Id = 1, Ime = "Margarita", Cena = 1500, ImageUrl = "https://images.prismic.io/eataly-us/ed3fcec7-7994-426d-a5e4-a24be5a95afd_pizza-recipe-main.jpg?auto=compress,format" });

			modelBuilder.Entity<Sastojak>().HasData(
			   new Sastojak { Id = 1, Ime = "Paradajz sos" },
			   new Sastojak { Id = 2, Ime = "Mocarela" }
			   );

			modelBuilder.Entity<SastojakJela>().HasData(
			  new SastojakJela { JelaId = 1, SastojciId = 1 },
			  new SastojakJela { JelaId = 1, SastojciId = 2 }
			  );

			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Jelo> Jelo { get; set; }
		public DbSet<Sastojak> Sastojak { get; set; }
		public DbSet<SastojakJela> SastojakJela { get; set; }
	}
}