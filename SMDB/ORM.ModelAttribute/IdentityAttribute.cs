using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.ModelAttribute
{
    /// <summary>
    /// 标识列特性
    /// </summary>
    public class IdentityAttribute: Attribute
    {
        public bool IsIdentity { get; } = true;
    }
}
