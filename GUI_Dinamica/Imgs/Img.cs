using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI_Dinamica.Img_s;

namespace GUI_Dinamica.Imgs
{
    public partial class Img : Form
    {
        private FlowLayoutPanel flowLayoutPanel1;
        private List<string> ImgPaths;
        public Img()
        {
            InitializeComponent();
            LoadImgAsync();
        }

        private void InitializeComponent()
        {
            this .flowLayoutPanel1 = new FlowLayoutPanel();
            this.SuspendLayout();

            //FlowLayoutPanel

            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.WrapContents = true;
            this.flowLayoutPanel1.Dock = DockStyle.Fill;
            this.flowLayoutPanel1.Location = new Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel";
            this.flowLayoutPanel1.Size = new Size(800, 450);
            this.flowLayoutPanel1.TabIndex = 0;

            //Img

            this.AutoScaleDimensions = new SizeF(8F, 10F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Img";
            this.Text = "Img";
            this.ResumeLayout(false);
        }

        private async void LoadImgAsync()
        {
            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string path = Path.Combine(projectPath, "Imgs", "imagenes");

            if (Directory.Exists(path)) 
            {
                string[] supportedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
                ImgPaths = Directory.GetFiles(path).Where(file  => supportedExtensions.Contains(Path.GetExtension(file).ToLower())).ToList();
                this.Show(); //Muestra el formulario 

                foreach (string ImgPath in ImgPaths) 
                {
                    await Task.Run(() =>  // Carga una imagen en las miniaturas
                    {
                        using (Image originalImg = Image.FromFile(ImgPath))
                        {
                            Image thumbnail = originalImg.GetThumbnailImage(100, 100, null, IntPtr.Zero); // Crea una miniatura
                            this.Invoke((MethodInvoker)delegate
                            {
                                PictureBox pic = new()
                                {
                                    Image = thumbnail,
                                    Tag = ImgPath,
                                    Name = Path.GetFileName(ImgPath)
                                };
                                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                                pic.Size = new Size(100, 100);
                                pic.Margin = new Padding(5);
                                pic.Cursor = Cursors.Hand;
                                pic.Click += Pic_Click;
                                flowLayoutPanel1.Controls.Add(pic);
                            });
                        }
                    });
                }
            }
            else 
            {
                MessageBox.Show("No se encontro la ubicacion de las imagenes: " + path, "Error Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Pic_Click(object sender, EventArgs e) 
        {
            PictureBox pic = (PictureBox)sender;
            string ImgPath = pic.Tag?.ToString();
            string name = pic.Name.ToString();
            if (string.IsNullOrEmpty(ImgPath)) 
            {
                MessageBox.Show("No se encontro la ruta de las imagen", "Error Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ImgForm imgForm = new (name, ImgPath);
            imgForm.ShowDialog();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (flowLayoutPanel1 != null)
                {
                    foreach (Control control in flowLayoutPanel1.Controls)
                    {
                        if (control is PictureBox pic)
                        {
                            pic.Image?.Dispose();
                            pic.Image = null;
                            pic.Dispose();
                        }
                    }
                    flowLayoutPanel1.Controls.Clear();
                    flowLayoutPanel1.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
