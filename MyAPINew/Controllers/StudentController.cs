using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPINew.Data;
using MyAPINew.Model;
using MyAPINew.Repository.Interface;
using MyAPINew.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAPINew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET
        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            return _studentService.GetAllStudents();
        }

        // GETById
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<Student>> Post([FromBody] Student value)
        {
            _studentService.AddStudent(value);
            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Student value)
        {
            if (id != value.Id)
            {
                return BadRequest("Invalid ID");
            }

            _studentService.UpdateStudent(value);
            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _studentService.DeleteStudent(id);
            return NoContent();
        }
    }
}
