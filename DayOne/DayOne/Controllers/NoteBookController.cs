using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DayOne.Entities;
using DayOne.IoObjects;
using DayOne.Services;


namespace DayOne.Controllers
{
    [RoutePrefix("NoteBook")]
    public class NoteBookController : Controller
    {
        private  NoteBookService notebookservice = new NoteBookService();

        #region  笔记本

        /// <summary>
        /// 笔记本首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()  //ok
        {
            return View("NoteBook", notebookservice.GetNoteBooks());
        }

        public ActionResult NoteBook()
        {
            return View();
        }

        /// <summary>
        /// 笔记本列表
        /// </summary>
        /// <returns></returns>
        public JsonResult NoteList()  //ok
        {
            var list = notebookservice.GetNoteBooks();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 新增笔记本
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost, Route("addNotebook")]
        public ActionResult AddNoteBook(string name)
        {
            var notebook = notebookservice.AddNoteBook(name);
            return Json(notebook);
        }

        /// <summary>
        /// 更新笔记本
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateNoteBook(int bookId, string newName)
        {
            var notebook = notebookservice.UpdateNoteBook(bookId, newName);
            return View(notebook);
        }

        /// <summary>
        /// 删除笔记本，并删除笔记本包含的笔记
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpDelete]
        public JsonResult Delete(int bookId)  // ok
        {
            notebookservice.RemoveNoteBook(bookId);
            return Json(true);
        }

        #endregion


        #region 笔记

        public JsonResult NoteList(int bookId)
        {
            var noteList = notebookservice.GetNotes(bookId);
            return Json(noteList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加笔记
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="content"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public JsonResult AddNote(NewNote note)
        {
            var oneNote = notebookservice.CreateNote(note);
            return Json(oneNote);
        }

        /// <summary>
        /// 修改笔记
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public ActionResult NoteEdit(NoteUpdating noteUpdating)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }

            var oneNote = notebookservice.UpdateNote(noteUpdating);
            return View(oneNote);
        }


        //提交笔记内容
        //[HttpPost]
        //public ActionResult NoteEdit2(int noteId)
        //{
        //    DayOneContext db = new DayOneContext();
        //    throw new NotImplementedException();
        //}


        /// <summary>
        /// 删除笔记
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>

        public ActionResult DeleteNote(int noteId)
        {
            notebookservice.RemoveNote2(noteId);
            return View();
        }

        #endregion

        //public ActionResult RecycleNote()
        //{
        //    ViewBag.Message = "Your contact page.";
        //    return View("recycleNote");
        //}
        //public ActionResult LoveNote()
        //{
        //    ViewBag.Message = "Your contact page.";
        //    return View("loveNote");
        //}

        //public ActionResult AttachNote()
        //{
        //    ViewBag.Message = "Your contact page.";
        //    return View("AttachmentNote");
        //}




        //}

        //[HttpPost]

        //public ActionResult DeleteNote(OneNote onenote)
        //{
        //    DayOneContext db = new DayOneContext();
        //    db.OneNoteTable.Attach(onenote);
        //    db.OneNoteTable.Remove(onenote);
        //    //db.ObjectStateManager.ChangeObjectState(onenote, Entities.Deleted);
        //    db.SaveChanges();
        //    return View("noteEdit", db.OneNoteTable);


        //}
        ////回收笔记

        //public ViewResult Details(int bookId, string title, string desciption, Boolean loveOrNot)
        //{
        //    throw new NotImplementedException();

        //}
    }
}
