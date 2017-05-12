using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
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

        public IQueryable<ShareInfo> QueryShareList(ShareQuery shareQuery)
        {
            //IQueryable<ShareInfo> statement = CurrentDB.ShareInfos.AsNoTracking();

            IQueryable<OneNote> noteSQL = CurrentDB.ShareInfos.OfType<OneNote>();
            IQueryable<DayPlan> planSQL = CurrentDB.ShareInfos.OfType<DayPlan>();

            //if (shareQuery.OnlyMyself)
            //{
            //    var userId = CurrentPrincipal.UserId;
            //    statement = statement.Where(o => o.UserId == userId);
            //}

            if (shareQuery.IncludeNote)
            {
                if (shareQuery.OnlyMyself)
                {
                    var userId = CurrentPrincipal.UserId;

                    noteSQL = noteSQL.Where(o => o.UserId == userId);
                }

                if (!string.IsNullOrWhiteSpace(shareQuery.Text))
                {
                    noteSQL =
                        noteSQL.Where(o => o.Content.Contains(shareQuery.Text) || o.Title.Contains(shareQuery.Text));
                }

                if (shareQuery.IncludePlan == false)
                {
                    return noteSQL.OrderByDescending(o => o.UpdateAt);
                }
            }

            if (shareQuery.IncludePlan)
            {
                if (shareQuery.OnlyMyself)
                {
                    var userId = CurrentPrincipal.UserId;

                    planSQL = planSQL.Where(o => o.UserId == userId);
                }

                if (!string.IsNullOrWhiteSpace(shareQuery.Text))
                {
                    planSQL =
                        planSQL.Where(o => o.Content.Contains(shareQuery.Text));
                }

                if (shareQuery.IncludeNote == false)
                {
                    return planSQL.OrderByDescending(o => o.UpdateAt);
                }
            }

            return planSQL.OfType<ShareInfo>().Concat(noteSQL.OfType<ShareInfo>())
                .OrderByDescending(o => o.UpdateAt);
        }

        public void LoadIsMyPraised(ShareInfo shareInfo)
        {
            if (CurrentPrincipal==null)
                return;

            var userId = CurrentPrincipal.UserId;

            shareInfo.IsMyPraised = CurrentDB.PraiseUsers.Any(o => o.UserId == userId && o.ShareId == shareInfo.Id);
        }

        public bool ToggleLoveIt(int shareId)
        {
            if (CurrentPrincipal == null)
                return false;

            var userId = CurrentPrincipal.UserId;


            try
            {

                if (!CurrentDB.PraiseUsers.Any(o => o.ShareId == shareId && o.UserId == userId))
                {
                    CurrentDB.PraiseUsers.Add(new PraiseUser()
                    {
                        UserId = userId,
                        ShareId = shareId,
                        LikeAt = DateTime.Now
                    });
                    CurrentDB.Database.ExecuteSqlCommand("UPDATE ShareInfos set LoveCount=LoveCount+1 WHERE Id=@p0",
                        new SqlParameter("p0", shareId));
                    return true;
                }
                else
                {
                    CurrentDB.PraiseUsers.RemoveRange(
                        CurrentDB.PraiseUsers.Where(o => o.ShareId == shareId && o.UserId == userId));

                    CurrentDB.Database.ExecuteSqlCommand("UPDATE ShareInfos set LoveCount=LoveCount-1 WHERE Id=@p0",
                        new SqlParameter("p0", shareId));

                    return false;
                }
            }
            finally
            {
                CurrentDB.SaveChanges();
            }
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
