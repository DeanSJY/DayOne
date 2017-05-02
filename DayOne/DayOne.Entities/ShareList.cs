using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne.Entities
{
    /// <summary>
    /// 分享信息
    /// </summary>
    public class ShareList
    {
        [Key]
        public long Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserInfo User { get; set; }


        public int? NoteId { get; set; }

        [ForeignKey("NoteId")]
        public OneNote Note { get; set; }

        public int? PlanId { get; set; }

        [ForeignKey("PlanId")]
        public DayPlan Plan { get; set; }

        public DateTime ShareAt { get; set; }

        ///// <summary>
        ///// 被赞次数
        ///// </summary>
        //public int Likes { get; set; }

        ///// <summary>
        ///// 被否定次数
        ///// </summary>
        //public int Rejects { get; set; }
    }
}
