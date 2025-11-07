using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using WebAPI1.Data;
using WebAPI1.models;
using WebAPI1.models.DTOs;

namespace WebAPI1.Services
{
    public class UserService
    {
        private readonly AppDbContext _appDbContext;

        public UserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            var user = _appDbContext.Users.ToListAsync();
            return await user;
        }

        public async Task<User> RegisterUserAsync(RegisterUserDto dto)
        {
            if (await _appDbContext.Users.AnyAsync(u => u.Email == dto.Email))
                throw new Exception("Email ya registrado");

            var user = new User
            {
                Email = dto.Email,
                UserName = dto.UserName,
                Password = HashPassword(dto.Password)
            };

            _appDbContext.Users.Add(user);
            await _appDbContext.SaveChangesAsync();

            return user;
        }


        public async Task<User> UpdateUserAsync(RegisterUserDto dto)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
                throw new Exception("Usuario no encontrado");

            user.UserName = dto.UserName ?? user.UserName;
            if (!string.IsNullOrEmpty(dto.Password))
                user.Password = HashPassword(dto.Password);

            _appDbContext.Users.Update(user);
            await _appDbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> UpdateEmailAsync(string oldEmail, string newEmail)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == oldEmail);
            if (user == null)
                throw new Exception("Usuario no encontrado");

            if (await _appDbContext.Users.AnyAsync(u => u.Email == newEmail))
                throw new Exception("El nuevo email ya esta en uso");

            user.Email = newEmail;
            _appDbContext.Users.Update(user);
            await _appDbContext.SaveChangesAsync();

            return user;
        }

        public async Task DeleteUserAsync(string email)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                throw new Exception("Usuario no encontrado");

            _appDbContext.Users.Remove(user);
            await _appDbContext.SaveChangesAsync();
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
