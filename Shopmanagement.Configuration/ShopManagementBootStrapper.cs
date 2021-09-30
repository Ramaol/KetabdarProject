using System;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Domain.BookCateguryAgg;
using ShopManagement.Infrastructure.Repositories;
using ShopManageMent.Application.Contract.BookCategury;
using ShopManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace Shopmanagement.Configuration
{
    public class ShopManagementBootStrapper
    {
        public static void Configure(IServiceCollection services , string ConnectionString)
        {   
            services.AddTransient<IBookCateguryRepository , BookCateguryRepository>();
            services.AddTransient<IBookCateguryApplication , BookCateguryApplication>();
     
            services.AddDbContext<ShopContext>( x => x.UseSqlServer(ConnectionString , b => b.MigrationsAssembly("WebHost")));  
        }
    }
}
