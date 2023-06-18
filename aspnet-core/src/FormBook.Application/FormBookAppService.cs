using System;
using System.Collections.Generic;
using System.Text;
using FormBook.Localization;
using Volo.Abp.Application.Services;

namespace FormBook;

/* Inherit your application services from this class.
 */
public abstract class FormBookAppService : ApplicationService
{
    protected FormBookAppService()
    {
        LocalizationResource = typeof(FormBookResource);
    }
}
