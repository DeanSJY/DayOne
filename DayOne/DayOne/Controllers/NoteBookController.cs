using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DayOne.Entities;
using DayOne.Services;


namespace DayOne.Controllers
{
    public class NoteBookController : Controller
    {
        //笔记本

        public ActionResult AddNoteBook(NoteBook notebook)
        {
            return null;
        }

        [HttpPost]
        // 增加笔记
        public ActionResult AddNote(OneNote onenote) {        
        
         return View(noteEdit);      
        }
       //修改笔记
        public ActionResult NoteEdit( int noteId )
        {
            ViewBag.Message = "Your contact page.";
            DayOneContext db = new DayOneContext();
            var onenote = new DayOne.Entities.OneNote();
            ViewData.Model = onenote;
            return View(noteEdit);  
        }


        //提交笔记内容
         [HttpPost]
        public ActionResult NoteEdit2(int noteId){
         DayOneContext db = new DayOneContext();
         throw new NotImplementedException();
         }


        //删除笔记
         public ActionResult DeleteNote(int noteId) {
             DayOneContext db = new DayOneContext();
             var onenote = db.OneNoteTable.FirstOrDefault(a => a.NoteId == noteId);
             ViewData.Model = onenote;
             db.OneNoteTable.Remove(onenote);
             db.SaveChanges();
             return View(noteEdit);
         }

         [HttpPost]

         public ActionResult DeleteNote(OneNote onenote) {
             DayOneContext db = new DayOneContext();
             db.OneNoteTable.Attach(onenote);
             db.OneNoteTable.Remove(onenote);
             //db.ObjectStateManager.ChangeObjectState(onenote, Entities.Deleted);
             db.SaveChanges();
             return View(noteEdit, db.OneNoteTable);

         
         }
        //回收笔记
        public ActionResult RecycleNote() {
            ViewBag.Message = "Your contact page.";
            return View(recycleNote);
        
        }
        //爱心笔记
        public ActionResult LoveNote() {
            ViewBag.Message = "Your contact page.";
            return View(loveNote);
        }
        //附件笔记
        public ActionResult AttachmentNote() {
            ViewBag.Message = "Your contact page.";
            return View(attachmentNote);
        }

        public ViewResult Details(int bookId, string title, string desciption, Boolean loveOrNot)
        {
            throw new NotImplementedException();

        }


        public IView noteEdit { get; set; }
        public IView recycleNote { get; set; }
        public IView loveNote { get; set; }
        public IView attachmentNote { get; set; }



    }



}
