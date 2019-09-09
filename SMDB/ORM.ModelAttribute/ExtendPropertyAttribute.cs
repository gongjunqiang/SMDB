using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.ModelAttribute
{
    /// <summary>
    /// 扩展属性特性
    /// </summary>
    public class ExtendPropertyAttribute:Attribute
    {
        public bool IsExtend { get; } = true;
    }
}
