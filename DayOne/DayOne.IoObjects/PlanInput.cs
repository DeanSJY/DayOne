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

        public string Title { get; set; }

        public DateTime ExpectEndAt { get; set; }
    }
}
