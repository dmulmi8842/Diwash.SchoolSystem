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
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IStudentService studentService, ILogger<StudentController> logger)
        {
            this._studentService = studentService;
            this._logger = logger;
        }

        //create student
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] Student student)
        {
            return await _studentService.CreateStudent(student);
        }

        //get specific list based on searched name or description / get all list
        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get([FromQuery] string nameKeyword)
        {
            return await _studentService.GetStudents(nameKeyword);
        }

        //get student by student id
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetDetails(int id)
        {
            var student = await _studentService.GetStudent(id);
            if (student == null) return NotFound();
            return student;
        }

        //update student
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student student)
        {
            bool checkstudent = await _studentService.UpdateStudent(id, student);
            if (checkstudent == false)
                return BadRequest();
            return NoContent();
        }

        //delete student by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            bool checkstudent = await _studentService.DeleteStudent(id);
            if (checkstudent == false)
                return BadRequest();
            return NoContent();
        }
    }
}
