using ASPCoreWebAPICRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreWebAPICRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly SchoolContext context;

        public StudentAPIController(SchoolContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = context.Students.ToList();
            if (students == null || !students.Any())
            {
                return NotFound("No students found.");
            }
            return Ok(students);
        }   

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = context.Students.Find(id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }
            return Ok(student);
        }

        [HttpPost]
        public IActionResult CreateStudent(Student std)
        {
            context.Students.Add(std);
            context.SaveChanges();
            return Ok(std);//CreatedAtAction(nameof(GetStudent), new { id = std.StudentId }, std);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student std)
        {
            if (id != std.StudentId)
                return BadRequest();
            context.Entry(std).State = EntityState.Modified;
            context.SaveChanges();
            return Ok(std);

        }

        [HttpDelete ("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = context.Students.Find(id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }
            context.Students.Remove(student);
            context.SaveChanges();
            return Ok($"Student with ID {id} deleted successfully.");
        }   
    }
}
