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
    public class EnrollmentService : IEnrollmentService
    {
        private readonly ApplicationDbContext _context;
        public EnrollmentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddEnrollmentAsync(Enrollment enrollment)
        {
            var currentEnrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.EnrollmentID == enrollment.EnrollmentID);
            if (currentEnrollment != null)
                throw new InvalidOperationException($"Enrollment with ID {enrollment.EnrollmentID} already exists.");
            _context.Enrollments.AddAsync(enrollment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEnrollmentAsync(Enrollment enrollment)
        {
            var currentEnrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.EnrollmentID == enrollment.EnrollmentID);
            if (currentEnrollment == null)
                throw new KeyNotFoundException($"Enrollment with ID {enrollment.EnrollmentID} not found.");
            _context.Enrollments.Update(enrollment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEnrollmentAsync(Guid enrollmentId)
        {
            var currentEnrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.EnrollmentID == enrollmentId);
            if (currentEnrollment == null)
                throw new KeyNotFoundException($"Enrollment with ID {enrollmentId} not found.");
            _context.Enrollments.Remove(currentEnrollment);
            await _context.SaveChangesAsync();
        }
        public async Task<Enrollment> GetEnrollmentByIdAsync(Guid enrollmentId)
        {
            var currentEnrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.EnrollmentID == enrollmentId);
            if (currentEnrollment == null)
                throw new KeyNotFoundException($"Enrollment with ID {enrollmentId} not found.");
            return currentEnrollment;
        }
        public async Task<IEnumerable<Enrollment>> GetUnconfirmEnrollmentsByStudentIdAsync(Guid studentId)
        {
            var listEnrollment = await _context.Enrollments.Where(e => e.UserID == studentId && e.StatusPayment == false).ToListAsync();
            if (listEnrollment == null || listEnrollment.Count == 0)
                throw new KeyNotFoundException($"Unconfirm enrollment with student ID {studentId} not found.");
            return listEnrollment;
        }

        public async Task<IEnumerable<Enrollment>> GetUnconfirmEnrollmentsByCourseIdAsync(Guid courseId)
        {
            var listEnrollment = await _context.Enrollments.Where(e => e.CourseId == courseId && e.StatusPayment == false).ToListAsync();
            if (listEnrollment == null || listEnrollment.Count == 0)
                throw new KeyNotFoundException($"Unconfirm enrollment with course ID {courseId} not found.");
            return listEnrollment;
        }

        public async Task<IEnumerable<Enrollment>> GetConfirmEnrollmentsByStudentIdAsync(Guid studentId)
        {
            var listEnrollment = await _context.Enrollments.Where(e => e.UserID == studentId && e.StatusPayment == true).ToListAsync();
            if (listEnrollment == null || listEnrollment.Count == 0)
                throw new KeyNotFoundException($"Unconfirm enrollment with student ID {studentId} not found.");
            return listEnrollment;
        }

        public async Task<IEnumerable<Enrollment>> GetConfirmEnrollmentsByCourseIdAsync(Guid courseId)
        {
            var listEnrollment = await _context.Enrollments.Where(e => e.CourseId == courseId && e.StatusPayment == true).ToListAsync();
            if (listEnrollment == null || listEnrollment.Count == 0)
                throw new KeyNotFoundException($"Unconfirm enrollment with course ID {courseId} not found.");
            return listEnrollment;
        }

        public async Task<IEnumerable<Enrollment>> GetAllUnconfirmEnrollmentAsync()
        {
            var listEnrollment = await _context.Enrollments.Where(e => e.StatusPayment == false).ToListAsync();
            if (listEnrollment == null || listEnrollment.Count == 0)
                throw new KeyNotFoundException($"No unconfirm enrollment found.");
            return listEnrollment;
        }

        public async Task<IEnumerable<Enrollment>> GetAllConfirmEnrollmentAsync()
        {
            var listEnrollment = await _context.Enrollments.Where(e => e.StatusPayment == true).ToListAsync();
            if (listEnrollment == null || listEnrollment.Count == 0)
                throw new KeyNotFoundException($"No confirm enrollment found.");
            return listEnrollment;
        }

        public async Task<IEnumerable<Enrollment>> GetAllEnrollmentAsync()
        {
            var listEnrollment = await _context.Enrollments.ToListAsync();
            if (listEnrollment == null || listEnrollment.Count == 0)
                throw new KeyNotFoundException($"No enrollment found.");
            return listEnrollment;
        }
    }
}