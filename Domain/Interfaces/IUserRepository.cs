using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<User> GetByEmailAndPassword(string email, string password);
        Task<bool> VerifyPasswordAsync(string password, byte[] storedHash, byte[] storedSalt);
    }
}
