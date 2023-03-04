using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToManyLesson
{
    internal class word
    {
        public int id { get; set; }
        public string name { get; set; }
        public int matrix_id { get; set; }
        public matrix matrix { get; set; }
    }
}
