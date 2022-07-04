using AuthorizationAPI.Models;
using AuthorizationAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AuthorizationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly ILogger<AuthorizationController> _logger;
        private readonly ILoginRepo _repo;

        public AuthorizationController(ILogger<AuthorizationController> logger, ILoginRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Login(Credentials request)
        {
            SignInResponse response1 = new SignInResponse();
            response1.IsSuccess = true;
            response1.Token = _repo.Login(request);

            if (response1.Token == null)
            {
                response1.IsSuccess = false;
                return BadRequest(response1);
            }

            return Ok(response1);
        }

        [HttpPost]
        public IActionResult Registration(Credentials request)
        {
            bool response = _repo.Registration(request);

            return Ok(response);
        }
    }
}
