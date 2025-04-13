using Microsoft.EntityFrameworkCore;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Interface
{
    public interface ILessonService
    {
        public Task AddLessonAsync(Lesson lesson);
        public Task UpdateLessonAsync(Lesson lesson);
        public Task DeleteLessonAsync(Guid lessonId);
        public Task<Lesson> GetLessonByIdAsync(Guid lessonId);
        public Task<IEnumerable<Lesson>> GetLessonsByCourseIdAsync(Guid courseId);
        public Task<IEnumerable<Lesson>> GetAllLessonsAsync();
    }
}
