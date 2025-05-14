using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PharmaCare.DAL.Configurations;
using PharmaCare.DAL.Migrations;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Models.ProductRel;
using PharmaCare.DAL.Models.UserAddress;
using PharmaCare.DAL.Models.UserMessages;
using PharmaCare.DAL.Models.UserNotifications;
namespace PharmaCare.DAL.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        #region DbSets
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> CustomerAddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Pharmacist> Pharmacists { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<CartProducts> CartProducts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PharmacistAddress> PharmacistAddresses { get; set; }
        public DbSet<MessagesCustomer> MessagesCustomers { get; set; }
        public DbSet<MessagesPharmacist> MessagesPharmacists { get; set; }
        public DbSet<CustomerNotification> CustomerNotifications { get; set; }
        public DbSet<PharmacyNotification> PharmacyNotifications { get; set; }
        public DbSet<PharmacistChats> PharmacistChats { get; set; }
        #endregion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(builder);
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if (typeof(Base).IsAssignableFrom(entityType.ClrType))
                {
                    builder.Entity(entityType.ClrType).HasQueryFilter(ConvertFilterExpression(entityType.ClrType));
                }

            }
        }
       private static LambdaExpression ConvertFilterExpression(Type entityType)
        {
            var parameter = Expression.Parameter(entityType, "e");
            var prop = Expression.Property(parameter, nameof(Base.IsDeleted));
            var body = Expression.Equal(prop, Expression.Constant(false));
            return Expression.Lambda(body, parameter);
        }



    }
}
