using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne.Entities
{
    public class ShareList
    {
        public int UserId { get; set; }
        public UserInfo User{get; set;}

        public int NoteId{get;set;}

        public int PlanId{get;set;}

        public DateTime ShareAt { get; set; }

    }
}
