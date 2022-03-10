using Microsoft.EntityFrameworkCore;
using ResponsiveSampleTPBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResponsiveSampleTPBackend.Database
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
