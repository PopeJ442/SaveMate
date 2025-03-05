using Microsoft.EntityFrameworkCore;
using SaveMate.ApplicationDbContext;
using SaveMate.Repositories;
using SaveMate.Services;



namespace SaveMate.IoC
{
    public class DependencyContainer
    {
        public static void RegisteringDependency(IConfiguration configuration, IServiceCollection services)
        {
         
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();
        }
        public static void AddingDbContext(IConfiguration configuration,IServiceCollection service) 
        {
            service.AddDbContext<SaveMateDbContext>(Option =>
            Option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
