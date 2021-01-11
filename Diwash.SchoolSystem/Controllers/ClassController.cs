using Diwash.SchoolSystem.Data.Entities;
using Diwash.SchoolSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diwash.SchoolSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;
        private readonly ILogger<ClassController> _logger;
        private readonly IUserService _userService;

        public ClassController(IClassService classService, ILogger<ClassController> logger)
        {
            this._classService = classService;
            this._logger = logger;
        }
        //public ClassController(IClassService classService, ILogger<ClassController> logger, IUserService userService)
        //{
        //    this._classService = classService;
        //    this._logger = logger;
        //    this._userService = userService;
        //}

        //create class
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] Class newClass)
        {
            return await _classService.CreateClass(newClass);
        }

        //get all classes
        [HttpGet]
        public async Task<ActionResult<List<Class>>> Get()
        {
            //if (!_userService.IsAuthenticated(Request))
            //    return BadRequest();

            return await _classService.GetAllClasses();
        }

        //update class
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Class updatedClass)
        {
            bool checkClass = await _classService.UpdateClass(id, updatedClass);
            if (checkClass == false)
                return BadRequest();
            return NoContent();
        }

        //delete class
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool checkClass = await _classService.DeleteClass(id);
            if (checkClass == false)
                return BadRequest();
            return NoContent();
        }
    }
}
