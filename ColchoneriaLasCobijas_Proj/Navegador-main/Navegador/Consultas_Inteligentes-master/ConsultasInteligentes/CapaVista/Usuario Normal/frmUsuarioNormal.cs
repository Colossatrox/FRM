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
using CapaControlador;
using System.Collections;
using CapaVista.Resultados;

namespace CapaVista.Usuario_Normal
{
    public partial class frmUsuarioNormal : Form
    {

        clsControlador cont = new clsControlador();
        
        //variable que obtiene el dato del txt
        string ValorComparar;
        //variable que obtiene que tipo de operador se usará en la consulta
        string operador;
        //variable que obtiene el dato del dgvCamposCreacion
        string campo;
        //nombre de la tabla de prueba
        string tabla;



        public frmUsuarioNormal(string Tabla)
        {
            tabla = Tabla;
            InitializeComponent();
            actualizardatagriew();
        }


        public void actualizardatagriew()
        {

            DataSet Datos = cont.funcLlenarCampos(tabla);

            //ciclo que recorre la fila de las columnas hasta que ya no hayan más
            for (int i = 0; i < Datos.Tables[0].Columns.Count; i++)
                {
                    //se agregan los nombres de las columnas al dgvCamposCreacion
                    dgvCamposCreacion.Rows.Add(Datos.Tables[0].Columns[i].ColumnName);

                }
        }


        public void dgvCamposCreacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //variable que obtiene el contenido de la celda a la que se le dió clic en dgvCamposCreacion
                campo = dgvCamposCreacion.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe de Seleccionar un dato de la tabla, NO el encabezado de la tabla ", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    
        }


        public void creacionConsulta()
        {
            //variable que obtiene el contenido del txtValorCreacion
            ValorComparar = txtValorCreacion.Text;
            //ciclo if para saber que radioButton se está seleccionando, la variable operador obtiene el valor dependiendo el radioButton
            if (rbtnMayorCreacion.Checked == true )
            {
                operador = ">";
            }
            if (rbtnMenorCreacion.Checked == true)
            {
                operador = "<";
            }
            if (rbtnIgualCreacion.Checked == true)
            {
                operador = "=";
            }

            //ciclo if para verificar la cadena que se ingresa con las opciones dadas en los radiobuttons
            if (funcIsNumeric(ValorComparar) == false && (rbtnMayorCreacion.Checked == true || rbtnMenorCreacion.Checked == true))
            {

                MessageBox.Show("Verifique el tipo de opción para generar la consulta", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                //condicion if para mostrar la consulta sin comillas simples ya que muestra los valores al ingresar una cadena de texto
                // que sea un número y compararla con un mayor
                if (rbtnMayorCreacion.Checked == true)
                {
                    //variable que arma toda la consulta 
                    clsDatoConsulta.consulta = "SELECT * FROM " + tabla + " WHERE " + campo + " " + operador + " " + ValorComparar + ";";
                    frmResultado frmSr = new frmResultado();
                    frmSr.Show();


                }
                else
                {
                    //variable que arma toda la consulta 
                    clsDatoConsulta.consulta = "SELECT * FROM " + tabla + " WHERE " + campo + " " + operador + " '" + ValorComparar + "';";
                    frmResultado frmSr = new frmResultado();
                    frmSr.Show();
                }

            }


        }



        //función para verificar si una variable es solamente una cadena de números o una cadena de texto
        public bool funcIsNumeric(object Expression)

        {

            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;

        }


        private void btnBuscarCreacion_Click(object sender, EventArgs e)
        {

            if(rbtnIgualCreacion.Checked == false && rbtnMayorCreacion.Checked == false && rbtnMenorCreacion.Checked == false || txtValorCreacion.Text == ""){
                MessageBox.Show("No ha llenado Todos los Componentes para Realizar la Consulta", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else{
                creacionConsulta();
                
            }

        }

        private void btnCancelarCreacion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUsuarioNormal_Load(object sender, EventArgs e)
        {
            //Se limpia la selección automática en la celda del datagrid que aparece al ejecutar la ventana en
            dgvCamposCreacion.ClearSelection();
        }
    }
}
