using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModeloSeguridad;

namespace CapaControladorSeguridad
{
    public class clsControlAsignacionDeAplicaciones
    {
        clsAsignacionDeAplicaciones asignacionDeAplicaciones = new clsAsignacionDeAplicaciones();


        public string NombreUsuario(string UserName)
        {
            return asignacionDeAplicaciones.ObtenerNombreUsuario(UserName);
        }

        //Obtener los datos de la tabla perfil
        public OdbcDataReader consulta_perfiles()
        {
            return asignacionDeAplicaciones.consultaperfil();
        }
        //Obtener los datos de la tabla aplicacion.
        public OdbcDataReader consulta_aplicaciones()
        {
            return asignacionDeAplicaciones.consultaaplicacion();
        }
        public OdbcDataReader consulta_perfiles_asignados(string UserName)
        {
            return asignacionDeAplicaciones.consultaperfilasignado(UserName);
        }
        //Obtener los datos de la tabla aplicacion.
        public OdbcDataReader consulta_aplicaciones_asignadas(string UserName)
        {
            return asignacionDeAplicaciones.consultaaplicacionasignada(UserName);
        }
        public OdbcDataReader consulta_adb(string UserName, string Aplicacion)
        {
            return asignacionDeAplicaciones.consultadb(UserName, Aplicacion);
        }
        public OdbcDataReader consulta_adbper(string UserName, string Aplicacion)
        {
            return asignacionDeAplicaciones.consultadbper(UserName, Aplicacion);
        }
        public OdbcDataReader eliminar_adb(string UserName, string Aplicacion)
        {
            return asignacionDeAplicaciones.eliminaradb(UserName, Aplicacion);
        }
        public OdbcDataReader eliminar_adbper(string UserName, string Aplicacion)
        {
            return asignacionDeAplicaciones.eliminardbper(UserName, Aplicacion);
        }
        public OdbcDataReader consultapermiso()
        {
            return asignacionDeAplicaciones.consultapermisos();
        }
        public OdbcDataReader consulta_aplicaciones_activas(string UserName, string Aplicacion)
        {
            return asignacionDeAplicaciones.consulta_aplicaciones_activas(UserName, Aplicacion);
        }
        public OdbcDataReader cambio_aplicaciones_activas(string UserName, string Aplicacion, string insertar, string modificar, string eliminar, string consultar, string imprimir, string apliid)
        {
            return asignacionDeAplicaciones.actualizacion_aplicaciones_activas(UserName, Aplicacion, insertar, modificar,eliminar,consultar,imprimir, apliid);
        }
    }
}
