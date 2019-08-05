using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 成绩表实体类
    /// </summary>
    [Serializable]
    public class ScoreList
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CSharp { get; set; }
        public int SQLServerDB { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
