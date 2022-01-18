using System.Threading.Tasks;

namespace GestionDeStock.Data
{
    public interface IGestionDeStockDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
