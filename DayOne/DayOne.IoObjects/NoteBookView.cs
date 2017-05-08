using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOne.Entities;

namespace DayOne.IoObjects
{
    public class NoteBookView  : NoteBook
    {
        public IList<OneNote> NoteList { get; set; }

        public NoteBookView(NoteBook noteBook, IList<OneNote> notes)
        {
            this.NoteBookId = noteBook.NoteBookId;
            this.UserId = noteBook.UserId;
            this.BookName = noteBook.BookName;
            this.CreateAt = noteBook.CreateAt;
            this.ShareOrNot = noteBook.ShareOrNot;
            this.NoteList = notes;
        }
    }
}
