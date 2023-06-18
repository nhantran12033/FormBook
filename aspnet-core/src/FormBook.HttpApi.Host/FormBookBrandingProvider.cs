using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FormBook;

[Dependency(ReplaceServices = true)]
public class FormBookBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "FormBook";
}
