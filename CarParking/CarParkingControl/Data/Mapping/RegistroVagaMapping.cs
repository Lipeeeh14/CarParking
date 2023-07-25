using CarParkingControl.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarParkingControl.Data.Mapping
{
	public class RegistroVagaMapping : IEntityTypeConfiguration<RegistroVaga>
	{
		public void Configure(EntityTypeBuilder<RegistroVaga> builder)
		{
			builder.ToTable("RegistroVaga");

			builder.HasKey(r => r.Id);

			builder.Property(r => r.PlacaVeiculo)
				.HasMaxLength(7)
				.IsRequired();
		}
	}
}
