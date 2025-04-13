
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PharmaCare.BLL.Services.AuthenticationService;
using PharmaCare.DAL.Database;
using PharmaCare.DAL.Models;
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
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
