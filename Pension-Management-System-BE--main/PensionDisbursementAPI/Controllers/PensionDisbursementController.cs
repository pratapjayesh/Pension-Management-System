using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PensionDisbursementAPI.Model;
using PensionDisbursementAPI.Provider;

namespace PensionDisbursementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PensionDisbursementController : ControllerBase
    {
        private readonly ILogger<PensionDisbursementController> _logger;
        private readonly IPensionDisbursementProvider _provider;

        public PensionDisbursementController(ILogger<PensionDisbursementController> logger, IPensionDisbursementProvider provider)
        {
            _logger = logger;
            _provider = provider;
        }

        [HttpPost]
        public IActionResult DisbursePension(ProcessPensionInput request)
        {
            int statusCode = _provider.DisbursePension(request);

            return Ok(statusCode);
        }
    }
}
