using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Model;


namespace SMDB
{
    /// <summary>
    /// 基于Excel模板打印学员信息
    /// </summary>
    public class PrintStudent
    {
        public void ExecPrint(StudentExt student)
        {
            //【1】定义一个Excel工作簿对象
            Application excelApp = new Application();
            //【2】获取已创建工作簿的路径
            string excelBookPath = Environment.CurrentDirectory + "\\StudentInfo.xls";
            //【3】将现有的工作簿加入以及定义的工作簿集合
            excelApp.Workbooks.Add(excelBookPath);
            //【4】获取第一个工作表
            Worksheet sheet = excelApp.Worksheets[0];
            //【5】将数据写入Excel
            //1.添加图片到指定位置
            if (student.StuImage.Length != 0)
            {

            }


        }


    }
}
