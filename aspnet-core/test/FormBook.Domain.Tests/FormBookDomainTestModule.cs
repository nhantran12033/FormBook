using FormBook.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FormBook;

[DependsOn(
    typeof(FormBookEntityFrameworkCoreTestModule)
    )]
public class FormBookDomainTestModule : AbpModule
{

}
