using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne.Entities
{
    public class Attachment
    {
        public int Id { get; set; }
        public int NoteId { get; set; }

        public string Title { get; set; }
        public string Path { get; set; }
        public string Icon { get; set; }
    }
}
