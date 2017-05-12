using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DayOne.Entities
{
    [Table("DayPlans")]
    public class DayPlan : ShareInfo
    {
        [NotMapped, Obsolete]
        public int PlanId
        {
            get { return Id; }
            set { Id = value; }
        }

        public DateTime? CompletedAt { get; set; }
        
        public DateTime? ExpectEndAt { get; set; }

        public string Content { get; set; }

        public PlanType PlanType { get; set; }

        public bool IsCompleted { get; set; }

        //public int UserId { get; set; }

        //[ForeignKey("UserId"), ScriptIgnore]
        //public UserInfo User { get; set; }


        //[NotMapped]
        //public bool LoveOrNot
        //{
        //    get { return ShareInfo.LoveOrNot; }
        //    set { ShareInfo.LoveOrNot = value; }
        //}

        //[NotMapped]
        //public bool ShareOrNot
        //{
        //    get { return ShareInfo.ShareOrNot; }
        //    set { ShareInfo.ShareOrNot = value; }
        //}

        /// <summary>
        /// 被赞次数
        /// </summary>
        [NotMapped,Obsolete]
        public int Likes
        {
            get { return LoveCount; }
            set { LoveCount = value; }
        }

        //[ForeignKey("PlanId"), ScriptIgnore]
        //public ShareInfo ShareInfo { get; set; }

    }
}
