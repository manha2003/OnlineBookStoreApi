using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class OnlineBookStoreDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }

        public OnlineBookStoreDbContext(DbContextOptions<OnlineBookStoreDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            base.OnModelCreating(modelBuilder);
        }

            
        }
    
}
