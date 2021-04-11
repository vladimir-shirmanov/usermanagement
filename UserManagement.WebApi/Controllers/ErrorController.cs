using Microsoft.AspNetCore.Mvc;

namespace UserManagement.WebApi.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error() => Problem("Sorry our web api is facing some issues. We are working to fix them, please return back later");
    }
}