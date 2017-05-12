using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DayOne.Entities
{
    [Table("ShareInfos")]
    public class ShareInfo
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId"),ScriptIgnore]
        public virtual UserInfo User { get; set; }

        public bool ShareOrNot { get; set; }

        public bool LoveOrNot { get; set; }

        public int LoveCount { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        [ScriptIgnore]
        public IList<PraiseUser> PraiseList { get; set; }

        [NotMapped]
        public bool IsMyPraised { get; set; }
    }
}
