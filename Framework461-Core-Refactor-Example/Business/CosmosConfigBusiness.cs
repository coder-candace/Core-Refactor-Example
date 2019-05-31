using Data.Repositories;
using System.Threading.Tasks;

namespace Business
{
    public class CosmosConfigBusiness
    {
        public static async Task<dynamic> GetAuditLogByIdAsync(string id, string siteId)
        {
            dynamic config = await CosmosRepository.GetAuditLogByIdAsync(id, siteId).ConfigureAwait(false);
            if (config == null)
                return null;

            return config;
        }

    }
}
