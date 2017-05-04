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
        [Required(AllowEmptyStrings = false, ErrorMessage = "请输入用户名")]
        [StringLength(64, MinimumLength = 4, ErrorMessage = "用户名必须大于4位")]
        
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "请输入密码")]
        [StringLength(32, MinimumLength = 6, ErrorMessage = "密码必须大于6位")]
        
        public string PassWord { get; set; }

    }

    public class RegisterRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "请输入注册的用户名")]
        [StringLength(64, MinimumLength = 4, ErrorMessage = "用户名必须大于4位")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "用户名必须是字母和数字的组合")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "请输入注册的密码")]
        [StringLength(64, MinimumLength = 6, ErrorMessage = "密码必须大于6位")]
        
        public string PassWord { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "请输入密码")]
        [StringLength(64, MinimumLength = 6, ErrorMessage = "密码必须大于6位")]
       
        public string PassWord2 { get; set; }

    }
}
