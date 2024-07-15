using apiEstudo;
using apiEstudo.Application;
using apiEstudo.Application.Services;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Infraestrutura;
using apiEstudo.Infraestrutura.Repositories;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            // Swagger config
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
                new List<string>()
                }
            });
        });

        // DataBase Context
        builder.Services.AddDbContext<ConnectionContext>(x =>
        x.UseSqlServer("Data Source=DESKTOP-HADLTPF\\SQLEXPRESS;Database=master;Integrated Security=True;TrustServerCertificate=True;"));

        // Repositories
        builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        builder.Services.AddTransient<IEmployeeTaskRepository, EmployeeTaskRepository>();
        builder.Services.AddTransient<IProductRepository, ProductRepository>();
        builder.Services.AddTransient<IBrandRepository, BrandRepository>();
        builder.Services.AddTransient<IShoppingRepository, ShoppingRepository>();
        builder.Services.AddTransient<IUserRepository, UserRepository>();
        builder.Services.AddTransient<IShoppingItemRepository, ShoppingItemRepository>();
        builder.Services.AddTransient<IShippingStatusRepository, ShippingStatusRepository>();

        // Services
        builder.Services.AddTransient<IEmployeeService, EmployeeService>();
        builder.Services.AddTransient<IEmployeeTaskService, EmployeeTaskService>();
        builder.Services.AddTransient<IBrandService, BrandService>();
        builder.Services.AddTransient<IProductService, ProductService>();
        builder.Services.AddTransient<IShoppingService, ShoppingService>();
        builder.Services.AddTransient<IUserService, UserService>();
        builder.Services.AddTransient<IShippingStatusService, ShippingStatusService>();
        builder.Services.AddTransient<IShoppingItemService, ShoppingItemService>();

        // JWT Token
        var key = Encoding.ASCII.GetBytes(Key.Secret);
        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
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

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}