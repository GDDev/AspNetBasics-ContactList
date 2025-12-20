using ContactApp.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.Api.Controllers
{
    [ApiController]
    [Route("api/imports")]
    public class ImportsController(ICallImportService service) : ControllerBase
    {
        private readonly ICallImportService _service = service;

        [HttpPost("calls")]
        public async Task<IActionResult> UploadCalls([FromForm] IFormFile file)
        {
            // TODO: remove once auth exists
            const int userId = 1;

            await _service.ImportFromCsvAsync(file, userId);
            return Accepted();
        }
    }
}
