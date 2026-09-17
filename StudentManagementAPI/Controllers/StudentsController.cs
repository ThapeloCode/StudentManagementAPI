using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        // Static list to temporarily hold student records (acts as our mock database)
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "John", Surname = "Smith", Email = "john.smith@example.com", Course = "Information Technology", Year = 1, StudentNumber = "STU001" },
            new Student { Id = 2, Name = "Mary", Surname = "Jones", Email = "mary.jones@example.com", Course = "Computer Science", Year = 2, StudentNumber = "STU002" },
            new Student { Id = 3, Name = "Peter", Surname = "Molefe", Email = "peter.molefe@example.com", Course = "Information Technology", Year = 1, StudentNumber = "STU003" },
            new Student { Id = 4, Name = "Sarah", Surname = "Mokoena", Email = "sarah.mokoena@example.com", Course = "Software Development", Year = 3, StudentNumber = "STU004" },
            new Student { Id = 5, Name = "David", Surname = "Naidoo", Email = "david.naidoo@example.com", Course = "Information Technology", Year = 2, StudentNumber = "STU005" }
        };
        // GET: api/students
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return Ok(students);
        }

        // GET: api/students/{id}
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound(); // Returns 404 if the student doesn't exist
            }

            return Ok(student); // Returns 200 with the student data
        }
    }

}