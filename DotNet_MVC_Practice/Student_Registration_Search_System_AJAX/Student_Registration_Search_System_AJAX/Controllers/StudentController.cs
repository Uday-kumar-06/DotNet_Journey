using Microsoft.AspNetCore.Mvc;
using Student_Registration_Search_System_AJAX.Models;
using Student_Registration_Search_System_AJAX.Repository;

namespace Student_Registration_Search_System_AJAX.Controllers
{
    public class StudentController : Controller
    {
        private readonly IRepository _repository;

        public StudentController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddStudent(Student student)
        {
            var result = _repository.AddStudent(student);

            return Json(result);
        }

        [HttpGet]
        public JsonResult GetStudents()
        {
            var students = _repository.GetAllStudents();

            return Json(students);
        }
    }
}
