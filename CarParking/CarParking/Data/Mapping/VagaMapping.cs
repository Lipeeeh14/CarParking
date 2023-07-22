using CarParking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarParking.Data.Mapping
{
    public class VagaMapping : IEntityTypeConfiguration<Vaga>
	{
		public void Configure(EntityTypeBuilder<Vaga> builder)
		{
			builder.ToTable("Vaga");
			builder.HasKey(v => v.Id);

			builder.HasOne(v => v.Setor)
				.WithMany(s => s.Vagas)
				.HasForeignKey(v => v.SetorId)
				.IsRequired();
		}
	}
}
