using Diwash.SchoolSystem.Data.Entities;
using Diwash.SchoolSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diwash.SchoolSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;
        public ClassController(IClassService classService)
        {
            this._classService = classService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] Class newClass)
        {
            return await _classService.CreateClass(newClass);
        }

        [HttpGet]
        public async Task<ActionResult<List<Class>>> Get()
        {
            return await _classService.GetAllClasses();
        }
    }
}
