using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Data.Context;
using UserManager.Data.Interface;
using UserManager.Domain;

namespace UserManager.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManagerContext _context;
        public UserRepository()
        {
            _context = new UserManagerContext();
        }       

        public bool Delete(Guid Id)
        {
            try
            {
                var user = _context.User.Where(x => x.Id == Id).FirstOrDefault();
                _context.User.Remove(user);
                var response = _context.SaveChanges();
                return (response > 0);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Insert(User user)
        {
            try
            {
                _context.User.Add(user);
                var response = _context.SaveChanges();
                return (response > 0);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(User user)
        {
            try
            {
                _context.User.Update(user);
                var response = _context.SaveChanges();
                return (response > 0);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
