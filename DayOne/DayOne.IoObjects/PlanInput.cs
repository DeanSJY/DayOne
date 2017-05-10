using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOne.Entities;

namespace DayOne.IoObjects
{
    public class PlanInput
    {
        public PlanType PlanType { get; set; }

        public string Content { get; set; }

        public DateTime? ExpectEndAt { get; set; }

        public bool LoveOrNot { get; set; }

        public static implicit operator DayPlan(PlanInput p)
        {
            var plan = new DayPlan()
            {
                CreateAt =  DateTime.Now,
                ExpectEndAt = p.ExpectEndAt,
                LoveOrNot = p.LoveOrNot,
                PlanType = p.PlanType,
                Content = p.Content
            };

            return plan;
        }
    }
}
