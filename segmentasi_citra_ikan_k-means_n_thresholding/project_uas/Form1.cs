using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ext;
using Ext.Utility;
using Accord.Imaging.Converters;
using Accord.Controls.Imaging;
using AForge.Imaging.Filters;

namespace project_uas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bitmap;
        CreateImage create;
        byte[,] grayscale, newGrayscale;
        int[,] newCanny, newCanny1;
        Bitmap tempBitmap, bitmapHasil;
        int nilaiOtsu = 0;
        int jumlahKluster;
        int[,] pusatkluster;
        double[,] distanceEuclidian;
        int[] hasilKluster, oldKluster;
        int[,] nilaiKluster;
        byte[,] citraKluster;
        int[] mean;
        Random r;


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                bitmap = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = (Image)bitmap;
                txtFileName.Text = openFileDialog1.FileName;

            }
        }

        private void btnGrayscale_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.pictureBox1.Image != null)
                {
                    ReadImage read = new ReadImage(bitmap);
                    byte[,] red = read.Red;
                    byte[,] green = read.Green;
                    byte[,] blue = read.Blue;


                    int mati = red.GetLength(0);
                    int matj = red.GetLength(1);

                    grayscale = new byte[mati, matj];
                    for (int i = 0; i < mati; i++)
                    {
                        for (int j = 0; j < matj; j++)
                        {
                            grayscale[i, j] = Convert.ToByte((red[i, j] + green[i, j] + blue[i, j]) / 3);
                        }
                    }

                    create = new CreateImage(grayscale);

                    this.pictureBox1.Image = (Image)create.Btmp;

                }
                else
                {
                    MessageBox.Show("Silahkan input gambar");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
            }

        }

        private void btnThresholding_Click(object sender, EventArgs e)
        {
            try
            {


                //Ext.Otsu otsu = new Ext.Otsu();
                //otsu.Process(grayscale);
                //int T = otsu.T;

                if (cbThreholding.SelectedIndex == -1)
                {
                    MessageBox.Show("Pilih Metode thresholding");
                }
                else
                {
                    int[] histogram = new int[256];
                    double[] wB, wF, sumB, mB, mF, variance;
                    wB = new double[256];
                    wF = new double[256];
                    sumB = new double[256];
                    mB = new double[256];
                    mF = new double[256];
                    variance = new double[256];

                    int baris1 = grayscale.GetLength(0);
                    int kolom = grayscale.GetLength(1);

                    int baris = baris1 * kolom;

                    int terbaik = 0;


                    int max = 0, min = 0, x = 0, y = 0, a = 0, b = 0;

                    if (cbThreholding.SelectedItem == "Global")
                    {

                        for (int i = 0; i < 256; i++)
                        {
                            for (int j = 0; j < grayscale.GetLength(0); j++)
                            {
                                for (int k = 0; k < grayscale.GetLength(1); k++)
                                {
                                    if (grayscale[j, k] == i)
                                    {
                                        histogram[i] += 1;
                                    }
                                }
                            }
                        }


                        int total = 0;
                        for (int i = 0; i < 256; i++)
                        {
                            total += histogram[i] * i;
                        }


                        for (int i = 0; i < 256; i++)
                        {
                            for (int j = 0; j <= i; j++)
                            {
                                wB[i] += histogram[j];
                                sumB[i] += j * histogram[j];
                            }

                            wF[i] = baris - wB[i];
                            mB[i] = sumB[i] / wB[i];
                            mF[i] = (total - sumB[i]) / wF[i];
                            variance[i] = Math.Round(wB[i] * wF[i] * (Math.Pow((mB[i] - mF[i]), 2)), 2);

                            if (double.IsNaN(variance[i]))
                            {
                                variance[i] = 0;
                            }

                            if (variance[terbaik] <= variance[i])
                            {
                                terbaik = i;
                            }

                        }

                        nilaiOtsu = terbaik;
                    }

                    else
                    {


                        if (radioButtonT1.Checked)
                        {
                            nilaiOtsu = 128;
                        }

                        if (radioButtonT2.Checked)
                        {


                            for (int i = 0; i < grayscale.GetLength(0); i++)
                            {
                                for (int j = 0; j < grayscale.GetLength(1); j++)
                                {
                                    if (grayscale[x, y] <= grayscale[i, j])
                                    {
                                        x = i;
                                        y = j;
                                    }

                                    if (grayscale[a, b] >= grayscale[i, j])
                                    {
                                        a = i;
                                        b = j;
                                    }
                                }
                            }

                            max = grayscale[x, y];
                            min = grayscale[a, b];

                            nilaiOtsu = (max + min) / 2;
                        }

                        if (radioButtonT3.Checked)
                        {
                            //textBox1.Text = nilaiOtsu.ToString();

                            int total = 0;

                            for (int i = 0; i < grayscale.GetLength(0); i++)
                            {
                                for (int j = 0; j < grayscale.GetLength(1); j++)
                                {
                                    total += grayscale[i, j];
                                }
                            }
                            nilaiOtsu = (total / baris) - 88;
                            //textBox1.Text = nilaiOtsu.ToString();
                        }
                    }
                    for (int i = 0; i < grayscale.GetLength(0); i++)
                    {
                        for (int j = 0; j < grayscale.GetLength(1); j++)
                        {
                            if (grayscale[i, j] >= nilaiOtsu)
                            {
                                grayscale[i, j] = 255;
                            }
                            else
                            {
                                grayscale[i, j] = 0;
                            }
                        }
                    }

                    create = new CreateImage(grayscale);

                    this.pictureBox1.Image = (Image)create.Btmp;
                    label10.Text = nilaiOtsu.ToString();

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
            }


        }

        private void btnDeteksiTepi_Click(object sender, EventArgs e)
        {
            try
            {


                //MatrixToImage mat2img = new MatrixToImage(0, 255);
                //mat2img.Convert(grayscale, out tempBitmap);
                //CannyEdgeDetector canny = new CannyEdgeDetector();
                //bitmapHasil = canny.Apply(tempBitmap);

                //this.pictureBox1.Image = bitmapHasil;


                //create = new CreateImage(grayscale);

                //this.pictureBox1.Image = (Image)create.Btmp;
                //canny();


                //Bitmap b = new Bitmap(pictureBox1.Image);


                if (cbThreholding.SelectedIndex == -1)
                {
                    MessageBox.Show("Pilih Metode Deteksi Tepi");
                }

                else
                {

                    if (cbDeteksiTepi.SelectedItem == "Operator Canny")
                    {

                        int width = grayscale.GetLength(0);
                        int height = grayscale.GetLength(1);

                        int[,] tempGrayScale = new int[width, height];

                        for (int i = 0; i < width; i++)
                        {
                            for (int j = 0; j < height; j++)
                            {
                                tempGrayScale[i, j] = grayscale[i, j];
                            }
                        }


                        newCanny = new int[width, height];


                        for (int i = 2; i < width - 2; i++)
                        {
                            for (int j = 2; j < height - 2; j++)
                            {
                                int intGray = (
                                          ((tempGrayScale[i - 2, j - 2]) * 1 + (tempGrayScale[i - 1, j - 2]) * 4 + (tempGrayScale[i, j - 2]) * 7 + (tempGrayScale[i + 1, j - 2]) * 4 + (tempGrayScale[i + 2, j - 2])
                                          + (tempGrayScale[i - 2, j - 1]) * 4 + (tempGrayScale[i - 1, j - 1]) * 16 + (tempGrayScale[i, j - 1]) * 26 + (tempGrayScale[i + 1, j - 1]) * 16 + (tempGrayScale[i + 2, j - 1]) * 4
                                          + (tempGrayScale[i - 2, j]) * 7 + (tempGrayScale[i - 1, j]) * 26 + (tempGrayScale[i, j]) * 41 + (tempGrayScale[i + 1, j]) * 26 + (tempGrayScale[i + 2, j]) * 7
                                          + (tempGrayScale[i - 2, j + 1]) * 4 + (tempGrayScale[i - 1, j + 1]) * 16 + (tempGrayScale[i, j + 1]) * 26 + (tempGrayScale[i + 1, j + 1]) * 16 + (tempGrayScale[i + 2, j + 1]) * 4
                                          + (tempGrayScale[i - 2, j + 2]) * 1 + (tempGrayScale[i - 1, j + 2]) * 4 + (tempGrayScale[i, j + 2]) * 7 + (tempGrayScale[i + 1, j + 2]) * 4 + (tempGrayScale[i + 2, j + 2]) * 1) / 273
                                          );


                                newCanny[i, j] = Convert.ToByte(intGray);
                            }
                        }


                        int[,] gx = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
                        int[,] gy = new int[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

                        int new_gx = 0, new_gy = 0;
                        int gc;//, gc, bc;
                        int gradGrayscale;//, gradG, gradB;

                        int[,] graidientG = new int[width, height];

                        int atanG; //, atanG, atanB;

                        int[,] tanG = new int[width, height];

                        for (int i = 1; i < width - 1; i++)
                        {
                            for (int j = 1; j < height - 1; j++)
                            {

                                new_gx = 0;
                                new_gy = 0;
                                gc = 0;

                                for (int wi = -1; wi < 2; wi++)
                                {
                                    for (int hw = -1; hw < 2; hw++)
                                    {
                                        gc = newCanny[i + hw, j + wi];
                                        new_gx += gx[wi + 1, hw + 1] * gc;
                                        new_gy += gy[wi + 1, hw + 1] * gc;
                                        ;
                                    }
                                }

                                //find gradieant
                                gradGrayscale = (int)Math.Sqrt((new_gx * new_gx) + (new_gy * new_gy));
                                graidientG[i, j] = gradGrayscale;

                                //find tans
                                ////////////////tan red//////////////////////////////////
                                atanG = (int)((Math.Atan((double)new_gy / new_gx)) * (180 / Math.PI));

                                if ((atanG > 0 && atanG < 22.5) || (atanG > 157.5 && atanG < 180))
                                {
                                    atanG = 0;
                                }
                                else if (atanG > 22.5 && atanG < 67.5)
                                {
                                    atanG = 45;
                                }
                                else if (atanG > 67.5 && atanG < 112.5)
                                {
                                    atanG = 90;
                                }
                                else if (atanG > 112.5 && atanG < 157.5)
                                {
                                    atanG = 135;
                                }

                                if (atanG == 0)
                                {
                                    tanG[i, j] = 0;
                                }
                                else if (atanG == 45)
                                {
                                    tanG[i, j] = 1;
                                }
                                else if (atanG == 90)
                                {
                                    tanG[i, j] = 2;
                                }
                                else if (atanG == 135)
                                {
                                    tanG[i, j] = 3;
                                }
                                ////////////////tan red end//////////////////////////////////


                            }
                        }


                        newCanny1 = new int[width, height];

                        for (int i = 2; i < width - 2; i++)
                        {
                            for (int j = 2; j < height - 2; j++)
                            {

                                ////red
                                if (tanG[i, j] == 0)
                                {
                                    if (graidientG[i - 1, j] < graidientG[i, j] && graidientG[i + 1, j] < graidientG[i, j])
                                    {
                                        newCanny1[i, j] = graidientG[i, j];
                                    }
                                    else
                                    {
                                        newCanny1[i, j] = 0;
                                    }
                                }
                                if (newCanny1[i, j] == 1)
                                {
                                    if (graidientG[i - 1, j + 1] < graidientG[i, j] && graidientG[i + 1, j - 1] < graidientG[i, j])
                                    {
                                        newCanny1[i, j] = graidientG[i, j];
                                    }
                                    else
                                    {
                                        newCanny1[i, j] = 0;
                                    }
                                }
                                if (tanG[i, j] == 2)
                                {
                                    if (graidientG[i, j - 1] < graidientG[i, j] && graidientG[i, j + 1] < graidientG[i, j])
                                    {
                                        newCanny1[i, j] = graidientG[i, j];
                                    }
                                    else
                                    {
                                        newCanny1[i, j] = 0;
                                    }
                                }
                                if (tanG[i, j] == 3)
                                {
                                    if (graidientG[i - 1, j - 1] < graidientG[i, j] && graidientG[i + 1, j + 1] < graidientG[i, j])
                                    {
                                        newCanny1[i, j] = graidientG[i, j];
                                    }
                                    else
                                    {
                                        newCanny1[i, j] = 0;
                                    }
                                }


                            }
                        }

                        int threshold = Convert.ToInt16(nilaiOtsu);


                        for (int i = 2; i < width - 2; i++)
                        {
                            for (int j = 2; j < height - 2; j++)
                            {
                                if (newCanny1[i, j] > threshold)
                                {
                                    grayscale[i, j] = 255;
                                }
                                else
                                {
                                    grayscale[i, j] = 0;
                                }

                            }
                        }
                    }


                    if (cbDeteksiTepi.SelectedItem == "Operator Laplacian")
                    {
                        //Penghalusan menggunakan operator gaussian

                        double[,] blur = {
                                        {  0.077, 0.077,  0.077},
                                        { 0.077,  0.308, 0.077},
                                        {  0.077, 0.077,  0.077 } };
                        double[,] edge = {
                                        {  -1, -1,  -1},
                                        { -1,  8, -1},
                                        {  -1, -1,  -1} };


                        double valBlur = 0, valEdge = 0;


                        for (int i = 1; i < grayscale.GetLength(0) - 1; i++)
                        {
                            for (int j = 1; j < grayscale.GetLength(1) - 1; j++)
                            {
                                valBlur = (blur[1, 1] * grayscale[i, j]) + (blur[0, 0] * grayscale[i - 1, j - 1]) + (blur[0, 1] * grayscale[i - 1, j]) + (blur[0, 2] * grayscale[i - 1, j + 1]) +
                                    (blur[1, 2] * grayscale[i, j + 1]) + (blur[2, 2] * grayscale[i + 1, j + 1]) + (blur[2, 1] * grayscale[i + 1, j]) + (blur[2, 0] * grayscale[i + 1, j - 1]) + (blur[1, 0] * grayscale[i, j - 1]);


                                if (valBlur > 255)
                                {
                                    valBlur = 255;
                                }

                                if (valBlur < 0)
                                {
                                    valBlur = 0;
                                }

                                grayscale[i, j] = Convert.ToByte(valBlur);

                                valEdge = (edge[1, 1] * grayscale[i, j]) + (edge[0, 0] * grayscale[i - 1, j - 1]) + (edge[0, 1] * grayscale[i - 1, j]) + (edge[0, 2] * grayscale[i - 1, j + 1]) +
                                   (edge[1, 2] * grayscale[i, j + 1]) + (edge[2, 2] * grayscale[i + 1, j + 1]) + (edge[2, 1] * grayscale[i + 1, j]) + (edge[2, 0] * grayscale[i + 1, j - 1]) + (edge[1, 0] * grayscale[i, j - 1]);

                                if (valEdge > 255)
                                {
                                    valEdge = 255;
                                }

                                if (valEdge < 0)
                                {
                                    valEdge = 0;
                                }

                                grayscale[i, j] = Convert.ToByte(valEdge);
                            }
                        }

                        for (int i = 0; i < grayscale.GetLength(0); i++)
                        {
                            for (int j = 0; j < grayscale.GetLength(1); j++)
                            {
                                if (grayscale[i, j] >= nilaiOtsu)
                                {
                                    grayscale[i, j] = 255;
                                }
                                else
                                {
                                    grayscale[i, j] = 0;
                                }
                            }
                        }
                    }

                    create = new CreateImage(grayscale);

                    this.pictureBox1.Image = (Image)create.Btmp;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        private void btnDilation_Click(object sender, EventArgs e)
        {
            try
            {
                int[,] dilasi = {
                            {  1, 1,  1},
                            { 1,  1, 1},
                            {  1, 1,  1} };

                newGrayscale = new byte[grayscale.GetLength(0), grayscale.GetLength(1)];

                for (int i = 0; i < grayscale.GetLength(0); i++)
                {
                    for (int j = 0; j < grayscale.GetLength(1); j++)
                    {
                        if (grayscale[i, j] > 0)
                        {
                            grayscale[i, j] = 1;
                        }
                        else
                        {
                            grayscale[i, j] = 0;
                        }

                        //richTextBox1.Text += grayscale[i, j].ToString() + " ";
                    }

                    //richTextBox1.Text += "\n";
                }

                //richTextBox1.Text += "\n\n";


                for (int i = 1; i < grayscale.GetLength(0) - 1; i++)
                {
                    for (int j = 1; j < grayscale.GetLength(1) - 1; j++)
                    {
                        int checkTotal = 0;

                        if (grayscale[i, j] == 1)
                        {
                            checkTotal += 1;
                        }
                        else if (grayscale[i - 1, j - 1] == 1)
                        {
                            checkTotal += 1;
                        }
                        if (grayscale[i - 1, j] == 1)
                        {
                            checkTotal += 1;
                        }
                        if (grayscale[i - 1, j + 1] == 1)
                        {
                            checkTotal += 1;
                        }
                        if (grayscale[i, j + 1] == 1)
                        {
                            checkTotal += 1;
                        }
                        if (grayscale[i + 1, j + 1] == 1)
                        {
                            checkTotal += 1;
                        }
                        if (grayscale[i + 1, j] == 1)
                        {
                            checkTotal += 1;
                        }
                        if (grayscale[i + 1, j - 1] == 1)
                        {
                            checkTotal += 1;
                        }
                        if (grayscale[i, j - 1] == 1)
                        {
                            checkTotal += 1;
                        }


                        if (checkTotal > 0)
                        {
                            newGrayscale[i, j] = 1;
                        }
                        else
                        {
                            newGrayscale[i, j] = 0;
                        }


                    }

                }


                //for (int i = 0; i < newGrayscale.GetLength(0); i++)
                //{
                //    for (int j = 0; j < newGrayscale.GetLength(1); j++)
                //    {

                //        richTextBox1.Text += newGrayscale[i, j].ToString() + " ";
                //    }
                //    richTextBox1.Text += "\n";
                //}


                for (int i = 1; i < newGrayscale.GetLength(0) - 1; i++)
                {
                    for (int j = 1; j < newGrayscale.GetLength(1) - 1; j++)
                    {
                        if (newGrayscale[i, j] > 0)
                        {
                            newGrayscale[i, j] = 255;
                        }
                        else
                        {
                            newGrayscale[i, j] = 0;
                        }
                    }
                }

                create = new CreateImage(newGrayscale);

                this.pictureBox1.Image = (Image)create.Btmp;



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        private void btnKMeans_Click(object sender, EventArgs e)
        {
            try
            {
                //richTextBox1.Text = "";
                jumlahKluster = Convert.ToInt32(txtCluster.Text);
                pusatkluster = new int[jumlahKluster, grayscale.GetLength(1)];
                distanceEuclidian = new double[grayscale.GetLength(0), jumlahKluster];

                r = new Random();
                int ambilRandom = 0;

                //richTextBox1.Text += "Data Awal\n";
                for (int i = 0; i < grayscale.GetLength(0); i++)
                {
                    //richTextBox1.Text += i.ToString() + " ";
                    for (int j = 0; j < grayscale.GetLength(1); j++)
                    {
                        //richTextBox1.Text += grayscale[i, j] + " ";
                    }
                    // richTextBox1.Text += "\n";
                }

                // richTextBox1.Text += "\n==========================\nPusat Terpilih\n";


                for (int i = 0; i < jumlahKluster; i++)
                {

                    ambilRandom = r.Next(0, grayscale.GetLength(0));
                    //richTextBox1.Text += ambilRandom.ToString() + " ";
                    for (int j = 0; j < grayscale.GetLength(1); j++)
                    {
                        pusatkluster[i, j] = grayscale[ambilRandom, j];
                        //richTextBox1.Text += pusatkluster[i, j] + " ";
                    }
                    //ambilRandom+=1;
                    //richTextBox1.Text += "\n";
                }

                hasilKluster = new int[grayscale.GetLength(1)];
                oldKluster = new int[grayscale.GetLength(1)];
                //richTextBox1.Text += "\n==========================\nMatriks Jarak\n";

                int konvergen = 1;

                int iterasi = 0;
                while (konvergen != 0)
                {
                    iterasi += 1;
                    label12.Text = "Iterasi : " + iterasi.ToString();

                    for (int i = 0; i < grayscale.GetLength(0); i++)
                    {
                        int pilihKluster = 0;
                        // richTextBox1.Text += "\nData ke-" + i.ToString() + "\n";
                        for (int j = 0; j < jumlahKluster; j++)
                        {
                            int totDistance = 0;

                            for (int k = 0; k < grayscale.GetLength(1); k++)
                            {
                                totDistance += Convert.ToInt32(Math.Pow(pusatkluster[j, k] - grayscale[i, k], 2));
                            }
                            distanceEuclidian[i, j] = Convert.ToDouble(Math.Pow(totDistance, 0.5));

                            if (distanceEuclidian[i, j] > 255)
                            {
                                distanceEuclidian[i, j] = 255;
                            }
                            //richTextBox1.Text += distanceEuclidian[i, j].ToString() + " ";

                            if (distanceEuclidian[i, pilihKluster] > distanceEuclidian[i, j])
                            {
                                pilihKluster = j;
                            }

                        }
                        hasilKluster[i] = pilihKluster;
                        //richTextBox1.Text += "\nC = " + hasilKluster[i].ToString();

                    }

                    mean = new int[jumlahKluster];

                    for (int i = 0; i < jumlahKluster; i++)
                    {
                        int jumlah = 0;
                        int tempPusatKluster = 0;
                        for (int j = 0; j < distanceEuclidian.GetLength(0); j++)
                        {
                            if (hasilKluster[j] == i)
                            {
                                jumlah += 1;
                                tempPusatKluster += Convert.ToInt32(distanceEuclidian[j, hasilKluster[j]]);
                            }
                        }

                        //richTextBox1.Text += tempPusatKluster.ToString() + " dan " + jumlah.ToString() + "\n";
                        if (jumlah != 0)
                        {
                            mean[i] = tempPusatKluster / jumlah;
                        }
                        else
                        {
                            mean[i] = 0;
                        }

                    }

                    //richTextBox1.Text += "\n===========Centroid\n";
                    for (int i = 0; i < jumlahKluster; i++)
                    {
                        //richTextBox1.Text += i.ToString() + " = " + mean[i].ToString() + "\n";
                    }


                    nilaiKluster = new int[grayscale.GetLength(0), grayscale.GetLength(1)];

                    //richTextBox1.Text += "\n Pusat kluster Baru";

                    for (int i = 0; i < jumlahKluster; i++)
                    {
                        //richTextBox1.Text += "Pusat Kluster = " + i.ToString() + "\n";

                        for (int j = 0; j < grayscale.GetLength(1); j++)
                        {
                            int jum = 0, tot = 0;
                            int rata = 0;
                            for (int k = 0; k < grayscale.GetLength(0); k++)
                            {
                                if (i == hasilKluster[k])
                                {
                                    tot += 1;
                                    jum += grayscale[k, j];
                                }

                            }

                            if (tot != 0)
                            {
                                rata = jum / tot;
                            }
                            else
                            {
                                rata = 0;
                            }

                            pusatkluster[i, j] = rata;
                            //richTextBox1.Text += rata.ToString() + " ";
                        }
                        //richTextBox1.Text += "\n";
                    }


                    // richTextBox1.Text += "\n===========Matriks Baru\n";
                    for (int i = 0; i < grayscale.GetLength(0); i++)
                    {
                        for (int j = 0; j < grayscale.GetLength(1); j++)
                        {
                            int temp = 0, oldHasil = 0, indeks = 0;
                            for (int k = 0; k < jumlahKluster; k++)
                            {
                                if (k == 0)
                                {

                                    oldHasil = mean[k] - grayscale[i, j];
                                    if (oldHasil < 0)
                                    {
                                        oldHasil = oldHasil * -1;
                                    }
                                    indeks = k;
                                }
                                else
                                {
                                    temp = mean[k] - grayscale[i, j];
                                    if (temp < 0)
                                    {
                                        temp = temp * -1;
                                    }

                                    if (temp < oldHasil)
                                    {
                                        indeks = k;
                                        oldHasil = temp;
                                    }
                                }
                            }

                            grayscale[i, j] = Convert.ToByte(mean[indeks]);
                            //richTextBox1.Text += mean[indeks].ToString() + " ";
                        }

                        //richTextBox1.Text += "\n";
                    }



                    for (int i = 0; i < grayscale.GetLength(1); i++)
                    {
                        if (oldKluster[i] != hasilKluster[i])
                        {
                            konvergen = 1;
                            i = grayscale.GetLength(1);
                        }
                        else
                        {
                            konvergen = 0;
                        }



                    }

                    for (int i = 0; i < grayscale.GetLength(1); i++)
                    {
                        //richTextBox1.Text += oldKluster[i].ToString() + " = " + hasilKluster[i].ToString() + "\n";
                        oldKluster[i] = hasilKluster[i];
                        //richTextBox1.Text += oldKluster[i].ToString() + " = " + hasilKluster[i].ToString() + "\n";

                    }

                    create = new CreateImage(grayscale);

                    this.pictureBoxKMeans.Image = (Image)create.Btmp;
                    MessageBox.Show("Iterasi ke " + iterasi.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        private void cbThreholding_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbThreholding.SelectedItem == "Local")
            {
                radioButtonT1.Enabled = true;
                radioButtonT2.Enabled = true;
                radioButtonT3.Enabled = true;
            }
        }

        private void btnGrayscale2_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.pictureBoxKMeans.Image != null)
                {
                    ReadImage read = new ReadImage(bitmap);
                    byte[,] red = read.Red;
                    byte[,] green = read.Green;
                    byte[,] blue = read.Blue;


                    int mati = red.GetLength(0);
                    int matj = red.GetLength(1);

                    grayscale = new byte[mati, matj];
                    for (int i = 0; i < mati; i++)
                    {
                        for (int j = 0; j < matj; j++)
                        {
                            grayscale[i, j] = Convert.ToByte((red[i, j] + green[i, j] + blue[i, j]) / 3);
                        }
                    }

                    create = new CreateImage(grayscale);

                    this.pictureBoxKMeans.Image = (Image)create.Btmp;

                }
                else
                {
                    MessageBox.Show("Silahkan input gambar");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
            }

        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                bitmap = new Bitmap(openFileDialog1.FileName);
                pictureBoxKMeans.Image = (Image)bitmap;
                txtFile2.Text = openFileDialog1.FileName;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
