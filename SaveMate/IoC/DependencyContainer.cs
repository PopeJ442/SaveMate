using Microsoft.EntityFrameworkCore;
using SaveMate.ApplicationDbContext;



namespace SaveMate.IoC
{
    public class DependencyContainer
    {
        //public static void DependencyContainer(IServiceCollection Service, IConfiguration configuration) 
        //{
            
        //}
        public static void AddingDbContext(IConfiguration configuration,IServiceCollection service) 
        {
            service.AddDbContext<SaveMateDbContext>(Option =>
            Option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
