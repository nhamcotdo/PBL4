using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PBL4.Data;
using Volo.Abp.DependencyInjection;

namespace PBL4.EntityFrameworkCore
{
    public class EntityFrameworkCorePBL4DbSchemaMigrator
        : IPBL4DbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCorePBL4DbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the PBL4DbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<PBL4DbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
