using Core.Entities;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class PasaliDbContext:DbContext
    {

        public PasaliDbContext(DbContextOptions<PasaliDbContext> options) : base(options)
        {
        }

        public PasaliDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=PasaliDb;trusted_connection=true");
        }
      
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
         public DbSet<Color> Colors { get; set; }
         public DbSet<Gender> Genders { get; set; }
         public DbSet<Order> Orders { get; set; }
         public DbSet<OrderItem> OrderItems { get; set; }
         public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
       
        public DbSet<Size> Sizes { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }


        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
   


       
    }
}
