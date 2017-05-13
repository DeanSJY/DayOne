using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOne.Entities;

namespace DayOne.IoObjects
{
    public class NoteUpdating
    {
        [StringLength(256, MinimumLength = 1)]
        public string Title { get; set; }


        public string Content { get; set; }

        public bool LoveOrNot { get; set; }


        [Range(0, Int32.MaxValue)]
        public int NoteId { get; set; }

        public OneNote Merge(OneNote oneNote)
        {
            oneNote.Title = Title;
            oneNote.Content = Content;
            oneNote.LoveOrNot = LoveOrNot;

            return oneNote;
        }
    }
}
