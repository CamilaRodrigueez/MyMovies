using Infraestructure.Core.Data;
using Infraestructure.Core.Repository;
using Infraestructure.Core.Repository.Interface;
using Infraestructure.Core.UnitOfWork;
using Infraestructure.Core.UnitOfWork.Interface;
using Microsoft.Extensions.DependencyInjection;
using MVC.Domain.Services;
using MVC.Domain.Services.Interface;

namespace CrudUsuarios.Handlers
{
    public class DependencyInyectionHandler
    {
        public static void DependencyInyectionConfig(IServiceCollection services)
        {
            // Repository await UnitofWork parameter ctor explicit
            services.AddScoped<UnitOfWork, UnitOfWork>();


            // Infrastructure
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<SeeDb>();

            ////Domain
            services.AddTransient<IUserServices, UserServices>();
            //services.AddTransient<IRolServices, RolServices>();
            //services.AddTransient<IPermissionServices, PermissionServices>();
            //services.AddTransient<IBooksServices, BooksServices>();
            //services.AddTransient<IEditorialServices, EditorialServices>();
            //services.AddTransient<IAuthorsServices, AuthorsServices>();


        }
    }
}
