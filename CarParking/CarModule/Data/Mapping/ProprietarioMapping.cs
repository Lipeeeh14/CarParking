using CarModule.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarModule.Data.Mapping
{
	public class ProprietarioMapping : IEntityTypeConfiguration<Proprietario>
	{
		public void Configure(EntityTypeBuilder<Proprietario> builder)
		{
			builder.ToTable("Proprietario");

			builder.HasKey(p => p.Id);

			builder.Property(p => p.Nome)
				.HasMaxLength(100)
				.IsRequired();

			builder.Property(p => p.CPF)
				.HasMaxLength(11)
				.IsRequired();

			builder.HasMany(p => p.Veiculos)
				.WithOne(v => v.Proprietario)
				.HasForeignKey(p => p.ProprietarioId)
				.IsRequired();
		}
	}
}
