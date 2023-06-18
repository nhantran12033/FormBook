using System.Threading.Tasks;

namespace FormBook.Data;

public interface IFormBookDbSchemaMigrator
{
    Task MigrateAsync();
}
