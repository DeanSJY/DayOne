using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOne.Entities;

namespace DayOne.IoObjects
{
    /// <summary>
    /// 登录完成后，存储在HttpRequest与HttpSession中的授权信息
    /// </summary>
    [Serializable]
    public class UserPrincipal : System.Security.Principal.IIdentity, System.Security.Principal.IPrincipal
    {
        private int userId;

        private string userName;

        public UserPrincipal(UserInfo userInfo)
        {
            userId = userInfo.Id;
            userName = userInfo.UserName;
        }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name
        {
            get { return userName; }
            set { userName = value; }
        }

        public string AuthenticationType
        {
            get { return "database"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public System.Security.Principal.IIdentity Identity
        {
            get { return this; }
        }

        public bool IsInRole(string role)
        {
            return true;
        }
    }
}
