namespace Tmdb.API.Controllers
{
    public class LoginController : BaseController
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Login([FromBody] LoginViewModel loginDto, [FromServices] ILoginService loginService)
        {


        }
    }
}