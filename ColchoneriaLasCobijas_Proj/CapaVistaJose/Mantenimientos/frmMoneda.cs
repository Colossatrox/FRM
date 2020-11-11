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
    public partial class frmMoneda : Form
    {
        string UsuarioAplicacion;
        static Form FormularioPadre;
        public frmMoneda(string usuario, Form formularioPadre)
        {
            InitializeComponent();
            UsuarioAplicacion = usuario;
            navegador1.Usuario = UsuarioAplicacion;
            FormularioPadre = formularioPadre;
            this.tltAyuda.SetToolTip(this.txtMoneda,"Ingrese el nombre de la moneda.");
            this.tltAyuda.SetToolTip(this.txtSimbolo, "Ingrese el simbolo de la moneda.");
            this.tltAyuda.SetToolTip(this.txtDescripcion, "Ingrese una descripcion sobre la moneda.");
        }

        private void navegador1_Load(object sender, EventArgs e)
        {
            List<string> CamposTabla = new List<string>();
            List<Control> lista = new List<Control>();
            //el numero de aplicacion se debe cambiar por el numero asignado en la base de datos 
            navegador1.aplicacion = 1303;
            //banco se debe cambiar por la tabla a la que se quiere hacer el mantenimiento
            navegador1.tbl = "tipo_moneda";
            //estado_banco se debe cambiar por el estado de la tabla a la que se desea hacer mantenimiento
            navegador1.campoEstado = "estado_tipo_moneda";
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
            //el dataGridView1 se debe cambiar por el que se tiene en el formulario
            navegador1.DatosActualizar = dgvDatos;
            navegador1.procActualizarData();
            navegador1.procCargar();
            //en la variable ayuda ruta debe colocar la carpeta y el archivo.chm de su proyecto de ayuda
            navegador1.ayudaRuta = "AyudaFRM/AyudaFRM.chm";
            navegador1.ruta = "Moneda.html";
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //si se selecciona el radioButon de inactivo, el dato que se reflejara en el campo de texto sera e estado  1
            if (rbtnActivo.Checked == true)
            {
                txtEstado.Text = "1";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //si se selecciona el radioButon de inactivo, el dato que se reflejara en el campo de texto sera e estado  0
            if (rbtnInactivo.Checked == true)
            {
                txtEstado.Text = "0";
            }
        }

        private void txtMoneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            //se validan que solo se ingresen letras en este campo
            ClsValidaciones Validar = new ClsValidaciones();
            Validar.funcSoloLetras(e);
            //se validan la cantidad de caracteres que soporta el campo
            if (txtMoneda.Text.Length > 40)
            {
                MessageBox.Show("No puede ingresar mas de 40 Caracteres", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMoneda.Text = "";

            }

        }

        private void txtSimbolo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //se validan la cantidad de caracteres que soporta el campo
            if (txtSimbolo.Text.Length > 2)
            {
                MessageBox.Show("No puede ingresar mas de 2 Caracteres", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSimbolo.Text = "";

            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //se validan la cantidad de caracteres que soporta el campoo
            if (txtDescripcion.Text.Length > 70)
            {
                MessageBox.Show("No puede ingresar mas de 70 Caracteres", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescripcion.Text = "";
            }
        }
    }
}
