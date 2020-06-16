using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ToFCamera.Wrapper;
using System.Drawing;
using System.Runtime.InteropServices;
//Today(2020 year) it's nuGet package System.Drawing.Common.dll. To add it: right click on project name (at solution explorer) --> "Manage NuGet packages" --> choose "Browse" label at the top --> search for "System.Drawing.Common" --> install it.


namespace RunAllExcel
{
    class RunAllExcel
    {
        public const int TFL_FRAME_SIZE = 640 * 480;
        public const int ID_COL = 1;
        public const int RAW_DATA_COL = 2;
        public const int CAMERA_ANGLE_IN_COL = 3;
        public const int INIT_RST_COL = 4;
        public const int GET_GND_RST_COL = 5;
        public const int SAVE_GND_RST_COL = 6;
        public const int GET_CAM_ANGLE_COL = 7;
        public const int EXE_RST_COL = 8;
        public const int EXE_RUNTIME_COL = 9;
        public const int DTC_HUMAN_NUM_COL = 10;
        public const int REAL_PEO_NUM_COL = 11;
        public const int TIFF_COL = 12;
        public const int GND_COL = 13;
        public const int PEO_COL = 14;

        public const string GND_RAW_DIR = @"C:\Users\tlong\source\repos\HumanDetectCombineTst\TOFHumanDetectDatabase\RAW\Ground\";
        public const string GND_PLY_DIR = @"C:\Users\tlong\source\repos\HumanDetectCombineTst\RunAllExcel\GND_PLY\";
        public const string PEOPLE_RAW_DIR_0 = @"C:\Users\tlong\source\repos\HumanDetectCombineTst\TOFHumanDetectDatabase\RAW\Human_0\";
        public const string PEOPLE_RAW_DIR_0v1 = @"C:\Users\tlong\source\repos\HumanDetectCombineTst\TOFHumanDetectDatabase\RAW\Human_0v1\";
        public const string PEOPLE_RAW_DIR_30 = @"C:\Users\tlong\source\repos\HumanDetectCombineTst\TOFHumanDetectDatabase\RAW\Human_30\";
        public const string PEOPLE_RAW_DIR_60 = @"C:\Users\tlong\source\repos\HumanDetectCombineTst\TOFHumanDetectDatabase\RAW\Human_60\";
        public const string PEOPLE_RAW_DIR_90 = @"C:\Users\tlong\source\repos\HumanDetectCombineTst\TOFHumanDetectDatabase\RAW\Human_90\";
        public const string PEOPLE_PLY_DIR = @"C:\Users\tlong\source\repos\HumanDetectCombineTst\RunAllExcel\PEO_PLY\";
        public const string LOG_PATH = @"C:\Users\tlong\source\repos\HumanDetectCombineTst\RunAllExcel\log.txt";
        public const string XLS_PATH = @"C:\Users\tlong\source\repos\HumanDetectCombineTst\RunAllExcel\xls\RunAllExcel.xls";
        public const string TMP_BMP_PATH = @"C:\Users\tlong\source\repos\HumanDetectCombineTst\RunAllExcel\tmp\tmp.bmp";
        public const int MAX_DTC_NUM = 5;

        public static List<int> runTimeAngle0People0 = new List<int>();
        public static List<int> runTimeAngle0People1 = new List<int>();
        public static List<int> runTimeAngle0People2 = new List<int>();
        public static List<int> runTimeAngle0People3 = new List<int>();
        public static List<int> runTimeAngle0People4 = new List<int>();
        public static List<int> runTimeAngle30People0 = new List<int>();
        public static List<int> runTimeAngle30People1 = new List<int>();
        public static List<int> runTimeAngle30People2 = new List<int>();
        public static List<int> runTimeAngle30People3 = new List<int>();
        public static List<int> runTimeAngle30People4 = new List<int>();
        public static List<int> runTimeAngle60People0 = new List<int>();
        public static List<int> runTimeAngle60People1 = new List<int>();
        public static List<int> runTimeAngle60People2 = new List<int>();
        public static List<int> runTimeAngle60People3 = new List<int>();
        public static List<int> runTimeAngle60People4 = new List<int>();
        public static List<int> runTimeAngle90People0 = new List<int>();
        public static List<int> runTimeAngle90People1 = new List<int>();
        public static List<int> runTimeAngle90People2 = new List<int>();
        public static List<int> runTimeAngle90People3 = new List<int>();
        public static List<int> runTimeAngle90People4 = new List<int>();

        public static void RAW2PCD(string fileName, ushort[] pcdBuf)
        {
            Console.WriteLine("Convert RAW to PCD");
            int cnt1 = 0;
            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    do
                    {
                        pcdBuf[cnt1] = reader.ReadUInt16();
                        cnt1++;
                    } while (reader.BaseStream.Position < reader.BaseStream.Length);
                }
            }
            else
            {
                Console.WriteLine("RAW NOT FOUND");
                Console.WriteLine(fileName);
            }
        }

        public static void InsertPicture(Excel.Worksheet xlWorkSheet, int row, int col, string fileName)
        {
            Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[row, col];
            float Left = (float)((double)oRange.Left);
            float Top = (float)((double)oRange.Top);
            oRange.RowHeight = 125;
            oRange.ColumnWidth = 30;
            string filePath = @"C:\Users\tlong\source\repos\HumanDetectCombineTst\TOFHumanDetectDatabase\TIFF\" + fileName;
            try
            {
                xlWorkSheet.Shapes.AddPicture(filePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, 160, 120);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static Bitmap createBitmapPanel(int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            Color c = Color.FromArgb(0, 0, 0);
            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    bmp.SetPixel(w, h, c);
                }
            }
            return bmp;
        }

        public static void InsertPicture(Excel.Worksheet xlWorkSheet, int row, int col, List<TFL_PointXYZ> points)
        {
            Color c = Color.FromArgb(255, 255, 0); // yellow
            Bitmap bmp = createBitmapPanel(640, 480);
            for (int i = 0; i < points.Count(); i++)
            {
                double pixel_x = (2.16 * points[i].x) / (0.0056 * points[i].z) + 320;
                double pixel_y = (2.16 * -points[i].y) / (0.0056 * points[i].z) + 240;
                bmp.SetPixel((int)pixel_x, (int)pixel_y, c);
            }
            bmp = new Bitmap(bmp, new Size(160, 120));
            bmp.Save(TMP_BMP_PATH);

            Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[row, col];
            float Left = (float)((double)oRange.Left);
            float Top = (float)((double)oRange.Top);
            oRange.RowHeight = 125;
            oRange.ColumnWidth = 30;
            xlWorkSheet.Shapes.AddPicture(TMP_BMP_PATH, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, 160, 120);
        }

        public static void InsertPicture(Excel.Worksheet xlWorkSheet, int row, int col, PeopleDetector peoDtc)
        {
            Bitmap bmp = createBitmapPanel(640, 480);
            Color c = Color.FromArgb(255, 255, 0); // yellow
            // Get Human Data
            TFL_Human ppl = new TFL_Human();
            UIntPtr humanNum;
            TFL_RESULT result = peoDtc.GetHumanNum(out humanNum);
            for (uint i = 0; i < humanNum.ToUInt32(); i++)
            {
                result = peoDtc.GetHumanData(i, out ppl);
                if (i == 0)
                {
                    c = Color.FromArgb(255, 0, 0); // red
                }
                else if (i == 1)
                {
                    c = Color.FromArgb(0, 255, 0); // green
                }
                else if (i == 2)
                {
                    c = Color.FromArgb(0, 0, 255); // blue
                }
                else if (i == 3)
                {
                    c = Color.FromArgb(125, 125, 125); // gray
                }
                else
                {
                    c = Color.FromArgb(255, 255, 255); // white
                }
                for (int cnt = 0; cnt < ppl.peoplePointCloud.Count(); cnt++)
                {
                    double pixel_x = (2.16 * ppl.peoplePointCloud[cnt].x) / (0.0056 * ppl.peoplePointCloud[cnt].z) + 320;
                    double pixel_y = (2.16 * -ppl.peoplePointCloud[cnt].y) / (0.0056 * ppl.peoplePointCloud[cnt].z) + 240;
                    bmp.SetPixel((int)pixel_x, (int)pixel_y, c);
                }
            }
            bmp = new Bitmap(bmp, new Size(160, 120));
            bmp.Save(TMP_BMP_PATH);

            Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[row, col];
            float Left = (float)((double)oRange.Left);
            float Top = (float)((double)oRange.Top);
            oRange.RowHeight = 125;
            oRange.ColumnWidth = 30;
            xlWorkSheet.Shapes.AddPicture(TMP_BMP_PATH, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, 160, 120);
        }

        public static void InsertText(Excel.Worksheet xlWorkSheet, int row, int col, string text)
        {
            xlWorkSheet.Cells[row, col] = text;
        }

        public static string GetTiffFileName(string rawFileName)
        {
            string fiffFileName = rawFileName.Substring(0, rawFileName.IndexOf(".raw")) + " (2).tiff";
            return fiffFileName;
        }

        public static long averageRunTime(List<int> lst)
        {
            if (lst.Count() == 0) return 0;
            long t = 0;
            for (int i = 0; i < lst.Count(); i++)
            {
                t = t + lst[i];
            }
            t = t / lst.Count();
            return t;
        }

        public static void InitRun(Excel.Worksheet xlWorkSheet, int row, PeopleDetector peoDtc, string gndRawFileName, ushort cameraAngle)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine(gndRawFileName);
            ushort[] depthBufInit = new ushort[TFL_FRAME_SIZE];
            RAW2PCD(GND_RAW_DIR + gndRawFileName, depthBufInit);

            Console.WriteLine("Run Initialize");
            TFL_RESULT rstInit = peoDtc.Initialize(depthBufInit, cameraAngle);
            Console.WriteLine(rstInit);

            var gnd = new List<TFL_PointXYZ>();
            Console.WriteLine("Run GetGroundCloud");
            TFL_RESULT rstGetGnd = peoDtc.GetGroundCloud(gnd);
            Console.WriteLine(rstGetGnd);

            string gndPLYFile = gndRawFileName.Substring(0, gndRawFileName.IndexOf(".raw")) + ".ply";
            Console.WriteLine("Save ground as " + gndPLYFile);
            TFL_RESULT rstSaveGnd = TFL_Utilities.SavePLY(gnd.ToArray(), (ulong)gnd.Count(), GND_PLY_DIR + gndPLYFile);
            Console.WriteLine(rstSaveGnd);

            ushort camAngle = 0;
            Console.WriteLine("Run GetCameraAngle");
            TFL_RESULT rstGetCamAngle = peoDtc.GetCameraAngle(out camAngle);
            Console.WriteLine(rstGetCamAngle);

            Console.WriteLine("--------------------------------------");

            InsertText(xlWorkSheet, row, RAW_DATA_COL, gndRawFileName);
            InsertText(xlWorkSheet, row, CAMERA_ANGLE_IN_COL, cameraAngle.ToString());
            InsertText(xlWorkSheet, row, INIT_RST_COL, rstInit.ToString());
            InsertText(xlWorkSheet, row, GET_GND_RST_COL, rstGetGnd.ToString());
            InsertText(xlWorkSheet, row, SAVE_GND_RST_COL, rstSaveGnd.ToString());
            InsertText(xlWorkSheet, row, GET_CAM_ANGLE_COL, camAngle.ToString());
            InsertPicture(xlWorkSheet, row, TIFF_COL, GetTiffFileName(gndRawFileName));
            InsertPicture(xlWorkSheet, row, GND_COL, gnd);
        }

        public static void ExeRun(Excel.Worksheet xlWorkSheet, int row, PeopleDetector peoDtc, string peoleRawDir, string peoRawFileName, ushort maxDetectedNumber)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine(peoRawFileName);
            ushort[] depthBuf = new ushort[TFL_FRAME_SIZE];
            RAW2PCD(peoleRawDir + peoRawFileName, depthBuf);

            Console.WriteLine("Run Execute");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            TFL_RESULT rstExe = peoDtc.Execute(depthBuf, maxDetectedNumber);
            watch.Stop();
            int elapsedMs = (int)watch.ElapsedMilliseconds;
            Console.WriteLine("Execute time " + elapsedMs);
            Console.WriteLine(rstExe);

            UIntPtr humanNum;
            Console.WriteLine("Run GetHumanNum");
            TFL_RESULT rstGetHumanNum = peoDtc.GetHumanNum(out humanNum);
            Console.WriteLine(rstGetHumanNum);
            Console.WriteLine("Number of people detected: " + humanNum);

            TFL_Human person;
            TFL_RESULT rstGetHumanData;
            string peoPLYFile = peoRawFileName.Substring(0, peoRawFileName.IndexOf(".raw"));
            for (uint i = 0; i < humanNum.ToUInt32(); i++)
            {
                Console.WriteLine("Run GetHumanData " + i);
                rstGetHumanData = peoDtc.GetHumanData(i, out person);
                Console.WriteLine("Save person " + i + " as " + peoPLYFile + "_" + i + ".ply");

                TFL_RESULT rstSavePerson = TFL_Utilities.SavePLY(person.peoplePointCloud.ToArray(),
                    (ulong)person.peoplePointCloud.Count(),
                    PEOPLE_PLY_DIR + peoPLYFile + "_" + i + ".ply");
                Console.WriteLine(rstSavePerson);
            }
            // Save Execute runtime
            string t = peoRawFileName.Substring(peoRawFileName.IndexOf("_") + 1, 1);
            int realPplNum = int.Parse(t);
            switch (peoleRawDir)
            {
                case PEOPLE_RAW_DIR_0:
                case PEOPLE_RAW_DIR_0v1:
                    switch (realPplNum)
                    {
                        case 0:
                            runTimeAngle0People0.Add(elapsedMs);
                            break;
                        case 1:
                            runTimeAngle0People1.Add(elapsedMs);
                            break;
                        case 2:
                            runTimeAngle0People2.Add(elapsedMs);
                            break;
                        case 3:
                            runTimeAngle0People3.Add(elapsedMs);
                            break;
                        case 4:
                            runTimeAngle0People4.Add(elapsedMs);
                            break;
                        default:
                            break;
                    }
                    break;
                case PEOPLE_RAW_DIR_30:
                    switch (realPplNum)
                    {
                        case 0:
                            runTimeAngle30People0.Add(elapsedMs);
                            break;
                        case 1:
                            runTimeAngle30People1.Add(elapsedMs);
                            break;
                        case 2:
                            runTimeAngle30People2.Add(elapsedMs);
                            break;
                        case 3:
                            runTimeAngle30People3.Add(elapsedMs);
                            break;
                        case 4:
                            runTimeAngle30People4.Add(elapsedMs);
                            break;
                        default:
                            break;
                    }
                    break;
                case PEOPLE_RAW_DIR_60:
                    switch (realPplNum)
                    {
                        case 0:
                            runTimeAngle60People0.Add(elapsedMs);
                            break;
                        case 1:
                            runTimeAngle60People1.Add(elapsedMs);
                            break;
                        case 2:
                            runTimeAngle60People2.Add(elapsedMs);
                            break;
                        case 3:
                            runTimeAngle60People3.Add(elapsedMs);
                            break;
                        case 4:
                            runTimeAngle60People4.Add(elapsedMs);
                            break;
                        default:
                            break;
                    }
                    break;
                case PEOPLE_RAW_DIR_90:
                    switch (realPplNum)
                    {
                        case 0:
                            runTimeAngle90People0.Add(elapsedMs);
                            break;
                        case 1:
                            runTimeAngle90People1.Add(elapsedMs);
                            break;
                        case 2:
                            runTimeAngle90People2.Add(elapsedMs);
                            break;
                        case 3:
                            runTimeAngle90People3.Add(elapsedMs);
                            break;
                        case 4:
                            runTimeAngle90People4.Add(elapsedMs);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            Console.WriteLine("--------------------------------------");

            InsertText(xlWorkSheet, row, RAW_DATA_COL, peoRawFileName);
            InsertText(xlWorkSheet, row, EXE_RST_COL, rstExe.ToString());
            InsertText(xlWorkSheet, row, EXE_RUNTIME_COL, elapsedMs.ToString());
            InsertText(xlWorkSheet, row, DTC_HUMAN_NUM_COL, humanNum.ToString());
            InsertText(xlWorkSheet, row, REAL_PEO_NUM_COL, realPplNum.ToString());
            InsertPicture(xlWorkSheet, row, TIFF_COL, GetTiffFileName(peoRawFileName));
            InsertPicture(xlWorkSheet, row, PEO_COL, peoDtc);
        }

        public static void Scan(Excel.Worksheet xlWorkSheet, string peoleRawDir)
        {
            string[] peoRawfilePaths = Directory.GetFiles(peoleRawDir, "*.raw", SearchOption.TopDirectoryOnly);
            PeopleDetector peoDtc = new PeopleDetector();
            int row = 2;
            switch (peoleRawDir)
            {
                case PEOPLE_RAW_DIR_0:
                    InitRun(xlWorkSheet, row, peoDtc, "0_0_0.raw", 0);
                    row++;
                    break;
                case PEOPLE_RAW_DIR_0v1:
                    InitRun(xlWorkSheet, row, peoDtc, "0v1_0_0.raw", 0);
                    row++;
                    break;
                case PEOPLE_RAW_DIR_30:
                    InitRun(xlWorkSheet, row, peoDtc, "30_0_0.raw", 30);
                    row++;
                    break;
                case PEOPLE_RAW_DIR_60:
                    InitRun(xlWorkSheet, row, peoDtc, "60_0_0.raw", 60);
                    row++;
                    break;
                case PEOPLE_RAW_DIR_90:
                    InitRun(xlWorkSheet, row, peoDtc, "90_0_0.raw", 90);
                    row++;
                    break;
                default:
                    break;
            }
            for (int i = 0; i < peoRawfilePaths.Count(); i++)
            {
                string peoRawFileName = Path.GetFileName(peoRawfilePaths[i]);
                ExeRun(xlWorkSheet, row, peoDtc, peoleRawDir, peoRawFileName, MAX_DTC_NUM);
                row++;
            }
        }

        public static void WriteWorkSheet(Excel.Worksheet xlWorkSheet)
        {
            xlWorkSheet.Cells[1, ID_COL] = "ID";
            xlWorkSheet.Cells[1, RAW_DATA_COL] = "RAW Data";
            xlWorkSheet.Cells[1, CAMERA_ANGLE_IN_COL] = "Camera Angle";
            xlWorkSheet.Cells[1, INIT_RST_COL] = "Initial Result";
            xlWorkSheet.Cells[1, GET_GND_RST_COL] = "GetGroundData Result";
            xlWorkSheet.Cells[1, SAVE_GND_RST_COL] = "SaveGround Result";
            xlWorkSheet.Cells[1, GET_CAM_ANGLE_COL] = "GetCameraAngle";
            xlWorkSheet.Cells[1, TIFF_COL] = "TIFF IMAGE                                  ";
            xlWorkSheet.Cells[1, GND_COL] = "GROUND IMAGE                                 ";
            xlWorkSheet.Cells[1, EXE_RST_COL] = "Execute Result";
            xlWorkSheet.Cells[1, EXE_RUNTIME_COL] = "Execute Runtime (ms)";
            xlWorkSheet.Cells[1, REAL_PEO_NUM_COL] = "Number of People In Real";
            xlWorkSheet.Cells[1, DTC_HUMAN_NUM_COL] = "Number of People Detected";
            xlWorkSheet.Cells[1, PEO_COL] = "DETECTED PEOPLE IMAGE                        ";
        }

        public static void WriteAvgRuntime(Excel.Worksheet xlWorksheet)
        {
            xlWorksheet.Cells[1, 1] = "0 degree";
            xlWorksheet.Cells[2, 1] = "0 people"; xlWorksheet.Cells[2, 2] = averageRunTime(runTimeAngle0People0);
            xlWorksheet.Cells[3, 1] = "1 people"; xlWorksheet.Cells[3, 2] = averageRunTime(runTimeAngle0People1);
            xlWorksheet.Cells[4, 1] = "2 people"; xlWorksheet.Cells[4, 2] = averageRunTime(runTimeAngle0People2);
            xlWorksheet.Cells[5, 1] = "3 people"; xlWorksheet.Cells[5, 2] = averageRunTime(runTimeAngle0People3);
            xlWorksheet.Cells[6, 1] = "4 people"; xlWorksheet.Cells[6, 2] = averageRunTime(runTimeAngle0People4);

            xlWorksheet.Cells[7, 1] = "30 degree";
            xlWorksheet.Cells[8, 1] = "0 people"; xlWorksheet.Cells[8, 2] = averageRunTime(runTimeAngle30People0);
            xlWorksheet.Cells[9, 1] = "1 people"; xlWorksheet.Cells[9, 2] = averageRunTime(runTimeAngle30People1);
            xlWorksheet.Cells[10, 1] = "2 people"; xlWorksheet.Cells[10, 2] = averageRunTime(runTimeAngle30People2);
            xlWorksheet.Cells[11, 1] = "3 people"; xlWorksheet.Cells[11, 2] = averageRunTime(runTimeAngle30People3);
            xlWorksheet.Cells[12, 1] = "4 people"; xlWorksheet.Cells[12, 2] = averageRunTime(runTimeAngle30People4);

            xlWorksheet.Cells[13, 1] = "60 degree";
            xlWorksheet.Cells[14, 1] = "0 people"; xlWorksheet.Cells[14, 2] = averageRunTime(runTimeAngle60People0);
            xlWorksheet.Cells[15, 1] = "1 people"; xlWorksheet.Cells[15, 2] = averageRunTime(runTimeAngle60People1);
            xlWorksheet.Cells[16, 1] = "2 people"; xlWorksheet.Cells[16, 2] = averageRunTime(runTimeAngle60People2);
            xlWorksheet.Cells[17, 1] = "3 people"; xlWorksheet.Cells[17, 2] = averageRunTime(runTimeAngle60People3);
            xlWorksheet.Cells[18, 1] = "4 people"; xlWorksheet.Cells[18, 2] = averageRunTime(runTimeAngle60People4);

            xlWorksheet.Cells[19, 1] = "90 degree";
            xlWorksheet.Cells[20, 1] = "0 people"; xlWorksheet.Cells[20, 2] = averageRunTime(runTimeAngle90People0);
            xlWorksheet.Cells[21, 1] = "1 people"; xlWorksheet.Cells[21, 2] = averageRunTime(runTimeAngle90People1);
            xlWorksheet.Cells[22, 1] = "2 people"; xlWorksheet.Cells[22, 2] = averageRunTime(runTimeAngle90People2);
            xlWorksheet.Cells[23, 1] = "3 people"; xlWorksheet.Cells[23, 2] = averageRunTime(runTimeAngle90People3);
            xlWorksheet.Cells[24, 1] = "4 people"; xlWorksheet.Cells[24, 2] = averageRunTime(runTimeAngle90People4);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("RunAllExcel!");

            // Check Excel properly installed
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                Console.WriteLine("Excel is not properly installed!!");
                return;
            }

            // Create workbook and worksheet
            Excel.Workbook xlWorkBook;
            object misValue = System.Reflection.Missing.Value;
            xlWorkBook = xlApp.Workbooks.Add(misValue);

            var xlSheets = xlWorkBook.Sheets as Excel.Sheets;
            var xlWorkSheet1 = (Excel.Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);
            xlWorkSheet1.Name = "0v1";
            var xlWorkSheet2 = (Excel.Worksheet)xlSheets.Add(xlSheets[2], Type.Missing, Type.Missing, Type.Missing);
            xlWorkSheet2.Name = "0";
            var xlWorkSheet3 = (Excel.Worksheet)xlSheets.Add(xlSheets[3], Type.Missing, Type.Missing, Type.Missing);
            xlWorkSheet3.Name = "30";
            var xlWorkSheet4 = (Excel.Worksheet)xlSheets.Add(xlSheets[4], Type.Missing, Type.Missing, Type.Missing);
            xlWorkSheet4.Name = "60";
            var xlWorkSheet5 = (Excel.Worksheet)xlSheets.Add(xlSheets[5], Type.Missing, Type.Missing, Type.Missing);
            xlWorkSheet5.Name = "90";
            var xlWorkSheet6 = (Excel.Worksheet)xlSheets.Add(xlSheets[6], Type.Missing, Type.Missing, Type.Missing);
            xlWorkSheet6.Name = "Average Runtime";

            // Write to worksheet
            WriteWorkSheet(xlWorkSheet1);
            WriteWorkSheet(xlWorkSheet2);
            WriteWorkSheet(xlWorkSheet3);
            WriteWorkSheet(xlWorkSheet4);
            WriteWorkSheet(xlWorkSheet5);

            // Scan people raw folder
            Scan(xlWorkSheet1, PEOPLE_RAW_DIR_0v1);
            Scan(xlWorkSheet2, PEOPLE_RAW_DIR_0);
            Scan(xlWorkSheet3, PEOPLE_RAW_DIR_30);
            Scan(xlWorkSheet4, PEOPLE_RAW_DIR_60);
            Scan(xlWorkSheet5, PEOPLE_RAW_DIR_90);
            WriteAvgRuntime(xlWorkSheet6);

            // Save workbook
            xlWorkSheet1.Columns.AutoFit();
            xlWorkSheet2.Columns.AutoFit();
            xlWorkSheet3.Columns.AutoFit();
            xlWorkSheet4.Columns.AutoFit();
            xlWorkSheet5.Columns.AutoFit();
            xlWorkSheet6.Columns.AutoFit();
            xlWorkBook.SaveAs(XLS_PATH, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            // Realease objects
            Marshal.ReleaseComObject(xlWorkSheet1);
            Marshal.ReleaseComObject(xlWorkSheet2);
            Marshal.ReleaseComObject(xlWorkSheet3);
            Marshal.ReleaseComObject(xlWorkSheet4);
            Marshal.ReleaseComObject(xlWorkSheet5);
            Marshal.ReleaseComObject(xlWorkSheet6);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
        }
    }
}
