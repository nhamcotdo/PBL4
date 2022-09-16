using Volo.Abp.Modularity;

namespace PBL4;

[DependsOn(
    typeof(PBL4ApplicationModule),
    typeof(PBL4DomainTestModule)
    )]
public class PBL4ApplicationTestModule : AbpModule
{

}
