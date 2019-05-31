using Data.Services;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CosmosRepository
    {
        public static async Task<dynamic> GetAuditLogByIdAsync(string id, string siteId) =>
            await CosmosClientService.GetAuditLogByIdAsync(id, siteId).ConfigureAwait(false);
    }
}
