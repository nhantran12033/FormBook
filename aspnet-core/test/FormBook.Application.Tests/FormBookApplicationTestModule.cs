using Volo.Abp.Modularity;

namespace FormBook;

[DependsOn(
    typeof(FormBookApplicationModule),
    typeof(FormBookDomainTestModule)
    )]
public class FormBookApplicationTestModule : AbpModule
{

}
