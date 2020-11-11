
using CapaControladorSeguridad;
using System;
using System.Data.Odbc;
using System.Drawing;
using System.Windows.Forms;

namespace CapaVistaSeguridad
{
    public partial class frmLogin : Form
    {

        clsControladorPerfil controlador = new clsControladorPerfil();
        clsVistaBitacora cn = new clsVistaBitacora();
        public frmLogin()
        {
            InitializeComponent();
            //CODIFICACION PARA EL TEXTFIELD DE CONTRASEÑA
            txtPassword.PasswordChar = '*';

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //CODIGO PARA HACER TRASLUCIDO EL PANEL
            pnlBlanco.BackColor = Color.FromArgb(25, 0, 0, 0);
        }


        private void btn_salir_Click(object sender, EventArgs e)
        {
             System.Windows.Forms.Application.Exit();
        }

        public string usuario()
        {
            return txtUsuario.Text;
        }
        int contador = 0;
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (contador <= 3)
            {
                if (controlador.Login(txtUsuario.Text, txtPassword.Text) == 1)
                {
                    //para registro de usuario en bitacora
                    cn.user(txtUsuario.Text);
                    cn.insert("Logeo Exitoso", 1);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    //para registro de usuario en bitacora  
                    cn.user(txtUsuario.Text);
                    cn.insert("Logeo erroneo", 1);
                    contador++;
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }
            }
            if (contador > 3)
            {
                //para registro de usuario en bitacora  
                cn.user(txtUsuario.Text);
                cn.insert("Logeo erroneo bloqueo de Usuario", 1);
                controlador.BloquearUsuario(txtUsuario.Text);
                MessageBox.Show("A completado los intentos posibles, el usuario a sido Bloqueado por seguridad, contacte a su jefe inmediato.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
