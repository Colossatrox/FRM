using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace CapaVistaJose.Mantenimientos
{
    public partial class frmPeticionPoliza : Form
    {
        ClsConexion cn = new ClsConexion();
        ClsValidaciones validar = new ClsValidaciones();
        string UsuarioAplicacion;
        static Form FormularioPadre;
        public frmPeticionPoliza(string usuario, Form formularioPadre)
        {
            InitializeComponent();
            UsuarioAplicacion = usuario;
            navegador1.Usuario = UsuarioAplicacion;
            FormularioPadre = formularioPadre;
            this.tltAyuda.SetToolTip(this.txtConcepto, "Ingrese el concepto de la poliza.");
            this.tltAyuda.SetToolTip(this.txtDescripcion, "Ingrese una descripcion sobre la poliza.");
            this.tltAyuda.SetToolTip(this.txtMonto, "Ingrese el monto de la poliza.");
            this.tltAyuda.SetToolTip(this.dtpFecha, "Seleccione una fecha que no sea superior a la de hoy.");
        }

        private void navegador1_Load(object sender, EventArgs e)
        {
            List<string> CamposTabla = new List<string>();
            List<Control> lista = new List<Control>();
            navegador1.aplicacion = 1309;
            navegador1.tbl = "peticion_poliza";
            navegador1.campoEstado = "estado_peticion_poliza";
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
            try
            {
                navegador1.procCargar();
            }
            catch(Exception ex)
            {

            }
            navegador1.ayudaRuta = "AyudaFRM/AyudaFRM.chm";
            navegador1.ruta = "Peticion.html";
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

        private void rdbActivo_CheckedChanged(object sender, EventArgs e)
        {
            //si se selecciona el radioButon de inactivo, el dato que se reflejara en el campo de texto sera e estado  1
            if (rbtnActivo.Checked == true)
            {
                txtEstado.Text = "1";
            }
        }

        private void rdbInactivo_CheckedChanged(object sender, EventArgs e)
        {
            //si se selecciona el radioButon de inactivo, el dato que se reflejara en el campo de texto sera e estado  0
            if (rbtnInactivo.Checked == true)
            {
                txtEstado.Text = "0";
            }
        }

        private void txtPeticionEncabezado_TextChanged(object sender, EventArgs e)
        {
            txtPeticionEncabezado.Text = txtPolizaSeguridad.Text;
        }

        private void txtConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //se validan la cantidad de caracteres que soporta el campo
            if (txtConcepto.Text.Length > 30)
            {
                MessageBox.Show("No puede ingresar mas de 30 Caracteres", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtConcepto.Text = "";
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //se validan la cantidad de caracteres que soporta el campo
            if (txtDescripcion.Text.Length > 100)
            {
                MessageBox.Show("No puede ingresar mas de 100 Caracteres", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescripcion.Text = "";
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //se validan que solo se ingresen numeros enteros o numeros con punto decimal
            validar.funcSueldo(e);
            //se validan la cantidad de caracteres que soporta el campo
            if (txtMonto.Text.Length > 12)
            {
                MessageBox.Show("No puede ingresar mas de 12 Caracteres", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMonto.Text = "";
            }
        }

        private void dtpFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dtpFecha.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("La fecha no puede ser mayor a la fecha de Hoy.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
