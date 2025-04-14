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
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _context;
        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddReviewAsync(Review review)
        {
            var currentReview = await _context.Reviews.FirstOrDefaultAsync(r => r.ReViewID == review.ReViewID);
            if (currentReview != null)
            {
                throw new InvalidOperationException($"Review with ID {review.ReViewID} already exists.");
            }
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReviewAsync(Review review)
        {

            var currentReview = await _context.Reviews.FirstOrDefaultAsync(r => r.ReViewID == review.ReViewID);
            if (currentReview == null)
            {
                throw new KeyNotFoundException($"Review with ID {review.ReViewID} not found.");
            }
            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();
        }

        public async Task<Review> GetReviewByIdAsync(Guid reviewId)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(r => r.ReViewID == reviewId);
            if (review != null)
            {
                return review;
            }
            else
            {
                throw new KeyNotFoundException($"Review with ID {reviewId} not found");
            }
        }

        public async Task<IEnumerable<Review>> GetReviewsByStudentIdAsync(Guid studentId)
        {
            var listReview = await _context.Reviews.Where(r => r.UserID == studentId).ToListAsync();
            if (listReview == null || listReview.Count == 0)
                throw new KeyNotFoundException($"Review with student ID {studentId} not found.");
            return listReview;
        }

        public async Task<IEnumerable<Review>> GetReviewsByCourseIdAsync(Guid courseId)
        {
            var listReview = await _context.Reviews.Where(r => r.CourseID == courseId).ToListAsync();
            if (listReview == null || listReview.Count == 0)
                throw new KeyNotFoundException($"Review with course ID {courseId} not found.");
            return listReview;
        }

        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            var listReview = await _context.Reviews.ToListAsync();
            if (listReview == null || listReview.Count == 0)
            {
                throw new KeyNotFoundException("No review found");
            }
            return listReview;
        }
    }
}