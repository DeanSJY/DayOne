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
        [StringLength(64, MinimumLength = 3, ErrorMessage = "用户名必须是字母和数字的组合")]

        public string UserName { get; set; }

        [StringLength(32, MinimumLength = 6, ErrorMessage = "密码必须是字母和数字的组合")]
        public string PassWord { get; set; }

    }

    public class RegisterRequest
    {

        [StringLength(64, MinimumLength = 3, ErrorMessage = "用户名必须是字母和数字的组合")]
        public string UserName { get; set; }

        [StringLength(64, MinimumLength = 8, ErrorMessage = "密码必须是字母和数字的组合")]
        public string PassWord { get; set; }

        [StringLength(64, MinimumLength = 8, ErrorMessage = "密码必须是字母和数字的组合")]
        public string PassWord2 { get; set; }

        //[StringLength(11, ErrorMessage = "请正确输入手机号")]
        public string CellPhone { get; set; }

        public int VerifyCode { get; set; }
    }
}
