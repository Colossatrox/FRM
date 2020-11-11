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
    public partial class frmTransacciones : Form
    {

        ClsConexion cn = new ClsConexion();
        int numero = 0;
        int codigoA = 0;
        float SaldoActual;
        float montoTransaccion, saldoNuevo;
        public frmTransacciones()
        {
            InitializeComponent();
            procCodigoA();
            CargarCombos();
            CargarDatos();

            this.tltAyuda.SetToolTip(this.txtMonto, "Ingrese el monto de la transaccion.");
            this.tltAyuda.SetToolTip(this.txtSaldoActual, "saldo actual de la cuenta bancaria.");
            this.tltAyuda.SetToolTip(this.txtDescripcion, "Ingrese una descripcion sobre la transaccion que se va a realizar.");
            this.tltAyuda.SetToolTip(this.dtpFecha, "Seleccione la fecha de la transaccion.");
            this.tltAyuda.SetToolTip(this.cmbCodigoCuenta, "Seleccione una cuenta bancaria, si no aparece la cuenta bancaria, verifique que la cuenta este guardado, si no esta guardado debe ingresar uno nuevo.");
            this.tltAyuda.SetToolTip(this.cmbMoneda, "Seleccione el tipo de moneda en el que trabaja la cuenta,si no aparece el tipo de moneda, verifique que la moneda este guardado, si no esta guardado debe ingresar uno nuevo. ");
            this.tltAyuda.SetToolTip(this.cmbTransaccion, "Seleccione el tipo de transaccion ,si no aparece tipo de transaccion, verifique que tipo de transaccion este guardado, si no esta guardado debe ingresar uno nuevo.");

        }
        //funcion que realiza el codigo automatico para almacenar los datos en la base de datos
        void procCodigoA()
        {
            try
            //esta funcion hace un conteo de los datos que se encuentran en la tabla pelicula y almacena ese valor en la variable numero

            {
                string contador = "SELECT count(pk_id_transaccion) FROM TRANSACCION ";
                OdbcCommand comando = new OdbcCommand(contador, cn.conexion());
                numero = Convert.ToInt32(comando.ExecuteScalar());
                //si numero = 0, no encuentra ningun registro convierte el cidigoA en 1 y envia ese codigo para guardado como ID
                if (numero == 0)
                {
                    codigoA = 1;
                }
                else
                {
                    //de lo contrario se ira incrementando + 1 codigoA
                    codigoA = numero + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
        //funcion que actualiza el saldo en la tabla cuenta despues de realizar una transaccion
        void NuevoSaldo()
        {
                try
                {
                    //se realiza la consulta de insertar en tabla pelicula con sus respectivos campos
                    string Insertar = "UPDATE cuenta_bancaria set saldo_cuenta_bancaria = " + saldoNuevo + " where pk_id_numero_cuenta_bancaria = " + Int32.Parse(cmbCodigoCuenta.SelectedItem.ToString()) + " ";
                    OdbcCommand comm = new OdbcCommand(Insertar, cn.conexion());
                    OdbcDataReader mostrarC = comm.ExecuteReader();
                }
                catch (Exception ex)
                {
                MessageBox.Show("Registro no valido, intente de nuevo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        } 
                          
        //funcion para cargar los datos de la base de datos a los combo Box
        void CargarCombos()
        {
            try
            {
                //se obtiene el codigo y el nombre de la cuenta bancaria y se asgina a los combos asignados
                string Banco = "SELECT * FROM CUENTA_BANCARIA ";
                OdbcCommand ComandBanco = new OdbcCommand(Banco, cn.conexion());
                OdbcDataReader MostarBanco = ComandBanco.ExecuteReader();

                while (MostarBanco.Read())
                {
                    cmbCodigoCuenta.Items.Add(MostarBanco.GetString(0));
                }
                //se obtiene el codigo y el nombre del tipo de transaccion y se asgina a los combos asignados
                string Propietario = "SELECT * FROM TIPO_TRANSACCION ";
                OdbcCommand ComandPropietario = new OdbcCommand(Propietario, cn.conexion());
                OdbcDataReader MostrarPropietario = ComandPropietario.ExecuteReader();

                while (MostrarPropietario.Read())
                {
                    cmbCodigoTransaccion.Items.Add(MostrarPropietario.GetInt32(0));
                    cmbTransaccion.Items.Add(MostrarPropietario.GetString(1));
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

        //funcion para cargar los datos en el dataGridView
        void CargarDatos()
        {
            //procedimiento que carga los datos al dataGridView
            try
            {
                string cadena = " SELECT T.pk_id_transaccion AS CODIGO, C.pk_id_numero_cuenta_bancaria AS CUENTA_BANCARIA , T.monto_transaccion AS MONTO,TT.nombre_tipo_transaccion AS TIPO_DE_TRANSACCION ,T.descripcion_transaccion AS DESCRIPCION, T.FECHA_TRANSACCION FROM transaccion T ,cuenta_bancaria C ,tipo_transaccion TT WHERE T.fk_id_numero_cuenta_bancaria = C.pk_id_numero_cuenta_bancaria AND T.fk_id_tipo_transaccion = TT.pk_id_tipo_transaccion;  ";
                OdbcDataAdapter datos = new OdbcDataAdapter(cadena, cn.conexion());
                DataTable dt = new DataTable();
                datos.Fill(dt);
                dgvDatos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los registros en este momento intente mas tarde" + ex);
            }

        }

        void procLimpiar()
        {

            //funcion para limpiar los controles del formulario 
            cmbCodigoCuenta.Items.Clear();
            cmbCodigoTransaccion.Items.Clear();
            cmbCodigoMoneda.Items.Clear();
            cmbTransaccion.Items.Clear();
            txtDescripcion.Text = "";
            cmbMoneda.Items.Clear();
            txtMonto.Text = "";
            txtSaldoActual.Text = "";
        }

        void IngresoDeTransaccion()
        {
            //esta funcion es llamada en el boton de guardar, y esta funcion realiza la consulta donde se almacenan los datos en la base de datos
            String Fecha = dtpFecha.Value.ToString("yyyy-MM-dd HH:MM");
            try
            {
                //se realiza la consulta de insertar en tabla pelicula con sus respectivos campos
                string Insertar = "INSERT INTO TRANSACCION (pk_id_transaccion,fk_id_numero_cuenta_bancaria,fecha_transaccion,fk_id_tipo_transaccion,fk_id_tipo_moneda,monto_transaccion,descripcion_transaccion) " +
                "VALUES (" + codigoA + "," + Int32.Parse(cmbCodigoCuenta.SelectedItem.ToString()) + ",'" + Fecha + "'," + Int32.Parse(cmbCodigoTransaccion.SelectedItem.ToString()) + ",'" + Int32.Parse(cmbCodigoMoneda.SelectedItem.ToString()) + "', " + txtMonto.Text + ",'" + txtDescripcion.Text + "' )";
                OdbcCommand comm = new OdbcCommand(Insertar, cn.conexion());
                OdbcDataReader mostrarC = comm.ExecuteReader();
                MessageBox.Show("Los Datos se ingresaron correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Registro no valido, intente de nuevo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            procLimpiar();
            procCodigoA();
            CargarCombos();
            CargarDatos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
            //Este if verifica que no se deje ningun campo en blanco, si hay uno en blando muestra el mensaje de que se necesitan llenar los campos
            if (txtDescripcion.Text == "" || txtMonto.Text == "" || cmbCodigoCuenta.SelectedItem == null || cmbTransaccion.SelectedItem == null || cmbMoneda.SelectedItem == null)
            {
                MessageBox.Show("NO DEBE DEJAR CAMPOS VACIOS", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int OpcionTransaccion = Int32.Parse(cmbCodigoTransaccion.SelectedItem.ToString());
                try
                {
                    float.Parse(txtMonto.Text.ToString());
                    montoTransaccion = float.Parse(txtMonto.Text.ToString());
                    if (OpcionTransaccion == 1)
                    {
                        saldoNuevo = SaldoActual + montoTransaccion;
                        NuevoSaldo();
                        IngresoDeTransaccion();
                    }
                    else
                  if (OpcionTransaccion == 2)
                    {
                        if (SaldoActual < montoTransaccion)
                        {
                            MessageBox.Show("El monto del retiro es mayor, al saldo actual de la cuenta. Verifique que el monto este ingresado correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            saldoNuevo = SaldoActual - montoTransaccion;
                            NuevoSaldo();
                            IngresoDeTransaccion();
                        }
                    }else if(OpcionTransaccion != 1 || OpcionTransaccion != 2)
                    {
                        MessageBox.Show("Verifique que la operacion sea una RETIRO O UN DEPOSITO.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("El monto ingresado no es valido", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

               
            }
        }

        private void cmbCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //se validan que solo se ingresen numeros enteros o numeros con punto decimal
            ClsValidaciones VALIDAR = new ClsValidaciones();
            VALIDAR.funcSueldo(e);
            //se validan la cantidad de caracteres que soporta el campo
            if (txtMonto.Text.Length > 20)
            {
                MessageBox.Show("No puede ingresar mas de 20 Numeros", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMonto.Text = "";

            }
           
        }

        private void cmbCodigoCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Se obtine el monto actual de la cuenta
                string Banco = "SELECT * FROM CUENTA_BANCARIA WHERE pk_id_numero_cuenta_bancaria = " + Int32.Parse(cmbCodigoCuenta.SelectedItem.ToString());
                OdbcCommand ComandBanco = new OdbcCommand(Banco, cn.conexion());
                OdbcDataReader MostarBanco = ComandBanco.ExecuteReader();

                while (MostarBanco.Read())
                {
                    txtSaldoActual.Text = (MostarBanco.GetDouble(4)).ToString();
                    try
                    {
                        //al obetener el saldo actual de la cuenta se verifica si se puede convertir a un tipo float, si no se puede convertir el saldo esta almacenado incorrectamente
                        float.Parse(txtSaldoActual.Text.ToString());
                        SaldoActual = float.Parse(txtSaldoActual.Text.ToString());
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error al obtener el saldo actual de la cuenta bancaria, verifique que el numero almacenado sea valido", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener Datos" + ex);
            }
        }

        private void cmbTransaccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCodigoTransaccion.SelectedIndex = cmbTransaccion.SelectedIndex;
        }

        private void cmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCodigoMoneda.SelectedIndex = cmbMoneda.SelectedIndex;
        }

        private void cmbCodigoTransaccion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Esta Seguro de cancelar la transaccion?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.OK)
            {
                procLimpiar();
                CargarCombos();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "AyudaFRM/AyudaFRM.chm", "Transacciones.html");
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //se validan la cantidad de caracteres que soporta el campo
            if (txtDescripcion.Text.Length > 40)
            {
                MessageBox.Show("No puede ingresar mas de 40 Caracteres", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescripcion.Text = "";
            }
        }
    }
}
