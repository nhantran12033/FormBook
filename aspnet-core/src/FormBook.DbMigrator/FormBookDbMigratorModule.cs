using FormBook.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace FormBook.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(FormBookEntityFrameworkCoreModule),
    typeof(FormBookApplicationContractsModule)
    )]
public class FormBookDbMigratorModule : AbpModule
{

}
