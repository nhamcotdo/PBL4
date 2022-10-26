using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace PBL4.Web
{
    [Dependency(ReplaceServices = true)]
    public class PBL4BrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "PBL4";
    }
}
