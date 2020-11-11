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
    public partial class frmCuentaBancaria : Form
    {
        string UsuarioAplicacion;
        static Form FormularioPadre;
        ClsConexion cn = new ClsConexion();
        public frmCuentaBancaria(string usuario, Form formularioPadre)
        {
            InitializeComponent();
            UsuarioAplicacion = usuario;
            navegador1.Usuario = UsuarioAplicacion;
            FormularioPadre = formularioPadre;
            CargarCombos();
            this.tltAyuda.SetToolTip(this.txtSueldo, "Ingrese el saldo de Actual de la cuenta Bancaria.");
            this.tltAyuda.SetToolTip(this.dtpFecha, "Seleccione la fecha de apertura de la cuenta Bancaria.");
            this.tltAyuda.SetToolTip(this.cmbBanco, "Seleccione el banco al cual pertenece la cuenta bancaria, si no aparece el banco, verifique que el banco este guardado, si no esta guardado debe ingresar uno nuevo.");
            this.tltAyuda.SetToolTip(this.cmbMoneda, "Seleccione el tipo de moneda en el que trabaja la cuenta,si no aparece el tipo de moneda, verifique que la moneda este guardado, si no esta guardado debe ingresar uno nuevo. ");
            this.tltAyuda.SetToolTip(this.cmbPropietario, "Seleccione el propietario de la cuenta ,si no aparece el propietario, verifique que el propietario este guardado, si no esta guardado debe ingresar uno nuevo.");
        }

        void CargarCombos()
        {
            try
            {
                //se obtiene el codigo y el nombre del banco y se asgina a los combos asignados
                string Banco = "SELECT * FROM BANCO ";
                OdbcCommand ComandBanco = new OdbcCommand(Banco, cn.conexion());
                OdbcDataReader MostarBanco = ComandBanco.ExecuteReader();

                while (MostarBanco.Read())
                {
                    cmbCodigoBanco.Items.Add(MostarBanco.GetInt32(0));
                    cmbBanco.Items.Add(MostarBanco.GetString(1));
                }
                //se obtiene el codigo y el nombre del propietario y se asgina a los combos asignados
                string Propietario = "SELECT * FROM PROPIETARIO ";
                OdbcCommand ComandPropietario = new OdbcCommand(Propietario, cn.conexion());
                OdbcDataReader MostrarPropietario = ComandPropietario.ExecuteReader();

                while (MostrarPropietario.Read())
                {
                    cmbCodigoPropietario.Items.Add(MostrarPropietario.GetInt32(0));
                    cmbPropietario.Items.Add(MostrarPropietario.GetString(1));
                }
                //se obtiene el codigo y el nombre del tipo de moneda y se asgina a los combos asignados
                string Moneda = "SELECT * FROM TIPO_MONEDA";
                OdbcCommand ComandMoneda = new OdbcCommand(Moneda, cn.conexion());
                OdbcDataReader MostrarMoneda = ComandMoneda.ExecuteReader();

                while (MostrarMoneda.Read())
                {
                    cmbCodigoMoneda.Items.Add(MostrarMoneda.GetInt32(0));
                    cmbMoneda.Items.Add(MostrarMoneda.GetString(1));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener datos de la tabla banco");
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

        private void rbEstadoActivo_CheckedChanged(object sender, EventArgs e)
        {
            //si se selecciona el radioButon de inactivo, el dato que se reflejara en el campo de texto sera e estado  1
            if (rbtnActivo.Checked == true)
            {
                txtEstado.Text = "1";
            }
        }

        private void rbEstadoInactivo_CheckedChanged(object sender, EventArgs e)
        {
            //si se selecciona el radioButon de inactivo, el dato que se reflejara en el campo de texto sera e estado  0
            if (rbtnInactivo.Checked == true)
            {
                txtEstado.Text = "0";
            }
        }




        private void navegador1_Load(object sender, EventArgs e)
        {
            List<string> CamposTabla = new List<string>();
            List<Control> lista = new List<Control>();
            //el numero de aplicacion se debe cambiar por el numero asignado en la base de datos 
            navegador1.aplicacion = 1305;
            //banco se debe cambiar por la tabla a la que se quiere hacer el mantenimiento
            navegador1.tbl = "cuenta_bancaria";
            //estado_banco se debe cambiar por el estado de la tabla a la que se desea hacer mantenimiento
            navegador1.campoEstado = "estado_apertura_cuenta_bancaria";
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
            try
            {
                navegador1.procCargar();
            }
            catch (Exception ex)
            {

            }
            //en la variable ayuda ruta debe colocar la carpeta y el archivo.chm de su proyecto de ayuda
            navegador1.ayudaRuta = "AyudaFRM/AyudaFRM.chm";
            navegador1.ruta = "Cuenta.html";
        }

        private void txtSueldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //se validan que solo se puedan ingresar numeros con puntos, para simular un numero con punto decimal
            ClsValidaciones validar = new ClsValidaciones();
            validar.funcSueldo(e);
            //se validan la cantidad de caracteres que soporta el campo
            if(txtSueldo.Text.Length > 20)
            {
                MessageBox.Show("No puede ingresar mas de 20 Caracteres", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSueldo.Text = "";
            }
            
        }

        private void cmbBanco_SelectedIndexChanged(object sender, EventArgs e)
        {

            cmbCodigoBanco.SelectedIndex = cmbBanco.SelectedIndex;
        }

        private void cmbCodigoBanco_SelectedIndexChanged(object sender, EventArgs e)
        {
 
            cmbBanco.SelectedIndex = cmbCodigoBanco.SelectedIndex;
        }

        private void cmbPropietario_SelectedIndexChanged(object sender, EventArgs e)
        {
  
            cmbCodigoPropietario.SelectedIndex = cmbPropietario.SelectedIndex;
        }

        private void cmbCodigoPropietario_SelectedIndexChanged(object sender, EventArgs e)
        {
 
            cmbPropietario.SelectedIndex = cmbCodigoPropietario.SelectedIndex;
        }

        private void cmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
 
            cmbCodigoMoneda.SelectedIndex = cmbMoneda.SelectedIndex;
        }

        private void cmbCodigoMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {

            cmbMoneda.SelectedIndex = cmbCodigoMoneda.SelectedIndex;
        }

        private void frmCuentaBancaria_FormClosed(object sender, FormClosedEventArgs e)
        {
        
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
