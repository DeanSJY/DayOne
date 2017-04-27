using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne.Entities
{
    public class OneNote
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public Boolean LoveOrNot { get; set; }

        public int BookId { get; set; }
        public Boolean IsDeleted { get; set; }
        public int LoveCount { get; set; }
       

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
