using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne.Entities
{
    public class DayPlan
    {        
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserInfo User { get; set; }

        [Key]
        public int PlanId { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime CompletedAt { get; set; }

        public DateTime ExpectEndAt { get; set; }

        public bool LoveOrNot { get; set; }

        public string Content { get; set; }

        public PlanType Type { get; set; }

        public bool IsCompleted { get; set; }


        /// <summary>
        /// 被赞次数
        /// </summary>
        public int Likes { get; set; }
    }
}
