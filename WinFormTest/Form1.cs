using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToFCamera.Wrapper;

namespace WinFormTest
{
    public partial class Form1 : Form
    {
        DataAccess data;
        public const int TFL_FRAME_SIZE = 640 * 480;

        void InitPtb(PictureBox ptb, Color c)
        {
            ptb.Image = new Bitmap(ptb.Width, ptb.Height);
            for(int w = 0; w < ptb.Width; w++)
            {
                for(int h = 0; h < ptb.Height; h++)
                {
                    ((Bitmap)ptb.Image).SetPixel(w, h, c);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            txtSetCameraAngle.Text = "0";
            txtMaxPeople.Text = "5";
            txtNumPeople.Text = "-1";
            InitPtb(ptbRedPerson, Color.FromArgb(255, 0, 0));
            InitPtb(ptbGreenPerson, Color.FromArgb(0, 255, 0));
            InitPtb(ptbBluePerson, Color.FromArgb(0, 0, 255));
            InitPtb(ptbGrayPerson, Color.FromArgb(125, 125, 125));
            InitPtb(ptbWhitePerson, Color.FromArgb(255, 255, 255));
            data = new DataAccess();
        }

        private void ClearRstGnd()
        {
            txtRstGetGND.Text = "";
            txtRstInit.Text = "";
            txtGndFileName.Text = "";
        }

        private void btnSearchGndRaw_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\Users\tlong\source\repos\HumanDetectCombineTst\TOFHumanDetectDatabase\RAW\Ground",
                Title = "Browse RAW Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "RAW",
                Filter = "RAW files (*.RAW)|*.RAW",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRawGndFileName.Text = System.IO.Path.GetFileName(openFileDialog1.FileName);
                data.initDepth_fileName = openFileDialog1.FileName.ToString();
                data.ReadRaw(data.initDepth_fileName, data.initDepth_buf);
                string tiffFilePath = @"C:\Users\tlong\source\repos\HumanDetectCombineTst\TOFHumanDetectDatabase\TIFF\"
                    + txtRawGndFileName.Text.Substring(0, txtRawGndFileName.Text.IndexOf(".raw")) + " (2).tiff";
                ptbGnd.Image = Image.FromFile(tiffFilePath);
                ptbGnd.SizeMode = PictureBoxSizeMode.StretchImage;

                ClearRstGnd();
            }
            else
            {
                data.initDepth_buf = null;
            }
        }

        private void btnSetCameraAngle_Click(object sender, EventArgs e)
        {
            data.cameraAngle = UInt16.Parse(txtSetCameraAngle.Text);
            ClearRstGnd();
        }

        private void btnRunInit_Click(object sender, EventArgs e)
        {
            data.cameraAngle = UInt16.Parse(txtSetCameraAngle.Text);
            data.result = data.pplDtc.Initialize(data.initDepth_buf, data.cameraAngle);
            txtRstInit.Text = data.result.ToString(); 
        }

        private void btnGetGND_Click(object sender, EventArgs e)
        {
            data.result = data.pplDtc.GetGroundCloud(data.groundCloud);
            txtRstGetGND.Text = data.result.ToString();
        }

        private void btnSaveGND_Click(object sender, EventArgs e)
        {
            if (data.result == TFL_RESULT.TFL_OK)
            {
                string gndFileName = "ground_" + txtRawGndFileName.Text.Substring(0, txtRawGndFileName.Text.IndexOf(".raw")) + ".ply";
                data.result = TFL_Utilities.SavePLY(data.groundCloud.ToArray(), (ulong)data.groundCloud.Count(), gndFileName);
                txtGndFileName.Text = gndFileName;
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            data.maxNumPeople = UInt16.Parse(txtMaxPeople.Text);
            data.result = data.pplDtc.Execute(data.Depth_buf, data.maxNumPeople);
            txtRstExecute.Text = data.result.ToString();
        }

        private void btnOpenPeopleRaw_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\Users\tlong\source\repos\HumanDetectCombineTst\TOFHumanDetectDatabase\RAW",
                Title = "Browse RAW Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "RAW",
                Filter = "RAW files (*.RAW)|*.RAW",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPeopleRawFileName.Text = System.IO.Path.GetFileName(openFileDialog1.FileName);
                data.Depth_fileName = openFileDialog1.FileName.ToString();
                data.ReadRaw(data.Depth_fileName, data.Depth_buf);
                string tiffFilePath = @"C:\Users\tlong\source\repos\HumanDetectCombineTst\TOFHumanDetectDatabase\TIFF\"
                    + txtPeopleRawFileName.Text.Substring(0, txtPeopleRawFileName.Text.IndexOf(".raw")) + " (2).tiff";
                ptbPeople.Image = Image.FromFile(tiffFilePath);
                ptbPeople.SizeMode = PictureBoxSizeMode.StretchImage;

                txtRstExecute.Text = "";
                txtNumPeople.Text = "";

                txtRedHeight.Text = "";
                txtGreenHeight.Text = "";
                txtBlueHeight.Text = "";
                txtGrayHeight.Text = "";
                txtWhiteHeight.Text = "";
            }
        }

        private void btnSetMaxNumPeople_Click(object sender, EventArgs e)
        {
            data.maxNumPeople = UInt16.Parse(txtMaxPeople.Text);
        }

        private void btnGetNumPeople_Click(object sender, EventArgs e)
        {
            data.result = data.pplDtc.GetHumanNum(out data.humanNum);
            txtNumPeople.Text = data.humanNum.ToString();
            // Get Human Data
            TFL_Human ppl = new TFL_Human();
            string pplFileName = "people_";
            for (uint i = 0; i < data.humanNum.ToUInt32(); i++)
            {
                data.result = data.pplDtc.GetHumanData(i, out ppl);
                data.result = TFL_Utilities.SavePLY(ppl.peoplePointCloud.ToArray(), (ulong)ppl.peoplePointCloud.Count(),
                    pplFileName + i + ".ply");
            }
        }

        private void btnShowDetectedPeople_Click(object sender, EventArgs e)
        {
            if(txtRstExecute.Text == TFL_RESULT.TFL_OK.ToString())
            {
                Image img = new Bitmap(640, 480);
                //ptbDetectedPeople.Image = new Bitmap(640, 480);
                Color c = Color.FromArgb(0, 0, 0);
                for (int w = 0; w < 640; w++)
                {
                    for(int h = 0; h < 480; h++)
                    {
                        ((Bitmap)img).SetPixel(w, h, c);
                    }
                }
                // Get Human Data
                TFL_Human ppl = new TFL_Human();
                string pplFileName = "people_";
                data.result = data.pplDtc.GetHumanNum(out data.humanNum);
                for (uint i = 0; i < data.humanNum.ToUInt32(); i++)
                {
                    data.result = data.pplDtc.GetHumanData(i, out ppl);
                    data.result = TFL_Utilities.SavePLY(ppl.peoplePointCloud.ToArray(), (ulong)ppl.peoplePointCloud.Count(),
                    pplFileName + i + ".ply");
                    if (i == 0)
                    {
                        c = Color.FromArgb(255, 0, 0);
                        txtRedHeight.Text = ppl.height.ToString();
                    }
                    else if (i == 1)
                    {
                        c = Color.FromArgb(0, 255, 0);
                        txtGreenHeight.Text = ppl.height.ToString();
                    }
                    else if (i == 2)
                    {
                        c = Color.FromArgb(0, 0, 255);
                        txtBlueHeight.Text = ppl.height.ToString();
                    }
                    else if (i == 3)
                    {
                        c = Color.FromArgb(125, 125, 125);
                        txtGrayHeight.Text = ppl.height.ToString();
                    }
                    else
                    {
                        c = Color.FromArgb(255, 255, 255);
                        txtWhiteHeight.Text = ppl.height.ToString();
                    }
                    for (int cnt = 0; cnt < ppl.peoplePointCloud.Count(); cnt++)
                    {
                        double pixel_x = (2.16 * ppl.peoplePointCloud[cnt].x) / (0.0056 * ppl.peoplePointCloud[cnt].z) + 320;
                        double pixel_y = (2.16 * -ppl.peoplePointCloud[cnt].y) / (0.0056 * ppl.peoplePointCloud[cnt].z) + 240;
                        ((Bitmap)img).SetPixel((int)pixel_x, (int)pixel_y, c);
                    }
                    ptbDetectedPeople.Image = img;
                    ptbDetectedPeople.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void btnGroundNull_Click(object sender, EventArgs e)
        {
            data.initDepth_buf = null;
            txtRawGndFileName.Text = "null";
        }

        private void btnPeopleNULL_Click(object sender, EventArgs e)
        {
            data.Depth_buf = null;
            txtPeopleRawFileName.Text = "null";
        }

        private void btnNewDetector_Click(object sender, EventArgs e)
        {
            data.pplDtc = new PeopleDetector();
            data.initDepth_buf = new ushort[TFL_FRAME_SIZE];
            data.Depth_buf = new ushort[TFL_FRAME_SIZE];
            data.groundCloud = new List<TFL_PointXYZ>();
            MessageBox.Show("New Detector created successfully");
        }
    }
}
