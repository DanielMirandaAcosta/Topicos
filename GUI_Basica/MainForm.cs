using System.Windows.Forms;

namespace GUI_Basica
{
    public partial class MainForm : Form
    {
        // Constructor de la clase MainForm
        public MainForm()
        {
            // Inicializa los componentes de la interfaz gr�fica
            InitializeComponent();
        }

        // Evento que se dispara al hacer clic en el men� "Salir"
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cierra la aplicaci�n
            this.Close();
        }

        // Evento que se dispara al hacer clic en el men� "Acerca de"
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mensaje que se mostrar� en el cuadro de di�logo "Acerca de"
            string message = "Gestor de usuarios\n" +
                             "Version 1.0\n" +
                             "Desarrollado por: MIranda Acosta Daniel\n";
            // Muestra un cuadro de mensaje con informaci�n sobre la aplicaci�n
            MessageBox.Show(message, "Acerca de: Gestor de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Evento que se dispara al hacer clic en el bot�n "Agregar"
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // Verifica si alguno de los campos de texto est� vac�o
            if (txtName.Text == "" || txtPhone.Text == "" || txtEmail.Text == "")
            {
                // Mensaje de error en validaci�n de datos
                Image errorIcon = SystemIcons.Error.ToBitmap();

                // Se muestra notificaci�n de error indicando que los campos est�n incompletos
                MostrarToast("Campos incompletos", "Favor de llenar los campos", 3000, errorIcon);
            }
            else
            {
                // Si todos los campos est�n completos, se almacenan los datos en variables
                string name = txtName.Text;
                string phone = txtPhone.Text;
                string email = txtEmail.Text;

                // Se crea la cadena en string para el guardado de usuarios
                string contact = $"Nombre: {name}, Telefono: {phone}, Correo: {email}\n\n";

                // Se agrega el nuevo usuario a la lista de usuarios
                Users.Items.Add(contact);

                // Se limpian los TextBoxes para permitir la entrada de nuevos datos
                ClearTextBoxes();

                // Se muestra un icono de confirmaci�n
                Image okIcon = SystemIcons.Information.ToBitmap();
                // Confirmaci�n de que el usuario se guard� correctamente
                MostrarToast("Confirmacion", "El usuario se registro con exito", 3000, okIcon);
            }
        }

        // Evento que se dispara al hacer clic en el bot�n "Limpiar"
        private void BtnClear_Click(object sender, EventArgs e)
        {
            // Verifica si la lista de usuarios est� vac�a
            if (Users.Items.Count == 0)
            {
                // Muestra un icono de advertencia si no hay usuarios registrados
                Image warningIcon = SystemIcons.Warning.ToBitmap();
                MostrarToast("Lista vacia", "No hay usuarios registrados", 3000, warningIcon);
                return; // Sale del m�todo si no hay usuarios
            }

            // Limpia la lista de usuarios
            Users.Items.Clear();
        }

        // Evento que se dispara al cargar el formulario
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Establece el orden de tabulaci�n para los controles
            txtName.TabIndex = 0;
            txtPhone.TabIndex = 1;
            txtEmail.TabIndex = 2;
            BtnAdd.TabIndex = 3;
            BtnDelete.TabIndex = 4;
            BtnClear.TabIndex = 5;
        }

        // M�todo para mostrar un mensaje emergente (toast)
        private void MostrarToast(string title, string message, int duration, Image icon)
        {
            // Crea una nueva instancia de ToastForm con los par�metros proporcionados
            Notify toast = new Notify(title, message, duration, icon);

            // Posicion del toast en la pantalla
            int margin = 10; // Margen desde el borde de la ventana
            int x = this.Location.X + margin; // Posici�n X
            int y = this.Location.Y + this.ClientSize.Height - toast.Height - margin; // Posici�n Y

            // Establece la ubicaci�n del toast y lo muestra
            toast.Location = new Point(x, y);
            toast.Show();
        }

        // M�todo para limpiar los campos de texto
        private void ClearTextBoxes()
        {
            // Limpia el contenido de los TextBoxes
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
        }

        // Evento que se dispara al hacer clic en el bot�n "Eliminar"
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            // Verifica si hay un usuario seleccionado en la lista
            if (Users.SelectedItem == null)
            {
                // Muestra un icono de error si no se ha seleccionado un usuario
                Image errorIcon = SystemIcons.Error.ToBitmap();
                MostrarToast("Usuario no seleccionado", "Favor de seleccionar algun usuario", 3000, errorIcon);
                return; // Sale del m�todo si no hay selecci�n
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
