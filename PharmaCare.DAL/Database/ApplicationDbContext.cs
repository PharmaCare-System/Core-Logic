using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Models.ProductRel;
using PharmaCare.DAL.Models.UserAddress;
using PharmaCare.DAL.Models.UserMessages;
using PharmaCare.DAL.Models.UserNotifications;

namespace PharmaCare.DAL.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        //private static void SetGlobalQueryFilter<T>(ModelBuilder builder) where T : BaseEntity
        //{
        //    builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        //}

        #region DbSets
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Address> CustomerAddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Category> Categories { get; set; }
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
        public DbSet<MessagesCustomer> MessagesCustomers { get; set; }
        public DbSet<MessagesPharmacist> MessagesPharmacists { get; set; }
        public DbSet<CustomerNotification> CustomerNotifications { get; set; }
        public DbSet<PharmacyNotification> PharmacyNotifications { get; set; }
        public DbSet<PharmacistChats> PharmacistChats { get; set; }
        #endregion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("AspNetUsers");
            builder.Entity<Customer>().ToTable("Customers");
            builder.Entity<Pharmacist>().ToTable("Pharmacists");

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            //// Apply global query filter to all BaseEntity entities
            //foreach (var entityType in builder.Model.GetEntityTypes())
            //{
            //    if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
            //    {
            //        var method = typeof(ApplicationDbContext)
            //            .GetMethod(nameof(SetGlobalQueryFilter), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
            //            .MakeGenericMethod(entityType.ClrType);

            //        method.Invoke(null, new object[] { builder });
            //    }
            //}
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedById = 1;
                        entry.Entity.CreatedByName = "name";
                        entry.Entity.CreatedDateTime = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifiedById = 1;
                        entry.Entity.ModifiedByName = "name";
                        entry.Entity.ModifiedDateTime = DateTime.Now;
                        break;

                    case EntityState.Deleted:
                        entry.Entity.DeletedById = 1;
                        entry.Entity.DeletedByName = "name";
                        entry.Entity.DeletedDateTime = DateTime.Now;
                        entry.Entity.IsDeleted = true;
                        entry.State = EntityState.Modified;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedById = 1;
                        entry.Entity.CreatedByName = "name";
                        entry.Entity.CreatedDateTime = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifiedById = 1;
                        entry.Entity.ModifiedByName = "name";
                        entry.Entity.ModifiedDateTime = DateTime.Now;
                        break;

                    case EntityState.Deleted:
                        entry.Entity.DeletedById = 1;
                        entry.Entity.DeletedByName = "name";
                        entry.Entity.DeletedDateTime = DateTime.Now;
                        entry.Entity.IsDeleted = true;
                        entry.State = EntityState.Modified;
                        break;
                }
            }

            return base.SaveChanges();
        }
    }
}
