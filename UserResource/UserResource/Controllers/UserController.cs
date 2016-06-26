using System.Collections.Generic;
using System.Web.Http;

namespace UserResource.Controllers
{
    public class UserController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "derp", "secondDerp" };
        }
    }
}
