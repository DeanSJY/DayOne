using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne.Entities
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string CellPhone { get; set; }

        //public string ValidCode { get; set; }

         [Key]
        public int Id { get; set; }
    }
}
