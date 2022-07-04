using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProcessPensionAPI.Models;
using ProcessPensionAPI.Provider;

namespace ProcessPensionAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProcessPensionController : ControllerBase
    {
        private readonly ILogger<ProcessPensionController> _logger;
        private readonly IProcessPensionProvider _provider;

        public ProcessPensionController(ILogger<ProcessPensionController> logger, IProcessPensionProvider provider)
        {
            _logger = logger;
            _provider = provider;
        }

        [HttpGet]
        public IActionResult PensionDetail(string aadhaarNumber)
        {
            PensionDetail pensionDetail  = _provider.PensionDetail(aadhaarNumber);

            if (pensionDetail == null)
                return BadRequest();

            return Ok(pensionDetail);
        }

        [HttpPost]
        public IActionResult ProcessPension(ProcessPensionRequest request)
        {
            ProcessPensionResponse response = new ProcessPensionResponse();
            string message = _provider.ProcessPension(request);
            if(message== "Pension Disbursement Success")
            {
                response.IsSuccess = true;
                response.Message = message;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = message;
            }
            return Ok(message);
        }
    }
}
