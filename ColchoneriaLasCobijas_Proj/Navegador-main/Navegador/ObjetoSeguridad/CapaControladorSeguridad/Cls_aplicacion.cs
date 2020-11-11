using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaModeloSeguridad;

namespace CapaControladorSeguridad
{
    public class Cls_aplicacion
    {
        public void insertar(string codigo, String nombre, String informe)
        {
            Aplicacion app = new Aplicacion();

            app.insertarAplicacion(codigo, nombre, informe);

        }

        public void insertarLogin(String usuario, String contraseña, String nombreempleado, String estado)
        {
            Aplicacion app = new Aplicacion();

            app.insertarUsuario(usuario, contraseña, nombreempleado, estado);

        }

        public DataTable buscar(string tabla)
        {
            Aplicacion app = new Aplicacion();


            OdbcDataAdapter dt = app.buscar(tabla);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }

        public DataTable buscarLogin(string tabla)
        {
            Aplicacion app = new Aplicacion();

            OdbcDataAdapter dt = app.buscarUsuario(tabla);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }

        public void modificar(string id, String nombre, String informe)
        {
            Aplicacion app = new Aplicacion();

            app.modificarAplicacion(id, nombre, informe);
            //public DataTable eliminar (string tabla)
 }

        public void modificarLogin(string id, String usuario, String contraseña, String nombreempleado,  String estado)
        {
            Aplicacion app = new Aplicacion();

            app.modificarUsuario(id, usuario, contraseña,nombreempleado, estado);
        }

        public void eliminar(string id) { 
        
            Aplicacion app = new Aplicacion();
            app.eliminarAplicacion(id);
        }

        public void eliminarLogin(string id)
        {

            Aplicacion app = new Aplicacion();
            app.eliminarUsuario(id);
        }
        public static void SoloNumeros (KeyPressEventArgs S){
            //String Seleccion;
            //Aplicacion app = new Aplicacion();
            if (char.IsDigit(S.KeyChar))
            {
                S.Handled = false;
            }
            else if (char.IsSeparator(S.KeyChar))
            {
                S.Handled = false;
            }
            else if (char.IsControl(S.KeyChar))
            {
                S.Handled = false;
            }
         //   else if () { 
            
            
            //}
            else {
                S.Handled = true;
                MessageBox.Show("solo numeros");
            }
            
        }
    }
}
