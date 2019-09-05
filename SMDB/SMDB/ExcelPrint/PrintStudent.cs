using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using Model;

namespace SMDB
{
    /// <summary>
    /// 基于Excel模板打印学员信息
    /// </summary>
    public class PrintStudent
    {
        public static void ExecPrint(StudentExt student)
        {
            //【1】定义一个Excel工作簿对象
            Application excelApp = new Application();
            //【2】获取已创建工作簿的路径
            string excelBookPath = Environment.CurrentDirectory + "\\StudentInfo.xlsx";
            //【3】将现有的工作簿加入以及定义的工作簿集合
            excelApp.Workbooks.Add(excelBookPath);
            //【4】获取第一个工作表
            Worksheet sheet = excelApp.Worksheets[1];
            //【5】将数据写入Excel
            //1.添加图片到指定位置
            if (student.StuImage.Length != 0)
            {
                Image image = (Image)SerializeObjectToString.DeserializeObject(student.StuImage);
                string imagePath= Environment.CurrentDirectory + "\\StudentInfo.jpg";
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }
                else
                {
                    //保存图片到系统目录
                    image.Save(imagePath);
                    //将图片插入到excel中
                    sheet.Shapes.AddPicture(imagePath, MsoTriState.msoFalse, MsoTriState.msoCTrue, 10, 50, 90, 100);
                    File.Delete(imagePath);
                }
            }
            //2.写入其他数据
            sheet.Cells[4, 4] = student.StudentId;
            sheet.Cells[4, 6] = student.StudentName;
            sheet.Cells[4, 8] = student.Gender;
            sheet.Cells[6, 4] = student.ClassName;
            sheet.Cells[6, 6] = student.PhoneNumber;
            sheet.Cells[8, 4] = student.StudentAddress;

            //【6】打印预览
            excelApp.Visible = true;
            excelApp.Sheets.PrintPreview(true);

            //【7】释放对象
            excelApp.Quit();//退出;代表不用该程序
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);//释放资源;从内存中清理
            excelApp = null;
        }
    }
}
