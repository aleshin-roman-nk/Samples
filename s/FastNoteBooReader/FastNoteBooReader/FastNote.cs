using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNoteBooReader
{
    public class FastNote
    {
        [Key]
        public int _id { get; set; }
        public string theme { get; set; }
        public string content_note { get; set; }
        public string color { get; set; }
        public long date_sort { get; set; }
        public string date_time { get; set; }
    }
}
