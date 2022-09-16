using PBL4.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace PBL4;

[DependsOn(
    typeof(PBL4EntityFrameworkCoreTestModule)
    )]
public class PBL4DomainTestModule : AbpModule
{

}
