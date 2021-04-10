using Carvajal.Domain.Models;
using System.Collections.Generic;

namespace Carvajal.Domain.Interfaces
{
    public interface IUserRepository
    {
        User Insert(User model);
        void Update(User model);
        void Delete(int id);
        IEnumerable<User> GetAll();
        User GetById(int id);
        bool Exists(string identification);
        bool ValidateUserPassword(string identification , string password);
    }
}
