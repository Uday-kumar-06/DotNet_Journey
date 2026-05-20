using Student_Registration_Search_System_AJAX.Models;

namespace Student_Registration_Search_System_AJAX.Repository
{
    public interface IRepository
    {
        Student AddStudent(Student student);

        List<Student> GetAllStudents();
    }
}
