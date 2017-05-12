using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne.IoObjects
{
    public class ShareQuery
    {
        public int Offset { get; set; }

        public int Limit { get; set; }

        public bool OnlyMyself { get; set; }

        public bool IncludeNote { get; set; }

        public bool IncludePlan { get; set; }

        public string Text { get; set; }
    }
}
