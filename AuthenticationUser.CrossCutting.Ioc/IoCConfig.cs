using AuthenticationUser.ApplicationService;
using AuthenticationUser.Domain.Repositories.Generic;
using AuthenticationUser.Domain.Repositories.UnitOfWork;
using AuthenticationUser.Domain.Services;
using AuthenticationUser.Infra;
using AuthenticationUser.Infra.Contexts;
using AuthenticationUser.Infra.Repositories.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthenticationUser.CrossCutting.Ioc
{
    public class IoCConfig
    {
        public static void Config(IServiceCollection services, IConfiguration configuration)
        {
            #region [ Commom ]

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            #endregion


            #region [ Job ]

            #endregion

            #region [ Application ]

            services.AddTransient(typeof(IProductApplicationService), typeof(ProductApplicationService));
            services.AddTransient(typeof(ICategoryApplicationService), typeof(CategoryApplicationService));

            #endregion            

            #region [ Repository ]            

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddScoped<IDbContextOptions, DbContextOptions<ApplicationDbContext>>();

            #endregion
        }
    }
}
