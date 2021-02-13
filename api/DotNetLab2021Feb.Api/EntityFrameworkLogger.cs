using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DotNetLab2021Feb
{
    public class EntityFrameworkLogger
    {
        public ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder => {
                builder.AddConsole()
                    .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information);
            });
            return serviceCollection.BuildServiceProvider().GetService<ILoggerFactory>();
        }
    }
}
