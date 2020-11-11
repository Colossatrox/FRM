
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModeloBryan
{
    public class clsSentencias
    {
        clsConexion Con = new clsConexion();
        //Esta funcion sirve para devolver a la capa controlador los datos que va contener el treeView de las cuentas
        public OdbcDataAdapter funcLlenarTree()
        {
            string Sql = "SELECT PK_ID_CUENTA_CONTABLE, NOMBRE_CUENTA_CONTABLE, NIVEL_CUENTA_CONTABLE, FK_CUENTA_PADRE_CUENTA_CONTABLE FROM CUENTA_CONTABLE;";
            OdbcDataAdapter DataTable = new OdbcDataAdapter(Sql, Con.conexion());
            return DataTable;
        }

        //Esta funcion sirve para devolver a la capa controlador los datos que va contener el datagridview de las peticiones
        public OdbcDataAdapter funcLlenarPeticiones()
        {
            string Sql = "SELECT PK_ID_PETICION_POLIZA AS CODIGO, FECHA_PETICION_POLIZA,CONCEPTO_PETICION_POLIZA AS FECHA, DESCRIPCION_PETICION_POLIZA AS DESCRIPCION, MONTO_PETICION_POLIZA AS MONTO" +
                " FROM PETICION_POLIZA WHERE ESTADO_PETICION_POLIZA=1;";
            OdbcDataAdapter DataTable = new OdbcDataAdapter(Sql, Con.conexion());
            return DataTable;
        }

        //Esta funcion sirve para obtener el codigo siguiente cuando se selecciona una cuenta del treeview
        public int funcInsertar(int Codigo)
        {
            string Sql = "SELECT MAX( PK_ID_CUENTA_CONTABLE) FROM CUENTA_CONTABLE WHERE PK_ID_CUENTA_CONTABLE LIKE '"+ Codigo +"%';";
            try
            {
                OdbcCommand Command = new OdbcCommand(Sql, Con.conexion());
                OdbcDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    Codigo = Reader.GetInt32(0);
                }

            }
            catch (Exception Ex) { Console.WriteLine(Ex.Message.ToString() + " \nError en asignarCombo, revise los parametros \n -\n -"); }
            return Codigo;
        }

        //Funcion para obtener el codigo siguiente de cuenta cuando se va insertar en la raiz
        public int funcInsertarNivel0()
        {
            int Codigo = 0;
            string Sql = "SELECT MAX( PK_ID_CUENTA_CONTABLE) FROM CUENTA_CONTABLE WHERE NIVEL_CUENTA_CONTABLE=1;";
            try
            {
                OdbcCommand Command = new OdbcCommand(Sql, Con.conexion());
                OdbcDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    Codigo = Reader.GetInt32(0);
                }

            }
            catch (Exception Ex) { Console.WriteLine(Ex.Message.ToString() + " \nError en asignarCombo, revise los parametros \n -\n -"); }
            return Codigo+1;
        }

        //Funcion para obtener el codigo siguiente 
        public int funcObtenerCodigo(string NombreTabla,string Campo)
        {
            int Codigo = 0;
            string Sql = "SELECT MAX("+Campo+") FROM "+NombreTabla+" ;";
            try
            {
                OdbcCommand Command = new OdbcCommand(Sql, Con.conexion());
                OdbcDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    Codigo = Reader.GetInt32(0);
                }

            }
            catch (Exception Ex) { Console.WriteLine(Ex.Message.ToString() + " \nError en asignarCombo, revise los parametros \n -\n -"); }
            return Codigo + 1;
        }

        //Funcion para agregar una nueva cuenta contable a la tabla de cuentas contables
        public bool funcAgregar(int Codigo, string Nombre, int Nivel, int Padre, int TipoCuenta)
        {
            try
            {
                string InsertarCuenta = "INSERT INTO CUENTA_CONTABLE VALUES (" + Codigo + ",'" + Nombre + "'," + Nivel + "," + Padre + ",0,0,0,0,0,0,1," + TipoCuenta + ")";
                OdbcCommand Comm = new OdbcCommand(InsertarCuenta, Con.conexion());
                Comm.ExecuteNonQuery();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }

        }

        //Funcion para agregar una nueva poliza encabezado
        public bool funcAgregarPolizaEnc(int Codigo, DateTime Fecha, string Descripcion, double Total)
        {
            try
            {
                string InsertarCuenta = "INSERT INTO POLIZA_ENCABEZADO (PK_POLIZA_ENCABEZADO,FECHA_POLIZA_ENCABEZADO,DESCRIPCION_POLIZA_ENCABEZADO, ESTADO_POLIZA_ENCABEZADO" +
                    ",TOTAL_POLIZA_ENCABEZADO) VALUES (" + Codigo + ",?,'" + Descripcion + "',1," + Total  + ")";
                OdbcCommand Comm = new OdbcCommand(InsertarCuenta, Con.conexion());
                Comm.Parameters.Add("@FECHA_POLIZA_ENCABEZADO", OdbcType.DateTime).Value = Fecha;
                Comm.ExecuteNonQuery();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        //Funcion para agregar una nueva poliza detalle
        public bool funcAgregarPolizaDet(int Codigo, int CodigoCuenta, double Monto, int DebeHaber)
        {
            try
            {
                string InsertarCuenta = "INSERT INTO POLIZA_DETALLE VALUES (" + Codigo + ","+CodigoCuenta+"," + Monto + "," + DebeHaber + ")";
                OdbcCommand Comm = new OdbcCommand(InsertarCuenta, Con.conexion());
                Comm.ExecuteNonQuery();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        //Funcion para agregar una nueva poliza detalle
        public Tuple<int, double> funcObtenerPadreSaldo(int Codigo)
        {
            int Padre = 0;
            double Saldo = 0;
            try
            {
                string Buscar = "SELECT FK_CUENTA_PADRE_CUENTA_CONTABLE, SALDO_ACTUAL_CUENTA_CONTABLE FROM CUENTA_CONTABLE WHERE PK_ID_CUENTA_CONTABLE="+Codigo;
                OdbcCommand Comm = new OdbcCommand(Buscar, Con.conexion());
                OdbcDataReader Reader = Comm.ExecuteReader();
                if (Reader.Read())
                {
                    Padre = Reader.GetInt32(0);
                    Saldo = Reader.GetDouble(1);
                }
                return Tuple.Create(Padre,Saldo);
            }
            catch (Exception Ex)
            {
                return Tuple.Create(Padre, Saldo);
            }
        }

        //Funcion para modifcar el saldo de una cuenta 
        public bool funcModificarSaldo(int Codigo,double Saldo)
        {
            try
            {
                string Modificar = "UPDATE CUENTA_CONTABLE SET SALDO_ACTUAL_CUENTA_CONTABLE="+Saldo+" WHERE PK_ID_CUENTA_CONTABLE=" + Codigo;
                OdbcCommand Comm = new OdbcCommand(Modificar, Con.conexion());
                Comm.ExecuteNonQuery();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        //funcion para obtener todos los encabezados
        public Tuple<int,DateTime,string,double> funcObtenerDatoPolEnc(int Codigo)
        {
            int CodigoEnc=0;
            DateTime Fecha=DateTime.Now;
            string Descripcion="";
            double Monto=0;
            try
            {
                string Buscar = "SELECT PK_POLIZA_ENCABEZADO, FECHA_POLIZA_ENCABEZADO, DESCRIPCION_POLIZA_ENCABEZADO, TOTAL_POLIZA_ENCABEZADO" +
                    " FROM POLIZA_ENCABEZADO WHERE PK_POLIZA_ENCABEZADO=" + Codigo;
                OdbcCommand Comm = new OdbcCommand(Buscar, Con.conexion());
                OdbcDataReader Reader = Comm.ExecuteReader();
                if (Reader.Read())
                {
                    CodigoEnc= Reader.GetInt32(0);
                    Fecha = Reader.GetDateTime(1);
                    Descripcion = Reader.GetString(2);
                    Monto = Reader.GetDouble(3);
                }
                return Tuple.Create(CodigoEnc,Fecha,Descripcion,Monto);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message.ToString() + " \nError en asignarCombo, revise los parametros \n -\n -"); 
            return Tuple.Create(CodigoEnc, Fecha, Descripcion, Monto);
            }
        }

        public List<int> funcObtenerPolizas(int Mes, int Anio)
        {
            List<int> Lista = new List<int>();
            try
            {
                string Buscar = "SELECT PK_POLIZA_ENCABEZADO FROM POLIZA_ENCABEZADO WHERE MONTH(FECHA_POLIZA_ENCABEZADO)="+Mes+" AND" +
                    " YEAR(FECHA_POLIZA_ENCABEZADO)="+Anio ;
                OdbcCommand Comm = new OdbcCommand(Buscar, Con.conexion());
                OdbcDataReader Reader = Comm.ExecuteReader();
                while (Reader.Read())
                {
                    Lista.Add(Reader.GetInt16(0));
                }
                return Lista;

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message.ToString() + " \nError en asignarCombo, revise los parametros \n -\n -");
                return Lista;
            }
        }

        public Tuple<string, double, int> funcObtenerDatoPolDet(int CodigoPoliza,int CodigoCuenta)
        {
            int Debe = 0;
            string Cuenta = "";
            double Monto = 0;
            try
            {
                string Buscar = "SELECT C.NOMBRE_CUENTA_CONTABLE, P.MONTO_POLIZA_DETALLE, P.DEBE_POLIZA_DETALLE FROM CUENTA_CONTABLE C" +
                    ",POLIZA_DETALLE P WHERE C.PK_ID_CUENTA_CONTABLE=P.PK_ID_CUENTA_CONTABLE AND P.PK_POLIZA_ENCABEZADO=" + CodigoPoliza+
                    " AND P.PK_ID_CUENTA_CONTABLE="+CodigoCuenta;
                OdbcCommand Comm = new OdbcCommand(Buscar, Con.conexion());
                OdbcDataReader Reader = Comm.ExecuteReader();
                if (Reader.Read())
                {
                    Debe = Reader.GetInt32(2);
                    Cuenta = Reader.GetString(0);
                    Monto = Reader.GetDouble(1);
                }
                return Tuple.Create(Cuenta, Monto, Debe);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message.ToString() + " \nError en asignarCombo, revise los parametros \n -\n -");
                return Tuple.Create(Cuenta, Monto, Debe);
            }
        }

        public List<int> funcObtenerDetalles(int Codigo)
        {
            List<int> Lista = new List<int>();
            try
            {
                string Buscar = "SELECT PK_ID_CUENTA_CONTABLE FROM POLIZA_DETALLE WHERE PK_POLIZA_ENCABEZADO="+Codigo+" " +
                    "ORDER BY DEBE_POLIZA_DETALLE DESC";
                OdbcCommand Comm = new OdbcCommand(Buscar, Con.conexion());
                OdbcDataReader Reader = Comm.ExecuteReader();
                while (Reader.Read())
                {
                    Lista.Add(Reader.GetInt32(0));
                }
                return Lista;

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message.ToString() + " \nError en asignarCombo, revise los parametros \n -\n -");
                return Lista;
            }
        }

        //Funcion para buscar una peticion de poliza
        public bool funcBuscarPeticion(int Codigo)
        {
            try
            {
                string Buscar = "SELECT PK_ID_PETICION_POLIZA FROM PETICION_POLIZA WHERE ESTADO_PETICION_POLIZA=1 AND PK_ID_PETICION_POLIZA=" + Codigo;
                OdbcCommand Comm = new OdbcCommand(Buscar, Con.conexion());
                OdbcDataReader Reader = Comm.ExecuteReader();
                if (Reader.Read())
                {
                    return true;
                }
                return false;
                
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        //Funcion para agregarle el codigo de poliza a una peticion ya hecha
        public bool funcModificarPeticion(int Codigo, int CodigoRelacionado)
        {
            try
            {
                string Modificar = "UPDATE PETICION_POLIZA SET FK_PK_POLIZA_ENCABEZADO=" + CodigoRelacionado + ", ESTADO_PETICION_POLIZA=0 WHERE PK_ID_PETICION_POLIZA=" + Codigo;
                OdbcCommand Comm = new OdbcCommand(Modificar, Con.conexion());
                Comm.ExecuteNonQuery();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        //Funcion para agregar una nueva cuenta contable a la tabla de cuentas contables
        public bool funcSaldoOk(int Codigo, double Cantidad)
        {
            
            string Sql = "SELECT SALDO_ACTUAL_CUENTA_CONTABLE FROM CUENTA_CONTABLE WHERE PK_ID_CUENTA_CONTABLE="+Codigo+";";
            try
            {
                OdbcCommand Command = new OdbcCommand(Sql, Con.conexion());
                OdbcDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    if (Reader.GetDouble(0) >= Cantidad)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex) { 
                Console.WriteLine(Ex.Message.ToString() + " \nError en asignarCombo, revise los parametros \n -\n -");
                return false;
            }
        }

        //Funcion para devolver los datos para llenar los combos del form
        public string[] funcLlenarCmb(string Tabla, string Campo1)
        {
            string[] Campos = new string[100];
            int I = 0;
            string Sql = "SELECT " + Campo1 + " FROM " + Tabla +  "  ;";

            try
            {
                OdbcCommand Command = new OdbcCommand(Sql, Con.conexion());
                OdbcDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {

                    Campos[I] = Reader.GetValue(0).ToString();
                    I++;
                }
            }
            catch (Exception Ex) { Console.WriteLine(Ex.Message.ToString() + " \nError en asignarCombo, revise los parametros \n -" + Tabla + "\n -" + Campo1); }
            return Campos;
        }
    }
}
