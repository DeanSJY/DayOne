using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOne.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DayOne.Tests
{
    [TestClass]
    public class Config
    {
        [AssemblyInitialize]
        public static void config_database(TestContext testContext)
        {
            DbUtils.InitializeEnvironment(new CallContextHolder());
        }
    }
}
