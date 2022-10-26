using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace PBL4.Data
{
    /* This is used if database provider does't define
     * IPBL4DbSchemaMigrator implementation.
     */
    public class NullPBL4DbSchemaMigrator : IPBL4DbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}