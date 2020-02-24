using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebSwash.DAL
{
    public class CourseRepository
    {
        private readonly CourseContext _courseContext;
        public CourseRepository(CourseContext courseContext)
        {
            _courseContext = courseContext;
        }
        public IEnumerable<Course> GetAll()
        {
            return _courseContext.Courses.ToList();
        }
        public Course GetId(int id)
        {
            return _courseContext.Courses.Find(id);
        }
        public int Create(Course course)
        {
            _courseContext.Courses.Add(course);
            _courseContext.SaveChanges();
            return course.Id;
        }
        public void Update(Course course, int id)
        {
            var inDb = _courseContext.Courses.Find(id);
            inDb.Subject = course.Subject;
            inDb.TeacherName = course.TeacherName;
            inDb.Inform = course.Inform;
            _courseContext.SaveChanges();
        }
        public void Delete(Course course)
        {
            _courseContext.Entry(course).State = EntityState.Deleted;
            _courseContext.SaveChanges();
        }
    }
}
