using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Custom.DebuggerVisualizer.V12.DebuggerVisulizer
{
    public partial class ImageView : Form
    {
        public ImageView()
        {
            InitializeComponent();
        }

        private void ImageView_Resize(object sender, EventArgs e)
        {
            UpdateViewSize();
        }

        private void ImageView_Load(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                // if image was already set by the time of form loading, update form's size
                int width = System.Math.Max(64, System.Math.Min(800, pictureBox.Image.Width));
                int height = System.Math.Max(64, System.Math.Min(600, pictureBox.Image.Height));
                this.Size = new Size(width + 200, height + 155);
            }
        }

        public void SetImage(Image image)
        {
            pictureBox.Image = image;

            if (image == null)
            {
                toolLog.Text = "Image not set";
            }
            else
            {
                toolLog.Text = string.Format("width: {0}, height: {1}", image.Width, image.Height);
            }

            UpdateViewSize();
        }

        private void UpdateViewSize()
        {
            pictureBox.SuspendLayout();

            int width = 160;
            int height = 120;

            if (pictureBox.Image != null)
            {
                width = pictureBox.Image.Width + 2;
                height = pictureBox.Image.Height + 2;
            }

            int x = (width > imagePanel.ClientSize.Width) ? 0 : (imagePanel.ClientSize.Width - width) / 2;
            int y = (height > imagePanel.ClientSize.Height) ? 0 : (imagePanel.ClientSize.Height - height) / 2;

            pictureBox.Size = new Size(width, height);
            pictureBox.Location = new System.Drawing.Point(x, y);

            pictureBox.ResumeLayout();
        }


        private string Log(string message)
        {
            return string.Format("[{0}]：{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), message);
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImageFormat format = ImageFormat.Jpeg;

                    // resolve file format
                    switch (Path.GetExtension(saveFileDialog.FileName).ToLower())
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                        case ".png":
                            format = ImageFormat.Png;
                            break;
                        default:
                            MessageBox.Show(this, "Unsupported image format was specified", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }

                    // save the image
                    try
                    {
                        pictureBox.Image.Save(saveFileDialog.FileName, format);
                        toolLog.Text = Log("保存成功！" + saveFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "Failed writing image file.\r\n\r\n" + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                Clipboard.SetDataObject(pictureBox.Image);
                toolLog.Text = Log("已复制粘贴板");
            }
        }


        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void stretchImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void centerImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void toolStripDropDownButton1_DropDownOpening(object sender, EventArgs e)
        {
            normalToolStripMenuItem.Checked = (pictureBox.SizeMode == PictureBoxSizeMode.Normal);
            stretchImageToolStripMenuItem.Checked = (pictureBox.SizeMode == PictureBoxSizeMode.StretchImage);
            centerImageToolStripMenuItem.Checked = (pictureBox.SizeMode == PictureBoxSizeMode.CenterImage);
            zoomToolStripMenuItem.Checked = (pictureBox.SizeMode == PictureBoxSizeMode.Zoom);
        }
    }
}

