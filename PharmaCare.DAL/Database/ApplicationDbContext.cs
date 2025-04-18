using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Configurations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Models.UserAddress;
using PharmaCare.DAL.Models.UserNotifications;

namespace PharmaCare.DAL.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers {  get; set; }
        public DbSet<Address> CustomerAddresses {  get; set; }
        public DbSet<Order> Orders {  get; set; }
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

            builder.ApplyConfiguration(new CustomerConfigurations());
            builder.ApplyConfiguration(new OrderConfigurations());

        }
        public DbSet<Pharmacy> pharmacies { get; set; }
        public DbSet<Inventory> inventories { get; set; }
        public DbSet<Notifacation> notifacations { get; set; }
        public DbSet<Pharmacist> pharmacists { get; set; }

    }
}
