using System;
using System.Runtime.InteropServices;
///using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel; //C:\Windows\assembly\GAC_MSIL\Microsoft.Office.Interop.Excel\15.0.0.0__71e9bce111e9429c\Microsoft.Office.Interop.Excel.dll

namespace WorkingWithExcel
{
    class WorkingWithExcel
    {
        static void Main(string[] args)
        {
            // Check Excel properly installed
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                //MessageBox.Show("Excel is not properly installed!!");
                return;
            }

            Console.WriteLine("Create workbook and worksheet!");
            // Create workbook and worksheet
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            Console.WriteLine("Write to worksheet!");
            // Write to worksheet
            xlWorkSheet.Cells[1, 1] = "ID";
            xlWorkSheet.Cells[1, 2] = "Name";
            xlWorkSheet.Cells[2, 1] = "1";
            xlWorkSheet.Cells[2, 2] = "One";
            xlWorkSheet.Cells[3, 1] = "2";
            xlWorkSheet.Cells[3, 2] = "Two";

            // Imsert picture
            Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[5, 5];
            float Left = (float)((double)oRange.Left);
            float Top = (float)((double)oRange.Top);
            oRange.RowHeight = 120;
            oRange.ColumnWidth = 30;
            xlWorkSheet.Shapes.AddPicture(@"C:\Users\tlong\source\repos\HumanDetectCombineTst\TOFHumanDetectDatabase\TIFF\0_1_1 (2).tiff", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left + 5, Top, 160, 120);
            

            Console.WriteLine("Save");
            // Save workbook
            xlWorkSheet.Columns.AutoFit();
            xlWorkBook.SaveAs(@"C:\Users\tlong\source\repos\HumanDetectCombineTst\WorkingWithExcel\xls\Csharp-Excel.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Console.WriteLine("Realease");
            // Realease objects
            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
            //MessageBox.Show("Excel file created , you can find the file d:\\csharp-Excel.xls");
        }
    }
}
