using Admin.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Data.Migrations
{
    public class CatalogMapping : IEntityTypeConfiguration<Catalog>
    {
        public void Configure(EntityTypeBuilder<Catalog> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Database)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Host)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.ToTable("Catalog");
        }
    }
}
