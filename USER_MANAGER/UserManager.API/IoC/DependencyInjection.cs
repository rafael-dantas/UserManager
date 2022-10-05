using Microsoft.Extensions.DependencyInjection;
using UserManager.Data.Interface;
using UserManager.Data.Repository;
using UserManager.Service;
using UserManager.Service.Interface;

namespace UserManager.API.IoC
{
    public class DependencyInjection
    {
        public DependencyInjection(IServiceCollection services)
        {
            AddTransient(services);       
        }

        private void AddTransient(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
