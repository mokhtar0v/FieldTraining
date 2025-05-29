using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using DataAccess.Contexts;
using DataAccess.Repositories.Classes;
using DataAccess.Repositories.Interfaces;
using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using BusinessLogic.Services.Classes;
using Microsoft.OpenApi.Models;
using BusinessLogic.Profiles;

namespace HireSphere
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container (DI Container)

            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
                options.UseLazyLoadingProxies();
            });

            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            builder.Services.AddScoped<IFreelancerService, FreelancerService>();
            builder.Services.AddScoped<IFreelancerRepository, FreelancerRepository>();

            builder.Services.AddScoped<IJobService, JobService>();
            builder.Services.AddScoped<IJobRepository, JobRepository>();

            builder.Services.AddScoped<IMessageRepository, MessageRepository>();
            builder.Services.AddScoped<IMessageService, MessageService>();

            builder.Services.AddScoped<IConversationRepository, ConversationRepository>();
            builder.Services.AddScoped<IConversationServices, ConversationServices>();

            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "HireSphere API",
                    Version = "v1"
                });
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // Commented out authentication and authorization for now
            /*
            builder.Services.AddAuthentication("Cookies")
                .AddCookie("Cookies", options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.AccessDeniedPath = "/Account/AccessDenied";
                });

            builder.Services.AddAuthorization();
            */

            #endregion

            var app = builder.Build();

            #region Configure the HTTP request pipeline.

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Commented out authentication and authorization middleware for now
            /*
            app.UseAuthentication();
            app.UseAuthorization();
            */

            app.UseCors("AllowAll");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Customer}/{action=Index}/{id?}");

            app.Run();

            #endregion
        }
    }
}
