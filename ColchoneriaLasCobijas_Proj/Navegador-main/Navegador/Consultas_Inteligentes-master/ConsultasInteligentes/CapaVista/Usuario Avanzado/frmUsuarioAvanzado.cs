using CapaControlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista.Usuario_Avanzado
{
    public partial class frmUsuarioAvanzado : Form
    {

        string tabla = "";
        string s1 = "", s2 = "", s3 = "";
        string sentencia = "";

        public frmUsuarioAvanzado()
        {
            InitializeComponent();
            funcTablas();
        }

        clsControlador Cont = new clsControlador();

        private void funcTablas()
        {
            DataTable Datos = Cont.funcItemsTablas();
            cmbTablasCreacion.DisplayMember = Datos.Columns[0].ToString();
            cmbTablasCreacion.DataSource = Datos;
            cmbTablasCreacion.ResetText();
        }

        private void funcCampos()
        {
            tabla = cmbTablasCreacion.Text;
            DataTable Campos = Cont.funcItemsCampos(tabla);
            cmbCampoCreacion.DisplayMember = Campos.Columns[3].ToString();
            cmbCampoCreacion.DataSource = Campos;
            cmbCampoCreacion.ResetText();

        }
        private void funcLlenarCmb() {

            DataTable dt = new DataTable();
            dt.Clear();
            cmbCampoComparacionCreacion.Items.Clear();
            cmbCampoAgruparCreacion.Items.Clear();
            dt.Columns.Add("clmCampo", typeof(System.String));
            foreach (DataGridViewRow rowGrid in dgvCamposCreacion.Rows)
            {
                DataRow row = dt.NewRow();
                row["clmCampo"] = Convert.ToString(rowGrid.Cells[0].Value);

                dt.Rows.Add(row);
            }
            foreach (DataRow row in dt.Rows)
            {
                cmbCampoComparacionCreacion.Items.Add(row[0].ToString());
                cmbCampoAgruparCreacion.Items.Add(row[0].ToString());
            }
        }

        private void frmUsuarioAvanzado_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregarTablaCreacion_Click(object sender, EventArgs e)
        {

            if (dgvTablasCreacion.RowCount > -1)
            {
                // Primero averigua si el registro existe:
                bool existe = false;
                for (int i = 0; i < dgvTablasCreacion.RowCount; i++)
                {
                    if (Convert.ToString(dgvTablasCreacion.Rows[i].Cells["clmTabla"].Value) == cmbTablasCreacion.Text)
                    {
                        MessageBox.Show("La tabla ya esta ingresada");
                        existe = true;
                        break;
                    }
                }
                if (existe == false)
                {
                    
                    dgvTablasCreacion.Rows.Add(cmbTablasCreacion.Text);
                    cmbTablasCreacion.Enabled = false;
                    btnAgregarTablaCreacion.Enabled = false;
                    funcCampos();
                }
            }
        }

        private void btnQuitarTablaCreacion_Click(object sender, EventArgs e)
        {
            if (dgvTablasCreacion.SelectedRows.Count > 0)
            {
                dgvTablasCreacion.Rows.Remove(dgvTablasCreacion.CurrentRow);
                cmbTablasCreacion.Enabled = true;
                btnAgregarTablaCreacion.Enabled = true;
                cmbCampoCreacion.Text = "";
                txtAliasCreacion.Text = "";
                dgvCamposCreacion.Rows.Clear();
            }

        }

        private void btnAgregarCampoCreacion_Click(object sender, EventArgs e)
        {
            if (chkTodosCamp.Checked == true) {

                dgvCamposCreacion.Rows.Add("*", "Todos los campos");
                funcLlenarCmb();
            }
            else{
                if(cmbCampoCreacion.Text!=""||txtAliasCreacion.Text != ""){
                    // Primero averigua si el registro existe:
                    bool existe = false;
                    for (int i = 0; i < dgvCamposCreacion.RowCount; i++)
                    {
                        if (Convert.ToString(dgvCamposCreacion.Rows[i].Cells["clmCampo"].Value) == cmbCampoCreacion.Text)
                        {
                            MessageBox.Show("La tabla ya esta ingresada");
                            existe = true;
                            break;
                        }
                    }
                    if (existe == false)
                    {

                        dgvCamposCreacion.Rows.Add(cmbCampoCreacion.Text, txtAliasCreacion.Text);
                        funcLlenarCmb();
                    }
                }
            }

        }

        private void chkTodosCamp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodosCamp.Checked == true) {
                txtAliasCreacion.Enabled = false;
                cmbCampoCreacion.Enabled = false;
                txtAliasCreacion.Text = "";
                cmbCampoCreacion.Text = "";
            }
            else
            {
                txtAliasCreacion.Enabled = true;
                cmbCampoCreacion.Enabled = true;
            }
        }

        private void btnQuitarCampoCreacion_Click(object sender, EventArgs e)
        {
            if (dgvCamposCreacion.SelectedRows.Count > 0)
            {
                dgvCamposCreacion.Rows.Remove(dgvCamposCreacion.CurrentRow);
                funcLlenarCmb();
            }
        }

        private void btnGuardarCreacion_Click(object sender, EventArgs e)
        {
            if (txtNombreCreacion.Text == "") { MessageBox.Show("Debe ingresar un nombre para la consulta"); }
            else
            {
                s1 = funcSentencia1(s1);
                s3 = funcSentencia3(s3);
                if (s3 == "")
                {
                    s3 = ";";
                }
                sentencia = s1 + s2 + s3;
                Cont.funcGuardarConsulta(sentencia, txtNombreCreacion.Text);
                txtConsultaCreacion.Text = sentencia;
     
                MessageBox.Show("Consulta guardada");
                funcVaciarCampos();
                funcLimpiar();
            }
        }

        

        private void btnAgregarCondiCreacion_Click(object sender, EventArgs e)
        {
            s2 = funcSentencia2(s2);
            if (gbxLogicaCreacion.Enabled == false)
            {
                gbxLogicaCreacion.Enabled = true;
            }
            cmbCampoComparacionCreacion.Text = "";
            txtValorCreacion.Text = "";
            chkAndCreacion.Checked = false;
            chkOrCreacion.Checked = false;
            rbtnIgualCreacion.Checked = false;
            rbtnMayorCreacion.Checked = false;
            rbtnMenorCreacion.Checked = false;
        }

        private string funcSentencia1(string s1)
        {
            string campos = "";
            for (int i = 0; i < dgvCamposCreacion.RowCount; i++)
            {

                if (i == dgvCamposCreacion.RowCount - 1)
                {
                    campos += Convert.ToString(dgvCamposCreacion.Rows[i].Cells["clmCampo"].Value);
                }
                else
                {
                    campos += Convert.ToString(dgvCamposCreacion.Rows[i].Cells["clmCampo"].Value) + ", ";
                }

            }
            s1 = "SELECT " + campos + " FROM " + tabla;
            return s1;
        }

        private string funcSentencia2(string s2)
        {
            string campocomp = "";
            string comparador = "";
            string valorcomp = "";

            if (gbxLogicaCreacion.Enabled == false)
            {
                campocomp = funcCampocomp(campocomp);
                comparador = funcComparador(comparador);
                valorcomp = funcValorcomp(valorcomp);
                s2 = " WHERE " + campocomp + " " + comparador + " '" + valorcomp+"'";
            }
            else
            {
                campocomp = funcCampocomp(campocomp);
                comparador = funcComparador(comparador);
                valorcomp = funcValorcomp(valorcomp);
                if (chkAndCreacion.Checked == true)
                {
                    if (chkOrCreacion.Checked == true)
                    {
                        MessageBox.Show("No se pueden seleccionar ambos comparadores logicos al mismo tiempo.");
                    }
                    else
                    {
                        s2 = s2 + " AND " + campocomp + " " + comparador + " '" + valorcomp+"'";
                    }
                }
                else if (chkOrCreacion.Checked == true)
                {
                    if (chkAndCreacion.Checked == true)
                    {
                        MessageBox.Show("No se pueden seleccionar ambos comparadores logicos al mismo tiempo.");

                    }
                    else
                    {
                        s2 = s2 + " OR " + campocomp + " " + comparador + " '" + valorcomp+"'";
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un comparador logico.");
                }
            }
            return s2;
        }
        private string funcSentencia3(string s3)
        {
            string campoorden = "";
            string orden = "";

            campoorden = cmbCampoAgruparCreacion.Text;
            if (cmbCampoAgruparCreacion.Text == "")
            {
                if (chkASCCreacion.Checked != false || chkDescCreacion.Checked != false)
                {
                    orden = funcOrderby(orden);
                }
            }
            else
            {
                if (chkASCCreacion.Checked == true || chkDescCreacion.Checked == true)
                {
                    orden = funcOrderby(orden);
                    s3 = " GROUP BY " + campoorden + " ORDER BY " + campoorden + " " + orden + " ;";
                }
                else
                {
                    orden = funcOrderby(orden);
                    s3 = " GROUP BY " + campoorden + " ;";
                }
            }
            
            return s3;
        }

        private string funcComparador(string comparador)
        {
            if (rbtnMayorCreacion.Checked == true)
            {
                comparador = ">";
            }
            else if (rbtnIgualCreacion.Checked == true)
            {
                comparador = "=";
            }
            else if (rbtnMenorCreacion.Checked == true)
            {
                comparador = "<";
            }
            else
            {
                MessageBox.Show("Selecciones un comparador." ,"", MessageBoxButtons.OK , MessageBoxIcon.Error);
            }

            return comparador;
        }

        private string funcCampocomp(string campocomp)
        {
            if (cmbCampoComparacionCreacion.Text == "")
            {
                MessageBox.Show("Seleccione un campo para la comparación.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                campocomp = cmbCampoComparacionCreacion.Text;
            }

            return campocomp;
        }

        private string funcValorcomp(string valorcomp)
        {
            if (txtValorCreacion.Text == "")
            {
                MessageBox.Show("Ingresar un valor para la comparación.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                valorcomp = txtValorCreacion.Text;
            }

            return valorcomp;
        }

        private void btnBuscarConsultaEditar_Click(object sender, EventArgs e)
        {
            string nombConsulta = txtNombreEditar.Text;

            rtxtCambioConsulta.Text = Cont.funcConsConsulta(nombConsulta);
        }

        private void btnGuardarEditar_Click(object sender, EventArgs e)
        {
            string nombConsulta = txtNombreEditar.Text;
            string nuevaConsulta = rtxtCambioConsulta.Text;
            Cont.funcNuevaConsulta(nuevaConsulta , nombConsulta);
            rtxtCambioConsulta.Text = "";
            txtNombreEditar.Text = "";
            funcVaciarCampos();
        }

        private void btnCancelarEditar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMostrarBuscar_Click(object sender, EventArgs e)
        {
           
            string nombConsulta = txtNombreEjec.Text;
            string consulta = Cont.funcConsConsulta(nombConsulta);
            if (consulta != "") {
                DataTable cons = Cont.funcEjecucionConsulta(consulta);
                dgvDatosMostrar.DataSource = cons;
            }
            

        }

        private string funcOrderby(string orden)
        {
            if (chkASCCreacion.Checked == true)
            {
                if (chkDescCreacion.Checked == true)
                {
                    MessageBox.Show("Solo se puede utilizar un orden para la consulta.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    orden = "ASC";
                }
            }
            else if (chkDescCreacion.Checked == true)
            {
                if (chkASCCreacion.Checked == true)
                {
                    MessageBox.Show("Solo se puede utilizar un orden para la consulta.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    orden = "DESC";
                }
            }
            s3 = " ORDER BY " + orden + " ;";
            return orden;
        }

        private void funcVaciarCampos()
        {
            s1 = "";
            s2 = "";
            s3 = "";

            
        }
        private void funcLimpiar() {
            cmbTablasCreacion.Enabled = true;
            btnAgregarTablaCreacion.Enabled = true;

            txtNombreCreacion.Text = "";
            cmbTablasCreacion.Text = "";
            cmbCampoCreacion.Text = "";
            txtAliasCreacion.Text = "";
            cmbCampoAgruparCreacion.Text = "";
            cmbCampoComparacionCreacion.Text = "";
            txtValorCreacion.Text = "";
            chkAndCreacion.Checked = false;
            chkDescCreacion.Checked = false;
            chkAndCreacion.Checked = false;
            chkOrCreacion.Checked = false;
            rbtnIgualCreacion.Checked = false;
            rbtnMayorCreacion.Checked = false;
            rbtnMenorCreacion.Checked = false;
            txtConsultaCreacion.Text = "";
            dgvTablasCreacion.Rows.Clear();
            dgvTablasCreacion.Refresh();
            dgvCamposCreacion.Rows.Clear();
            dgvCamposCreacion.Refresh();
            txtNombreEditar.Text = "";
            rtxtCambioConsulta.Text = "";
            txtNombreEjec.Text = "";
            dgvDatosMostrar.Rows.Clear();
            dgvDatosMostrar.Refresh();

        }
    }
}
