using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client.AppConfig;
using Microsoft.IdentityModel.Tokens;
using pharmacare.bll.services.pharmacyserivce;
using PharmaCare.API.Middleware;
using PharmaCare.BLL.DTOs.ProductDTOs;
using PharmaCare.BLL.Services.AuthenticationService;
using PharmaCare.BLL.Services.Category;
using PharmaCare.BLL.Services.CategoryService;
using PharmaCare.BLL.Services.Chat;
using PharmaCare.BLL.Services.CustomerService;
using PharmaCare.BLL.Services.InventoryService;
using PharmaCare.BLL.Services.NotificationService;
using PharmaCare.BLL.Services.OrderService;
using PharmaCare.BLL.Services.PharmacistService;
using PharmaCare.BLL.Services.PharmacySerivce;
using PharmaCare.BLL.Services.ProductService;
using PharmaCare.DAL;
using PharmaCare.DAL.Database;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.ProductRepository;
using PharmaCare.DAL.Repository.Category;
using PharmaCare.DAL.Repository.Chats;
using PharmaCare.DAL.Repository.Customers;
using PharmaCare.DAL.Repository.InventoryRepository;
using PharmaCare.DAL.Repository.NotificationRepository;
using PharmaCare.DAL.Repository.Orders;
using PharmaCare.DAL.Repository.Payment;
using PharmaCare.DAL.Repository.PaymentRepository;
using PharmaCare.DAL.Repository.Pharmacists;
using PharmaCare.DAL.Repository.ProductRepository;
using PharmaCare.DAL.Repository.UnitOfWork;
using PharmaCareInv.DAL;
using PharmaCareInv.DAL.Repository.InventoryRepository;
using PharmaCareNot.DAL;
using PharmaCarepharmacy.DAL.Repository;
using pharmacy.DAL;



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
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<INotificationService, NotifacationService>();
            builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IPharmacyRepository, PharmacyRepository>();
            builder.Services.AddScoped<IChatRepository, ChatRepository>();
            builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IPharmacyRepository, PharmacyRepository>();
            builder.Services.AddScoped<IPharmacyService, PharmacyService>();
            builder.Services.AddScoped<IPharmacistRepository, PharmacistRepository>();
            builder.Services.AddScoped<IPharmacistService, PharmacistService>();
            builder.Services.AddScoped<IChatRepository, ChatRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
            builder.Services.AddScoped<IInventoryService, InventoryService>();


            // Service registrations
            //-------------------------------------------------------------------//

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<Product, ProductReadDTO>();
                // Add other mappings here
            }, typeof(Program).Assembly);
            builder.Services.AddScoped<IMapper, Mapper>();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


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
            if (app.Environment.IsDevelopment())
            {
                app.Use(async (context, next) =>
                {
                    // Log all incoming requests
                    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
                    await next();
                });

                // Add endpoint route debugger
                app.MapGet("/debug/routes", (IEnumerable<EndpointDataSource> endpointSources) =>
                    string.Join("\n", endpointSources.SelectMany(source => source.Endpoints)));
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
