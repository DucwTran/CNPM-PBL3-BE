using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Interface;
using api.Models;
using Microsoft.IdentityModel.Tokens;

namespace api.Services
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _context;
        public CourseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCourseAsync(Course course)
        {
            var currentCourse = await _context.Courses.FirstOrDefaultAsync(c => c.CourseID == course.CourseID);
            if (currentCourse != null)
            {
                throw new InvalidOperationException($"Course with ID {course.CourseID} already exists.");
            }
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCourseAsync(Course course)
        {
            var currentCourse = await _context.Courses.FirstOrDefaultAsync(c => c.CourseID == course.CourseID);
            if (currentCourse == null)
            {
                throw new KeyNotFoundException($"Course with ID {course.CourseID} not found.");
            }
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourseAsync(Guid courseId)
        {
            var currentCourse = await _context.Courses.FirstOrDefaultAsync(c => c.CourseID == courseId);
            if (currentCourse == null)
            {
                throw new KeyNotFoundException($"Course with ID {courseId} not found.");
            }
            _context.Courses.Remove(currentCourse);
            await _context.SaveChangesAsync();
        }

        public async Task<Course> GetCourseByIdAsync(Guid courseId)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseID == courseId);
            if (course != null)
            {
                return course;
            }
            else
            {
                throw new KeyNotFoundException($"Course with ID {courseId} not found");
            }
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            var listCourse = await _context.Courses.ToListAsync();
            if (listCourse == null || listCourse.Count == 0)
            {
                throw new KeyNotFoundException("No course found");
            }
            return listCourse;
        }
    }
}