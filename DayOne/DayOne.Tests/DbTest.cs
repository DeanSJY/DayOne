using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DayOne.Tests
{
    [TestClass]
    public class DbTest
    {
        [TestMethod]
        public void CreateDb()
        {
            using (var db = new DayOne.Entities.DayOneContext())
            {
                db.Database.Initialize(true);
            }
        }
    }
}
