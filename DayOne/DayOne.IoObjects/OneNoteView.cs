using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOne.Entities;

namespace DayOne.IoObjects
{
    public class OneNoteView
    {
        [Key]
        public int NoteId { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool LoveOrNot { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public int BookId { get; set; }

        public string BookName { get; set; }

        public bool IsDeleted { get; set; }

        public int LoveCount { get; set; }

        public bool WithAttach { get; set; }

        public string KeyWords { get; set; }

    }
}
