using Microsoft.AspNetCore.Mvc;

namespace Blazor3D.Examples.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : Controller
    {
        /// <summary>
        /// Addition as a controller for accessing local files
        /// </summary>
        /// <param name="link">Full path local file</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IActionResult FileDownload([FromQuery] string link)
        {
            var saveFileName = link.Substring(link.LastIndexOf('\\') + 1);
            try
            {
                var fileBytes = System.IO.File.ReadAllBytes(link);

                var contentType = "APPLICATION/octet-stream";
                var fileName = saveFileName;
                return File(fileBytes, contentType, fileName);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error download: " + ex.Message);
            }
        }
    }
}
