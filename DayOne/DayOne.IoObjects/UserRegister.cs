using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne.IoObjects
{
   public class UserRegister
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string PassWord2 { get; set; }
        public int CellPhone { get; set; }
        private int VerifyCode { get; set; }
    }
}
