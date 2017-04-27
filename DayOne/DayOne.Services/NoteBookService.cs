using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOne.Entities;
using System.Web.Mvc;

namespace DayOne.Services
{
    public class NoteBookService : BaseService
    {  //笔记本的数据结构

        public NoteBookService()
        {

        }

        public NoteBook AddNoteBook(string bookName, int bookId)
        {
            NoteBook notebook = new NoteBook();
            notebook.BookName = bookName;
            CurrentDB.NoteBookTable.Add(notebook);
            CurrentDB.SaveChanges();
            return notebook;
        }

        public NoteBook UpdateNoteBook(int bookId, string bookName)
        {
            var notebook = CurrentDB.NoteBookTable.Find(bookId);
            notebook.BookName = bookName;
            CurrentDB.SaveChanges();
            return notebook;
        }
        /// <summary>
        /// 删除笔记本
        /// </summary>
        /// <param name="bookId"></param>
        public void RemoveNoteBook(int bookId)
        {
            var notebook = CurrentDB.NoteBookTable.Find(bookId);
            //CurrentDB.NoteBookTable.Find(bookId);
            CurrentDB.NoteBookTable.Remove(notebook);
            var notes = CurrentDB.OneNoteTable.Where(o => o.BookId == bookId);
            CurrentDB.OneNoteTable.RemoveRange(notes);
            CurrentDB.SaveChanges();
        }


        //添加1条笔记
        public OneNote CreateNote(OneNote note)
        {
            note.CreateAt = DateTime.Now;
            note.UpdateAt = DateTime.Now;
            note.IsDeleted = false;
            CurrentDB.OneNoteTable.Add(note);
            CurrentDB.SaveChanges();
            return note;
        }


        //修改笔记


        /// <summary>
        /// 修改笔记
        /// </summary>
        /// <param name="noteId"></param>
        /// <param name="oneNote"></param>
        /// <returns></returns>
        public OneNote UpdateNote(int noteId, OneNote oneNote)
        {
            var onenote = CurrentDB.OneNoteTable.Find(noteId);
            if (string.IsNullOrWhiteSpace(oneNote.Title))
                onenote.Title = oneNote.Title;

            onenote.UpdateAt = DateTime.Now;
            if (string.IsNullOrWhiteSpace(oneNote.Content))
                onenote.Content = oneNote.Content;
            onenote.LoveOrNot = oneNote.LoveOrNot;
            CurrentDB.SaveChanges();
            return onenote;

        }

        /// <summary>
        /// 逻辑删除 放到回收站
        /// </summary>
        /// <param name="noteId"></param>
        public void RemoveNote2(int noteId)
        {
            var onenote = CurrentDB.OneNoteTable.Find(noteId);
            onenote.IsDeleted = true;
            UpdateNote(noteId, onenote);
        }
        /// <summary>
        /// 物理删除笔记
        /// </summary>
        /// <param name="noteId"></param>
        public void RemoveNoteFinal(int noteId)
        {
            var note = CurrentDB.OneNoteTable.Find(noteId);
            CurrentDB.OneNoteTable.Remove(note);
            CurrentDB.SaveChanges();
        }

        /// <summary>
        /// 撤销删除的笔记
        /// </summary>
        /// <param name="noteId"></param>
        public void RecoveryNote(int noteId)
        {
            var onenote = CurrentDB.OneNoteTable.Find(noteId);
            onenote.IsDeleted = false;
            UpdateNote(noteId, onenote);
        }

        public List<OneNote> GetRecycleList(int bookId)
        {
            var notes = CurrentDB.OneNoteTable.Where(o=>o.BookId==bookId && o.IsDeleted).ToList();
            return notes;
            
        }
        public List<NoteBook> GetNoteBooks()
        {
            return CurrentDB.NoteBookTable.OrderBy(o => o.BookName).ToList();

        }

        public List<OneNote> GetNotes(int bookId)
        {
            var notes = CurrentDB.OneNoteTable.Where(o => o.BookId == bookId && !o.IsDeleted).ToList();
            return notes;       
        }

        public Attachment GetAttachmentList(int noteId)
        {
            throw new NotImplementedException();
        }
        public OneNote GetLoveList()
        {
            throw new NotImplementedException();
        }

        public void LoveIt(int noteId)
        {
            throw new NotImplementedException();
        }

        public void CreateAttachment(int noteId)
        {
            throw new NotImplementedException();
        }
        public void RemoveAttachment(int attachmentId)
        {
            throw new NotImplementedException();
        }

    }
}

