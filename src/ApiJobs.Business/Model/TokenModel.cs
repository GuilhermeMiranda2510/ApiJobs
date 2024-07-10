using System.Net;

namespace ApiJobs.Business.Model
{
    public class TokenModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
