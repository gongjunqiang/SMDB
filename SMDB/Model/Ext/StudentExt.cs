using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.ModelAttribute;

namespace Model
{
    public class StudentExt:Students
    {
        [ExtendProperty]
        public string ClassName { get; set; }
        [ExtendProperty]
        public int CSharp { get; set; }
        [ExtendProperty]
        public int SQLServerDB { get; set; }
        [ExtendProperty]
        public DateTime DTime { get; set; }

    }
}
