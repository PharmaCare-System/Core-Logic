using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PharmaCare.API.Middleware;
using PharmaCare.BLL.Services.AuthenticationService;
using PharmaCare.BLL.Services.InventoryService;
using PharmaCare.BLL.Services.NotificationService;
using PharmaCare.BLL.Services.PharmacistService;
using PharmaCare.BLL.Services.PharmacySerivce;
using PharmaCare.DAL;
using PharmaCare.DAL.Database;
using PharmaCare.DAL.Models;
using PharmaCareInv.DAL;
using PharmaCarepharmacy.DAL.Repository;
using pharmacy.DAL;
using PharmaCare.DAL.Repository.UnitOfWork;
using System.Text;
using PharmaCare.DAL.Repository.Customers;
using PharmaCare.BLL.Services.CustomerService;
using PharmaCare.DAL.ProductRepository;
using PharmaCare.DAL.Repository.ProductRepository;
using PharmaCare.BLL.Services.ProductService;
using PharmaCare.BLL.Services.CategoryService;
using PharmaCare.BLL.Services.Category;
using PharmaCare.BLL.Services.Chat;
using pharmacare.bll.services.pharmacyserivce;
using PharmaCare.DAL.Repository.Category;
using PharmaCare.DAL.Repository.Pharmacists;


namespace PharmaCare.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //-------------------------------------------------------------------//
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ChatService, ChatService>();

            builder.Services.AddScoped<IPharmacistService, PharmacistService>();
            builder.Services.AddScoped<IPharmacyService, PharmacyService>();

            builder.Services.AddScoped<IPharmacistRepository, PharmacistRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            // Service registrations
            //-------------------------------------------------------------------//


            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                                        b => b.MigrationsAssembly("PharmaCare.DAL")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>()
                   .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Pharma";
                options.DefaultChallengeScheme = "Pharma";
            }).AddJwtBearer("Pharma", options =>
            {
                var secreteKeyString = builder.Configuration.GetSection("SecretKey").Value;
                var secreteKeyBytes = Encoding.UTF8.GetBytes(secreteKeyString);
                SecurityKey secreteKey = new SymmetricSecurityKey(secreteKeyBytes);

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = secreteKey,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<GlobalExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
