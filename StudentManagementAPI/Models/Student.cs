namespace StudentManagementAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Course { get; set; }
        public int Year { get; set; }

        // Challenge Property: StudentNumber
        public string StudentNumber { get; set; }
    }
}