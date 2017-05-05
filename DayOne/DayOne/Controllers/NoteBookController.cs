using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DayOne.Entities;
using DayOne.Services;


namespace DayOne.Controllers
{
    [RoutePrefix("NoteBook")]
    public class NoteBookController : Controller
    {
        //笔记本

        public ActionResult NoteBook()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult NoteEdit()
        {
            ViewBag.Message = "Your contact page.";
            return View("noteEdit");
        }

        public ActionResult RecycleNote()
        {
            ViewBag.Message = "Your contact page.";
            return View("recycleNote");
        }
        public ActionResult LoveNote()
        {
            ViewBag.Message = "Your contact page.";
            return View("loveNote");
        }

        public ActionResult AttachNote()
        {
            ViewBag.Message = "Your contact page.";
            return View("AttachmentNote");
        }

        [HttpPost]
        [Route("addNotebook")]
        public ActionResult AddNoteBook(string name)
        {
            var notebookservice = new NoteBookService();
            notebookservice.AddNoteBook(name);
            return Json(true);

        }

        public bool AddNote(int bookId, string content, string title)
        {
            return true;
        }

        public JsonResult NoteList()
        {
            var notebookservice = new NoteBookService();
            var list = notebookservice.GetNoteBooks();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        //修改笔记
        //public ActionResult NoteEdit(int noteId)
        //{
        //    ViewBag.Message = "Your contact page.";
        //    DayOneContext db = new DayOneContext();
        //    var onenote = new DayOne.Entities.OneNote();
        //    ViewData.Model = onenote;
        //    return View();
        //}


        //提交笔记内容
        //[HttpPost]
        //public ActionResult NoteEdit2(int noteId)
        //{
        //    DayOneContext db = new DayOneContext();
        //    throw new NotImplementedException();
        //}


        //删除笔记
        //public ActionResult DeleteNote(int noteId)
        //{
        //    DayOneContext db = new DayOneContext();
        //    var onenote = db.OneNoteTable.FirstOrDefault(a => a.NoteId == noteId);
        //    ViewData.Model = onenote;
        //    db.OneNoteTable.Remove(onenote);
        //    db.SaveChanges();
        //    return View();
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
