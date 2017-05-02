using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOne.Entities;
using DayOne.IoObjects;
using System.Web.Mvc;

namespace DayOne.Services
{


    public partial class NoteBookService : BaseService
    {
        public DayPlan Create(PlanType type, long UserId, DateTime StartAt)
        {
            DayPlan dayplan = new DayPlan();
            {
                UserId = CurrentPrincipal.UserId;
                StartAt = DateTime.Now;
            }
            ;
            CurrentDB.DayPlanTable.Add(dayplan);
            CurrentDB.SaveChanges();
            return dayplan;
        }

        public void Delete(int planId)
        {
            var plan = CurrentDB.DayPlanTable.Find(planId);
            CurrentDB.DayPlanTable.Remove(plan);
            CurrentDB.SaveChanges();
        }

        public DayPlan Update(int planId, string content, DateTime endAt)
        {
            var plan = CurrentDB.DayPlanTable.Find(planId);
            plan.Content = content;
            plan.StartAt = endAt;
            CurrentDB.SaveChanges();
            return plan;
        }

        public List<DayPlan> Query(PlanType type, Boolean showCompleted, int planId)
        {
            var plan = CurrentDB.DayPlanTable.Where(o => o.PlanId == planId && o.IsCompleted).ToList();
            return plan;


        }

        public void Complete(int planId)
        {
            var plan = CurrentDB.DayPlanTable.Find(planId);
            plan.IsCompleted = true;


        }
    }
}
