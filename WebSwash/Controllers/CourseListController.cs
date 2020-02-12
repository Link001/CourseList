using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebSwash.Models;

namespace WebSwash.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseListController : ControllerBase
    {
        private readonly ILogger<CourseListController> _logger;

        public CourseListController(ILogger<CourseListController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            using(CourseContext db = new CourseContext())
            {
                var course = db.Courses.ToList();
                return new OkObjectResult(course);
            }
        }

        [HttpGet("GetId")]
        public IActionResult Get(int id)
        {
            Course course = new Course { Id = id };
            using (CourseContext db = new CourseContext())
            {
                course = db.Courses.Find(id); 
                return new OkObjectResult(course);
            }
        }

        [HttpPost("CreateCourse")]
        public int CreateCourse(CreateCourseModel createCourseModel)
        {
            Course course = new Course
            {
                Date = DateTime.Now,
                Subject = createCourseModel.Subject,
                TeacherName = createCourseModel.TeacherName,
                Inform = createCourseModel.Inform,
            };
            using (CourseContext db = new CourseContext())
            {
                db.Courses.Add(course);
                db.SaveChanges();
            }
            return  course.Id;
        }

        [HttpPut("UpdateCourse")]
        public int UpdateCourse(UpdateCourseModel updateCourseModel, int id)
        {
            Course course = new Course
            {
                Id = id,
                Subject = updateCourseModel.Subject,
                TeacherName = updateCourseModel.TeacherName,
                Inform = updateCourseModel.Inform,
            };
             using (CourseContext db = new CourseContext())
            {
                course = db.Courses.Find(id);
                course.Subject = updateCourseModel.Subject;
                course.TeacherName = updateCourseModel.TeacherName;
                course.Inform = updateCourseModel.Inform;
                db.SaveChanges();
            }
            return  course.Id;
        }

        [HttpDelete("DeleteId")]
        public void Delete(int id)
        {
            Course course = new Course { Id = id };
            using (CourseContext db = new CourseContext())
            {
                db.Entry(course).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
