using System;
using System.Threading.Tasks;
using UserManager.Domain;

namespace UserManager.Data.Interface
{
    public interface IUserRepository
    {
        bool Insert(User user);
        bool Update(User user);
        bool Delete(Guid Id);
    }
}
