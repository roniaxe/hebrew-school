using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.Models;

namespace TestWebApi.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly TestEntities _entities;

        public AuthRepository(TestEntities entities)
        {
            _entities = entities;
        }

        public async Task<User> Register(User user, string password)
        {
            CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _entities.Users.AddAsync(user);
            await _entities.SaveChangesAsync();

            return user;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _entities.Users.FirstOrDefaultAsync(u => u.Username.Equals(username));
            if (user == null) return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)) return null;

            return user;
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _entities.Users.AnyAsync(x => x.Username.Equals(username))) return true;
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] userPasswordHash, byte[] userPasswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(userPasswordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != userPasswordHash[i]) return false;
                }
            }

            return true;
        }
    }
}