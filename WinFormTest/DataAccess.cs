using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToFCamera.Wrapper;

namespace WinFormTest
{
    class DataAccess
    {
        public const int TFL_FRAME_SIZE = 640 * 480;
        public TFL_RESULT result;
        public PeopleDetector pplDtc;
        public ushort[] initDepth_buf;
        public string initDepth_fileName;
        public string Depth_fileName;
        public ushort[] Depth_buf;
        public ushort cameraAngle;
        public List<TFL_PointXYZ> groundCloud;
        public ushort maxNumPeople;
        public UIntPtr humanNum;

        public DataAccess()
        {
            pplDtc = null;
            initDepth_buf = null;
            Depth_buf = null;
            groundCloud = null;
        }

        public void ReadRaw(string fileName, ushort[] depthBuf)
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
    }
}
