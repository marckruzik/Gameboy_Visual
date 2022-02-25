using NS_Gameboy_Visual;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gameboy_Visual_Gui
{

    public partial class MainForm : Form
    {
        public static string URL_GITHUB = "https://github.com/marckruzik/Gameboy_Visual";
        private string filepath;

        public MainForm ()
        {
            InitializeComponent ();

            this.buttonSave.Enabled = false;
            this.checkBoxNoise.Checked = true;
        }

        private void toolStripMenuItem2_Click (object sender, EventArgs e)
        {
            Process.Start ("explorer.exe", URL_GITHUB);
        }

        private void aboutToolStripMenuItem_Click (object sender, EventArgs e)
        {
            AboutForm formPopup = new AboutForm ();
            formPopup.ShowDialog ();
        }

        private void buttonOpen_Click (object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "Select a picture",

                CheckFileExists = true,
                CheckPathExists = true,

                Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (openFileDialog1.ShowDialog () != DialogResult.OK)
            {
                return;
            }

            // string filepath = @"C:\internet\art-1645556867727.jpg";
            this.filepath = openFileDialog1.FileName;
            open_picture ();
        }


        private void open_picture ()
        {
            //Bitmap bmp_before = new Bitmap (this.filepath);
            this.pictureBoxBefore.Image = Image.FromFile(this.filepath);

            bool noise = this.checkBoxNoise.Checked;
            Bitmap bmp_after = Gameboy_Visual.from_path_get_gbbmp (this.filepath, noise);
            this.pictureBoxAfter.Image = bmp_after;

            this.buttonSave.Enabled = true;
        }


        private void buttonSave_Click (object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog ();
            saveFileDialog1.Filter = "PNG Image|*.png|Jpeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.FileName = Path.GetFileNameWithoutExtension (this.filepath);
            
            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.ShowDialog () != DialogResult.OK)
            {
                return;
            }

            save_image (saveFileDialog1.FileName, this.pictureBoxAfter.Image);
        }

        private void save_image (string filepath, Image image)
        {
            // Saves the Image via a FileStream created by the OpenFile method.
            FileStream fs = new FileStream (filepath, FileMode.Create);

            string ext = Path.GetExtension (filepath).ToLower ();
            // Saves the Image in the appropriate ImageFormat based upon the
            // File type selected in the dialog box.
            // NOTE that the FilterIndex property is one-based.
            switch (ext)
            {
                case ".jpg":
                    image.Save (fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                    break;
                case ".bmp":
                    image.Save (fs, System.Drawing.Imaging.ImageFormat.Bmp);
                    break;
                case ".gif":
                    image.Save (fs, System.Drawing.Imaging.ImageFormat.Gif);
                    break;
                case ".png":
                    image.Save (fs, System.Drawing.Imaging.ImageFormat.Png);
                    break;
            }

            fs.Close ();
        }

        private void checkBoxNoise_CheckedChanged (object sender, EventArgs e)
        {
            if (this.pictureBoxBefore.Image == null)
            {
                return;
            }

            open_picture ();
        }

        private void openToolStripMenuItem_Click (object sender, EventArgs e)
        {
            buttonOpen_Click (sender, e);
        }

        private void saveToolStripMenuItem_Click (object sender, EventArgs e)
        {
            buttonSave_Click (sender, e);
        }
    }
}
