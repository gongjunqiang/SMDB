using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.ModelAttribute
{
    /// <summary>
    /// 主键特性
    /// </summary>
    public class PrimaryKeyAttribute: Attribute
    {
        public bool IsPKey { get; } = true;
    }
}
