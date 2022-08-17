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
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.NameTeam).IsRequired().HasMaxLength(100);
            builder.Property(c => c.City).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Owner).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Telephone).IsRequired().HasMaxLength(10);

        }
    }

}
