using CapaModeloBryan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladorBryan
{
    public class clsControlador
    {
        clsSentencias Sn = new clsSentencias();
        //Funcion para obtener los datos que se van a mostrar en el treeview y pasarlos a la capa vista
        public DataSet funcLlenarTree()
        {
            OdbcDataAdapter Dt = Sn.funcLlenarTree();
            DataSet Table = new DataSet();
            Dt.Fill(Table,"cuenta_contable");
            return Table;
        }

        //Funcion para obtener los datos que se van a mostrar en el datagridview y pasarlos a la capa vista
        public DataTable funcLLenarPeticiones()
        {
            OdbcDataAdapter Dt = Sn.funcLlenarPeticiones();
            DataTable Table = new DataTable();
            Dt.Fill(Table);
            return Table;
        }

        //Funcion para obtener el codigo cuando se seleccciona una cuenta del treeview y pasarlo a la capa vista
        public int funcCodigoMax(int Codigo)
        {
            int CodigoNuevo = Sn.funcInsertar(Codigo);
            return CodigoNuevo;
        }

        //Funcion para buscar una peticion de poliza y pasarlo a la capa vista
        public bool funcBuscarPeticion(int Codigo)
        {
            bool Respuesta = Sn.funcBuscarPeticion(Codigo);
            return Respuesta;
        }

        //Funcion para obtener el codigo cuando no se seleccciona una cuenta del treeview y pasarlo a la capa vista
        public int funcCodigoMaxNivel0()
        {
            int CodigoNuevo = Sn.funcInsertarNivel0();
            return CodigoNuevo;
        }

        //Funcion para obtener el codigo maximo pasando tabla y campo querido
        public int funcCodigoMaximo(string Tabla,string Campo)
        {
            int CodigoNuevo = Sn.funcObtenerCodigo(Tabla,Campo);
            return CodigoNuevo;
        }

        //Funcion para mandar los datos para ejecutar la consulta de agregar una nueva cuenta contable y devolver la respuesta a la capa vista
        public bool funcAgregar(int Codigo, string Nombre, int Nivel, int Padre, int TipoCuenta)
        {
            bool Respuesta = Sn.funcAgregar(Codigo, Nombre, Nivel, Padre, TipoCuenta);
            return Respuesta;
        }

        //Funcion para mandar los datos para ejecutar la consulta de agregar un nuevo encabezadod de poliza y devolver la respuesta a la capa vista
        public bool funcAgregarPolEnc(int Codigo, DateTime Fecha, string Descripcion, double Total)
        {
            bool Respuesta = Sn.funcAgregarPolizaEnc(Codigo, Fecha, Descripcion, Total);
            return Respuesta;
        }


        //Funcion para mandar los datos para ejecutar la consulta de agregar un nuevo detalle de poliza y devolver la respuesta a la capa vista
        public bool funcAgregarPolDet(int Codigo, int CodigoCuenta, double Monto, int DebeHaber)
        {
            bool Respuesta = Sn.funcAgregarPolizaDet(Codigo, CodigoCuenta, Monto, DebeHaber);
            return Respuesta;
        }

        //Funcion para mandar los datos para buscar el padre y saldo de una cuenta y devolver la respuesta a la capa vista
        public Tuple<int,double> funcObtenerPadreSaldo(int Codigo)
        {
            var Resultado = Sn.funcObtenerPadreSaldo(Codigo);
            return Tuple.Create(Resultado.Item1,Resultado.Item2);
        }

        //Funcion para modificar el saldo de una cuenta y devolver la respuesta a la capa vista
        public bool funcModificarSaldo(int Codigo,double Saldo)
        {
            bool Resultado = Sn.funcModificarSaldo(Codigo,Saldo);
            return Resultado;
        }

        //Funcion para modificar el saldo de una cuenta y devolver la respuesta a la capa vista
        public bool funcModificarPeticion(int Codigo, int CodigoRelacionado)
        {
            bool Resultado = Sn.funcModificarPeticion(Codigo, CodigoRelacionado);
            return Resultado;
        }

        //Funcion para mandar los datos para ejecutar la consulta de agregar una nueva cuenta contable y devolver la respuesta a la capa vista
        public bool funcSaldoBueno(int Codigo, double Cantidad)
        {
            bool Respuesta = Sn.funcSaldoOk(Codigo,Cantidad);
            return Respuesta;
        }

        //Funcion para obtener los items con los que se van a llenar los combobox del form
        public string[] funcItems(string Tabla, string Campo1)
        {
            string[] Items = Sn.funcLlenarCmb(Tabla, Campo1);
            return Items;
        }

        //funcion para obtener los encabezados
        public Tuple<int, DateTime, string, double> funcObtenerDatoPolEnc(int Codigo)
        {
            var Respuesta = Sn.funcObtenerDatoPolEnc(Codigo);
            return Tuple.Create(Respuesta.Item1, Respuesta.Item2, Respuesta.Item3, Respuesta.Item4);
        }

        public List<int> funcObtenerPolizas(int Mes, int Anio)
        {
            List<int> Lista = new List<int>();
            Lista = Sn.funcObtenerPolizas(Mes, Anio);
            return Lista;
        }

        public Tuple<string, double, int> funcObtenerDatoPolDet(int CodigoPoliza, int CodigoCuenta)
        {
            var Respuesta = Sn.funcObtenerDatoPolDet(CodigoPoliza,CodigoCuenta);
            return Tuple.Create(Respuesta.Item1, Respuesta.Item2, Respuesta.Item3);
        }

        public List<int> funcObtenerDetalles(int Codigo)
        {
            List<int> Lista = new List<int>();
            Lista = Sn.funcObtenerDetalles(Codigo);
            return Lista;
        }
    }
}
