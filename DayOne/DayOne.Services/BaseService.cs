using DayOne.Entities;
using DayOne.IoObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne.Services
{
    public class BaseService
    {
        private DayOneContext _dbContext;

        protected DayOneContext CurrentDB
        {
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = DbUtils.CurrentDB;
                }
                return _dbContext;
            }
        }


        public UserPrincipal CurrentPrincipal
        {
            get
            {
                return AuthorizationContext.CurrentPrincipal;
            }
        }
    }
}
