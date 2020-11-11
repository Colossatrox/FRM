using CapaControladorSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaVistaSeguridad
{
    public class clsFuncionesSeguridad
    {
        clsObtenerPermisos obtenerPermisos = new clsObtenerPermisos();
        public string Permisos(string strAplicacion, string strUsuario)
        {
            string strPermisos = obtenerPermisos.PermisosPorPerfil(strAplicacion, strUsuario);
            if (strPermisos == null)
            {
                strPermisos = obtenerPermisos.PermisosPorAplicacion(strAplicacion, strUsuario);
                if (strPermisos == null)
                {
                    return "0,0,0,0,0";
                }
                else
                {
                    return strPermisos;
                }
            }
            else
            {
                return strPermisos;
            }
        }


        public int PermisosAcceso(string strIdAplicacion, string strUsuario)
        {
            int permisos = obtenerPermisos.AccesoAplicacionPerfil(strIdAplicacion, strUsuario);
            Console.WriteLine(permisos);
            if (permisos == 0)
            { 
                permisos = obtenerPermisos.AccesoAplicacion(strIdAplicacion, strUsuario);
                Console.WriteLine(permisos);
                if (permisos == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 1;
            }
        }

    }
}
