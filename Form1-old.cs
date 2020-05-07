using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Threading;

namespace ImageUpload
{
    public partial class Form1 : Form
    {
        protected Graphics myGraphics;
        List<ImageClass> ImageList = new List<ImageClass>();
        List<DateTime> UniqueDates = new List<DateTime>();
        List<PictureBox> picBox1 = new List<PictureBox>();
        int ImagesLeft = 0;

        public Form1()
        {
            InitializeComponent();
            myGraphics = Graphics.FromHwnd(panel1.Handle);
            this.Text = "Image Uploader - v5.1";

            //Get save location from file "config.txt"
            //System.IO.StreamReader file = new System.IO.StreamReader("c:\\Projects\\ImageUpload - V5.0\\bin\\Debug\\config.txt");
            System.IO.StreamReader file = new System.IO.StreamReader("config.txt");
            string DriveLetter = file.ReadLine();
            string[] DriveArray = DriveLetter.Split('=');
            Drive.Text = DriveArray[1];
            string ImageDir = file.ReadLine();
            string[] ImageArray = ImageDir.Split('=');
            SaveDirectory.Text = ImageArray[1];
            string HTMLDir = file.ReadLine();
            string[] HTMLArray = HTMLDir.Split('=');
            HTMLFiles.Text = HTMLArray[1];
            string removeString = file.ReadLine();
            string[] removeArray = removeString.Split('=');
            Remove.Text = removeArray[1];

            String ConfigLocation = Directory.GetCurrentDirectory();
            this.Text += " : " + ConfigLocation;

            file.Close();


        }

        //*************************
        // Load Images from disk
        //*************************
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog2.Multiselect = true;
            openFileDialog2.Filter = "JPEG Images|*.jpg;*.JPG";
            
            this.Cursor = Cursors.WaitCursor;            
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog2.FileNames != null)
                {
                    FileInfo startfile = new FileInfo(openFileDialog2.FileNames.First());
                    FileInfo endfile = new FileInfo(openFileDialog2.FileNames.Last());

                    ImagesLeft = openFileDialog2.FileNames.Count();
                    label4.Text = ImagesLeft + " images loaded";
                    textBox1.AppendText("Loading Files " + startfile.Name + " to " + endfile.Name + "\r\n");
                    textBox1.AppendText(ImagesLeft + " total files\r\n");

                    for (int i = 0; i < openFileDialog2.FileNames.Length; i++)
                    {
                        ImageClass newImage = new ImageClass(openFileDialog2.FileNames[i]);
                        ImageList.Add(newImage);
                        //picBox1.Add(new PictureBox());
                        //picBox1[i].Image = ImageList[i].GetThumbnail(ImageList[i].FileName);
                        //picBox1[i].Location = new System.Drawing.Point(12, (100 * i) + (i * 10) + 10);
                        //picBox1[i].Name = i.ToString();
                        //picBox1[i].Size = new System.Drawing.Size(picBox1[i].Image.Width, picBox1[i].Image.Height);
                        //panel1.Controls.Add(picBox1[i]);
                    }
                }
                textBox1.AppendText("Done Loading.\r\n\r\n");
            }
            this.Cursor = Cursors.Default;
        }

        //*************************************
        // Save and Upload Images
        //*************************************
        private void button2_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Drive.Text))
            {
                this.Cursor = Cursors.WaitCursor;

                textBox1.AppendText("\r\nUploading Image files:\r\n");
                progressBar1.Value = 0;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = ImageList.Count;
                for (int i = 0; i < ImageList.Count; i++)
                {
                    //Image Image = ImageList[i].ScaleImage(ImageList[i].FileName);
                    UniqueDates.Add(ImageList[i].creationTime1.Date);

                    //if (ImageList[i].Rotated1 == 6)Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    //if (ImageList[i].Rotated1 == 8)Image.RotateFlip(RotateFlipType.Rotate270FlipNone);

                    //Image.Save(Drive.Text + SaveDirectory.Text + ImageList[i].NameOfFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                    textBox1.AppendText("Image Uploaded: " + ImageList[i].NameOfFile + "\r\n");

                    progressBar1.Value = i;
                    int percent = (int)(((double)progressBar1.Value / (double)progressBar1.Maximum) * 100);  
                    progressBar1.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Arial", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7)); 
                    //Image.Dispose();
                }
                progressBar1.Value = progressBar1.Maximum;
                progressBar1.CreateGraphics().DrawString("Complete", new Font("Arial", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7)); 

                if (!checkBox3.Checked)
                    CreateHTMLPages();
                this.Cursor = Cursors.Default;
            }
            else textBox1.AppendText("Drive does not Exist!!\r\n\r\n ... Aborting Upload ...  \r\n\r\n");
        }

        void CreateHTMLPages()
        {
            textBox1.AppendText("\r\nUploading HTML files:\r\n");

            // create date buckets for daily web page entries.
            IEnumerable<DateTime> Unique = UniqueDates.Distinct();
            List<bool> Exists = new List<bool>();
            List<DateTime> NewList = Unique.ToList();
            List<ImageClass> IList1 = new List<ImageClass>();

            for (int i = 0; i < Unique.Count(); i++)
            {
                for (int j = 0; j < ImageList.Count; j++)
                {
                    if (ImageList[j].creationTime1.Date == NewList[i])
                        IList1.Add(ImageList[j]);
                }
                Exists.Add(false);
                createHTML(IList1, NewList[i], Exists[i]);
                IList1.Clear();
            }

            if (checkBox2.Checked)
            {
                // Append Date to filename and save months
                textBox1.AppendText("\r\nSaving Monthly pages:\r\n");
                SavePages();
            }

            if (checkBox1.Checked)
            {
                // Add links to HTML pages
                textBox1.AppendText("\r\nAdding Tags to Monthly HTML files:\r\n");
                AddLinks(NewList, Exists);
            }
            UniqueDates.Clear();
            textBox1.AppendText("\r\nUpload Done.\r\n\r\n\r\n");

        }

        //*************************************
        // Add links to Monthly HTML pages
        //*************************************
        void AddLinks(List<DateTime> NewList, List<bool> Exists)
        {
            for (int i = 0; i < NewList.Count; i++)
            {
                try
                {
                    if (!Exists[i])
                    {
                        String DriveString = Drive.Text + Remove.Text + "/" + NewList[i].ToString("MMMM") + ".html";
                        String newString = "<br></font><a href='Days/" + NewList[i].Year + "_" + NewList[i].Month + "_" + NewList[i].Day + ".html'>Pictures</a>";
                        String dayString = "  " + NewList[i].Day + Environment.NewLine;
                        File.AppendAllText(DriveString, newString + dayString);
                        textBox1.AppendText("Added Link for Day: " + NewList[i].Day + " to " + NewList[i].ToString("MMMM") + ".html\r\n");
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        //*************************************
        // Add links to Monthly HTML pages
        //*************************************
        void SavePages()
        {
            string sourceDir = Drive.Text + Remove.Text + "/";
            string backupDir = Drive.Text + Remove.Text + "/backup/";
            string DateString = DateTime.Today.Day + "_" + DateTime.Today.Year;
            string MonthString;
            string FileString;

            DateTime dt = new DateTime(2000, 1, 1);
            
            //Make copy of Files
            for (int i = 1; i++ <= 12; dt = dt.AddMonths(1))
            {
                MonthString = dt.ToString("MMMM");
                FileString = Path.Combine(backupDir, MonthString + "_" + DateString + ".html");

                if (File.Exists(FileString))
                {
                    DialogResult dialogResult = MessageBox.Show(MonthString + "_" + DateString + ".html Exists!! Do you want to overwrite the file?", "File Exists!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        File.Copy(Path.Combine(sourceDir, MonthString + ".html"), FileString, true);
                        textBox1.AppendText("Replaced " + MonthString + "_" + DateString + ".html\r\n");
                    }
                    else 
                    {
                        textBox1.AppendText("Did NOT replace " + MonthString + "_" + DateString + ".html\r\n");
                    }

                }
                else
                    File.Copy(Path.Combine(sourceDir, MonthString + ".html"), FileString);
            }

            textBox1.AppendText("Done\r\n");
        }

        //*************************************
        // Create Daily HTML Pages
        //*************************************
        void createHTML(List<ImageClass> nImageList, DateTime FileName, bool Exists)
        {
            String newString = "";
            
            int index = SaveDirectory.Text.IndexOf(Remove.Text);
            string cleanPath = (index < 0)
                ? SaveDirectory.Text
                : SaveDirectory.Text.Remove(index, Remove.Text.Length);
            
            for (int i = 0; i < nImageList.Count; i++)
            {
                newString += "<a href='.." + cleanPath + nImageList[i].NameOfFile + "'>";
//                newString += "<img border='0' src='.." + cleanPath + nImageList[i].NameOfFile + "' width='" + nImageList[i].Thumbnail1.Width + "' height='" + nImageList[i].Thumbnail1.Height + "'></a>";
                newString += "<img border='0' src='.." + cleanPath + nImageList[i].NameOfFile + "' width='100' height='75'></a>";
            }

            String StrFileName = FileName.Year + "_" + FileName.Month + "_" + FileName.Day + ".html";

            UploadViaFile(nImageList, newString, FileName, Exists);
        }

        //*************************************
        // Upload Images via File System
        //*************************************
        void UploadViaFile(List<ImageClass> nImageList, String newString, DateTime FileName, bool Exists)
        {
            StreamWriter SW;
            String StrFileName = FileName.Year + "_" + FileName.Month + "_" + FileName.Day + ".html";
            // see if an html page already exists.  If so, append the data before the final page tag.
            // if it doesn't exist, create a new one and add the information.

            if (File.Exists(Drive.Text + HTMLFiles.Text + StrFileName))
            {
                Exists = true;
                string s = "";
                StreamReader rdr = File.OpenText(Drive.Text + HTMLFiles.Text + StrFileName);
                s = rdr.ReadToEnd();
                newString += "</BODY>\r\n</HTML>";

                string v = s.Replace("</BODY>\r\n</HTML>", newString);
                rdr.Close();
                //File.Delete(Drive.Text + HTMLFiles.Text + StrFileName);
                SW = File.CreateText(Drive.Text + HTMLFiles.Text + StrFileName);
                SW.WriteLine(v);
                SW.Close();
            }
            else
            {
                SW = File.CreateText(Drive.Text + HTMLFiles.Text + StrFileName);
                SW.WriteLine("<HTML>");
                SW.WriteLine("<HEAD>");
                SW.WriteLine("<TITLE>");
                SW.WriteLine(StrFileName);
                SW.WriteLine("</TITLE>");
                SW.WriteLine("</HEAD>");
                SW.WriteLine("<BODY>");
                SW.WriteLine(newString);
                SW.WriteLine("</BODY>");
                SW.WriteLine("</HTML>");
                SW.Close();
            }
            textBox1.AppendText("HTML Page Uploaded: " + StrFileName + "\r\n");
        }
        
        // Clear the image list and start over
        private void button3_Click(object sender, EventArgs e)
        {
            ImageList.Clear();
            panel1.Controls.Clear();
            progressBar1.Value = 0;
        }
    }

    //*************************************
    // Image Class
    //*************************************
    public class ImageClass
    {
        public Image GetThumbnail(string FileName)
        {
            Image Image = Image.FromFile(FileName);
            const double thumbSize = 100.0; // Longer dimension of thumbnails
            int newWidth, newHeight;
            
            Rotated = GetOrientation(Image);
            if (Rotated == 3) Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            if (Rotated == 6) Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            if (Rotated == 8) Image.RotateFlip(RotateFlipType.Rotate270FlipNone);

            if (Image.Height > Image.Width)
            {
                newHeight = (int)thumbSize;
                newWidth = (int)(Image.Width * thumbSize / Image.Height);
            }
            else
            {
                newWidth = (int)thumbSize;
                newHeight = (int)(Image.Height * thumbSize / Image.Width);
            } // end if

            Thumbnail = Image.GetThumbnailImage(newWidth, newHeight, null, new System.IntPtr());
            Image.Dispose();
            return Thumbnail;
        }

        public DateTime GetImageDate(Image Image)
        {
            DateTime creation;
            try
            {
                //Convert date taken from metadata to a DateTime object 
                PropertyItem propItem = Image.GetPropertyItem(306);
                string sdate = Encoding.UTF8.GetString(propItem.Value).Trim();
                string secondhalf = sdate.Substring(sdate.IndexOf(" "), (sdate.Length - sdate.IndexOf(" ")));
                string firsthalf = sdate.Substring(0, 10);
                firsthalf = firsthalf.Replace(":", "-");
                sdate = firsthalf + secondhalf;
                creation = DateTime.Parse(sdate);
            }
            catch
            {
                creation = File.GetCreationTime(FileName);
            }
            return creation;
        }

        public int GetOrientation(Image image)
        {
            try
            {
                PropertyItem propItem = image.GetPropertyItem(274);
                int pv0 = BitConverter.ToInt16(propItem.Value, 0);
                //if (pv0 == "1") return "Correct";
                //if (pv0 == "6") return "Requires Rotation to the Right";
                //if (pv0 == "8") return "Requires Rotation to the Left";
                return pv0;
            }
            catch (Exception e)
            {
                if (e.GetType().ToString() != "System.ArgumentNullException")
                {
                }
            }
            return 0;
        }

        public string GetManufacturer(Image Image)
        {
            try
            {
                PropertyItem propItem1 = Image.GetPropertyItem(0x10F);
                return Encoding.UTF8.GetString(propItem1.Value).Trim();
            }
            catch
            {
                return "0";
            }
        }
        
        public Image ScaleImage(string FileName)
        {
            Image Image = Image.FromFile(FileName);
            Bitmap bmp;
            int newWidth=0, newHeight=0;
            bool landscape = true;
            String Camera = "";

            creationTime = GetImageDate(Image);
            string Manufacturer = GetManufacturer(Image);

            if (Manufacturer.IndexOf("NIKON") == 0)
                Camera = "Nikon";
            else if (Manufacturer.IndexOf("Canon\0") == 0)
                Camera = "Canon";
            else if (Manufacturer.IndexOf("PENTAX") == 0)
                Camera = "Pentax";
            if (Image.Height > Image.Width)
                landscape = false;

            // 640 x 480 - Small Landscape (PENTAX) - 640x480
            // 480 x 640 - Small (PENTAX) - 480x640
            // 4288 x 2848 - Big Landscape (NIKON) 722x480
            // 2848 x 4288 - Big (NIKON) - 480x722
            // 4000 x 3000 - Big Landscape (Canon\0) - 640x480
            // 3000 x 4000 - Big (Canon\0) - 480x640
            switch (Camera)
            {
                case "Nikon":
                    if (landscape == true)
                    {
                        newWidth = 722;
                        newHeight = 480;
                    }
                    else
                    {
                        newWidth = 480;
                        newHeight = 722;
                    }
                    break;
                case "Pentax":
                case "Canon":
                default:
                    if (landscape == true)
                    {
                        newWidth = 640;
                        newHeight = 480;
                    }
                    else
                    {
                        newWidth = 480;
                        newHeight = 640;
                    }
                    break;
            }
            bmp = new Bitmap(newWidth, newHeight);

            ////create a new graphic from the Bitmap
            Graphics graphic = Graphics.FromImage((Image)bmp);
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

            graphic.DrawImage(Image, 0, 0, newWidth, newHeight);

            ////dispose and free up the resources
            graphic.Dispose();
            Image.Dispose();

            ////set the image
            //SmallImage = (Image)bmp;
            Exists = false;
            return bmp;

        }

        public ImageClass(string FileName)
        {
            FileName = FileName.Replace(".jpg", ".JPG");
            fileName = FileName;
            nameOfFile = new FileInfo(FileName).Name;
        }

        private bool Exists;
        public bool Exists1
        {
            get { return Exists; }
            set {Exists = value; }
        }

        private string fileName;
        public string FileName
        {
            get { return fileName; }
        }
        
        private int Rotated = 0;
        public int Rotated1
        {
            set { Rotated = value; }
            get { return Rotated; }
        }

        private DateTime creationTime;
        public DateTime creationTime1
        {
            get { return creationTime; }
        }

        private string nameOfFile;
        public string NameOfFile
        {
            get { return nameOfFile; }
        }

        private Image Thumbnail;
        public Image Thumbnail1
        {
            get { return Thumbnail; }
        }        
    }
}
