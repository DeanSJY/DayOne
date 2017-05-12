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
    [Table("OneNotes")]
    public class OneNote : ShareInfo
    {
        [NotMapped]
        public int NoteId
        {
            get { return Id; }
            set { Id = value; }
        }

        public string Title { get; set; }

        public string Content { get; set; }


        public int BookId { get; set; }

        [ForeignKey("BookId"), ScriptIgnore]
        public virtual NoteBook Book { get; set; }

        public Boolean IsDeleted { get; set; }


        public bool WithAttach { get; set; }

        public string KeyWords { get; set; }

        //[ForeignKey("NoteId"), ScriptIgnore]
        //public ShareInfo ShareInfo { get; set; }
    }
}
