using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Controllers
{
 // Controller-level attributes defining this as an API controller and setting its base route to api/students
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
     // ==========================================
     // 1. MOCK DATABASE (In-Memory Data Store)
     // ==========================================
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "John", Surname = "Smith", Email = "john.smith@example.com", Course = "Information Technology", Year = 1, StudentNumber = "STU001" },
            new Student { Id = 2, Name = "Mary", Surname = "Jones", Email = "mary.jones@example.com", Course = "Computer Science", Year = 2, StudentNumber = "STU002" },
            new Student { Id = 3, Name = "Peter", Surname = "Molefe", Email = "peter.molefe@example.com", Course = "Information Technology", Year = 1, StudentNumber = "STU003" },
            new Student { Id = 4, Name = "Sarah", Surname = "Mokoena", Email = "sarah.mokoena@example.com", Course = "Software Development", Year = 3, StudentNumber = "STU004" },
            new Student { Id = 5, Name = "David", Surname = "Naidoo", Email = "david.naidoo@example.com", Course = "Information Technology", Year = 2, StudentNumber = "STU005" }
        };

     // ==========================================
     // 2. READ ENDPOINTS (GET)
     // ==========================================

     // GET: api/students - Retrieves the full list of students
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return Ok(students); // Returns status 200 with the collection
        }

     // GET: api/students/{id} - Retrieves a single student by their unique ID
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound(); // Returns status 404 if the student doesn't exist
            }

            return Ok(student); // Returns status 200 with the requested student data
        }

     // ==========================================
     // 3. CREATE ENDPOINT (POST)
     // ==========================================

     // POST: api/students - Adds a new student record to the list
        [HttpPost]
        public ActionResult<Student> CreateStudent([FromBody] Student newStudent)
        {
         // Simple logic to auto-generate the next incremental ID
            if (students.Any())
            {
                newStudent.Id = students.Max(s => s.Id) + 1;
            }
            else
            {
                newStudent.Id = 1;
            }

         // Add the new student to our mock list
            students.Add(newStudent);

         // Returns status 201 Created with a Location header pointing to the new resource
            return CreatedAtAction(nameof(GetStudent), new { id = newStudent.Id }, newStudent);
        }

     // ==========================================
     // 4. UPDATE ENDPOINT (PUT)
     // ==========================================

     // PUT: api/students/{id} - Fully updates an existing student's details
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound(); // Returns status 404 if the student record doesn't exist
            }

         // Update the matching student's properties with incoming values
            student.Name = updatedStudent.Name;
            student.Surname = updatedStudent.Surname;
            student.Email = updatedStudent.Email;
            student.Course = updatedStudent.Course;
            student.Year = updatedStudent.Year;
            student.StudentNumber = updatedStudent.StudentNumber;

            return NoContent(); // Returns status 204 No Content on successful update
        }

     // ==========================================
     // 5. DELETE ENDPOINT (DELETE)
     // ==========================================

     // DELETE: api/students/{id} - Removes a student record from the list
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound(); // Returns status 404 if the student doesn't exist
            }

         // Remove the student instance from the static list
            students.Remove(student);

            return NoContent(); // Returns status 204 No Content on successful deletion
        }
    }
}