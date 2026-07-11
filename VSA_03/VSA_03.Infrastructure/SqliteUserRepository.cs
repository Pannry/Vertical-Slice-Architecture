using Microsoft.EntityFrameworkCore;
using VSA_03.Core.Models;

namespace VSA_03.Infrastructure
{
    public class SqliteUserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public SqliteUserRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<int> CreateAsync(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return user.Id;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
