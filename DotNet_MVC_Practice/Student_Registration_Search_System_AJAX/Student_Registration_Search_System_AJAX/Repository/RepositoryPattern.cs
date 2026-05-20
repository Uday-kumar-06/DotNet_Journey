using Student_Registration_Search_System_AJAX.Data;
using Student_Registration_Search_System_AJAX.Models;

namespace Student_Registration_Search_System_AJAX.Repository
{
    public class RepositoryPattern : IRepository
    {
        private readonly AppDbContext _context;

        public RepositoryPattern(AppDbContext context)
        {
            _context = context;
        }

        public Student AddStudent(Student student)
        {
            _context.Students.Add(student);

            _context.SaveChanges();

            return student;
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }
    }
}
