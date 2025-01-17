using Service;
using Service.Impl;

namespace PRN221_Assignment3_Json
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IKoiFishService, KoiFishService>();
            builder.Services.AddScoped<IAdvertisementService, AdvertisementService>();
            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddSession();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}