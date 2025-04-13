using Microsoft.EntityFrameworkCore;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Interface
{
    public interface IErollmentService
    {
        public Task AddEnrollmentAsync(Enrollment enrollment);
        public Task UpdateEnrollmentAsync(Enrollment enrollment);
        public Task DeleteEnrollmentAsync(Guid enrollmentId);
        public Task<Enrollment> GetEnrollmentByIdAsync(Guid enrollmentId);
        public Task<IEnumerable<Enrollment>> GetUnconfirmEnrollmentsByStudentIdAsync(Guid studentId);
        public Task<IEnumerable<Enrollment>> GetUnconfirmEnrollmentsByCourseIdAsync(Guid courseId);
        public Task<IEnumerable<Enrollment>> GetConfirmEnrollmentsByStudentIdAsync(Guid studentId);
        public Task<IEnumerable<Enrollment>> GetConfirmEnrollmentsByCourseIdAsync(Guid courseId);
        public Task<IEnumerable<Enrollment>> GetAllUnconfirmEnrollmentAsync();
        public Task<IEnumerable<Enrollment>> GetAllConfirmEnrollmentAsync();
        public Task<IEnumerable<Enrollment>> GetAllEnrollmentAsync();
    }
}
