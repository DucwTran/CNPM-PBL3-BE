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
    public class FavouriteCourseService : IFavouriteCourseService
    {
        private readonly ApplicationDbContext _context;
        public FavouriteCourseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddFavouriteCourseAsync(FavouriteCourse favouriteCourse)
        {
            var currentFavourite = await _context.Favourites.FirstOrDefaultAsync(f => f.FavouriteCourseID == favouriteCourse.FavouriteCourseID);
            if (currentFavourite != null)
            {
                throw new InvalidOperationException($"Favourite course with ID {favouriteCourse.FavouriteCourseID} already exists.");
            }
            await _context.Favourites.AddAsync(favouriteCourse);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFavouriteCourseAsync(Guid favouriteCourseId)
        {
            var currentFavourite = await _context.Favourites.FirstOrDefaultAsync(f => f.FavouriteCourseID == favouriteCourseId);
            if (currentFavourite == null)
                throw new KeyNotFoundException($"Favourite course with ID {favouriteCourseId} not found.");
            _context.Favourites.Remove(currentFavourite);
            await _context.SaveChangesAsync();
        }

        public async Task<FavouriteCourse> GetFavouriteCourseByIdAsync(Guid favourtiteCourseId)
        {
            var favouriteCourse = await _context.Favourites.FirstOrDefaultAsync(f => f.FavouriteCourseID == favourtiteCourseId);
            if (favouriteCourse != null)
            {
                return favouriteCourse;
            }
            else
            {
                throw new KeyNotFoundException($"Favourite course with ID {favourtiteCourseId} not found");
            }
        }

        public async Task<IEnumerable<FavouriteCourse>> GetFavouriteCoursesByStudentIdAsync(Guid studentId)
        {
            var listFavouriteCourse = await _context.Favourites.Where(f => f.UserID == studentId).ToListAsync();
            if (listFavouriteCourse == null || listFavouriteCourse.Count == 0)
                throw new KeyNotFoundException($"Favourite course with student ID {studentId} not found.");
            return listFavouriteCourse;
        }

        public async Task<IEnumerable<FavouriteCourse>> GetAllFavouriteCoursesAsync()
        {
            var listFavouriteCourse = await _context.Favourites.ToListAsync();
            if (listFavouriteCourse == null || listFavouriteCourse.Count == 0)
            {
                throw new KeyNotFoundException("No favourite course found");
            }
            return listFavouriteCourse;
        }
    }
}