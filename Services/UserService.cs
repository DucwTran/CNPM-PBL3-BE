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

namespace api.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.UserID == user.UserID);
            if (currentUser != null)
            {
                throw new InvalidOperationException($"User with ID {user.UserID} already exists.");
            }
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {

            var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.UserID == user.UserID);
            if (currentUser == null)
            {
                throw new KeyNotFoundException($"User with ID {user.UserID} not found.");
            }
            _context.Users.Update(user);
            await _context.SaveChangesAsync(); 
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            var currentUser = await _context.Users.Where(u => u.UserID == userId).FirstOrDefaultAsync();
            if (currentUser == null)
            {
                throw new KeyNotFoundException($"User with ID {userId} not found.");
            }    
            _context.Users.Remove(currentUser);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserID == userId);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new KeyNotFoundException($"User with ID {userId} not found");
            }
        }

        public async Task<User> GetUserByNameAsync(string name)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Fullname == name);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new KeyNotFoundException($"User with name {name} not found");
            }
        }
        
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var listUser = await _context.Users.ToListAsync();
            if (listUser == null || listUser.Count == 0)
            {
                throw new KeyNotFoundException("No user found");
            }
            return listUser;
        }
    }
}