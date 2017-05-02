namespace project_uas
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDilation = new System.Windows.Forms.Button();
            this.btnDeteksiTepi = new System.Windows.Forms.Button();
            this.btnThresholding = new System.Windows.Forms.Button();
            this.btnGrayscale = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.cbDeteksiTepi = new System.Windows.Forms.ComboBox();
            this.radioButtonT3 = new System.Windows.Forms.RadioButton();
            this.radioButtonT2 = new System.Windows.Forms.RadioButton();
            this.radioButtonT1 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.cbThreholding = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnKMeans = new System.Windows.Forms.Button();
            this.btnGrayscale2 = new System.Windows.Forms.Button();
            this.pictureBoxKMeans = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFile2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnBrowse2 = new System.Windows.Forms.Button();
            this.txtCluster = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKMeans)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(787, 624);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(779, 597);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Metode Thresholding";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDilation);
            this.groupBox2.Controls.Add(this.btnDeteksiTepi);
            this.groupBox2.Controls.Add(this.btnThresholding);
            this.groupBox2.Controls.Add(this.btnGrayscale);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(0, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(769, 413);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // btnDilation
            // 
            this.btnDilation.Location = new System.Drawing.Point(587, 264);
            this.btnDilation.Name = "btnDilation";
            this.btnDilation.Size = new System.Drawing.Size(159, 23);
            this.btnDilation.TabIndex = 4;
            this.btnDilation.Text = "Dilasi";
            this.btnDilation.UseVisualStyleBackColor = true;
            this.btnDilation.Click += new System.EventHandler(this.btnDilation_Click);
            // 
            // btnDeteksiTepi
            // 
            this.btnDeteksiTepi.Location = new System.Drawing.Point(587, 185);
            this.btnDeteksiTepi.Name = "btnDeteksiTepi";
            this.btnDeteksiTepi.Size = new System.Drawing.Size(159, 23);
            this.btnDeteksiTepi.TabIndex = 3;
            this.btnDeteksiTepi.Text = "Deteksi Tepi";
            this.btnDeteksiTepi.UseVisualStyleBackColor = true;
            this.btnDeteksiTepi.Click += new System.EventHandler(this.btnDeteksiTepi_Click);
            // 
            // btnThresholding
            // 
            this.btnThresholding.Location = new System.Drawing.Point(587, 117);
            this.btnThresholding.Name = "btnThresholding";
            this.btnThresholding.Size = new System.Drawing.Size(159, 23);
            this.btnThresholding.TabIndex = 2;
            this.btnThresholding.Text = "Thresholding";
            this.btnThresholding.UseVisualStyleBackColor = true;
            this.btnThresholding.Click += new System.EventHandler(this.btnThresholding_Click);
            // 
            // btnGrayscale
            // 
            this.btnGrayscale.Location = new System.Drawing.Point(587, 36);
            this.btnGrayscale.Name = "btnGrayscale";
            this.btnGrayscale.Size = new System.Drawing.Size(159, 23);
            this.btnGrayscale.TabIndex = 1;
            this.btnGrayscale.Text = "Grayscale";
            this.btnGrayscale.UseVisualStyleBackColor = true;
            this.btnGrayscale.Click += new System.EventHandler(this.btnGrayscale_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(22, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(528, 378);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtFileName);
            this.groupBox1.Controls.Add(this.cbDeteksiTepi);
            this.groupBox1.Controls.Add(this.radioButtonT3);
            this.groupBox1.Controls.Add(this.radioButtonT2);
            this.groupBox1.Controls.Add(this.radioButtonT1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbThreholding);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(14, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(749, 175);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(228, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 14);
            this.label10.TabIndex = 22;
            this.label10.Text = "Nilai Threshold";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(189, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 14);
            this.label8.TabIndex = 21;
            this.label8.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 14);
            this.label5.TabIndex = 20;
            this.label5.Text = "Nilai Threshold";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(222, 133);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(328, 22);
            this.txtFileName.TabIndex = 19;
            // 
            // cbDeteksiTepi
            // 
            this.cbDeteksiTepi.FormattingEnabled = true;
            this.cbDeteksiTepi.Items.AddRange(new object[] {
            "Operator Canny",
            "Operator Laplacian"});
            this.cbDeteksiTepi.Location = new System.Drawing.Point(222, 97);
            this.cbDeteksiTepi.Name = "cbDeteksiTepi";
            this.cbDeteksiTepi.Size = new System.Drawing.Size(193, 22);
            this.cbDeteksiTepi.TabIndex = 18;
            // 
            // radioButtonT3
            // 
            this.radioButtonT3.AutoSize = true;
            this.radioButtonT3.Enabled = false;
            this.radioButtonT3.Location = new System.Drawing.Point(609, 22);
            this.radioButtonT3.Name = "radioButtonT3";
            this.radioButtonT3.Size = new System.Drawing.Size(39, 18);
            this.radioButtonT3.TabIndex = 17;
            this.radioButtonT3.Text = "T3";
            this.radioButtonT3.UseVisualStyleBackColor = true;
            // 
            // radioButtonT2
            // 
            this.radioButtonT2.AutoSize = true;
            this.radioButtonT2.Enabled = false;
            this.radioButtonT2.Location = new System.Drawing.Point(537, 22);
            this.radioButtonT2.Name = "radioButtonT2";
            this.radioButtonT2.Size = new System.Drawing.Size(39, 18);
            this.radioButtonT2.TabIndex = 16;
            this.radioButtonT2.Text = "T2";
            this.radioButtonT2.UseVisualStyleBackColor = true;
            // 
            // radioButtonT1
            // 
            this.radioButtonT1.AutoSize = true;
            this.radioButtonT1.Checked = true;
            this.radioButtonT1.Enabled = false;
            this.radioButtonT1.Location = new System.Drawing.Point(454, 22);
            this.radioButtonT1.Name = "radioButtonT1";
            this.radioButtonT1.Size = new System.Drawing.Size(39, 18);
            this.radioButtonT1.TabIndex = 15;
            this.radioButtonT1.TabStop = true;
            this.radioButtonT1.Text = "T1";
            this.radioButtonT1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(189, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 14);
            this.label7.TabIndex = 14;
            this.label7.Text = ":";
            // 
            // cbThreholding
            // 
            this.cbThreholding.FormattingEnabled = true;
            this.cbThreholding.Items.AddRange(new object[] {
            "Local",
            "Global"});
            this.cbThreholding.Location = new System.Drawing.Point(222, 21);
            this.cbThreholding.Name = "cbThreholding";
            this.cbThreholding.Size = new System.Drawing.Size(193, 22);
            this.cbThreholding.TabIndex = 13;
            this.cbThreholding.SelectedIndexChanged += new System.EventHandler(this.cbThreholding_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Metode Thresholding";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(573, 132);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(189, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 14);
            this.label6.TabIndex = 5;
            this.label6.Text = ":";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Operator Deteksi Tepi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = ":";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Insert Picture";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(779, 597);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Metode K-Means";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.btnKMeans);
            this.groupBox4.Controls.Add(this.btnGrayscale2);
            this.groupBox4.Controls.Add(this.pictureBoxKMeans);
            this.groupBox4.Location = new System.Drawing.Point(15, 142);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(749, 439);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 14);
            this.label12.TabIndex = 6;
            this.label12.Text = "Iterasi : ";
            // 
            // btnKMeans
            // 
            this.btnKMeans.Location = new System.Drawing.Point(574, 117);
            this.btnKMeans.Name = "btnKMeans";
            this.btnKMeans.Size = new System.Drawing.Size(159, 23);
            this.btnKMeans.TabIndex = 5;
            this.btnKMeans.Text = "K-Means";
            this.btnKMeans.UseVisualStyleBackColor = true;
            this.btnKMeans.Click += new System.EventHandler(this.btnKMeans_Click);
            // 
            // btnGrayscale2
            // 
            this.btnGrayscale2.Location = new System.Drawing.Point(574, 46);
            this.btnGrayscale2.Name = "btnGrayscale2";
            this.btnGrayscale2.Size = new System.Drawing.Size(159, 23);
            this.btnGrayscale2.TabIndex = 1;
            this.btnGrayscale2.Text = "Grayscale";
            this.btnGrayscale2.UseVisualStyleBackColor = true;
            this.btnGrayscale2.Click += new System.EventHandler(this.btnGrayscale2_Click);
            // 
            // pictureBoxKMeans
            // 
            this.pictureBoxKMeans.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxKMeans.Location = new System.Drawing.Point(22, 46);
            this.pictureBoxKMeans.Name = "pictureBoxKMeans";
            this.pictureBoxKMeans.Size = new System.Drawing.Size(528, 353);
            this.pictureBoxKMeans.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxKMeans.TabIndex = 0;
            this.pictureBoxKMeans.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtFile2);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.btnBrowse2);
            this.groupBox3.Controls.Add(this.txtCluster);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Location = new System.Drawing.Point(15, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(749, 120);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(190, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(10, 14);
            this.label11.TabIndex = 27;
            this.label11.Text = ":";
            // 
            // txtFile2
            // 
            this.txtFile2.Location = new System.Drawing.Point(223, 66);
            this.txtFile2.Name = "txtFile2";
            this.txtFile2.Size = new System.Drawing.Size(328, 22);
            this.txtFile2.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 14);
            this.label9.TabIndex = 26;
            this.label9.Text = "Input Jumlah Cluster";
            // 
            // btnBrowse2
            // 
            this.btnBrowse2.Location = new System.Drawing.Point(574, 65);
            this.btnBrowse2.Name = "btnBrowse2";
            this.btnBrowse2.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse2.TabIndex = 10;
            this.btnBrowse2.Text = "Browse...";
            this.btnBrowse2.UseVisualStyleBackColor = true;
            this.btnBrowse2.Click += new System.EventHandler(this.btnBrowse2_Click);
            // 
            // txtCluster
            // 
            this.txtCluster.Location = new System.Drawing.Point(223, 28);
            this.txtCluster.Name = "txtCluster";
            this.txtCluster.Size = new System.Drawing.Size(100, 22);
            this.txtCluster.TabIndex = 25;
            this.txtCluster.Text = "5";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(190, 69);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(10, 14);
            this.label15.TabIndex = 5;
            this.label15.Text = ":";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(32, 69);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(78, 14);
            this.label18.TabIndex = 2;
            this.label18.Text = "Insert Picture";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 661);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Segmentasi Citra Digital Ikan";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKMeans)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDilation;
        private System.Windows.Forms.Button btnDeteksiTepi;
        private System.Windows.Forms.Button btnThresholding;
        private System.Windows.Forms.Button btnGrayscale;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.ComboBox cbDeteksiTepi;
        private System.Windows.Forms.RadioButton radioButtonT3;
        private System.Windows.Forms.RadioButton radioButtonT2;
        private System.Windows.Forms.RadioButton radioButtonT1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbThreholding;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtFile2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnBrowse2;
        private System.Windows.Forms.TextBox txtCluster;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnKMeans;
        private System.Windows.Forms.Button btnGrayscale2;
        private System.Windows.Forms.PictureBox pictureBoxKMeans;
        private System.Windows.Forms.Label label10;
    }
}

