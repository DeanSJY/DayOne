﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using DayOne.Entities;
using System.Web.Mvc;
using DayOne.IoObjects;

namespace DayOne.Services
{
    public partial class NoteBookService : BaseService
    {

        #region 笔记本

        /// <summary>
        /// 增加笔记本
        /// </summary>
        /// <param name="bookName"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public NoteBook AddNoteBook(string bookName)  // OK
        {
            if (string.IsNullOrWhiteSpace(bookName))
                throw new ArgumentNullException("bookName");

            NoteBook notebook = new NoteBook()
            {
                UserId = CurrentPrincipal.UserId,
                CreateAt = DateTime.Now,
                BookName = bookName,
                ShareOrNot = false,

            };
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
            var notebook = GetMyBook(bookId);
            notebook.BookName = bookName;
            CurrentDB.SaveChanges();
            return notebook;
        }

        public NoteBook GetMyBook(int bookId)
        {
            var userId = AuthorizationContext.CurrentPrincipal.UserId;

            return CurrentDB.NoteBookTable.FirstOrDefault(o => o.NoteBookId == bookId && o.UserId == userId);
        }

        /// <summary>
        /// 删除笔记本
        /// </summary>
        /// <param name="bookId"></param>
        public void RemoveNoteBook(int bookId)  // OK
        {
            var notebook = GetMyBook(bookId);
            if (notebook != null)
            {
                var notes = CurrentDB.OneNoteTable.Where(o => o.BookId == bookId);
                CurrentDB.OneNoteTable.RemoveRange(notes);

                CurrentDB.NoteBookTable.Remove(notebook);

                CurrentDB.SaveChanges();
            }
        }

        /// <summary>
        /// 笔记本的列表
        /// </summary>
        /// <returns></returns>
        public List<NoteBook> GetNoteBooks()
        {
            var userId = AuthorizationContext.CurrentPrincipal.UserId;

            return CurrentDB.NoteBookTable.Where(o => o.UserId == userId).ToList();
        }

        #endregion

        #region  笔记

        private OneNote GetMyNote(int noteId)
        {
            var userId = CurrentPrincipal.UserId;

            return CurrentDB.OneNoteTable.FirstOrDefault(o => o.NoteId == noteId && o.UserId == userId);
        }


        /// <summary>
        /// 增加一条笔记
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public OneNote CreateNote(NewNote note)
        {
            var oneNote = (OneNote) note;
            oneNote.UserId = CurrentPrincipal.UserId;
            CurrentDB.OneNoteTable.Add(oneNote);
            CurrentDB.SaveChanges();
            return note;
        }

        /// <summary>
        /// 修改1条笔记
        /// </summary>
        /// <param name="noteId"></param>
        /// <param name="oneNote"></param>
        /// <returns></returns>
        public OneNote UpdateNote(NoteUpdating noteUpdating)
        {
            var oneNote = GetMyNote(noteUpdating.NoteId);
            if (oneNote == null)
            {
                throw new ArgumentException("笔记未找到");
            }
            noteUpdating.Merge(oneNote).UpdateAt = DateTime.Now;
            CurrentDB.SaveChanges();
            return oneNote;

        }

        /// <summary>
        /// 逻辑删除 放到回收站
        /// </summary>
        /// <param name="noteId"></param>
        public void RemoveNote2(int noteId)
        {
            var onenote = GetMyNote(noteId);
            onenote.IsDeleted = true;
            CurrentDB.SaveChanges();
        }

        /// <summary>
        /// 物理删除笔记
        /// </summary>
        /// <param name="noteId"></param>
        public void RemoveNoteFinal(int noteId)
        {
            var note = GetMyNote(noteId);
            CurrentDB.OneNoteTable.Remove(note);
            CurrentDB.SaveChanges();
        }

        /// <summary>
        /// 撤销删除的笔记
        /// </summary>
        /// <param name="noteId"></param>
        public void RecoveryNote(int noteId)
        {
            var onenote = GetMyNote(noteId);
            onenote.IsDeleted = false;
            CurrentDB.SaveChanges();
        }


        /// <summary>
        /// 创建笔记查询
        /// </summary>
        /// <returns></returns>
        private IQueryable<OneNote> CreateNoteQuery(bool includeDeleted = false)
        {
            var userId = CurrentPrincipal.UserId;
            if (includeDeleted == true)
            {
                return CurrentDB.OneNoteTable.Where(o => o.UserId == userId);
            }
            return CurrentDB.OneNoteTable.Where(o => o.UserId == userId && o.IsDeleted == false);
        }

        /// <summary>
        /// 笔记列表
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public List<OneNote> GetNotes(int bookId)
        {
            var notes = CreateNoteQuery().Where(o => o.BookId == bookId).ToList();
            return notes;
        }

        /// <summary>
        /// 回收站的笔记列表
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public List<OneNote> GetRecycleList(int bookId)
        {
            var notes = CreateNoteQuery(true).Where(o => o.BookId == bookId && o.IsDeleted).ToList();
            return notes;
        }

        /// <summary>
        /// 附件笔记罗列的页面
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public List<OneNote> GetAttachmentList(int bookId)
        {
            var attachnotes = CreateNoteQuery(true).Where(o => o.BookId == bookId && o.WithAttach).ToList();
            return attachnotes;
        }

        /// <summary>
        /// 爱心笔记罗列的页面
        /// </summary>
        /// <returns></returns>
        public List<OneNote> GetLoveList(int BookId)
        {
            var loveNotes = CreateNoteQuery().Where(o => o.BookId == BookId && o.LoveOrNot).ToList();
            return loveNotes;
        }

        #endregion

        /// <summary>
        /// 是否将笔记设置为爱心笔记
        /// </summary>
        /// <param name="noteId"></param>
        public void LoveIt(int noteId)
        {
            var note = CurrentDB.OneNoteTable.Find(noteId);
            note.LoveOrNot = true;
            CurrentDB.SaveChanges();
        }

        /// <summary>
        /// 是否将上传了附件笔记
        /// </summary>
        /// <param name="noteId"></param>
        public void CreateAttachment(int noteId)
        {
            var note = CurrentDB.OneNoteTable.Find(noteId);
            note.WithAttach = true;
            CurrentDB.SaveChanges();
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
        public List<OneNote> Search(int noteId, string content, string keyword, DateTime CreateAt)
        {
            var notes = CurrentDB.OneNoteTable.Where(o => o.Title.Contains(keyword) || o.Content.Contains(keyword))
                .OrderByDescending(o => o.UpdateAt).ThenBy(o => o.CreateAt).ToList();
            return notes;
        }

    }
}

