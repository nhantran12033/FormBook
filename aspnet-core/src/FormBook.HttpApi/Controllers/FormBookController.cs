using FormBook.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FormBook.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class FormBookController : AbpControllerBase
{
    protected FormBookController()
    {
        LocalizationResource = typeof(FormBookResource);
    }
}
