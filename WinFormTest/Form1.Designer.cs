namespace WinFormTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.simpleTestBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtWhiteHeight = new System.Windows.Forms.TextBox();
            this.txtGrayHeight = new System.Windows.Forms.TextBox();
            this.txtBlueHeight = new System.Windows.Forms.TextBox();
            this.txtGreenHeight = new System.Windows.Forms.TextBox();
            this.txtRedHeight = new System.Windows.Forms.TextBox();
            this.ptbWhitePerson = new System.Windows.Forms.PictureBox();
            this.ptbGrayPerson = new System.Windows.Forms.PictureBox();
            this.ptbBluePerson = new System.Windows.Forms.PictureBox();
            this.ptbGreenPerson = new System.Windows.Forms.PictureBox();
            this.ptbRedPerson = new System.Windows.Forms.PictureBox();
            this.btnGetNumPeople = new System.Windows.Forms.Button();
            this.txtNumPeople = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSetMaxNumPeople = new System.Windows.Forms.Button();
            this.txtMaxPeople = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOpenPeopleRaw = new System.Windows.Forms.Button();
            this.txtPeopleRawFileName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.txtRstExecute = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveGND = new System.Windows.Forms.Button();
            this.txtGndFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetGND = new System.Windows.Forms.Button();
            this.txtRstGetGND = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRunInit = new System.Windows.Forms.Button();
            this.txtRstInit = new System.Windows.Forms.TextBox();
            this.btnInit = new System.Windows.Forms.Label();
            this.btnSetCameraAngle = new System.Windows.Forms.Button();
            this.txtSetCameraAngle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchGndRaw = new System.Windows.Forms.Button();
            this.txtRawGndFileName = new System.Windows.Forms.TextBox();
            this.gndRawTxt = new System.Windows.Forms.Label();
            this.ptbGnd = new System.Windows.Forms.PictureBox();
            this.ptbPeople = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ptbDetectedPeople = new System.Windows.Forms.PictureBox();
            this.btnShowDetectedPeople = new System.Windows.Forms.Button();
            this.btnGroundNull = new System.Windows.Forms.Button();
            this.btnPeopleNULL = new System.Windows.Forms.Button();
            this.btnNewDetector = new System.Windows.Forms.Button();
            this.simpleTestBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbWhitePerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrayPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBluePerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbGreenPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRedPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbGnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPeople)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbDetectedPeople)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleTestBox
            // 
            this.simpleTestBox.Controls.Add(this.btnNewDetector);
            this.simpleTestBox.Controls.Add(this.btnPeopleNULL);
            this.simpleTestBox.Controls.Add(this.btnGroundNull);
            this.simpleTestBox.Controls.Add(this.groupBox1);
            this.simpleTestBox.Controls.Add(this.btnGetNumPeople);
            this.simpleTestBox.Controls.Add(this.txtNumPeople);
            this.simpleTestBox.Controls.Add(this.label7);
            this.simpleTestBox.Controls.Add(this.btnSetMaxNumPeople);
            this.simpleTestBox.Controls.Add(this.txtMaxPeople);
            this.simpleTestBox.Controls.Add(this.label6);
            this.simpleTestBox.Controls.Add(this.btnOpenPeopleRaw);
            this.simpleTestBox.Controls.Add(this.txtPeopleRawFileName);
            this.simpleTestBox.Controls.Add(this.label5);
            this.simpleTestBox.Controls.Add(this.btnExecute);
            this.simpleTestBox.Controls.Add(this.txtRstExecute);
            this.simpleTestBox.Controls.Add(this.label4);
            this.simpleTestBox.Controls.Add(this.btnSaveGND);
            this.simpleTestBox.Controls.Add(this.txtGndFileName);
            this.simpleTestBox.Controls.Add(this.label3);
            this.simpleTestBox.Controls.Add(this.btnGetGND);
            this.simpleTestBox.Controls.Add(this.txtRstGetGND);
            this.simpleTestBox.Controls.Add(this.label2);
            this.simpleTestBox.Controls.Add(this.btnRunInit);
            this.simpleTestBox.Controls.Add(this.txtRstInit);
            this.simpleTestBox.Controls.Add(this.btnInit);
            this.simpleTestBox.Controls.Add(this.btnSetCameraAngle);
            this.simpleTestBox.Controls.Add(this.txtSetCameraAngle);
            this.simpleTestBox.Controls.Add(this.label1);
            this.simpleTestBox.Controls.Add(this.btnSearchGndRaw);
            this.simpleTestBox.Controls.Add(this.txtRawGndFileName);
            this.simpleTestBox.Controls.Add(this.gndRawTxt);
            this.simpleTestBox.Location = new System.Drawing.Point(12, 12);
            this.simpleTestBox.Name = "simpleTestBox";
            this.simpleTestBox.Size = new System.Drawing.Size(582, 531);
            this.simpleTestBox.TabIndex = 0;
            this.simpleTestBox.TabStop = false;
            this.simpleTestBox.Text = "Control Board";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtWhiteHeight);
            this.groupBox1.Controls.Add(this.txtGrayHeight);
            this.groupBox1.Controls.Add(this.txtBlueHeight);
            this.groupBox1.Controls.Add(this.txtGreenHeight);
            this.groupBox1.Controls.Add(this.txtRedHeight);
            this.groupBox1.Controls.Add(this.ptbWhitePerson);
            this.groupBox1.Controls.Add(this.ptbGrayPerson);
            this.groupBox1.Controls.Add(this.ptbBluePerson);
            this.groupBox1.Controls.Add(this.ptbGreenPerson);
            this.groupBox1.Controls.Add(this.ptbRedPerson);
            this.groupBox1.Location = new System.Drawing.Point(9, 334);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(552, 182);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Height";
            // 
            // txtWhiteHeight
            // 
            this.txtWhiteHeight.Location = new System.Drawing.Point(74, 137);
            this.txtWhiteHeight.Name = "txtWhiteHeight";
            this.txtWhiteHeight.Size = new System.Drawing.Size(100, 22);
            this.txtWhiteHeight.TabIndex = 9;
            // 
            // txtGrayHeight
            // 
            this.txtGrayHeight.Location = new System.Drawing.Point(74, 109);
            this.txtGrayHeight.Name = "txtGrayHeight";
            this.txtGrayHeight.Size = new System.Drawing.Size(100, 22);
            this.txtGrayHeight.TabIndex = 8;
            // 
            // txtBlueHeight
            // 
            this.txtBlueHeight.Location = new System.Drawing.Point(74, 80);
            this.txtBlueHeight.Name = "txtBlueHeight";
            this.txtBlueHeight.Size = new System.Drawing.Size(100, 22);
            this.txtBlueHeight.TabIndex = 7;
            // 
            // txtGreenHeight
            // 
            this.txtGreenHeight.Location = new System.Drawing.Point(74, 51);
            this.txtGreenHeight.Name = "txtGreenHeight";
            this.txtGreenHeight.Size = new System.Drawing.Size(100, 22);
            this.txtGreenHeight.TabIndex = 6;
            // 
            // txtRedHeight
            // 
            this.txtRedHeight.Location = new System.Drawing.Point(74, 22);
            this.txtRedHeight.Name = "txtRedHeight";
            this.txtRedHeight.Size = new System.Drawing.Size(100, 22);
            this.txtRedHeight.TabIndex = 5;
            // 
            // ptbWhitePerson
            // 
            this.ptbWhitePerson.Location = new System.Drawing.Point(6, 137);
            this.ptbWhitePerson.Name = "ptbWhitePerson";
            this.ptbWhitePerson.Size = new System.Drawing.Size(52, 23);
            this.ptbWhitePerson.TabIndex = 4;
            this.ptbWhitePerson.TabStop = false;
            // 
            // ptbGrayPerson
            // 
            this.ptbGrayPerson.Location = new System.Drawing.Point(6, 108);
            this.ptbGrayPerson.Name = "ptbGrayPerson";
            this.ptbGrayPerson.Size = new System.Drawing.Size(52, 23);
            this.ptbGrayPerson.TabIndex = 3;
            this.ptbGrayPerson.TabStop = false;
            // 
            // ptbBluePerson
            // 
            this.ptbBluePerson.Location = new System.Drawing.Point(6, 79);
            this.ptbBluePerson.Name = "ptbBluePerson";
            this.ptbBluePerson.Size = new System.Drawing.Size(52, 23);
            this.ptbBluePerson.TabIndex = 2;
            this.ptbBluePerson.TabStop = false;
            // 
            // ptbGreenPerson
            // 
            this.ptbGreenPerson.Location = new System.Drawing.Point(6, 50);
            this.ptbGreenPerson.Name = "ptbGreenPerson";
            this.ptbGreenPerson.Size = new System.Drawing.Size(52, 23);
            this.ptbGreenPerson.TabIndex = 1;
            this.ptbGreenPerson.TabStop = false;
            // 
            // ptbRedPerson
            // 
            this.ptbRedPerson.Location = new System.Drawing.Point(6, 21);
            this.ptbRedPerson.Name = "ptbRedPerson";
            this.ptbRedPerson.Size = new System.Drawing.Size(52, 23);
            this.ptbRedPerson.TabIndex = 0;
            this.ptbRedPerson.TabStop = false;
            // 
            // btnGetNumPeople
            // 
            this.btnGetNumPeople.Location = new System.Drawing.Point(382, 296);
            this.btnGetNumPeople.Name = "btnGetNumPeople";
            this.btnGetNumPeople.Size = new System.Drawing.Size(75, 23);
            this.btnGetNumPeople.TabIndex = 26;
            this.btnGetNumPeople.Text = "Get";
            this.btnGetNumPeople.UseVisualStyleBackColor = true;
            this.btnGetNumPeople.Click += new System.EventHandler(this.btnGetNumPeople_Click);
            // 
            // txtNumPeople
            // 
            this.txtNumPeople.Location = new System.Drawing.Point(151, 295);
            this.txtNumPeople.Name = "txtNumPeople";
            this.txtNumPeople.Size = new System.Drawing.Size(214, 22);
            this.txtNumPeople.TabIndex = 25;
            this.txtNumPeople.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 298);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 15);
            this.label7.TabIndex = 24;
            this.label7.Text = "Number of People";
            // 
            // btnSetMaxNumPeople
            // 
            this.btnSetMaxNumPeople.Location = new System.Drawing.Point(382, 233);
            this.btnSetMaxNumPeople.Name = "btnSetMaxNumPeople";
            this.btnSetMaxNumPeople.Size = new System.Drawing.Size(75, 23);
            this.btnSetMaxNumPeople.TabIndex = 23;
            this.btnSetMaxNumPeople.Text = "Set";
            this.btnSetMaxNumPeople.UseVisualStyleBackColor = true;
            this.btnSetMaxNumPeople.Click += new System.EventHandler(this.btnSetMaxNumPeople_Click);
            // 
            // txtMaxPeople
            // 
            this.txtMaxPeople.Location = new System.Drawing.Point(151, 234);
            this.txtMaxPeople.Name = "txtMaxPeople";
            this.txtMaxPeople.Size = new System.Drawing.Size(214, 22);
            this.txtMaxPeople.TabIndex = 22;
            this.txtMaxPeople.Text = "5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 15);
            this.label6.TabIndex = 21;
            this.label6.Text = "Max People";
            // 
            // btnOpenPeopleRaw
            // 
            this.btnOpenPeopleRaw.Location = new System.Drawing.Point(382, 205);
            this.btnOpenPeopleRaw.Name = "btnOpenPeopleRaw";
            this.btnOpenPeopleRaw.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPeopleRaw.TabIndex = 20;
            this.btnOpenPeopleRaw.Text = "Open";
            this.btnOpenPeopleRaw.UseVisualStyleBackColor = true;
            this.btnOpenPeopleRaw.Click += new System.EventHandler(this.btnOpenPeopleRaw_Click);
            // 
            // txtPeopleRawFileName
            // 
            this.txtPeopleRawFileName.Location = new System.Drawing.Point(151, 205);
            this.txtPeopleRawFileName.Name = "txtPeopleRawFileName";
            this.txtPeopleRawFileName.Size = new System.Drawing.Size(214, 22);
            this.txtPeopleRawFileName.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "People RAW";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(382, 261);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 17;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // txtRstExecute
            // 
            this.txtRstExecute.Location = new System.Drawing.Point(151, 262);
            this.txtRstExecute.Name = "txtRstExecute";
            this.txtRstExecute.Size = new System.Drawing.Size(214, 22);
            this.txtRstExecute.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Execute";
            // 
            // btnSaveGND
            // 
            this.btnSaveGND.Location = new System.Drawing.Point(382, 172);
            this.btnSaveGND.Name = "btnSaveGND";
            this.btnSaveGND.Size = new System.Drawing.Size(75, 23);
            this.btnSaveGND.TabIndex = 14;
            this.btnSaveGND.Text = "Save";
            this.btnSaveGND.UseVisualStyleBackColor = true;
            this.btnSaveGND.Click += new System.EventHandler(this.btnSaveGND_Click);
            // 
            // txtGndFileName
            // 
            this.txtGndFileName.Location = new System.Drawing.Point(151, 171);
            this.txtGndFileName.Name = "txtGndFileName";
            this.txtGndFileName.Size = new System.Drawing.Size(214, 22);
            this.txtGndFileName.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Save Ground";
            // 
            // btnGetGND
            // 
            this.btnGetGND.Location = new System.Drawing.Point(382, 142);
            this.btnGetGND.Name = "btnGetGND";
            this.btnGetGND.Size = new System.Drawing.Size(75, 23);
            this.btnGetGND.TabIndex = 11;
            this.btnGetGND.Text = "Get";
            this.btnGetGND.UseVisualStyleBackColor = true;
            this.btnGetGND.Click += new System.EventHandler(this.btnGetGND_Click);
            // 
            // txtRstGetGND
            // 
            this.txtRstGetGND.Location = new System.Drawing.Point(151, 142);
            this.txtRstGetGND.Name = "txtRstGetGND";
            this.txtRstGetGND.Size = new System.Drawing.Size(214, 22);
            this.txtRstGetGND.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Get Ground";
            // 
            // btnRunInit
            // 
            this.btnRunInit.Location = new System.Drawing.Point(382, 110);
            this.btnRunInit.Name = "btnRunInit";
            this.btnRunInit.Size = new System.Drawing.Size(75, 23);
            this.btnRunInit.TabIndex = 8;
            this.btnRunInit.Text = "Init";
            this.btnRunInit.UseVisualStyleBackColor = true;
            this.btnRunInit.Click += new System.EventHandler(this.btnRunInit_Click);
            // 
            // txtRstInit
            // 
            this.txtRstInit.Location = new System.Drawing.Point(151, 110);
            this.txtRstInit.Name = "txtRstInit";
            this.txtRstInit.Size = new System.Drawing.Size(214, 22);
            this.txtRstInit.TabIndex = 7;
            // 
            // btnInit
            // 
            this.btnInit.AutoSize = true;
            this.btnInit.Location = new System.Drawing.Point(6, 113);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(40, 15);
            this.btnInit.TabIndex = 6;
            this.btnInit.Text = "Initial";
            // 
            // btnSetCameraAngle
            // 
            this.btnSetCameraAngle.Location = new System.Drawing.Point(382, 78);
            this.btnSetCameraAngle.Name = "btnSetCameraAngle";
            this.btnSetCameraAngle.Size = new System.Drawing.Size(75, 23);
            this.btnSetCameraAngle.TabIndex = 5;
            this.btnSetCameraAngle.Text = "Set";
            this.btnSetCameraAngle.UseVisualStyleBackColor = true;
            this.btnSetCameraAngle.Click += new System.EventHandler(this.btnSetCameraAngle_Click);
            // 
            // txtSetCameraAngle
            // 
            this.txtSetCameraAngle.Location = new System.Drawing.Point(151, 79);
            this.txtSetCameraAngle.Name = "txtSetCameraAngle";
            this.txtSetCameraAngle.Size = new System.Drawing.Size(214, 22);
            this.txtSetCameraAngle.TabIndex = 4;
            this.txtSetCameraAngle.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Set Camera Angle";
            // 
            // btnSearchGndRaw
            // 
            this.btnSearchGndRaw.Location = new System.Drawing.Point(382, 47);
            this.btnSearchGndRaw.Name = "btnSearchGndRaw";
            this.btnSearchGndRaw.Size = new System.Drawing.Size(75, 23);
            this.btnSearchGndRaw.TabIndex = 2;
            this.btnSearchGndRaw.Text = "Open";
            this.btnSearchGndRaw.UseVisualStyleBackColor = true;
            this.btnSearchGndRaw.Click += new System.EventHandler(this.btnSearchGndRaw_Click);
            // 
            // txtRawGndFileName
            // 
            this.txtRawGndFileName.Location = new System.Drawing.Point(151, 48);
            this.txtRawGndFileName.Name = "txtRawGndFileName";
            this.txtRawGndFileName.Size = new System.Drawing.Size(214, 22);
            this.txtRawGndFileName.TabIndex = 1;
            // 
            // gndRawTxt
            // 
            this.gndRawTxt.AutoSize = true;
            this.gndRawTxt.Location = new System.Drawing.Point(6, 50);
            this.gndRawTxt.Name = "gndRawTxt";
            this.gndRawTxt.Size = new System.Drawing.Size(87, 15);
            this.gndRawTxt.TabIndex = 0;
            this.gndRawTxt.Text = "Ground RAW";
            // 
            // ptbGnd
            // 
            this.ptbGnd.Location = new System.Drawing.Point(603, 32);
            this.ptbGnd.Name = "ptbGnd";
            this.ptbGnd.Size = new System.Drawing.Size(244, 128);
            this.ptbGnd.TabIndex = 1;
            this.ptbGnd.TabStop = false;
            // 
            // ptbPeople
            // 
            this.ptbPeople.Location = new System.Drawing.Point(603, 195);
            this.ptbPeople.Name = "ptbPeople";
            this.ptbPeople.Size = new System.Drawing.Size(244, 147);
            this.ptbPeople.TabIndex = 2;
            this.ptbPeople.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(600, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "GND TIFF";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(600, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "PEOPLE TIFF";
            // 
            // ptbDetectedPeople
            // 
            this.ptbDetectedPeople.Location = new System.Drawing.Point(603, 385);
            this.ptbDetectedPeople.Name = "ptbDetectedPeople";
            this.ptbDetectedPeople.Size = new System.Drawing.Size(244, 158);
            this.ptbDetectedPeople.TabIndex = 5;
            this.ptbDetectedPeople.TabStop = false;
            // 
            // btnShowDetectedPeople
            // 
            this.btnShowDetectedPeople.Location = new System.Drawing.Point(603, 356);
            this.btnShowDetectedPeople.Name = "btnShowDetectedPeople";
            this.btnShowDetectedPeople.Size = new System.Drawing.Size(134, 23);
            this.btnShowDetectedPeople.TabIndex = 6;
            this.btnShowDetectedPeople.Text = "Show People";
            this.btnShowDetectedPeople.UseVisualStyleBackColor = true;
            this.btnShowDetectedPeople.Click += new System.EventHandler(this.btnShowDetectedPeople_Click);
            // 
            // btnGroundNull
            // 
            this.btnGroundNull.Location = new System.Drawing.Point(475, 46);
            this.btnGroundNull.Name = "btnGroundNull";
            this.btnGroundNull.Size = new System.Drawing.Size(75, 23);
            this.btnGroundNull.TabIndex = 28;
            this.btnGroundNull.Text = "NULL";
            this.btnGroundNull.UseVisualStyleBackColor = true;
            this.btnGroundNull.Click += new System.EventHandler(this.btnGroundNull_Click);
            // 
            // btnPeopleNULL
            // 
            this.btnPeopleNULL.Location = new System.Drawing.Point(475, 205);
            this.btnPeopleNULL.Name = "btnPeopleNULL";
            this.btnPeopleNULL.Size = new System.Drawing.Size(75, 23);
            this.btnPeopleNULL.TabIndex = 29;
            this.btnPeopleNULL.Text = "NULL";
            this.btnPeopleNULL.UseVisualStyleBackColor = true;
            this.btnPeopleNULL.Click += new System.EventHandler(this.btnPeopleNULL_Click);
            // 
            // btnNewDetector
            // 
            this.btnNewDetector.Location = new System.Drawing.Point(382, 10);
            this.btnNewDetector.Name = "btnNewDetector";
            this.btnNewDetector.Size = new System.Drawing.Size(168, 23);
            this.btnNewDetector.TabIndex = 30;
            this.btnNewDetector.Text = "Create New Detector";
            this.btnNewDetector.UseVisualStyleBackColor = true;
            this.btnNewDetector.Click += new System.EventHandler(this.btnNewDetector_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 555);
            this.Controls.Add(this.btnShowDetectedPeople);
            this.Controls.Add(this.ptbDetectedPeople);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ptbPeople);
            this.Controls.Add(this.ptbGnd);
            this.Controls.Add(this.simpleTestBox);
            this.Name = "Form1";
            this.Text = "Human Detection";
            this.simpleTestBox.ResumeLayout(false);
            this.simpleTestBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbWhitePerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrayPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBluePerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbGreenPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRedPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbGnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPeople)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbDetectedPeople)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox simpleTestBox;
        private System.Windows.Forms.Label gndRawTxt;
        private System.Windows.Forms.Button btnSearchGndRaw;
        private System.Windows.Forms.TextBox txtRawGndFileName;
        private System.Windows.Forms.Button btnSetCameraAngle;
        private System.Windows.Forms.TextBox txtSetCameraAngle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRunInit;
        private System.Windows.Forms.TextBox txtRstInit;
        private System.Windows.Forms.Label btnInit;
        private System.Windows.Forms.Button btnGetGND;
        private System.Windows.Forms.TextBox txtRstGetGND;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveGND;
        private System.Windows.Forms.TextBox txtGndFileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRstExecute;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnOpenPeopleRaw;
        private System.Windows.Forms.TextBox txtPeopleRawFileName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaxPeople;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSetMaxNumPeople;
        private System.Windows.Forms.TextBox txtNumPeople;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGetNumPeople;
        private System.Windows.Forms.PictureBox ptbGnd;
        private System.Windows.Forms.PictureBox ptbPeople;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox ptbDetectedPeople;
        private System.Windows.Forms.Button btnShowDetectedPeople;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtWhiteHeight;
        private System.Windows.Forms.TextBox txtGrayHeight;
        private System.Windows.Forms.TextBox txtBlueHeight;
        private System.Windows.Forms.TextBox txtGreenHeight;
        private System.Windows.Forms.TextBox txtRedHeight;
        private System.Windows.Forms.PictureBox ptbWhitePerson;
        private System.Windows.Forms.PictureBox ptbGrayPerson;
        private System.Windows.Forms.PictureBox ptbBluePerson;
        private System.Windows.Forms.PictureBox ptbGreenPerson;
        private System.Windows.Forms.PictureBox ptbRedPerson;
        private System.Windows.Forms.Button btnGroundNull;
        private System.Windows.Forms.Button btnPeopleNULL;
        private System.Windows.Forms.Button btnNewDetector;
    }
}

