using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace hOcrImageMapper
{
    public partial class Form1 : Form
    {
        private Image mImage = null;
        private Rectangle mHoverRectangle = Rectangle.Empty;
        private int mScaleFactor = 5;

        public Form1()
        {
            InitializeComponent();

            pictureBox1.Paint += pictureBox1_Paint;
        }

        Label GetLabel(int top, int left, string text, int[] coords)
        {
            Label label = new Label();
            label.Top = top;
            label.Left = left;
            label.Text = text;
            label.Visible = true;
            label.Name = string.Format("{0}={1}-{2}-{3}-{4}", text, coords[0], coords[1], coords[2], coords[3]);
            label.Click += label_Click;
            label.MouseLeave += label_MouseLeave;
            label.MouseEnter += label_MouseEnter;
            label.Size = label.PreferredSize;

            return label;
        }

        void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (mHoverRectangle != Rectangle.Empty)
            {
                using (Brush b = new SolidBrush(Color.FromArgb(150, Color.GreenYellow)))
                {
                    e.Graphics.FillRectangle(b, mHoverRectangle);
                }
            }
        }

        void label_MouseEnter(object sender, EventArgs e)
        {
            string[] coords = ((Label)sender).Name.Split('=')[1].Split('-');

            int x = Convert.ToInt32(coords[0]) / mScaleFactor;
            int y = Convert.ToInt32(coords[1]) / mScaleFactor;
            int width = (Convert.ToInt32(coords[2]) / mScaleFactor) - (Convert.ToInt32(coords[0]) / mScaleFactor);
            int height = (Convert.ToInt32(coords[3]) / mScaleFactor) - (Convert.ToInt32(coords[1]) / mScaleFactor);

            mHoverRectangle = new Rectangle(x, y, width, height);

            pictureBox1.Invalidate();
        }

        void label_MouseLeave(object sender, EventArgs e)
        {
            mHoverRectangle = Rectangle.Empty;
            pictureBox1.Invalidate();
        }

        void label_Click(object sender, EventArgs e)
        {
            MessageBox.Show(((Label)sender).Name);
        }

        private void btnSelectImageFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog().ToString() == "OK")
            {
                if (LoadImageFile(openFileDialog1.FileName))
                {
                    txtImageFile.Text = openFileDialog1.FileName;
                    btnZoomIn.Visible = true;
                    btnZoomOut.Visible = true;
                }
            }
        }

        private bool LoadImageFile(string fileName)
        {
            bool loaded = true;

            // Get the image
            try
            {
                mImage = Image.FromStream(File.OpenRead(fileName));
                mScaleFactor = (mImage.Height / pictureBox1.Height) + 1;
                SetPictureBoxSource(mImage, mScaleFactor);
            }
            catch
            {
                MessageBox.Show("Error loading the image: " + fileName);
                loaded = false;
            }

            return loaded;
        }

        private void btnSelectOcrFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog().ToString() == "OK")
            {
                if (LoadOcrText(openFileDialog1.FileName))
                {
                    txtOcrFile.Text = openFileDialog1.FileName;
                }
            }
        }

        private bool LoadOcrText(string fileName)
        {
            bool loaded = true;
            panel1.Controls.Clear();

            try
            {
                string ocrRaw = File.ReadAllText(fileName);
                TextPage hOcrPage = new Parser().ParseHOcr(ocrRaw);

                int wordCount = 0;
                int top = 3;

                foreach (TextLine line in hOcrPage.lines)
                {
                    int left = 3;
                    Label label = null;
                    foreach (TextWord word in line.words)
                    {
                        label = GetLabel(top, left, word.text, new int[] { word.x1, word.y1, word.x2, word.y2 });
                        panel1.Controls.Add(label);
                        left = label.Right + 1;
                        wordCount++;
                    }
                    top = label.Bottom + 1;
                }

                if (wordCount == 0) MessageBox.Show("No words founds");
            }
            catch
            {
                MessageBox.Show("Error reading and parsing the hOCR file: " + fileName);
                loaded = false;
            }

            return loaded;
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            mScaleFactor--;
            SetPictureBoxSource(mImage, mScaleFactor);
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            mScaleFactor++;
            SetPictureBoxSource(mImage, mScaleFactor);
        }

        private void SetPictureBoxSource(Image image, int scaleFactor)
        {
            Bitmap objBitmap = new Bitmap(image, new Size(image.Width / scaleFactor, image.Height / scaleFactor));
            pictureBox1.Width = objBitmap.Width;
            pictureBox1.Height = objBitmap.Height;
            pictureBox1.Image = objBitmap;
        }

        private void form_Resize(object sender, EventArgs e)
        {
            panel1.Height = Form1.ActiveForm.Height - 95;
            panel2.Height = Form1.ActiveForm.Height - 115;
            panel2.Width = Form1.ActiveForm.Width - 520;
        }
    }
}
