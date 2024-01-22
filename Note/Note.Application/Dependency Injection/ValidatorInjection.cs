using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Reflection;
using MediatR;
using Note.Application.Behviour;

namespace Note.Application.Dependency_Injection
{
    public static class ValidatorInjection
    {
        public static IServiceCollection AddValidator(this IServiceCollection service)
        {
            service.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            
            return service;
        }
    }
}