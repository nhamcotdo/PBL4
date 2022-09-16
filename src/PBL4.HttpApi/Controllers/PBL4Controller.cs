using PBL4.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace PBL4.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class PBL4Controller : AbpControllerBase
{
    protected PBL4Controller()
    {
        LocalizationResource = typeof(PBL4Resource);
    }
}
