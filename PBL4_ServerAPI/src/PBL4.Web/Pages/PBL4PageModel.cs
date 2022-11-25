using PBL4.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace PBL4.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class PBL4PageModel : AbpPageModel
    {
        protected PBL4PageModel()
        {
            LocalizationResourceType = typeof(PBL4Resource);
        }
    }
}