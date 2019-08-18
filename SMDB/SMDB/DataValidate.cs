using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SMDB
{
    /// <summary>
    /// 基于正则表达式的数据验证
    /// </summary>
    public class DataValidate
    {
        /// <summary>
        /// 验证非零的正整数
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsInteger(string txt)
        {
            Regex regex = new Regex(@"^[1-9]\d*$");
            if (regex.IsMatch(txt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
