using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVistaJose.Mantenimientos
{
    public partial class MantenimientosBancos1302 : Form
    {

        string UsuarioAplicacion;
        static Form FormularioPadre;
        public MantenimientosBancos1302(string usuario, Form formularioPadre)
        {
            InitializeComponent();
            UsuarioAplicacion = usuario;
            navegador1.Usuario = UsuarioAplicacion;
            FormularioPadre = formularioPadre;
            this.tltAyuda.SetToolTip(this.txtBanco,"Ingrese el nombre del Banco.");
        }

        private void rbEstadoInactivo_CheckedChanged(object sender, EventArgs e)
        {
            //si se selecciona el radioButon de inactivo, el dato que se reflejara en el campo de texto sera e estado  0
            if (rbtnInactivo.Checked == true)
            {
                txtEstado.Text = "0";
            }
        }

        private void rbEstadoActivo_CheckedChanged(object sender, EventArgs e)
        {
            //si se selecciona el radioButon de inactivo, el dato que se reflejara en el campo de texto sera e estado  1

            if (rbtnActivo.Checked == true)
            {
                txtEstado.Text = "1";
            }
        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {
            //si el campo estado esta vacio coloca los 2 radioButons en falso, para que se puedan volver a seleccionar
            if (txtEstado.Text == "")
            {
                rbtnActivo.Checked = false;
                rbtnInactivo.Checked = false;
            }
            if (txtEstado.Text == "1")
            {
                rbtnActivo.Checked = true;
            }
        }

        private void navegador1_Load(object sender, EventArgs e)
        {
            List<string> CamposTabla = new List<string>();
            List<Control> lista = new List<Control>();
            navegador1.aplicacion = 1302;
            navegador1.tbl = "banco";
            navegador1.campoEstado = "estado_banco";
            navegador1.MDIformulario = FormularioPadre;
            foreach (Control C in this.Controls)
            {
                if ((C.Tag != null) && (!C.Tag.ToString().Equals("")))
                {
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
            navegador1.control = lista;
            navegador1.formulario = this;
            navegador1.DatosActualizar = dgvDatos;
            navegador1.procActualizarData();
            navegador1.procCargar();
            navegador1.ayudaRuta = "AyudaFRM/AyudaFRM.chm";
            navegador1.ruta = "Bancos.html";
        }

        private void txtBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            //se validan de que solo se puedan ingresar letras en este campo
            ClsValidaciones Validar = new ClsValidaciones();
            Validar.funcSoloLetras(e);
            //se valida la cantidad de caracteres que puede ingresar en el campo
            if (txtBanco.Text.Length > 40)
            {
                MessageBox.Show("No puede ingresar mas de 40 Caracteres", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);  
                txtBanco.Text = "";
            }
          
        }
    }
}
