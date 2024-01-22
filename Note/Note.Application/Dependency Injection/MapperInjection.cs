using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Note.Application.Mapper;

namespace Note.Application.Dependency_Injection
{
    public static class MapperInjection
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection service)
        {
            return service.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}