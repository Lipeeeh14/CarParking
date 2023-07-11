using CarModule.Data.Mapping;
using CarModule.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarModule.Data
{
	public class CarContext : DbContext
	{
		public CarContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new VeiculoMapping());
			modelBuilder.ApplyConfiguration(new ProprietarioMapping());
		}

		public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Proprietario> Proprietario { get; set; }
	}
}
