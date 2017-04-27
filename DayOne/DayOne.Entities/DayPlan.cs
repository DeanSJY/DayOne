using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne.Entities
{
   public  class DayPlan
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }

        public int LoveOrNot { get; set; }
        public string Content { get; set; }
        public PlanType type { get; set; }

        public int LoveCount { get; set; }
    }
}
