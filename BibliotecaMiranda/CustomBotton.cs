using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaMiranda
{
    public partial class CustomButton : UserControl
    {
        private DoubleClickButton CustomBtn;
        // Evento personalizado que se dispara solo al confirmar
        public event EventHandler ConfirmedDoubleClick;

        public CustomButton()
        {
            InitializeComponent();
            this.Size = new Size(123, 25);
            CustomBtn = new DoubleClickButton();
            CustomBtn.Text = "Custom Button";
            CustomBtn.Name = "CustomBtn";
            CustomBtn.Dock = DockStyle.Fill;
            // Suscribir al evento DoubleClick del botón interno
            CustomBtn.DoubleClick += CustomBtn_DoubleClick;
            CustomBtn.MouseEnter += CustomBtn_Hover;
            CustomBtn.MouseLeave += CustomBtn_Leave;
            this.Controls.Add(CustomBtn);
        }

        private void CustomBtn_Hover(object sender, EventArgs e)
        {
            CustomBtn.BackColor = Color.LightBlue;
        }

        private void CustomBtn_Leave(object sender, EventArgs e)
        {
            CustomBtn.BackColor = Color.White;
        }

        private void CustomBtn_DoubleClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Estás seguro que deseas continuar?",
                "Confirmacion",
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                // Disparar el evento personalizado solo si se confirma
                OnConfirmedDoubleClick(EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Confirmacion Cancelada");
            }
        }

        protected virtual void OnConfirmedDoubleClick(EventArgs e)
        {
            ConfirmedDoubleClick?.Invoke(this, e);
        }
    }

    public class DoubleClickButton : Button
    {
        public DoubleClickButton() : base()
        {
            SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true);
        }
    }
}
