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
                    CurrentDB.DayPlanTable.Where(o => o.UserId == userId && o.Type == planType)
                        .OrderByDescending(o => o.PlanId);
            }

            return
                CurrentDB.DayPlanTable.Where(o => o.UserId == userId && o.Type == planType && o.IsCompleted == false)
                    .OrderByDescending(o => o.PlanId);
        }

        public IQueryable<DayPlan> CreateQuery(bool includeCompleted)
        {
            var userId = CurrentPrincipal.UserId;

            if (includeCompleted)
            {
                return CurrentDB.DayPlanTable.Where(o => o.UserId == userId).OrderByDescending(o => o.PlanId);
            }

            return
                CurrentDB.DayPlanTable.Where(o => o.UserId == userId && o.IsCompleted == false)
                    .OrderByDescending(o => o.PlanId);
        }
    }
}
