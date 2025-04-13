using Microsoft.EntityFrameworkCore;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Interface
{
    public interface ICourseService
    {
        public Task AddCourseAsync(Course course);
        public Task UpdateCourseAsync(Course course);
        public Task DeleteCourseAsync(Guid courseId);
        public Task<Course> GetCourseByIdAsync(Guid courseId);
        public Task<IEnumerable<Course>> GetAllCoursesAsync();
    }
}
