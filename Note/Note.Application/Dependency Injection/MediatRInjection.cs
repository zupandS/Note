using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace Note.Application.Dependency_Injection
{
    public static class MediatRInjection
    {
        public static IServiceCollection AddMediatR(this IServiceCollection service)
        {
            return service.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}