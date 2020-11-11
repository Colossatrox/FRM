using CapaModeloSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladorSeguridad
{

    public class clsObtenerPermisos
    {
        clsPermisos permisos = new clsPermisos();
        public string PermisosPorAplicacion(string strAplicacion, string strUsuario)
        {
            return permisos.PermisosPorAplicacion(strAplicacion, strUsuario);
        }

        public string PermisosPorPerfil(string strAplicacion, string strUsuario)
        {
            return permisos.PermisosPorPerfil(strAplicacion, strUsuario);
        }

        public int AccesoAplicacionPerfil(string strIdAplicacion, string strUsuario)
        {
            return permisos.AccesoAplicacionPerfil(strIdAplicacion, strUsuario);
        }

        public int AccesoAplicacion(string strIdAplicacion, string strUsuario)
        {
            return permisos.AccesoAplicacion(strIdAplicacion, strUsuario);
        }
    }
}