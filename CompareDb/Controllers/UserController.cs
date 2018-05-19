using System.Threading.Tasks;
using CompareDb.Interfaces.MongoDB;
using CompareDb.Models.Filters;
using CompareDb.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CompareDb.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        public IUserManager UserManager { get; }

        public UserController(IUserManager userManager)
        {
            UserManager = userManager;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Insert([FromBody]GenerateUserRequest request)
        {
            return Ok(await UserManager.GenerateUsersAsync(request));
        }

        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> Search([FromBody]UserFilter request)
        {
            return Ok(await UserManager.GetUsersByFilterAsync(request));
        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> Search([FromBody]DeleteUserRequest request)
        {
            return Ok(await UserManager.BulkDeleteContractAsync(request));
        }
    }
}
