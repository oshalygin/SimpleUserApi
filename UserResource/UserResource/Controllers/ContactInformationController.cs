using System.Web.Mvc;
using UserResource.Attributes;

namespace UserResource.Controllers
{
    [ApiControllerConfiguration]
    [RoutePrefix("api/v1/user/{userId}/contact-information")]
    [Authorize] // Non-public api.

    public class ContactInformationController : Controller
    {
        // This class is another route resource similar to the user endpoint
      
    }
}