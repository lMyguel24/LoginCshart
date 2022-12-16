using System.Drawing.Text;
using System.Runtime.InteropServices;
using Domain;

namespace Presentancion
{
    public partial class Login : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public Login()
        {
            InitializeComponent();
        }
        private void msgError()
        {
            ErrorMensaje.Text = "Datos Incorrectos";
            ErrorMensaje.Visible = true;
            textUsuario.Clear();
            textPass.Clear();
            textUsuario.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void buttonAcceder_Click(object sender, EventArgs e)
        {
            if(textUsuario.Text != string.Empty && textPass.Text != string.Empty)
            {
                UserModel user = new UserModel();
                var ValidLogin = user.LoginUser(textUsuario.Text, textPass.Text);
                if(ValidLogin == true)
                {
                    Formulario formulario = new Formulario();
                    formulario.Show();
                    formulario.FormClosed += Logout;
                    this.Hide();
                }
                else
                {
                    msgError();

                }

            }
            else if (textUsuario.Text == string.Empty)
            {
                msgError();

            }
            else if(textPass.Text == string.Empty)
            {
                msgError();


            }
            else 
            {
                msgError();
            }

        }
        
        private void Logout(object sender, FormClosedEventArgs e)
        {
            textUsuario.Clear();
            textPass.Clear();
            ErrorMensaje.Visible=false;
            this.Show();
            textUsuario.Focus();


        }

        private void textPass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == (char)Keys.Enter) { 
                buttonAcceder_Click(sender, e);
            }
        }

        private void textUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                buttonAcceder_Click(sender, e);
            }
        }

    }
    
}