using System;
using System.Threading.Tasks;
using UserManager.Data.Interface;
using UserManager.Domain;
using UserManager.Service.Interface;

namespace UserManager.Service
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Delete(Guid Id)
        {
            return _userRepository.Delete(Id);
        }

        public bool Insert(User user)
        {
            if (ValidUser(user))
                return _userRepository.Insert(user);
            else
                return false;
        }

        public bool Update(User user)
        {
            if (ValidUser(user))
                return _userRepository.Update(user);
            else
                return true;
        }

        private bool ValidUser(User user)
        {
            if (user.Email.Contains("@") && user.Email.Contains(".com") && !string.IsNullOrEmpty(user.Name))
                return true;
            else
                return false;
        }
    }
}
