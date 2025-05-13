using Microsoft.EntityFrameworkCore;
using SaveMate.ApplicationDbContext;
using SaveMate.Repositories;
using SaveMate.Repositories.IRepository;
using SaveMate.Services;
using SaveMate.Services.IService;



namespace SaveMate.IoC
{
    public class DependencyContainer
    {
        public static void RegisteringDependency(IConfiguration configuration, IServiceCollection services)
        {
         
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();
            
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ITransactionService, TransactionService>();


            services.AddTransient<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
        }
        public static void AddingDbContext(IConfiguration configuration,IServiceCollection service) 
        {
            service.AddDbContext<SaveMateDbContext>(Option =>
            Option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
