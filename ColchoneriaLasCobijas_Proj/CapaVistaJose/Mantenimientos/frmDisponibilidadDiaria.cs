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
    public partial class frmDisponibilidadDiaria : Form
    {
        ClsConexion cn = new ClsConexion();
        public frmDisponibilidadDiaria()
        {
            InitializeComponent();
            CargarDatos();
        }

        void CargarDatos()
        {
            //procedimiento que carga los datos al dataGridView
            try
            {
                string cadena = " SELECT CB.PK_ID_NUMERO_CUENTA_BANCARIA AS CUENTA_BANCARIA, P.nombre_propietario AS NOMBRE_PROPIETARIO, B.NOMBRE_BANCO AS BANCO, MO.MONEDA_TIPO_MONEDA AS TIPO_MONEDA, CB.SALDO_CUENTA_BANCARIA AS SALDO FROM propietario P, cuenta_bancaria CB,banco B,tipo_moneda MO WHERE P.pk_id_propietario = CB.fk_id_propietario AND MO.pk_id_tipo_moneda = CB.fk_id_tipo_moneda and B.pk_id_banco = CB.fk_id_banco ";
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            /*se llama a la funcion CargarDatos que realiza una consulta donde se obtienen datos especificos de la base de datos
            para presentarlos en el DataGridView*/
            CargarDatos();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "AyudaFRM/AyudaFRM.chm", "Disponibilidad.html");
        }
    }
}
