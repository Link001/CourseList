using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebSwash.Models;
using WebSwash.DAL;

namespace WebSwash.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseListController : ControllerBase
    {
        private readonly CourseRepository _courseRepository;

        public CourseListController(ILogger<CourseListController> logger, CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
          return Ok(_courseRepository.GetAll());
        }

        [HttpGet("{id}", Name = "GetId")]
        public IActionResult Get(int id)
        {
            return Ok(_courseRepository.GetId(id));
        }

        [HttpPost("CreateCourse")]
        public IActionResult CreateCourse(CreateCourseModel createCourseModel)
        {
            Course course = new Course
            {
                Date = DateTime.Now,
                Subject = createCourseModel.Subject,
                TeacherName = createCourseModel.TeacherName,
                Inform = createCourseModel.Inform,
            };
            _courseRepository.Create(course);
            return CreatedAtRoute("GetId", new { Id = course.Id }, course);
        }

        [HttpPut("UpdateCourse")]
        public IActionResult UpdateCourse(UpdateCourseModel updateCourseModel, int id)
        {
            Course course = new Course
            {
                Id = id,
                Subject = updateCourseModel.Subject,
                TeacherName = updateCourseModel.TeacherName,
                Inform = updateCourseModel.Inform,
            };
            //if (!Validator.IsValid(course))
            //    return NotFound();
            _courseRepository.Update(course, id);
            return Ok();
        }

        [HttpDelete("DeleteId")]
        public IActionResult Delete(int id)
        {
            Course course = new Course { Id = id};
            _courseRepository.Delete(course);
            return  Ok();
        }
    }
}
