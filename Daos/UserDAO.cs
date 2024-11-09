using BOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Daos
{
    public class UserDAO
    {
        private static UserDAO _instance;
        private List<User> users;
        public UserDAO()
        {
            users = new List<User>();
            users = GetUsers();
        }

        public static UserDAO Instance
        {
            get
            {
                if( _instance == null)
                {
                    _instance = new UserDAO();
                }
                return _instance;
            }
        }

        private List<User> GetUsers()
        {
            // Đọc dữ liệu từ file JSON
            string strData = File.ReadAllText("User.json");
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<List<User>>(strData, options);
        }
        public User GetUserById(string id)
        {
            return users.FirstOrDefault(x => x.Id.Equals(id));
        }
        public User GetUser(string email, string password)
        {
            //users = GetUsers();
            return users.SingleOrDefault(x => x.Email.Equals(email) && x.Password.Equals(password));
        }

        public void AddUser(User user)
        {
            users.Add(user);
            string data = JsonSerializer.Serialize(users);
            File.WriteAllText("User.json", data);
        }

        //public bool IsAdmin(User user)
        //{
        //    try
        //    {
        //        return user.Role == 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public bool IsStaff(User user)
        //{
        //    try
        //    {
        //        return user.Role == 3;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
