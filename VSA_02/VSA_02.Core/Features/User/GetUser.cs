using VSA_02.Core.Models;

namespace VSA_02.Core.Features.Users
{
    public class GetUserHandler
    {
        private readonly UserDatabase _db;

        public GetUserHandler(UserDatabase db)
        {
            _db = db;
        }

        public User Handle(int id)
        {
            if (id == 0)
                throw new ArgumentException("Id é obrigatório");

            return _db.Users.First(x => x.Id == id);
        }
    }
}
