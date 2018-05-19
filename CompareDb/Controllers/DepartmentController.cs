using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompareDb.Managers.MongoDB;
using CompareDb.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CompareDb.Controllers
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
