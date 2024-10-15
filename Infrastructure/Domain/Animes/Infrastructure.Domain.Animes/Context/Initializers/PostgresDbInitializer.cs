using Infrastructure.Domain.Animes.Context.Implementations;
using Infrastructure.Domain.Animes.Mapping.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Domain.Animes.Context.Initializers
{
    public class PostgresDbInitializer : IDesignTimeDbContextFactory<AnimesPostgresContext>
    {
        public AnimesPostgresContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config/appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AnimesPostgresContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("PostgresConnection"));

            return new AnimesPostgresContext(configuration, new AnimeMapping());
        }
    }
}