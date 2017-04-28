using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne.Entities
{
    public class DayOneContext : DbContext
    {
        public DayOneContext()
            : base("name=DefaultConnection")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();  //去除“设置表名为复数”这条约定
        }

        public DbSet<UserInfo> UserTable { get; set; }


        public DbSet<NoteBook> NoteBookTable { get; set; }


        public DbSet<OneNote> OneNoteTable { get; set; }


        public DbSet<DayPlan> DayPlanTable { get; set; }


        public DbSet<ShareList> ShareTable { get; set; }



    }
}
