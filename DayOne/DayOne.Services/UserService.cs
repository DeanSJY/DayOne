using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOne.Entities;
using DayOne.IoObjects;

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

        public UserInfo RegisterV1(RegisterRequest userRegister)
        {
            if (!string.Equals(userRegister.PassWord, userRegister.PassWord2))
            {
                throw new ArgumentException("密码不匹配", "PassWord");
            }

            var dbContext = CurrentDB;

            if (dbContext.UserTable.Any(o => o.UserName == userRegister.UserName))
            {
                throw new ArgumentException("用户名已经存在", "UserName");
            }

            var user = CurrentDB.UserTable.Add(new DayOne.Entities.UserInfo
            {
                UserName = userRegister.UserName,
                PassWord = userRegister.PassWord
            });

            CurrentDB.SaveChanges();

            return user;
        }

        [Obsolete("使用RegisterV1")]
        public DayOne.Entities.UserInfo Register(DayOne.Entities.UserInfo user)
        {
            user = CurrentDB.UserTable.Add(user);
            return user;
        }
    }
}

