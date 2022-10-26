using PBL4.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace PBL4.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(PBL4EntityFrameworkCoreModule),
        typeof(PBL4ApplicationContractsModule)
        )]
    public class PBL4DbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
