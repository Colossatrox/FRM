using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControladorSeguridad;

namespace CapaVistaSeguridad.Formularios.Mantenimientos
{
    public partial class frmMantenimientoUsuario : Form
    {
        String ap = "aplicacion";

        string UsuarioAplicacion;

        public frmMantenimientoUsuario(string usuario)
        {
            InitializeComponent();
            
            rbtnHabilitado.Checked = true;
            
            UsuarioAplicacion = usuario;
            navegadorMUsuario.Usuario = UsuarioAplicacion;
        }

     

        
        private void dtl_registro_usuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void navegadorMUsuario_Load(object sender, EventArgs e)
        {
            List<string> CamposTabla = new List<string>();
            List<Control> lista = new List<Control>();
            //List<Control> lista = new List<Control>();
            navegadorMUsuario.aplicacion = 2;
            navegadorMUsuario.tbl = "login";
            navegadorMUsuario.campoEstado = "estado_login";

            //se agregan los componentes del formulario a la lista tipo control

            foreach (Control C in this.Controls)
            {
                if (C.Tag != null)
                {
                    //  MessageBox.Show(""+C.Name)
                    if (C is TextBox)
                    {
                        lista.Add(C);

                    }
                    else if (C is ComboBox)
                    {
                        lista.Add(C);

                    }
                    else if (C is DateTimePicker)
                    {
                        lista.Add(C);

                    }
                }


            }

            navegadorMUsuario.control = lista;
            navegadorMUsuario.DatosActualizar = dtlRegistroUsuario;
            navegadorMUsuario.actualizarData();
            navegadorMUsuario.cargar();
            navegadorMUsuario.ayudaRuta = "AyudasSeguridad/Mantenimiento_Perfil/Mantenimiento_Perfil.chm";
            navegadorMUsuario.ruta = "Mantenimiento-Perfil.html";
            

        }

        private void gbxEstado_Enter(object sender, EventArgs e)
        {

        }

        private void rbtnHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            txtEstado.Text = "1";
        }

        private void rbtnDesabilitado_CheckedChanged(object sender, EventArgs e)
        {
            txtEstado.Text = "0";
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            txtEstado.Text = "1";
        }
    }
}
