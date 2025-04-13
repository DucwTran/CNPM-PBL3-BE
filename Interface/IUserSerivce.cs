using Microsoft.EntityFrameworkCore;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Interface
{
    public interface IUserService
    {
        public Task AddUserAsync(User user);
        public Task UpdateUserAsync(User user);
        public Task DeleteUserAsync(Guid userId);
        public Task<User> GetUserByIdAsync(Guid userId);
        public Task<User> GetUserByNameAsync(string name);
        public Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
