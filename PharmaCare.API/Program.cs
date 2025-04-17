
using inventory.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Notification.Dal;
using PharmaCare.BLL.Services.AuthenticationService;
using PharmaCare.BLL.Services.InventoryService;
using PharmaCare.BLL.Services.NotifacationService;
using PharmaCare.BLL.Services.PharmacistService;
using PharmaCare.BLL.Services.PharmacySerivce;
using PharmaCare.DAL;
using PharmaCare.DAL.Database;
using PharmaCare.DAL.Models;
using PharmaCareInv.DAL;
using PharmaCareNot.DAL;
using PharmaCarepharmacy.DAL.Repository;
using pharmacy.DAL;
using pharmasist.DAL;
using System.Text;


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

            builder.Services.AddScoped<IAccountService, AccountService>();


            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                   .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = "Pharma";
                options.DefaultChallengeScheme = "Pharma";
            }).AddJwtBearer("Pharma", options =>
            {
                var secreteKeyString = builder.Configuration.GetSection("SecretKey").Value;
                var secreteKeyBytes = Encoding.ASCII.GetBytes(secreteKeyString);
                SecurityKey secreteKey = new SymmetricSecurityKey(secreteKeyBytes);

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = secreteKey,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            var app = builder.Build();

            builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
            builder.Services.AddScoped<IInventoryService, InventoryService>();
            builder.Services.AddScoped<INotifacationRepository, NoticationRepository>();
            builder.Services.AddScoped<INotifacationService, NotifacationService>();
            builder.Services.AddScoped<IPharmacistService, PharmacistService>();
            builder.Services.AddScoped<IPharmacistRepository, PharmacistRepository>();
            builder.Services.AddScoped<IPharmacyRepository, PharmacyRepository>();
            builder.Services.AddScoped<IPharmacySerivce, PharmacySerivce>();





            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}
