using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Domain;

namespace UserManager.Service.Interface
{
    public interface IUserService
    {       
        bool Insert(User user);
        bool Update(User user); 
        bool Delete(Guid Id);
    }
}
