using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Webmotors.Back9944.Models;

namespace Webmotors.Back9944.Data.Mappings
{
    public class AdvertisingMap : IEntityTypeConfiguration<Advertising>
    {
        public void Configure(EntityTypeBuilder<Advertising> builder)
        {
            builder.ToTable("tb_AnuncioWebmotors");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Marca).HasColumnType("VARCHAR(45)").IsRequired();
            builder.Property(a => a.Modelo).HasColumnType("VARCHAR(45)").IsRequired();
            builder.Property(a => a.Versao).HasColumnType("VARCHAR(45)").IsRequired();
            builder.Property(a => a.Ano).HasColumnType("INT").IsRequired();
            builder.Property(a => a.Quilometragem).HasColumnType("INT").IsRequired();
            builder.Property(a => a.Observacao).HasColumnType("TEXT").IsRequired();
        }
    }
}
