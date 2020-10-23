using System;
using VirtualRock.Core.Models;
using Microsoft.EntityFrameworkCore;
using VirtualRock.Data.Configurations;

namespace VirtualRock.Data
{
    public class VirtualRockDataContext: DbContext
    {
        public DbSet<Nomination> Nominations { get; set; }
        public DbSet<User> Users { get; set; }

        public VirtualRockDataContext(DbContextOptions<VirtualRockDataContext> options)
            : base(options)
        { }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite("Data Source=virtualrock.db");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .ApplyConfiguration(new UserConfiguration());

            //builder
            //    .ApplyConfiguration(new NominationConfiguration());
        }
    }
}
