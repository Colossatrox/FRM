using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using System.Collections;
using System.Windows.Forms;

namespace CapaModelo
{
    public class clsConsultas
    {

        clsConexion conexion = new clsConexion();


        public DataSet funcLlenarCampos(string tabla)// metodo  que obtinene el contenio de una tabla
        {

            DataSet Campos = new DataSet();

            try
            {
                string Query_SELECT = "SELECT * FROM " + tabla;
                OdbcCommand Ejecucion_Query = new OdbcCommand(Query_SELECT, conexion.funcConexion());
                OdbcDataAdapter Lector = new OdbcDataAdapter();

                Lector.SelectCommand = Ejecucion_Query;
                Lector.Fill(Campos);

                return Campos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar SQL: " +
                     System.Environment.NewLine + System.Environment.NewLine +
                     ex.GetType().ToString() + System.Environment.NewLine +
                     ex.Message, "Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Campos;
            }
            

        }

        public string funcLlamarConsulta(string nombre) {

            string Query_SELECT = "SELECT contenido_consulta_inteligente FROM consulta_inteligente as con WHERE con.nombre_consulta_inteligente = '"+ nombre + "' ";
            OdbcCommand Ejecucion_Query = new OdbcCommand(Query_SELECT, conexion.funcConexion());
            OdbcDataReader Lector = Ejecucion_Query.ExecuteReader();

            string consulta=""; 

            if (Lector.HasRows == true)
            {
                while (Lector.Read())
                {
                    consulta = Lector.GetString(0);
                }    
            }
            else
            {
                MessageBox.Show("Nombre no encontrado.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return consulta;

        }

        public void funcActualizarConsulta(string nuevaConsulta, string nombre)
        {
            char comillas = '"';
            string Query_SELECT = "UPDATE consulta_inteligente SET contenido_consulta_inteligente="+ comillas + "" + nuevaConsulta + ""+comillas+"WHERE nombre_consulta_inteligente ='" + nombre + "'";
            OdbcCommand Query_UPDATE1 = new OdbcCommand(Query_SELECT, conexion.funcConexion());
            Query_UPDATE1.ExecuteNonQuery();
            MessageBox.Show("Modificación Exitosa","Consultas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public void funcCnsGuardarConsulta(string consulta, string nombre)
        {
           char comillas='"';
           string guardarConsulta = "INSERT INTO consulta_inteligente (nombre_consulta_inteligente , contenido_consulta_inteligente) VALUES ('"+ nombre + "',"+ comillas + ""+consulta+ ""+comillas+")";
           OdbcCommand Query_Validacion1 = new OdbcCommand(guardarConsulta, conexion.funcConexion());
           Query_Validacion1.ExecuteNonQuery();

        }


        public OdbcDataAdapter funcEjecucionConsulta(string consulta)
        {
            string Query_SELECT = consulta;
            OdbcDataAdapter tablaDatos = new OdbcDataAdapter(Query_SELECT, conexion.funcConexion());

            return tablaDatos;
        }

        public DataTable funcLlenarCmbTablas()
        {
            DataTable Datos = new DataTable();

            try
            {

                string CargaDepa = "SHOW TABLES";
                OdbcCommand Query_Busqueda1 = new OdbcCommand(CargaDepa, conexion.funcConexion());

                OdbcDataAdapter Lector = new OdbcDataAdapter();
                Lector.SelectCommand = Query_Busqueda1;
                Lector.Fill(Datos);
                return Datos;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al ejecutar SQL: " +
                    System.Environment.NewLine + System.Environment.NewLine +
                    ex.GetType().ToString() + System.Environment.NewLine +
                    ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Datos;

            }

        }

        public DataTable funcLlenarCmbCampos(string tabla)
        {
            DataTable Datos = new DataTable();

            try 
            {
                string CargaCampos = "select * from Information_Schema.Columns WHERE TABLE_NAME = '"+ tabla + "'";
                OdbcCommand Query_Busqueda1 = new OdbcCommand(CargaCampos, conexion.funcConexion());

                OdbcDataAdapter Lector = new OdbcDataAdapter();
                Lector.SelectCommand = Query_Busqueda1;
                Lector.Fill(Datos);
                return Datos;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al ejecutar SQL: " +
                   System.Environment.NewLine + System.Environment.NewLine +
                   ex.GetType().ToString() + System.Environment.NewLine +
                   ex.Message, "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Datos;
            }
        }


    }
}
