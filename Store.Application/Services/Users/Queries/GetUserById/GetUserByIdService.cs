using Store.Application.Interfaces.Context;
using Store.Domain.Entities.Users;

namespace Store.Application.Services.Users.Queries.GetUserById
{
    public class GetUserByIdService : IGetUserByIdService
    {
        private readonly IStoreDBContext _db;
        public GetUserByIdService(IStoreDBContext db)
        {
            _db = db;
        }
        public User GetUserById(long id)
        {
            return _db.Users.Find(id);
        }
    }
}
