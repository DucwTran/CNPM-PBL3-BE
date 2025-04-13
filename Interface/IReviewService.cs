using Microsoft.EntityFrameworkCore;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Interface
{
    public interface IReviewService
    {
        public Task AddReviewAsync(Review review);
        public Task UpdateReviewAsync(Review review);
        public Task<Review> GetReviewByIdAsync(Guid reviewId);
        public Task<IEnumerable<Review>> GetReviewsByStudentIdAsync(Guid studentId);
        public Task<IEnumerable<Review>> GetReviewsByCourseIdAsync(Guid courseId);
        public Task<IEnumerable<Review>> GetAllReviewsAsync();
    }
}
