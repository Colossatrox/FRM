using CapaControladorBryan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVistaBryan.Mantenimientos
{
    public partial class frmPolizas : Form
    {
        clsControlador Cn = new clsControlador();
        public DataSet DtsN = null;
        public frmPolizas()
        {
            InitializeComponent();
            procCargaDatos();
            dgvPoliza.Rows.Add("TOTAL", "", "0.00", "0.00");
        }
        public void procCargaDatos()
        {
            //limpia el treeview
            tvwCuentas.Nodes.Clear();
            try
            {
                //obtiene los datos para llenar el treeview en un dataset
                DtsN = Cn.funcLlenarTree();
                //crea la estructura de arbol para el treeview
                procCrearNodosDelPadre(0, null);
                //expande todas las categorias del treeview
                tvwCuentas.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en cargaDatosSQL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //procedimiento recursivo que crea la estructura de arbol para el treeview
        private void procCrearNodosDelPadre(int IndicePadre, TreeNode NodoPadre)
        {
            // Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
            DataView DataViewHijos = new DataView(DtsN.Tables["cuenta_contable"]);
            //filra los resultados por el indice pasado
            DataViewHijos.RowFilter = DtsN.Tables["cuenta_contable"].Columns["fk_cuenta_padre_cuenta_contable"].ColumnName + " = " + IndicePadre;
            foreach (DataRowView DataRowActual in DataViewHijos)
            {
                //por cada resultado encontrado crea el nodo y le asisnga su nombre, texto a mostrar y tag que es el nivel
                TreeNode NuevoNodo = new TreeNode();
                NuevoNodo.Text = DataRowActual["nombre_cuenta_contable"].ToString().Trim();
                NuevoNodo.Name = DataRowActual["pk_id_cuenta_contable"].ToString().Trim();
                NuevoNodo.Tag = DataRowActual["nivel_cuenta_contable"].ToString().Trim();
                // si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
                // del primer nivel que no dependen de otro nodo.
                if (NodoPadre == null)
                    tvwCuentas.Nodes.Add(NuevoNodo);
                else
                    NodoPadre.Nodes.Add(NuevoNodo); // se añade el nuevo nodo al nodo padre.
                // Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.
                procCrearNodosDelPadre(Int32.Parse(DataRowActual["pk_id_cuenta_contable"].ToString()), NuevoNodo);
            }
        }

        

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //revisa que puede ingresar letras, tecla de borrar o espacio
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)46)
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //revisa que la cantidad no este vacia
            if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                MessageBox.Show("Debe de ingresar la cantidad", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(rbtnDebe.Checked==false && rbtnHaber.Checked == false)
            {
                MessageBox.Show("Debe de marcar si es debe o haber", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //revisa que sea un double o int lo de cantidad
                try
                {
                    double.Parse(txtCantidad.Text.ToString());
                    //si se selecciona alguna cuenta
                    if (tvwCuentas.SelectedNode != null)
                    {
                        //se obtiene el codigo de la cuenta seleccionada
                        string CuentaSeleccionada = tvwCuentas.SelectedNode.Name.ToString();
                        //si la cuenta es de naturaleza deudora
                        if (CuentaSeleccionada.StartsWith("1") || CuentaSeleccionada.StartsWith("4"))
                        {
                            //si esta marcado el radiobutton de HABER
                            if (rbtnHaber.Checked == true)
                            {
                                //revisa si hay saldo suficiente y lo agrega al datagrid sino muestra un mensaje de que no hay saldo suficiente
                                if (Cn.funcSaldoBueno(int.Parse(CuentaSeleccionada), double.Parse(txtCantidad.Text.ToString())))
                                {
                                    dgvPoliza.Rows.Insert(dgvPoliza.Rows.Count - 1, CuentaSeleccionada, tvwCuentas.SelectedNode.Text.ToString(), "", txtCantidad.Text.ToString(),"1");
                                    procSuma();
                                }
                                else
                                {
                                    MessageBox.Show("La cuenta seleccionada actualmente no cuenta con el saldo necesario", "SALDO NO DISPONIBLE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                dgvPoliza.Rows.Insert(dgvPoliza.Rows.Count - 1, CuentaSeleccionada, tvwCuentas.SelectedNode.Text.ToString(), txtCantidad.Text.ToString(), "", "1");
                                procSuma();
                            }
                        }
                        else //si es acreedora
                        {
                            //si esta marcado el radiobutton de DEBE
                            if (rbtnDebe.Checked == true)
                            {
                                //revisa si hay saldo suficiente y lo agrega al datagrid sino muestra un mensaje de que no hay saldo suficiente
                                if (Cn.funcSaldoBueno(int.Parse(CuentaSeleccionada), double.Parse(txtCantidad.Text.ToString())))
                                {
                                    dgvPoliza.Rows.Insert(dgvPoliza.Rows.Count - 1, CuentaSeleccionada, tvwCuentas.SelectedNode.Text.ToString(), txtCantidad.Text.ToString(),"", "2");
                                    procSuma();
                                }
                                else
                                {
                                    MessageBox.Show("La cuenta seleccionada actualmente no cuenta con el saldo necesario", "SALDO NO DISPONIBLE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                dgvPoliza.Rows.Insert(dgvPoliza.Rows.Count - 1, CuentaSeleccionada, tvwCuentas.SelectedNode.Text.ToString(), "", txtCantidad.Text.ToString(), "2");
                                procSuma();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe de seleccionar una cuenta contable", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("El numero ingresado en cantidad no es correcto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void procSuma()
        {
            double Debe=0, Haber=0;
            if (dgvPoliza.Rows.Count > 0)
            {
                for (int i = 0; i < dgvPoliza.Rows.Count - 1; i++)
                {
                    if (dgvPoliza.Rows[i].Cells[2].Value.ToString() != "")
                    {
                        Debe += double.Parse(dgvPoliza.Rows[i].Cells[2].Value.ToString());
                    }
                    if (dgvPoliza.Rows[i].Cells[3].Value.ToString() != "")
                    {
                        Haber += double.Parse(dgvPoliza.Rows[i].Cells[3].Value.ToString());
                    }
                }
                dgvPoliza.Rows[dgvPoliza.Rows.Count - 1].Cells[2].Value = Debe.ToString();
                dgvPoliza.Rows[dgvPoliza.Rows.Count - 1].Cells[3].Value = Haber.ToString();
            }
            else
            {
                dgvPoliza.Rows.Add("TOTAL", "", "0.00", "0.00");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //revisar que la descripcion no este vacia
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Debe de ingresar la descripción de la póliza", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if (dgvPoliza.Rows.Count <= 2) //revisa que al menos tenga dos partes
            {
                MessageBox.Show("La póliza debe de contener al menos 2 partes", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if(dgvPoliza.Rows[dgvPoliza.Rows.Count-1].Cells[2].Value.ToString()!= dgvPoliza.Rows[dgvPoliza.Rows.Count - 1].Cells[3].Value.ToString())//revisa que el total del debe sea igual al del haber
            {
                MessageBox.Show("El valor de la columna del DEBE no es igual a la de HABER y deben ser iguales", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int Error = 0, Hacer = 0; ;
                if (chkPeticion.Checked)
                {
                    Hacer = 1;
                    if (txtCodPeticion.Text.Length == 0)
                    {
                        MessageBox.Show("Debe de escribir el codigo de la peticion", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Error = 1;
                    }
                    else
                    {
                        bool Resp=Cn.funcBuscarPeticion(int.Parse(txtCodPeticion.Text.ToString()));
                        if (Resp == false)
                        {
                            MessageBox.Show("El codigo de peticion ingresado no existe", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Error = 1;
                        }
                    }
                }
                if (Error != 1)
                {
                    if (txtDescripcion.Text.Length > 75)
                    {
                        MessageBox.Show("La descripcion no puede contener mas de 75 caracteres", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        int Codigo = Cn.funcCodigoMaximo("POLIZA_ENCABEZADO", "PK_POLIZA_ENCABEZADO");
                        DateTime Fecha = DateTime.Now;
                        bool Respuesta = Cn.funcAgregarPolEnc(Codigo, Fecha, txtDescripcion.Text.ToString(), double.Parse(dgvPoliza.Rows[dgvPoliza.Rows.Count - 1].Cells[2].Value.ToString()));
                        if (Respuesta)
                        {
                            if (Hacer == 1)
                            {
                                Respuesta = Cn.funcModificarPeticion(int.Parse(txtCodPeticion.Text.ToString()), Codigo);
                            }
                            for (int i = 0; i < dgvPoliza.Rows.Count - 1; i++)
                            {
                                string Debe, Haber;
                                double Monto = 0;
                                int DebeHaber = 0;
                                int CodigoCuenta = int.Parse(dgvPoliza.Rows[i].Cells[0].Value.ToString());
                                Debe = dgvPoliza.Rows[i].Cells[2].Value.ToString();
                                if (Debe.Length == 0)
                                {
                                    Haber = dgvPoliza.Rows[i].Cells[3].Value.ToString();
                                    Monto = double.Parse(Haber);
                                }
                                else
                                {
                                    Monto = double.Parse(Debe);
                                    DebeHaber = 1;
                                }
                                Respuesta = Cn.funcAgregarPolDet(Codigo, CodigoCuenta, Monto, DebeHaber);
                                if (Respuesta)
                                {
                                    int Operacion = 0;
                                    if (DebeHaber == 1 && dgvPoliza.Rows[i].Cells[4].Value.ToString().Equals("1"))
                                    {
                                        Operacion = 1;
                                    }
                                    else if (DebeHaber == 1 && dgvPoliza.Rows[i].Cells[4].Value.ToString().Equals("2"))
                                    {
                                        Operacion = 2;
                                    }
                                    else if (DebeHaber == 0 && dgvPoliza.Rows[i].Cells[4].Value.ToString().Equals("1"))
                                    {
                                        Operacion = 2;
                                    }
                                    else if (DebeHaber == 0 && dgvPoliza.Rows[i].Cells[4].Value.ToString().Equals("2"))
                                    {
                                        Operacion = 1;
                                    }
                                    procModificarSaldos(CodigoCuenta, Operacion, Monto);
                                }
                            }
                            MessageBox.Show("Póliza Guardada", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtDescripcion.Text = "";
                            txtCantidad.Text = "";
                            chkPeticion.Checked = false;
                            rbtnDebe.Checked = false;
                            rbtnHaber.Checked = false;
                            txtCodPeticion.Text = "";
                            dgvPoliza.Rows.Clear();
                            dgvPoliza.Rows.Add("TOTAL", "", "0.00", "0.00");
                        }
                        else
                        {
                            //hubo error al guardar el encabezado de la poliza

                        }
                    }
                }    
            }
        }
        private void procModificarSaldos(int Cuenta, int Operacion,double Cantidad)
        {
            var Respuesta = Cn.funcObtenerPadreSaldo(Cuenta);
            int Padre = Respuesta.Item1;
            double Saldo = Respuesta.Item2;
            if (Operacion == 1)
            {
                Saldo += Cantidad;
            }
            else
            {
                Saldo -= Cantidad;
            }
            bool Modificado = Cn.funcModificarSaldo(Cuenta, Saldo);
            //MessageBox.Show("MODIFICADO" + Modificado);
            if (Padre != 0)
            {
                procModificarSaldos(Padre, Operacion, Cantidad);
            }
        }

        private void chkPeticion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPeticion.Checked)
            {
                txtCodPeticion.Visible = true;
                lblCodPeticion.Visible = true;
                btnVerPeticiones.Visible = true;
            }
            else
            {
                txtCodPeticion.Visible = false;
                lblCodPeticion.Visible = false;
                btnVerPeticiones.Visible = false;
            }
        }

        private void btnVerPeticiones_Click(object sender, EventArgs e)
        {
            frmVerPeticiones Peticiones = new frmVerPeticiones();
            Peticiones.Show();
        }

        private void dgvPoliza_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            procSuma();
        }

        private void txtCodPeticion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //revisa que puede ingresar letras, tecla de borrar o espacio
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

    }
}
