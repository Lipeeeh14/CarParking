using CarParking.Data.Mapping;
using CarParking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarParking.Data
{
	public class CarParkingContext : DbContext
	{
		public CarParkingContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) 
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new SetorMapping());
			modelBuilder.ApplyConfiguration(new VagaMapping());
		}

        public DbSet<Setor> Setor { get; set; }
        public DbSet<Vaga> Vaga { get; set; }
    }
}
