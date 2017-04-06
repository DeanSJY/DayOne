using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOne.Entities;

namespace DayOne.Services
{
    public class UserService : BaseService
    {
        //private DayOneContext dbContext;
        public UserService()
        {
            //dbContext = new DayOneContext();
        }
        public UserInfo GetUserByName(string name)
        {
            var user = CurrentDB.UserTable.FirstOrDefault(o => o.UserName == name);
            return user;
        }

        public UserInfo Certify(string username, string password)
        {
            var user = GetUserByName(username);
            if (user != null && user.PassWord == password)
            {
                return user;
            }
            return null;
        }

        public DayOne.Entities.UserInfo Register(DayOne.Entities.UserInfo user)
        {
            user = CurrentDB.UserTable.Add(user);
            return user;
        }
    }
}

