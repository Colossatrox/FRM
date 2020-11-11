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
    public partial class frmCuentas : Form
    {
        clsControlador Cn = new clsControlador();
        public DataSet DtsN = null;
        public frmCuentas()
        {
            InitializeComponent();
            procCargaDatos();
        }
        //procedimiento para limpiar el treeview y cargar los datos que estan actualmente en la base de datos
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

        //funcion para obtener el codigo que le toca a la nueva cuenta
        private string funcRecuperaindiceNodo(TreeNode Nodo)
        {
            try
            {
                //Recuperamos la posición del nodo añadido
                TreeNode Tnodo = new TreeNode();
                //obtiene el indice del nodo seleccionado
                string Indice = (tvwCuentas.SelectedNode.Index+1).ToString();
                Tnodo = tvwCuentas.SelectedNode.Parent;
                //recorre los nodos para agregar el camino 
                while (Tnodo != null)
                {
                    Indice = (Tnodo.Index+1).ToString()  + Indice;
                    Tnodo = Tnodo.Parent;
                }
                //devuelve el camino recorrido
                return (Indice);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Source + "\n" + Ex.Message, "Error en recuperaindiceNodo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ("");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int Nivel = 1;
            int Padre = 0;
            string Indice = "";
            bool Res;
            int Codigo = 0;
            try
            {
                //revisa que el nombre de la cuenta este escrito y este seleccionado el tipo de cuenta, de lo contrario no deja avanzar
                if (txtNombreCuenta.Text.Length == 0)
                {
                    MessageBox.Show("Debe de ingresar el nombre de la cuenta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }else if(cmbTipoCuenta.SelectedIndex==0){
                    MessageBox.Show("Debe de seleccionar el tipo de cuenta contable", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }else if (txtNombreCuenta.Text.Length > 75)
                {
                    MessageBox.Show("El nombre no puede tener mas de 75 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Crea un nodo nuevo con el texto introducido
                TreeNode ANode = new TreeNode(txtNombreCuenta.Text.Trim());
                string NodoP, Nodo;
                NodoP = Nodo = "";
                //Comprueba si existen nodos
                if (tvwCuentas.Nodes.Count == 0)
                {   //Si no hay lo añade al nodo raíz
                    NodoP = "";
                    Nodo = ANode.Text;
                    Codigo = 1; Nivel = 1; Padre = 0;
                    tvwCuentas.Nodes.Add(ANode);
                }
                else
                {
                    Nodo = ANode.Text;
                    //si se selecciono algun nodo
                    if (tvwCuentas.SelectedNode != null)
                    {
                        //Añadimos el nodo al treeView
                        tvwCuentas.SelectedNode.Nodes.Add(ANode);
                        //Guardamos el padre, nivel, indice y codigo del nodo para despues guardarlo con la consulta
                        Padre = int.Parse(tvwCuentas.SelectedNode.Name.ToString());
                        Nivel = int.Parse(tvwCuentas.SelectedNode.Tag.ToString())+1;
                        Indice =  funcRecuperaindiceNodo(tvwCuentas.SelectedNode);
                        //obtiene el codigo usando la funcion de cuando se selecciona un nodo
                        Codigo = Cn.funcCodigoMax(int.Parse(Indice));
                        //si la longitud del codigo es la misma del camino obtenido se concatena un 1 sino se suma un 1
                        if (Codigo.ToString().Length == Indice.Length)
                        {
                            string Aux = Indice + "1";
                            Codigo = int.Parse(Aux);
                        }
                        else
                        {
                            Codigo++;
                        }
                    }
                    else //si no se selecciona un nodo se llama a su respectiva funcion 
                    {
                        Codigo = Cn.funcCodigoMaxNivel0(); 
                        Nivel = 1; Padre = 0;
                        MessageBox.Show("La cuenta se va agregar en la raíz ya que no se seleccionó ninguna","AGREGADO A RAIZ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tvwCuentas.Nodes.Add(ANode);
                    }
                }
                /*MessageBox.Show("codigo es: " + Codigo);
                MessageBox.Show("el nivel es " + Nivel);
                MessageBox.Show("el papa es " + Padre);*/
                //se llama a la funcion para hacer la consulta con los datos obtenidos 
                Res = Cn.funcAgregar(Codigo, txtNombreCuenta.Text.ToString(), Nivel, Padre, int.Parse(cmbIdTipoCuenta.SelectedItem.ToString()));
                //se muestra su mensaje dependiendo de la respuesta obtenida
                if (Res == true)
                {
                    MessageBox.Show("La cuenta se agrego correctamente", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("La cuenta no se agrego correctamente", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //LIMPIA
                txtNombreCuenta.Text = "";
                cmbTipoCuenta.SelectedIndex = 0;
                //refresca el treeview
                procCargaDatos();
                tvwCuentas.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en btnNodo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //procedimiento para cargar los items a los combobox del form
        public void procLlenarCmb(string Tabla, string Campo1, ComboBox CmbAgregar)
        {
            string[] Items = Cn.funcItems(Tabla, Campo1);
            for (int I = 0; I < Items.Length; I++)
            {
                if (Items[I] != null)
                {
                    if (Items[I] != "")
                    {
                        CmbAgregar.Items.Add(Items[I]);
                    }
                }
            }
        }

        //al cargar el formulario se llama el procedimiento para cargar los items
        private void frmCuentas_Load(object sender, EventArgs e)
        {
            cmbIdTipoCuenta.Items.Add("Seleccione...");
            cmbTipoCuenta.Items.Add("Seleccione...");
            procLlenarCmb("tipo_cuenta_contable", "pk_id_tipo_cuenta_contable", cmbIdTipoCuenta);
            procLlenarCmb("tipo_cuenta_contable", "nombre_tipo_cuenta_contable", cmbTipoCuenta);
            cmbTipoCuenta.SelectedIndex = 0;
        }

        private void cmbTipoCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            //al cambiar la seleccion del combobox del nombre de tipo de cuenta cambiara automaticamente el del id
            cmbIdTipoCuenta.SelectedIndex = cmbTipoCuenta.SelectedIndex;
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "AyudaBryan/AyudaBryan.chm", "CuentasContables.html");
        }

        private void txtNombreCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            //revisa que puede ingresar letras, tecla de borrar o espacio
            if (Char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space)
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
