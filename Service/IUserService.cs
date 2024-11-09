using BOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserService
    {
        User GetUser(string email, string password);

        User GetUserById(string id);

        void AddUser(User user);

        bool IsAdmin(User user);

        bool IsStaff(User user);

        List<User> GetAllUsers();
    }
}
