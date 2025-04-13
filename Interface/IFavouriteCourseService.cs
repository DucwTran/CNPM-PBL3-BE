using Microsoft.EntityFrameworkCore;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Interface
{
    public interface IFavouriteCourseService
    {
        public Task AddFavouriteCourseAsync(FavouriteCourse favouriteCourse);
        public Task DeleteFavouriteCourseAsync(Guid favouriteCourseId);
        public Task<FavouriteCourse> GetFavvouriteCourseByIdAsync(Guid favouriteCourseId);
        public Task<IEnumerable<FavouriteCourse>> GetFavouriteCoursesByStudentIdAsync(Guid studentId);
        public Task<IEnumerable<FavouriteCourse>> GetAllFavouriteCourses();
    }
}
