using Blogy.Business.Mappings;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.Business.Validations.CategoryValidations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blogy.Business.Extensions
{
    public static class ServiceRegistrations
    {

        public static void AddServiceExtensions(this IServiceCollection services)
        {



            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IBlogService, BlogService>();

            services.AddAutoMapper(typeof(CategoryMappings).Assembly);


            services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters()
                .AddValidatorsFromAssembly(typeof(UpdateCategoryValidation).Assembly);



        }


    }
}
