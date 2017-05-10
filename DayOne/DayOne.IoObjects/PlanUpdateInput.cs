using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOne.Entities;

namespace DayOne.IoObjects
{
    public class PlanUpdateInput : PlanInput
    {
        public int PlanId { get; set; }


        public DayPlan UpdateTo(DayPlan plan)
        {
            plan.ExpectEndAt = this.ExpectEndAt;
            plan.PlanType = this.PlanType;
            plan.Content = this.Content;
            plan.LoveOrNot = this.LoveOrNot;
            return plan;
        }
    }
}
