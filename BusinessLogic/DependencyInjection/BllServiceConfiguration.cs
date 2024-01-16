using BusinessLayer.BusinessLogic.Crud;
using BusinessLayer.BusinessLogic.Security;
using Bo = BusinessLayer.BusinessObjects.BusinessObjects;
using BusinessLayer.Service.AuthService;
using BusinessLayer.Service.SecurityService;
using BusinessLayer.Validators.SpecificValidators.Security;
using Dal = DataAccessLayer.Models;
using Microsoft.Extensions.DependencyInjection;
using BusinessLayer.Service.CrudService;
using BusinessLayer.Validators.SpecificValidators.Crud;
using BusinessLayer.Validators.SpecificValidators.Crud.UserGroups;
using BusinessLayer.Helpers.MapperObjectFiller;
using BusinessLayer.Helpers.MapperObjectFiller.SpecificObjectFillers;

namespace BusinessLayer.DependencyInjection
{
    public static class BllServiceConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            // Validators
            services.AddTransient<ISecurityValidator, SecurityValidator>();
            services.AddTransient<ICrudValidator<Bo.UserGroups.UserGroup>, UserGroupValidator>();

            // Business logics
            services.AddTransient<ISecurityBusinessLogic, SecurityBusinessLogic>();
            services.AddTransient<ICrudBusinessLogic<Bo.UserGroups.UserGroup>, CrudBusinessLogic<Bo.UserGroups.UserGroup, Dal.UserGroups.UserGroup>>();

            // Business services
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddTransient<ICrudService<Bo.UserGroups.UserGroup>, CrudService<Bo.UserGroups.UserGroup>>();

            return services;
        }
    }
}
