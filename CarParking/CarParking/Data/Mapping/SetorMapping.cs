using CarParking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarParking.Data.Mapping
{
    public class SetorMapping : IEntityTypeConfiguration<Setor>
	{
		public void Configure(EntityTypeBuilder<Setor> builder)
		{
			builder.ToTable("Setor");

			builder.HasKey(s => s.Id);
			
			builder.Property(s => s.Sigla)
				.HasMaxLength(2)
				.IsRequired();

			builder.HasMany(s => s.Vagas)
				.WithOne(v => v.Setor)
				.HasForeignKey(s => s.SetorId)
				.IsRequired();
		}
	}
}
