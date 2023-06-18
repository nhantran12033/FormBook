using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace FormBook.Data;

/* This is used if database provider does't define
 * IFormBookDbSchemaMigrator implementation.
 */
public class NullFormBookDbSchemaMigrator : IFormBookDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
