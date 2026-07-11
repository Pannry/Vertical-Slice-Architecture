using VSA_03.Core.Models;

namespace VSA_03.Core.Features.Users
{
    public class GetUserHandler
    {
        private readonly IUserRepository _repo;

        public GetUserHandler(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<User?> HandleAsync(int id)
        {
            if (id == 0)
                throw new ArgumentException("Id é obrigatório");

            return await _repo.GetByIdAsync(id);
        }
    }
}
