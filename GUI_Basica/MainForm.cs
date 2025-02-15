using System.Windows.Forms;

namespace GUI_Basica
{
    public partial class MainForm : Form
    {
        // Constructor de la clase MainForm
        public MainForm()
        {
            // Inicializa los componentes de la interfaz gráfica
            InitializeComponent();
        }

        // Evento que se dispara al hacer clic en el menú "Salir"
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cierra la aplicación
            this.Close();
        }

        // Evento que se dispara al hacer clic en el menú "Acerca de"
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mensaje que se mostrará en el cuadro de diálogo "Acerca de"
            string message = "Gestor de usuarios\n" +
                             "Version 1.0\n" +
                             "Desarrollado por: MIranda Acosta Daniel\n";
            // Muestra un cuadro de mensaje con información sobre la aplicación
            MessageBox.Show(message, "Acerca de: Gestor de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Evento que se dispara al hacer clic en el botón "Agregar"
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // Verifica si alguno de los campos de texto está vacío
            if (txtName.Text == "" || txtPhone.Text == "" || txtEmail.Text == "")
            {
                // Mensaje de error en validación de datos
                Image errorIcon = SystemIcons.Error.ToBitmap();

                // Se muestra notificación de error indicando que los campos están incompletos
                MostrarToast("Campos incompletos", "Favor de llenar los campos", 3000, errorIcon);
            }
            else
            {
                // Si todos los campos están completos, se almacenan los datos en variables
                string name = txtName.Text;
                string phone = txtPhone.Text;
                string email = txtEmail.Text;

                // Se crea la cadena en string para el guardado de usuarios
                string contact = $"Nombre: {name}, Telefono: {phone}, Correo: {email}\n\n";

                // Se agrega el nuevo usuario a la lista de usuarios
                Users.Items.Add(contact);

                // Se limpian los TextBoxes para permitir la entrada de nuevos datos
                ClearTextBoxes();

                // Se muestra un icono de confirmación
                Image okIcon = SystemIcons.Information.ToBitmap();
                // Confirmación de que el usuario se guardó correctamente
                MostrarToast("Confirmacion", "El usuario se registro con exito", 3000, okIcon);
            }
        }

        // Evento que se dispara al hacer clic en el botón "Limpiar"
        private void BtnClear_Click(object sender, EventArgs e)
        {
            // Verifica si la lista de usuarios está vacía
            if (Users.Items.Count == 0)
            {
                // Muestra un icono de advertencia si no hay usuarios registrados
                Image warningIcon = SystemIcons.Warning.ToBitmap();
                MostrarToast("Lista vacia", "No hay usuarios registrados", 3000, warningIcon);
                return; // Sale del método si no hay usuarios
            }

            // Limpia la lista de usuarios
            Users.Items.Clear();
        }

        // Evento que se dispara al cargar el formulario
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Establece el orden de tabulación para los controles
            txtName.TabIndex = 0;
            txtPhone.TabIndex = 1;
            txtEmail.TabIndex = 2;
            BtnAdd.TabIndex = 3;
            BtnDelete.TabIndex = 4;
            BtnClear.TabIndex = 5;
        }

        // Método para mostrar un mensaje emergente (toast)
        private void MostrarToast(string title, string message, int duration, Image icon)
        {
            // Crea una nueva instancia de ToastForm con los parámetros proporcionados
            Notify toast = new Notify(title, message, duration, icon);

            // Posicion del toast en la pantalla
            int margin = 10; // Margen desde el borde de la ventana
            int x = this.Location.X + margin; // Posición X
            int y = this.Location.Y + this.ClientSize.Height - toast.Height - margin; // Posición Y

            // Establece la ubicación del toast y lo muestra
            toast.Location = new Point(x, y);
            toast.Show();
        }

        // Método para limpiar los campos de texto
        private void ClearTextBoxes()
        {
            // Limpia el contenido de los TextBoxes
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
        }

        // Evento que se dispara al hacer clic en el botón "Eliminar"
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            // Verifica si hay un usuario seleccionado en la lista
            if (Users.SelectedItem == null)
            {
                // Muestra un icono de error si no se ha seleccionado un usuario
                Image errorIcon = SystemIcons.Error.ToBitmap();
                MostrarToast("Usuario no seleccionado", "Favor de seleccionar algun usuario", 3000, errorIcon);
                return; // Sale del método si no hay selección
            }

            // Elimina el usuario seleccionado de la lista
            Users.Items.Remove(Users.SelectedItem);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
