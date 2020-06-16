using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToFCamera.Wrapper;

namespace CheckGround
{
    class CheckGround
    {
        public const int TFL_FRAME_SIZE = 640 * 480;

        static void ReadRaw(string fileName, ushort[] depthBuf)
        {
            int cnt1 = 0;
            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    do
                    {
                        depthBuf[cnt1] = reader.ReadUInt16();
                        cnt1++;
                    } while (reader.BaseStream.Position < reader.BaseStream.Length);
                }
            }
        }

        static void GndCheck(PeopleDetector pplDtc, string initDepth_fileName, ushort cameraAngle, string gndFileName)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("cameraAngle = " + cameraAngle + " " + gndFileName);
            ushort[] initDepth_buf = new ushort[TFL_FRAME_SIZE];
            ReadRaw(initDepth_fileName, initDepth_buf);
            TFL_RESULT result;
            // Init
            result = pplDtc.Initialize(initDepth_buf, cameraAngle);
            Console.WriteLine("Initialize result = " + result);
            if(result == TFL_RESULT.TFL_DETECT_GROUND_ERR)
            {
                return;
            }
            // Get ground
            var groundCloud = new List<TFL_PointXYZ>();
            result = pplDtc.GetGroundCloud(groundCloud);
            Console.WriteLine("GetGroundCloud result = " + result);
            // Save ground
            result = TFL_Utilities.SavePLY(groundCloud.ToArray(), (ulong)groundCloud.Count(), gndFileName);
            Console.WriteLine("Save gnd result = " + result);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("CheckGround!");
            PeopleDetector pplDtc = new PeopleDetector();
            string initDepth_fileName;
            initDepth_fileName = @"C:\Users\tlong\source\repos\HumanDetectCombineTst\TOFHumanDetectDatabase\RAW\Ground\0v1_0_0.raw";
            GndCheck(pplDtc, initDepth_fileName, 5, "ground_0v1_5.ply");
            GndCheck(pplDtc, initDepth_fileName, 10, "ground_0v1_10.ply");
            initDepth_fileName = @"C:\Users\tlong\source\repos\HumanDetectCombineTst\TOFHumanDetectDatabase\RAW\Ground\0_0_0.raw";
            GndCheck(pplDtc, initDepth_fileName, 5, "ground_0_5.ply");
            GndCheck(pplDtc, initDepth_fileName, 10, "ground_0_10.ply");
            initDepth_fileName = @"C:\Users\tlong\source\repos\HumanDetectCombineTst\TOFHumanDetectDatabase\RAW\Ground\30_0_0.raw";
            GndCheck(pplDtc, initDepth_fileName, 25, "ground_30_25.ply");
            GndCheck(pplDtc, initDepth_fileName, 35, "ground_30_35.ply");
            GndCheck(pplDtc, initDepth_fileName, 20, "ground_30_20.ply");
            GndCheck(pplDtc, initDepth_fileName, 40, "ground_30_40.ply");
            initDepth_fileName = @"C:\Users\tlong\source\repos\HumanDetectCombineTst\TOFHumanDetectDatabase\RAW\Ground\60_0_0.raw";
            GndCheck(pplDtc, initDepth_fileName, 55, "ground_60_55.ply");
            GndCheck(pplDtc, initDepth_fileName, 65, "ground_60_65.ply");
            GndCheck(pplDtc, initDepth_fileName, 50, "ground_60_50.ply");
            GndCheck(pplDtc, initDepth_fileName, 70, "ground_60_70.ply");
            initDepth_fileName = @"C:\Users\tlong\source\repos\HumanDetectCombineTst\TOFHumanDetectDatabase\RAW\Ground\90_0_0.raw";
            GndCheck(pplDtc, initDepth_fileName, 85, "ground_90_85.ply");
            GndCheck(pplDtc, initDepth_fileName, 80, "ground_90_80.ply");
        }
    }
}
