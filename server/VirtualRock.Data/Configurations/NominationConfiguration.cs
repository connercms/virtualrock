using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualRock.Core.Models;

namespace VirtualRock.Data.Configurations
{
    public class NominationConfiguration : IEntityTypeConfiguration<Nomination>
    {
        public void Configure(EntityTypeBuilder<Nomination> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NominationDate).IsRequired();

            builder.Property(x => x.ExpirationDate).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.Nominations).HasForeignKey(x => x.UserId);

            builder.ToTable("Nominations");
        }
    }
}
