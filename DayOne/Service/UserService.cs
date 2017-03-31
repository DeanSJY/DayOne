using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService
    {
        private DayOneContext dbContext;
        public UserService()
        {
            dbContext = new DayOneContext();
        }
        public UserInfo GetUserByName(string name)
        {
            var user = dbContext.UserTable.FirstOrDefault(o => o.UserName == name);
            return user;
        }

        public bool Certify(string username, string password)
        {
            var user = GetUserByName(username);
            return user != null && user.PassWord == password;
        }

        public Entity.UserInfo Register(Entity.UserInfo user)
        {
            user = dbContext.UserTable.Add(user);
            return user;
        }
    }
}

