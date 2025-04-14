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
using Microsoft.OpenApi.Validations;

namespace api.Services
{
    public class LessonService : ILessonService
    {
        private readonly ApplicationDbContext _context;
        public LessonService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddLessonAsync(Lesson lesson)
        {
            var currentLesson = await _context.Lessons.FirstOrDefaultAsync(l => l.LessonID == lesson.LessonID);
            if (currentLesson != null)
            {
                throw new InvalidOperationException($"Lesson with ID {lesson.LessonID} already exists.");
            }
            await _context.Lessons.AddAsync(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLessonAsync(Lesson lesson)
        {

            var currentLesson = await _context.Lessons.FirstOrDefaultAsync(l => l.LessonID == lesson.LessonID);
            if (currentLesson == null)
            {
                throw new KeyNotFoundException($"Lesson with ID {lesson.LessonID} not found.");
            }
            _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLessonAsync(Guid lessonId)
        {
            var currentLesson = await _context.Lessons.FirstOrDefaultAsync(l => l.LessonID == lessonId);
            if (currentLesson == null)
                throw new KeyNotFoundException($"Lesson with ID {lessonId} not found");
            _context.Lessons.Remove(currentLesson);
            await _context.SaveChangesAsync();
        }

        public async Task<Lesson> GetLessonByIdAsync(Guid lessonId)
        {
            var lesson = await _context.Lessons.FirstOrDefaultAsync(l => l.LessonID == lessonId);
            if (lesson != null)
            {
                return lesson;
            }
            else
            {
                throw new KeyNotFoundException($"Lesson with ID {lessonId} not found");
            }
        }

        public async Task<IEnumerable<Lesson>> GetLessonsByCourseIdAsync(Guid courseId)
        {
            var listLesson = await _context.Lessons.Where(l => l.CourseID == courseId).ToListAsync();
            if (listLesson == null || listLesson.Count == 0)
                throw new KeyNotFoundException($"Lesson with course ID {courseId} not found.");
            return listLesson;
        }

        public async Task<IEnumerable<Lesson>> GetAllLessonsAsync()
        {
            var listLesson = await _context.Lessons.ToListAsync();
            if (listLesson == null || listLesson.Count == 0)
            {
                throw new KeyNotFoundException("No lesson found");
            }
            return listLesson;
        }
    }
}