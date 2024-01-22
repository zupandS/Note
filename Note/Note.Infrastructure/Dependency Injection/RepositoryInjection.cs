using Microsoft.Extensions.DependencyInjection;
using Note.Infrastructure.Interfaces;
using Note.Infrastructure.Repositories;

namespace Note.Infrastructure.Dependency_Injection
{
    public static class RepositoryInjection
    {
        public static IServiceCollection AddNotepadRepository(this IServiceCollection service)
        {
            return service.AddScoped<INotepadRepository, NotepadRepository>();
        }
    }
}