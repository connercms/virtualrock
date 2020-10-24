using System;
using Microsoft.EntityFrameworkCore;
using VirtualRock.Domain.Models;

namespace VirtualRock.Data
{
    public class DataContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Nomination> Nominations { get; set; }

        public DataContext(DbContextOptions<DataContext> dbContextOptions): base(dbContextOptions)
        {
        }
    }
}
