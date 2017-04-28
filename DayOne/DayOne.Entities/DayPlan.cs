using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne.Entities
{
   public  class DayPlan
    {
        public long UserId { get; set; }

        public int PlanId { get; set; }

        public DateTime StartAt { get; set; }

        public DateTime EndAt { get; set; }

        public bool  LoveOrNot { get; set; }

        public string Content { get; set; }

        public PlanType type { get; set; }

        public bool IsCompleted { get; set; }

       
    }
}
