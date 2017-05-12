using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOne.Entities;

namespace DayOne.IoObjects
{
    public class NewNote
    {
        [MinLength(1, ErrorMessage = "标题太短")]
        public string Title { get; set; }

        [MinLength(1, ErrorMessage = "内容太短")]
        public string Content { get; set; }

        [Range(0, Int32.MaxValue)]
        public int BookId { get; set; }

        public bool LoveOrNot { get; set; }

        public bool ShareOrNot { get; set; }


        public static implicit operator OneNote(NewNote newNote)
        {
            return new OneNote()
            {
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                IsDeleted = false,
                LoveCount = 0,
                LoveOrNot = newNote.LoveOrNot,
                ShareOrNot =  newNote.ShareOrNot,
                Content =  newNote.Content,
                Title =  newNote.Title,
                BookId =  newNote.BookId
            };
        }
    }
}
