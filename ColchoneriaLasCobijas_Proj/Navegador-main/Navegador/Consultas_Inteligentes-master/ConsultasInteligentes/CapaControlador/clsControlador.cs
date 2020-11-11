using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using CapaModelo;
using System.Collections;
using System.Windows;

namespace CapaControlador
{
    public class clsControlador
    {
        clsConsultas cons = new clsConsultas();


        public DataSet funcLlenarCampos(string tabla)
        {
            DataSet Items = cons.funcLlenarCampos(tabla);
            return Items;
        }


        public DataTable funcItemsTablas()
        {
            DataTable Items = cons.funcLlenarCmbTablas();
            return Items;
        }

        public DataTable funcEjecucionConsulta(string consulta)
        {

            OdbcDataAdapter dt = cons.funcEjecucionConsulta(consulta);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;

        }

        public DataTable funcItemsCampos(string tabla)
        {
            DataTable Campos = cons.funcLlenarCmbCampos(tabla);
            return Campos;
        }
        public string funcConsConsulta(string nombre)
        {
            nombre = cons.funcLlamarConsulta(nombre);

            return nombre;
        }

        public void funcNuevaConsulta(string nuevaConsulta, string nombre) {
            cons.funcActualizarConsulta(nuevaConsulta, nombre);
        
        }
        public void funcGuardarConsulta(string consulta, string nombre) {

            cons.funcCnsGuardarConsulta(consulta, nombre);
        }
       
    }
}
