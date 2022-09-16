using System.Threading.Tasks;

namespace PBL4.Data;

public interface IPBL4DbSchemaMigrator
{
    Task MigrateAsync();
}
