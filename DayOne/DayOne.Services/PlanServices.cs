using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOne.Entities;
using DayOne.IoObjects;

namespace DayOne.Services
{
    public class PlanServices : BaseService
    {
        public DayOne.Entities.DayPlan CreatePlan(PlanInput planInput)
        {
            if (planInput == null)
                throw new ArgumentNullException("planInput");

            DayPlan dayplan = planInput;
            dayplan.UserId = this.CurrentPrincipal.UserId;

            dayplan = CurrentDB.DayPlanTable.Add(dayplan);
            CurrentDB.SaveChanges();
            return dayplan;
        }

        public IQueryable<DayPlan> CreateQuery(PlanType planType, bool includeCompleted = false)
        {
            var userId = CurrentPrincipal.UserId;

            if (includeCompleted)
            {
                return
                    CurrentDB.DayPlanTable.Where(o => o.UserId == userId && o.PlanType == planType)
                        .OrderBy(o => o.PlanId);
            }

            return
                CurrentDB.DayPlanTable.Where(o => o.UserId == userId && o.PlanType == planType && o.IsCompleted == false)
                    .OrderBy(o => o.PlanId);
        }

        private IQueryable<DayPlan> CreateMyQuery()
        {
            var userId = CurrentPrincipal.UserId;

            return CurrentDB.DayPlanTable.Where(o => o.UserId == userId);
        }

        private IQueryable<DayPlan> QueryMyPlan(bool? includeCompleted = false,
            DateTime beforeCompleteAt = default(DateTime))
        {
            var userId = CurrentPrincipal.UserId;

            var statement = CurrentDB.DayPlanTable.Where(o => o.UserId == userId);
            if (includeCompleted != null)
            {
                var completed = includeCompleted.Value;

                statement = statement.Where(o => o.IsCompleted == completed);
            }
            if (beforeCompleteAt != default(DateTime))
            {
                statement = statement.Where(o => o.IsCompleted  && o.CompletedAt >= beforeCompleteAt);
            }

            return statement;
        }


        public bool ToggleCompleted(int planId)
        {
            var plan = CreateMyQuery().FirstOrDefault(o => o.PlanId == planId);
            if (plan != null)
            {
                plan.IsCompleted = !plan.IsCompleted;
                plan.CompletedAt = plan.IsCompleted ? new DateTime?(DateTime.Now) : null;
                CurrentDB.SaveChanges();
                return plan.IsCompleted;
            }
            return false;
        }

        public bool ToggleLoveOrNot(int planId)
        {
            var plan = CreateMyQuery().FirstOrDefault(o => o.PlanId == planId);
            if (plan != null)
            {
                plan.LoveOrNot = !plan.LoveOrNot;
                CurrentDB.SaveChanges();
                return plan.LoveOrNot;
            }
            return false;
        }

        public bool ToggleShareOrNot(int planId)
        {
            var plan = CreateMyQuery().FirstOrDefault(o => o.PlanId == planId);
            if (plan != null)
            {
                plan.ShareOrNot = !plan.ShareOrNot;
                CurrentDB.SaveChanges();
                return plan.ShareOrNot;
            }
            return false;
        }

        public DayPlan UpdatePlan(PlanUpdateInput updating)
        {
            var plan = CreateMyQuery().FirstOrDefault(o => o.PlanId == updating.PlanId);
            if (plan == null)
                return null;

            plan = updating.UpdateTo(plan);
            CurrentDB.SaveChanges();
            return plan;
        }

        public bool DeletePlan(int planId)
        {
            var plan = CreateMyQuery().FirstOrDefault(o => o.PlanId == planId);
            if (plan == null)
            {
                return false;
            }

            CurrentDB.DayPlanTable.Remove(plan);
            CurrentDB.SaveChanges();
            return true;
        }
    }
}
