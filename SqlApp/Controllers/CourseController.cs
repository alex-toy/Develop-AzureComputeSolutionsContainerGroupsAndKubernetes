using Microsoft.AspNetCore.Mvc;
using SqlApp.Models;
using SqlApp.Services;

namespace SqlApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _course_service;
        private readonly IConfiguration _configuration;

        public CourseController(CourseService _svc, IConfiguration configuration)
        {
            _course_service = _svc;
            _configuration = configuration;

        }

        public IActionResult Index()
        {
            string _connection_string = _configuration.GetConnectionString("SQLConnection");
            IEnumerable<Course> _course_list = _course_service.GetCourses(_connection_string);
            return View(_course_list);
        }
    }
}
