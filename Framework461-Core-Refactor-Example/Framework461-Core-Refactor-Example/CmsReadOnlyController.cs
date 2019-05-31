using Business;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Web
{
    public class CmsReadOnlyController : ApiController
    {
        [HttpGet]
        [Route("getAuditLogById/{id}/{siteId}")]
        public async Task<HttpResponseMessage> GetAuditLogById(string id, string siteId)
        {
            dynamic response = await CosmosConfigBusiness.GetAuditLogByIdAsync(id, siteId);
            HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(response)
            };
            return resp;
        }
    }
}