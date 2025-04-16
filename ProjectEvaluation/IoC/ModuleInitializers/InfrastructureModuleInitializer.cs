using Domain.Contracts.Repositories;
using Infrastructure;
using Infrastructure.Repositories;
using IoC.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.ModuleInitializers
{
    public class InfrastructureModuleInitializer : IModuleInitializer
    {
        public void Initialize(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<DbContext>(x => x.GetRequiredService<Context>());

            builder.Services.AddDbContext<Context>(x =>
                x.UseNpgsql(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Infrastructure")));

            builder.Services.AddTransient<IOrderRepository, OrderRepository>();
            builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
        }
    }
}
