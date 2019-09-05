using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace SMDB
{
    public class DataExport
    {
        public static void Export(DataGridView dgv)
        {
            //定义excel操作对象
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            //定义Excel工作表
            Worksheet workSheet = excelApp.Workbooks.Add().Worksheets[1];

            //设置标题样式（第二行第二列开始）
                //设置标题名字
            workSheet.Cells[2,2] = "学生成绩表";
            workSheet.Cells[2, 2].RowHeight = 25;
            Range range = workSheet.get_Range("B2", "H2");
            range.Merge(0);//合并单元格
            range.Borders.Value = 1; //设置边框
            range.HorizontalAlignment = XlHAlign.xlHAlignCenter;//设置单元格居中
            range.Font.Size = 15;//设置字体大小；
            
            //获取总列数与总行数
            int columnCount = dgv.ColumnCount;
            int rowCount = dgv.RowCount;

            //显示列标题
            for (int i = 0; i < columnCount; i++)
            {
                //从第三行第二列开始
                workSheet.Cells[3, i + 2] = dgv.Columns[i].HeaderText;
                workSheet.Cells[3, i + 2].Borders.Value = 1; //设置边框
                workSheet.Cells[3, i + 2].RowHeight = 23;
                //workSheet.Cells[3, i + 2].ColumnWidth //设置宽度
            }


            //显示数据:从第四行第二列开始
            for (int i = 0; i < rowCount-1; i++)
            {
                //从第四行第二列开始
                for (int j = 0; j < columnCount; j++)
                {
                    //从第三行第二列开始
                    workSheet.Cells[i + 4, j + 2] = dgv.Rows[i].Cells[j].Value;
                    workSheet.Cells[i + 4, j + 2].Borders.Value = 1; //设置边框
                    workSheet.Cells[i + 4, j + 2].RowHeight = 23;
                }
            }
            //设置列宽和数据一直
            workSheet.Columns.AutoFit();
            //打印预览
            excelApp.Visible = true;
            excelApp.Sheets.PrintPreview();

            //释放资源
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            excelApp = null;
        }


    }
}
