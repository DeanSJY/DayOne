using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne.Entities
{
    public class OneNote
    {
        [Key]
        public int NoteId { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public Boolean LoveOrNot { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserInfo User { get; set; }

        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public NoteBook Book { get; set; }

        public Boolean IsDeleted { get; set; }

        public int LoveCount { get; set; }

        public bool WithAttach { get; set; }

        public string KeyWords { get; set; }
    }
}
