using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne.Entities
{
    public class PraiseUser
    {
        [Key]
        public long Id { get; set; }

        public int ShareId { get; set; }

        [ForeignKey("ShareId")]
        public ShareInfo ShareInfo { get; set; }

        public long UserId { get; set; }

        public DateTime LikeAt { get; set; }
    }
}
