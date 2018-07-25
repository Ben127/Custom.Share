using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualStudio.DebuggerVisualizers;


[assembly: System.Diagnostics.DebuggerVisualizer(
typeof(Custom.DebuggerVisualizer.ImageCustomDebuggerVisulizer),
typeof(VisualizerObjectSource),
Target = typeof(System.Drawing.Image),
Description = "Image Visualizer")]


namespace Custom.DebuggerVisualizer
{

    /// <summary>
    ///  ImageCustomDebuggerVisulizer
    ///     图片调试器
    /// </summary>
    public class ImageCustomDebuggerVisulizer : CustomDebuggerVisualizer
    {

        protected override void Show(Microsoft.VisualStudio.DebuggerVisualizers.IDialogVisualizerService windowService, Microsoft.VisualStudio.DebuggerVisualizers.IVisualizerObjectProvider objectProvider)
        {
            Image image = (Image)objectProvider.GetObject();
            Form form = image == null ? new Form() : CreateForm(image);
            windowService.ShowDialog(form);
        }



        private Form CreateForm(Image image)
        {
            Form form = new Form();
            int Height = 0;
            int Width = 0;
            SetFormSize(image, out Height, out Width);

            PictureBox picture = new PictureBox();

            // form
            form.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            form.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            form.ClientSize = new System.Drawing.Size(253, 171);

            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            form.MaximizeBox = false;
            form.Name = "Form1";
            form.ShowIcon = false;
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.Text = "图片可视化工具";
            form.Width = Width;
            form.Height = Height;

            ((System.ComponentModel.ISupportInitialize)(picture)).BeginInit();
            form.SuspendLayout();

            // picture
            picture.Location = new System.Drawing.Point(0, 0);
            picture.Size = new System.Drawing.Size(253, 171);
            picture.Dock = System.Windows.Forms.DockStyle.Fill;
            picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picture.Name = "pictureBox1";
            picture.Image = image;
            picture.Width = Width;
            picture.Height = Height;

            form.Controls.Add(picture);

            ((System.ComponentModel.ISupportInitialize)(picture)).EndInit();
            form.ResumeLayout(false);

            return form;
        }


        private void SetFormSize(Image image, out int Height, out int Width)
        {
            Height = Screen.PrimaryScreen.Bounds.Height / 2;
            Width = Screen.PrimaryScreen.Bounds.Width / 2;

            // 判断当前图片是否不超过屏幕大小的一半
            if (image.Width <= Width &&
                image.Height <= Height)
            {
                Height = image.Height;
                Width = image.Width;
            }

        }



    }
}
