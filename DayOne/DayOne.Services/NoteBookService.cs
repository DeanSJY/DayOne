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
    {
        /// <summary>
        /// 增加笔记本
        /// </summary>
        /// <param name="bookName"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public NoteBook AddNoteBook(string bookName, int bookId)
        {
            NoteBook notebook = new NoteBook()
            {
                UserId = CurrentPrincipal.UserId,
                CreateAt = DateTime.Now,
                BookName = bookName,
                ShareOrNot = false
            };
            //notebook.BookName = bookName;
            CurrentDB.NoteBookTable.Add(notebook);
            CurrentDB.SaveChanges();
            return notebook;
        }

        /// <summary>
        /// 更新笔记本
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="bookName"></param>
        /// <returns></returns>
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
            CurrentDB.NoteBookTable.Remove(notebook);
            var notes = CurrentDB.OneNoteTable.Where(o => o.BookId == bookId);
            CurrentDB.OneNoteTable.RemoveRange(notes);
            CurrentDB.SaveChanges();
        }


        /// <summary>
        /// 增加一条笔记
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>

        public OneNote CreateNote(OneNote note)
        {
            note.CreateAt = DateTime.Now;
            note.UpdateAt = DateTime.Now;
            note.IsDeleted = false;
            CurrentDB.OneNoteTable.Add(note);
            CurrentDB.SaveChanges();
            return note;
        }



        /// <summary>
        /// 修改1条笔记
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
        /// <summary>
        /// 回收站的笔记列表
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public List<OneNote> GetRecycleList(int bookId)
        {
            var notes = CurrentDB.OneNoteTable.Where(o => o.BookId == bookId && o.IsDeleted).ToList();
            return notes;

        }
        /// <summary>
        /// 笔记本的列表
        /// </summary>
        /// <returns></returns>
        public List<NoteBook> GetNoteBooks()
        {
            return CurrentDB.NoteBookTable.OrderBy(o => o.BookName).ToList();

        }
        /// <summary>
        /// 笔记列表
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public List<OneNote> GetNotes(int bookId)
        {
            var notes = CurrentDB.OneNoteTable.Where(o => o.BookId == bookId && !o.IsDeleted).ToList();
            return notes;
        }
        /// <summary>
        /// 附件笔记罗列的页面
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public List<OneNote> GetAttachmentList(int noteId)
        {
            var attachnotes = CurrentDB.OneNoteTable.Where(o => o.NoteId == noteId && o.WithAttach).ToList();
            return attachnotes;
        }
        /// <summary>
        /// 爱心笔记罗列的页面
        /// </summary>
        /// <returns></returns>
        public List<OneNote> GetLoveList(int noteId)
        {
            var loveNotes = CurrentDB.OneNoteTable.Where(o => o.NoteId == noteId && o.LoveOrNot).ToList();
            return loveNotes;
        }
        /// <summary>
        /// 是否将笔记设置为爱心笔记
        /// </summary>
        /// <param name="noteId"></param>
        public void LoveIt(int noteId)
        {
            var note = CurrentDB.OneNoteTable.Find(noteId);
            note.LoveOrNot = true;
            UpdateNote(noteId, note);

        }
        /// <summary>
        /// 是否将上传了附件笔记
        /// </summary>
        /// <param name="noteId"></param>
        public void CreateAttachment(int noteId)
        {
            var note = CurrentDB.OneNoteTable.Find(noteId);
            note.WithAttach = true;
            UpdateNote(noteId, note);
        }

        /// <summary>
        /// 删除上传的附件笔记
        /// </summary>
        /// <param name="noteId"></param>
        public void RemoveAttachment(int noteId)
        {
            var attachNote = CurrentDB.OneNoteTable.Find(noteId);
            attachNote.WithAttach = true;
            CurrentDB.OneNoteTable.Remove(attachNote);

        }
        /// <summary>
        /// 搜索功能
        /// </summary>
        /// <param name="noteId"></param>
        /// <param name="content"></param>
        /// <param name="keyword"></param>
        /// <param name="CreateAt"></param>
        /// <returns></returns>
        public List<OneNote> Search(int noteId, string content, string keyword,DateTime CreateAt)
        {
            var notes = CurrentDB.OneNoteTable.Where(o => o.Title.Contains(keyword) || o.Content.Contains(keyword))
                .OrderByDescending(o => o.UpdateAt).ThenBy(o => o.CreateAt).ToList();
            return notes;

        }

    }
}

