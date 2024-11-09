using BOs;
using Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Impl
{
    public class UserService : IUserService
    {
        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }
        public User GetUserById(string id)
        {
            return UserDAO.Instance.GetUserById(id);
        }
        public User GetUser(string email, string password)
        {
            return UserDAO.Instance.GetUser(email, password);
        }

        public bool IsAdmin(User user)
        {
            throw new NotImplementedException();
        }

        public bool IsStaff(User user)
        {
            throw new NotImplementedException();
        }
    }
}
