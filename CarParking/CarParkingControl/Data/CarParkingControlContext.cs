using CarParkingControl.Data.Mapping;
using CarParkingControl.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarParkingControl.Data
{
	public class CarParkingControlContext : DbContext
	{
		public CarParkingControlContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new RegistroVagaMapping());
		}

        public DbSet<RegistroVaga> RegistroVaga { get; set; }
    }
}
