using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DayOne.Entities;

namespace DayOne.Tests
{
    public class CallContextHolder :DbUtils.DbHolder
    {
        private const string __key__ssss = "__key__dbd";

        public override DayOneContext CurrentDB
        {
            get { return CallContext.GetData(__key__ssss) as DayOneContext; }
            set
            {
                if (value == null)
                {

                    CallContext.FreeNamedDataSlot(__key__ssss);
                }
                else
                {   
                    CallContext.SetData(__key__ssss, value);
                }

            }
        }
    }
}
