namespace VSA_03.Core.Models
{
    public interface IUserRepository
    {
        Task<int> CreateAsync(User user);
        Task<User?> GetByIdAsync(int id);
    }
}
