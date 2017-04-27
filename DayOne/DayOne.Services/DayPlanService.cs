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
    class DayPlanService
    {
        PlanType type;
        string content;
        DateTime startAt;
        DateTime endAt;
        Boolean showCompleted;
        int planId;

        [HttpPost]
        public DayPlan Create(PlanType type,string content,DateTime startAt,DateTime endAt) 
        {
            throw new NotImplementedException();
        }

        public void Delete(int PlanId)
        {
            throw new NotImplementedException();
        }

        public DayPlan Update(int planId, string content, DateTime startAt, DateTime endAt)
        {
            throw new NotImplementedException();
        }

        public DayPlan Query(PlanType type,Boolean showCompleted) 
        {
            throw new NotImplementedException();
        }

        public void Complete(int planId)
        {
            throw new NotImplementedException();
        }
    }
    }
