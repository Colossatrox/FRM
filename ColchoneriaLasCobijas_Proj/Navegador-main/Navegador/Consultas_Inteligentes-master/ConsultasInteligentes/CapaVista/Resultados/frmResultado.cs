using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador;
namespace CapaVista.Resultados
{
    public partial class frmResultado : Form
    {
        public frmResultado()
        {
            InitializeComponent();
        }
        clsControlador cont = new clsControlador();
        private void frmResultado_Load(object sender, EventArgs e)
        {
            try{

            DataTable dt = cont.funcEjecucionConsulta(clsDatoConsulta.consulta);
            dgvDatosMostrar.DataSource = dt;


            }catch (Exception ex) {
                MessageBox.Show("NO ha ingresado los datos correctos para generar la consulta, revise y vuelva a intentarlo ", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            }//fin try catch

        }
    }
}
