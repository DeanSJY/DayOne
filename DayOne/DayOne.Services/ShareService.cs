using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOne.Entities;
using DayOne.IoObjects;

namespace DayOne.Services
{
    public class ShareService : BaseService
    {
        public void PublishNote(int noteId)
        {
            CreateShareList(noteId);
        }

        public void PublishPlan(int planId)
        {
            CreateShareList(planId: planId);
        }

        
        public void UnpublishNote(int noteId)
        {
            var db = CurrentDB;

            db.ShareTable.RemoveRange(db.ShareTable.Where(o => o.NoteId == noteId));
        }

        public void UnpublishPlan(int planId)
        {
            var db = CurrentDB;

            db.ShareTable.RemoveRange(db.ShareTable.Where(o => o.PlanId == planId));
        }

        private ShareList CreateShareList(int? noteId = null, int? planId = null)
        {
            var shareInfo = CurrentDB.ShareTable.Add(new ShareList()
            {
                UserId = AuthorizationContext.CurrentPrincipal.UserId,
                ShareAt = DateTime.Now,
                PlanId = planId,
                NoteId = noteId
            });
            CurrentDB.SaveChanges();
            return shareInfo;
        }

        public IList<ShareableContent> GetShareList(int start, int limit)
        {
            var dbContext = CurrentDB;
            var resultSet =  dbContext.ShareTable.OrderByDescending(o => o.ShareAt).Skip(0).Take(limit).ToList();
            var returnSet = new List<ShareableContent>();
            foreach (var shareList in resultSet)
            {
                returnSet.Add(new ShareableContent(shareList));
            }
            return returnSet;
        }

        public void LikeIt(int shareId)
        {
            var dbContext = CurrentDB;
            var shareInfo = dbContext.ShareTable.FirstOrDefault(o => o.Id == shareId);
            if (shareInfo != null)
            {
                if (shareInfo.Plan != null)
                {
                    shareInfo.Plan.Likes += 1;
                }
                else if (shareInfo.Note != null)
                {
                    shareInfo.Note.LoveCount += 1;
                }
                else
                {
                    throw new InvalidProgramException();
                }
                dbContext.SaveChanges();
            }
        }

        public void KillIt(int shareId)
        {
            var dbContext = CurrentDB;
            var shareInfo = dbContext.ShareTable.FirstOrDefault(o => o.Id == shareId);
            if (shareInfo != null)
            {
                if (shareInfo.Plan != null)
                {
                    shareInfo.Plan.Likes -= 1;
                }
                else if (shareInfo.Note != null)
                {
                    shareInfo.Note.LoveCount -= 1;
                }
                else
                {
                    throw new InvalidProgramException();
                }
                dbContext.SaveChanges();
            }
        }
    }
}
