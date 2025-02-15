using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Dinamica.Img_s
{
    public partial class ImgForm : Form
    {
        private PictureBox pictureBox;
        private Image image;

        public ImgForm(string name, string ImgPath)
        {
            InitializeComponent();
            ConfigureImageForm(name, ImgPath);
        }

        private void ConfigureImageForm(string name, string imagePath)
        {
            try
            {
                // Cargar la imagen y almacenar una referencia
                image = Image.FromFile(imagePath);

                pictureBox = new PictureBox
                {
                    Image = image,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                };

                this.Controls.Add(pictureBox);
                this.StartPosition = FormStartPosition.CenterParent;
                this.Text = "Imagen: " + name;

                // Ajustar el tamaño del formulario al tamaño de la imagen
                this.ClientSize = new Size(image.Width + 10, image.Height + 10); // +10 para el margen
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Liberar la imagen si se ha cargado correctamente
                if (image != null)
                {
                    image.Dispose();
                    image = null;
                }

                // Liberar la caja de la imagen
                if (pictureBox != null)
                {
                    pictureBox.Dispose();
                    pictureBox = null;
                }
            }
            base.Dispose(disposing);
        }

    }
}
