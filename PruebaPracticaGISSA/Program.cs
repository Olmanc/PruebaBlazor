using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PruebaPracticaGISSA.Data;

namespace PruebaPracticaGISSA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();

            builder.Services.AddScoped<DbService, DbService>(serviceProvider =>
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                var serverId = "Prueba";
                return new DbService(configuration, serverId);
            });


            builder.Services.AddHttpClient<ILoginService, LoginService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7298/");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
