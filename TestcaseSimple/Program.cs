//Tool1

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToFCamera.Wrapper;

namespace TestcaseSimple
{
    unsafe class Program
    {
        public const int TFL_FRAME_SIZE = 640 * 480;
        public static void RAW2PCD(string fileName, ushort[] pcdBuf)
        {
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

        // Human detection simplest test
        static void HumanDetectionFullFlow()
        {
            // Read raw
            ushort[] initDepth_buf = new ushort[TFL_FRAME_SIZE];
            ushort[] Depth_buf = new ushort[TFL_FRAME_SIZE];
            string initDepth_fileName = @"C:\Users\tlong\source\repos\HumanDetectCombineTst\TOFHumanDetectDatabase\RAW\Ground\90_0_0.raw";
            string Depth_fileName = @"C:\Users\tlong\source\repos\HumanDetectCombineTst\TOFHumanDetectDatabase\RAW\Human_90\90_4_1.raw";
            ReadRaw(initDepth_fileName, initDepth_buf);
            ReadRaw(Depth_fileName, Depth_buf);
            // Full Flow
            PeopleDetector pplDtc = new PeopleDetector();
            TFL_RESULT result;
            // Init
            result = pplDtc.Initialize(null, 90);
            Console.WriteLine("Initialize result = " + result);
            // Get ground
            var groundCloud = new List<TFL_PointXYZ>();
            result = pplDtc.GetGroundCloud(groundCloud);
            Console.WriteLine("GetGroundCloud result = " + result);
            // Save ground
            /*string gndFileName = "ground_90.ply";
            result = TFL_Utilities.SavePLY(groundCloud.ToArray(), (ulong)groundCloud.Count(), gndFileName);
            Console.WriteLine("Save gnd result = " + result);
            // Get Camera Angle
            ushort cameraAngle = 0;
            result = pplDtc.GetCameraAngle(out cameraAngle);
            Console.WriteLine("GetCameraAngle result = " + result + " cameraAngle = " + cameraAngle);
            // Execute*/
            result = pplDtc.Execute(Depth_buf, 0);
            Console.WriteLine("Execute result = " + result);
            // Get Human num
            UIntPtr humanNum;
            result = pplDtc.GetHumanNum(out humanNum);
            Console.WriteLine("GetHumanNum result = " + result + " humanNum = " + humanNum);
            // Get Human Data
            TFL_Human ppl = new TFL_Human();
            string pplFileName = "people_";
            for (uint i = 0; i < humanNum.ToUInt32(); i++)
            {
                result = pplDtc.GetHumanData(i, out ppl);
                Console.WriteLine("GetHumanData " + i + " result = " + result);
                result = TFL_Utilities.SavePLY(ppl.peoplePointCloud.ToArray(), (ulong)ppl.peoplePointCloud.Count(),
                    pplFileName + i + ".ply");
                Console.WriteLine("Save human " + i + " result = " + result);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("HumanDetectionFullFlow");
            HumanDetectionFullFlow();
        }
    }
}
