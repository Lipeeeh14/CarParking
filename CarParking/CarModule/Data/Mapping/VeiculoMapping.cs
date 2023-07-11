using CarModule.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarModule.Data.Mapping
{
	public class VeiculoMapping : IEntityTypeConfiguration<Veiculo>
	{
		public void Configure(EntityTypeBuilder<Veiculo> builder)
		{
			builder.ToTable("Veiculo");

			builder.HasKey(v => v.Placa);
			builder.Property(v => v.Placa)
				.HasMaxLength(7)
				.IsRequired();

			builder.Property(v => v.Marca)
				.HasMaxLength(30)
				.IsRequired();

			builder.Property(v => v.Modelo)
				.HasMaxLength(50)
				.IsRequired();

			builder.HasOne(v => v.Proprietario)
				.WithMany(p => p.Veiculos)
				.HasForeignKey(v => v.ProprietarioId)
				.IsRequired();
		}
	}
}
