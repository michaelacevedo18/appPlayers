using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            // TODO Relaciones
            builder.HasOne(e => e.Position).WithMany()
                   .HasForeignKey(e => e.PositionId);
            builder.HasOne(e => e.Team).WithMany()
                   .HasForeignKey(e => e.TeamId);
        }
    } 
}
