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
    public partial class frmLibroDiario : Form
    {
        clsControlador Cn = new clsControlador();
        List<int> ListaPolizas = new List<int>();
        public frmLibroDiario()
        {
            InitializeComponent();
            cmbAnio.Items.Add("...");
            for(int i = 0; i <= 5; i++)
            {
                cmbAnio.Items.Add((2020 + i).ToString());
            }
            cmbAnio.SelectedIndex = 0;
            cmbMes.SelectedIndex = 0;
        }

        private void cmbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAnio.SelectedIndex != 0)
            {
                ListaPolizas.Clear();
                ListaPolizas = Cn.funcObtenerPolizas(cmbMes.SelectedIndex,int.Parse(cmbAnio.SelectedItem.ToString()));
                procCargarDatos();
            }
        }

        private void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAnio.SelectedIndex != 0)
            {
                ListaPolizas.Clear();
                ListaPolizas = Cn.funcObtenerPolizas(cmbMes.SelectedIndex, int.Parse(cmbAnio.SelectedItem.ToString()));
                procCargarDatos();
            }
        }

        public void procCargarDatos()
        {
            dgvPoliza.Rows.Clear();
            for(int i = 0; i < ListaPolizas.Count; i++)
            {
                //obtener los datos de la poliza actual
                var PolizaEnc = Cn.funcObtenerDatoPolEnc(ListaPolizas[i]);
                dgvPoliza.Rows.Add(PolizaEnc.Item2.ToString(), PolizaEnc.Item1.ToString(), " ", " ");
                //obtener las cuentas de ese encabezado
                List<int> CuentasDetalle = new List<int>();
                CuentasDetalle = Cn.funcObtenerDetalles(ListaPolizas[i]);
                //MessageBox.Show("POLIZA" + ListaPolizas[i] + " CUENTA" + CuentasDetalle[0]);
                //buscar datos de esa poliza y esa cuenta
                for(int j = 0; j < CuentasDetalle.Count; j++)
                {
                    var Detalle = Cn.funcObtenerDatoPolDet(ListaPolizas[i], CuentasDetalle[j]);
                    if (Detalle.Item3 == 1)
                    {
                        dgvPoliza.Rows.Add(" ", Detalle.Item1, Detalle.Item2.ToString(), " ");
                    }
                    else
                    {
                        dgvPoliza.Rows.Add(" ", "               "+Detalle.Item1, " ",Detalle.Item2.ToString());
                    }                   
                }
                dgvPoliza.Rows.Add(" ", PolizaEnc.Item3, PolizaEnc.Item4.ToString(), PolizaEnc.Item4.ToString());
                dgvPoliza.Rows.Add(" ", " ", " ", " ");
            }
        }
    }
}
