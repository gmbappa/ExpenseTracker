using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ExpenseTracker.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            //var host = CreateWebHostBuilder(args).Build();
            //using (var serviceScope = host.Services.CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            //    context.Database.Migrate(); //enable migration to run seed data automaticaly
            //}
            //host.Run();
        }

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //   WebHost.CreateDefaultBuilder(args)
        //       .UseStartup<Startup>();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
