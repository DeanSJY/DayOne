using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne.IoObjects
{
    /// <summary>
    /// 登录请求信息
    /// </summary>
    public class LoginRequest
    {
        [StringLength(64,MinimumLength=3, ErrorMessage="Username can not be empty!")]
        public string UserName { get; set; }

        [StringLength(32, MinimumLength=6, ErrorMessage="Password can not be empty!")]
        public string PassWord { get; set; }
    } 
}
