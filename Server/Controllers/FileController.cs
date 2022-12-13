using CDPModule1.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CDPModule1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FileController : ControllerBase
    {
        [HttpPost]
        [System.Web.Http.Route("upload")]
        [Authorize(Roles = "Admin")]
        public ResponseModal UploadFile([FromBody] string fileBaseString)
        {
            return new ResponseModal();
        }
    }
}
