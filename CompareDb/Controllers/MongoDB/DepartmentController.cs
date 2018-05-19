using System.Threading.Tasks;
using CompareDb.Interfaces.MongoDB;
using CompareDb.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CompareDb.Controllers.MongoDB
{
    [Route("api/department")]
    public class DepartmentController : Controller
    {
        public IDepartmentManager DepartmentManager { get; }

        public DepartmentController(IDepartmentManager departmentManager)
        {
            DepartmentManager = departmentManager;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Insert([FromBody]GenerateDepartmentsAsync request)
        {
            return Ok(await DepartmentManager.GenerateDepartmentsAsync(request));
        }
    }
}
