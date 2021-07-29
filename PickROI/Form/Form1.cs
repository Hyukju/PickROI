using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection; // doublebuffer
using System.IO;

namespace PickROI
{
    public partial class Form1 : Form
    {
        ImageViewer imgViewer;
        public Form1()
        {
            InitializeComponent();

            //this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            //this.SetStyle(ControlStyles.Selectable, false);
            //this.UpdateStyles();

        }
        
        private void OpenImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Multiselect = true;
            openFileDlg.DefaultExt = "PNG";
            openFileDlg.Filter = "Image Files(*.png;*.bmp;*.jpg;*.tif;*.gif)|*.png;*.bmp;*.jpg;*.tif;*.gif|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg|TIFF (*.tif)|*.tif|GIF(*.gif)|*.gif|All files(*.*)|*.*";

            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                imgViewer.ImshowFilePath(openFileDlg.FileNames);                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imgViewer = new ImageViewer();
            this.Controls.Add(imgViewer);            
            this.Controls.Add(this.menuStrip1);

            //
            imgViewer.Dock = DockStyle.Fill;
            //
            Assembly assemObj = Assembly.GetExecutingAssembly();
            Version v = assemObj.GetName().Version;

            this.Text = "PickROI " + v.Major.ToString() + "." + v.Minor.ToString();

        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image  
            // assigned to Button2.  
            
            if (!imgViewer.IsExist())
            {
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "저장할 영상 파일이 존재하지 않습니다.";
                string caption = "Error no image file";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                
            }
            else
            {
                SaveFileDialog saveFileDlg = new SaveFileDialog();
                saveFileDlg.Filter = "Png Image|*.png|JPeg Image|*.jpg|Bitmap Image(24-bit)|*.bmp|Bitmap Image(32-bit)|*.bmp|Tiff Image|*.tif";
                saveFileDlg.Title = "Save an Image File";


                if (saveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    // If the file name is not an empty string open it for saving.  
                    if (saveFileDlg.FileName != "")
                    {
                        System.IO.FileStream fs = (System.IO.FileStream)saveFileDlg.OpenFile();
                        imgViewer.SaveAs(imgViewer._image, fs, saveFileDlg.FilterIndex);
                        fs.Close();
                    }
                }
            }
            
            
        }

        private void OpenRaw_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDlg = new OpenFileDialog();
            //openFileDlg.Multiselect = true;            
            //openFileDlg.Filter = "RAW(*.raw)|*.raw";
            
            //if (openFileDlg.ShowDialog() == DialogResult.OK)
            //{
               
            //}
        }
    }
       
    public static class ExtenstionMedthods
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty);
            pi.SetValue(dgv, setting, null);
        }
    }


}
