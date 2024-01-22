using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Note.Infrastructure.Dependency_Injection
{
    public static class DataInjection
    {
        public static IServiceCollection AddData(this IServiceCollection service, string connectionString)
        {
            return service.AddDbContext<DataContext>(option => option.UseNpgsql(connectionString));
        }
    }
}