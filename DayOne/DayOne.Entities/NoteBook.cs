using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne.Entities
{
    public class NoteBook
    {
        
        public int UserId { get; set; }
        public string BookName { get; set; }

        public int NoteBookId { get; set; }
        public Boolean ShareOrNot { get; set; }
        public int NoteId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string NoteContent { get; set; }
        public string Title { get; set; }

        public string bookName { get; set; }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
