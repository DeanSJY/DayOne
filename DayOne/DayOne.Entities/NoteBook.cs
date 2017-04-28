using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne.Entities
{
    public class NoteBook
    {
        [Key]
        public int NoteBookId { get; set; }
        
        public long UserId { get; set; }

        public string BookName { get; set; }

        public bool ShareOrNot { get; set; }

        public DateTime CreateAt { get; set; }
    }
}
