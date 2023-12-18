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

            modelBuilder.Entity<User>()
            .HasOne(u => u.Cart)
            .WithOne(c => c.User)
            .HasForeignKey<Cart>(c => c.UserId);

            // Cart and Order (1:1 relationship)
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Order)
                .WithOne(o => o.Cart)
                .HasForeignKey<Order>(o => o.CartId);

            // User and Order (1:N relationship)



            // Cart and Book (1:N relationship)
            modelBuilder.Entity<Cart>()
                .HasMany(c => c.Books)
                .WithMany(b => b.Carts);
                
            

            // Book and Author (N:M relationship)
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Authors)
                .WithMany(a => a.Books)
                .UsingEntity(j => j.ToTable("BookAuthor"));


            base.OnModelCreating(modelBuilder);
        }

            
        }
    
}
