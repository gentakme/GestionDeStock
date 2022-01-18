using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GestionDeStock.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class GestionDeStockMigrationsDbContextFactory : IDesignTimeDbContextFactory<GestionDeStockMigrationsDbContext>
    {
        public GestionDeStockMigrationsDbContext CreateDbContext(string[] args)
        {
            GestionDeStockEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<GestionDeStockMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new GestionDeStockMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../GestionDeStock.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
