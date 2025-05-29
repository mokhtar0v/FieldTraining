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
                //options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"]);
                //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            });
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            builder.Services.AddScoped<IFreelancerService, FreelancerService>();
            builder.Services.AddScoped<IFreelancerRepository, FreelancerRepository>();

            builder.Services.AddAutoMapper(typeof(Program).Assembly); // Register AutoMapper with the current assembly

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


            #endregion

            var app = builder.Build();

            #region Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run(); 
            #endregion
        }
    }
}
