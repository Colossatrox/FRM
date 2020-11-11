using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaVistaBryan.Mantenimientos;
using CapaVistaJose.Mantenimientos;
using CapaVistaSeguridad;
using CapaVistaSeguridad.Formularios.Mantenimientos;
using CapaVistaSeguridad.Formularios;

namespace ColchoneriaLasCobijas_Proj_MDI
{
    public partial class MDIFRM : Form
    {
        clsFuncionesSeguridad seguridad = new clsFuncionesSeguridad();
        clsVistaBitacora bit = new clsVistaBitacora();
        public MDIFRM()
        {
            InitializeComponent();
        }

        private void MDIFRM_Load(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtUsuario.Text = frm.usuario();
            }   
        }

        private void bancosToolStripMenuItem1_Click(object sender, EventArgs e)
        {   
            if (seguridad.PermisosAcceso("1302", txtUsuario.Text) == 1)
            {
                bit.user(txtUsuario.Text);
                bit.insert("Ingreso a la aplicacion Bancos", 1302);
                MantenimientosBancos1302  asignacion = new MantenimientosBancos1302(txtUsuario.Text,this);
                asignacion.MdiParent = this;
                asignacion.Show();
            }
            else
            {
                bit.user(txtUsuario.Text);
                bit.insert("Trato de ingresar a la aplicacion Bancos", 1302);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void cuentaBancariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("1305", txtUsuario.Text) == 1)
            {
                bit.user(txtUsuario.Text);
                bit.insert("Ingreso a la aplicacion Cuenta Bancaria", 1305);
                frmCuentaBancaria asignacion = new frmCuentaBancaria(txtUsuario.Text, this);
                asignacion.MdiParent = this;
                asignacion.Show();
            }
            else
            {
                bit.user(txtUsuario.Text);
                bit.insert("Trato de ingresar a la aplicacion Cuenta Bancaria", 1305);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void propietarioDeCuentaBancariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("1306", txtUsuario.Text) == 1)
            {
                bit.user(txtUsuario.Text);
                bit.insert("Ingreso a la aplicacion Propietario de cuenta bancaria", 1306);
                frmPropietario asignacion = new frmPropietario(txtUsuario.Text, this);
                asignacion.MdiParent = this;
                asignacion.Show();
            }
            else
            {
                bit.user(txtUsuario.Text);
                bit.insert("Trato de ingresar a la aplicacion  Propietario de cuenta bancaria", 1306);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void monedaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("1303", txtUsuario.Text) == 1)
            {
                bit.user(txtUsuario.Text);
                bit.insert("Ingreso a la aplicacion de tipo moneda", 1303);
                frmMoneda asignacion = new frmMoneda(txtUsuario.Text, this);
                asignacion.MdiParent = this;
                asignacion.Show();
            }
            else
            {
                bit.user(txtUsuario.Text);
                bit.insert("Trato de ingresar a la aplicacion de tipo moneda", 1303);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void movimientosBancariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("1304", txtUsuario.Text) == 1)
            {
                bit.user(txtUsuario.Text);
                bit.insert("Ingreso a la aplicacion de movimiento bancario", 1304);
                frmTipoMovimientoBancario asignacion = new frmTipoMovimientoBancario(txtUsuario.Text, this);
                asignacion.MdiParent = this;
                asignacion.Show();
            }
            else
            {
                bit.user(txtUsuario.Text);
                bit.insert("Trato de ingresar a la aplicacion de movimiento bancario", 1304);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void cuentasContablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("1310", txtUsuario.Text) == 1)
            {
                bit.user(txtUsuario.Text);
                bit.insert("Ingreso a la aplicacion de cuentas contables", 1310);
                CapaVistaBryan.Mantenimientos.frmCuentas Cuentas = new CapaVistaBryan.Mantenimientos.frmCuentas();
                Cuentas.MdiParent = this;
                Cuentas.Show();
            }
            else
            {
                bit.user(txtUsuario.Text);
                bit.insert("Trato de ingresar a la aplicacion de cuentas contables", 1310);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
            
        }

        private void peticiónPolizaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("1309", txtUsuario.Text) == 1)
            {
                bit.user(txtUsuario.Text);
                bit.insert("Ingreso a la aplicacion de peticion poliza", 1309);
                frmPeticionPoliza asignacion = new frmPeticionPoliza(txtUsuario.Text, this);
                asignacion.MdiParent = this;
                asignacion.Show();
            }
            else
            {
                bit.user(txtUsuario.Text);
                bit.insert("Trato de ingresar a la aplicacion de peticion poliza", 1309);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void transaccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("1307", txtUsuario.Text) == 1)
            {
                bit.user(txtUsuario.Text);
                bit.insert("Ingreso al proceso de Transacciones", 1307);
                frmTransacciones asignacion = new frmTransacciones();
                asignacion.MdiParent = this;
                asignacion.Show();
            }
            else
            {
                bit.user(txtUsuario.Text);
                bit.insert("Trato de ingresar al proceso de Transacciones", 1307);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void disponibilidadDiariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                 if (seguridad.PermisosAcceso("1308", txtUsuario.Text) == 1)
            {
                bit.user(txtUsuario.Text);
                bit.insert("Ingreso al reporte de Disponibilidad Diaria", 1308);
                frmDisponibilidadDiaria asignacion = new frmDisponibilidadDiaria();
                asignacion.MdiParent = this;
                asignacion.Show();
            }
            else
            {
                bit.user(txtUsuario.Text);
                bit.insert("Trato de ingresar al reporte de Disponibilidad Diaria", 1308);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }

        }

        private void opcionesDeSesionYSalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtUsuario.Text = frm.usuario();
            }
        }

        private void cambioDeContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCambioContraseña cambioContraseña = new frmCambioContraseña(txtUsuario.Text);
            cambioContraseña.MdiParent = this;
            cambioContraseña.Show();
        }

        private void mantenimientoDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (seguridad.PermisosAcceso("2", txtUsuario.Text) == 1)
            {
                bit.user(txtUsuario.Text);
                bit.insert("Ingreso al mantenimiento de usuarios", 2);
                frmMantenimientoUsuario asignacion = new frmMantenimientoUsuario(txtUsuario.Text);
                asignacion.MdiParent = this;
                asignacion.Show();
            }
            else
            {
                bit.user(txtUsuario.Text);
                bit.insert("Trato de ingresar al mantenimiento de usuarios", 2);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void mantenimientoDeAplicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("3", txtUsuario.Text) == 1)
            {
                bit.user(txtUsuario.Text);
                bit.insert("Ingreso al mantenimiento de aplicaciones", 3);
                frmAplicativo asignacion = new frmAplicativo();
                asignacion.MdiParent = this;
                asignacion.Show();
            }
            else
            {
                bit.user(txtUsuario.Text);
                bit.insert("Trato de ingresar al mantenimiento de aplicaciones", 3);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void asignacionDePerfilYPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("6", txtUsuario.Text) == 1)
            {
                bit.user(txtUsuario.Text);
                bit.insert("Ingreso a la asignacion de aplicaciones", 6);
                frmAsignacionDeAplicaciones asignacion = new frmAsignacionDeAplicaciones();
                asignacion.MdiParent = this;
                asignacion.Show();
            }
            else
            {
                bit.user(txtUsuario.Text);
                bit.insert("Trato de ingresar a l asignacion de aplicaciones", 6);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("8", txtUsuario.Text) == 1)
            {
                bit.user(txtUsuario.Text);
                bit.insert("Ingreso a la apliacion de Modulo", 8);
                frmModulo asignacion = new frmModulo(txtUsuario.Text);
                asignacion.MdiParent = this;
                asignacion.Show();
            }
            else
            {
                bit.user(txtUsuario.Text);
                bit.insert("Trato de ingresar a la aplicacion de Modulo", 8);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void mantenimientoPerfulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("4", txtUsuario.Text) == 1)
            {
                bit.user(txtUsuario.Text);
                bit.insert("Ingreso a la apliacion de mantenimiento de perfil", 4);
                frmMantenimientoPerfil asignacion = new frmMantenimientoPerfil(txtUsuario.Text);
                asignacion.MdiParent = this;
                asignacion.Show();
            }
            else
            {
                bit.user(txtUsuario.Text);
                bit.insert("Trato de ingresar a la aplicacion de mantenimiento de perfil", 4);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void asignacionDeAplicacionesAPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("5", txtUsuario.Text) == 1)
            {
                bit.user(txtUsuario.Text);
                bit.insert("Ingreso a la apliacion de mantenimiento de perfil apliaciones a perfil", 5);
                frmMantenimientoPerfil asignacion = new frmMantenimientoPerfil(txtUsuario.Text);
                asignacion.MdiParent = this;
                asignacion.Show();
            }
            else
            {
                bit.user(txtUsuario.Text);
                bit.insert("Trato de ingresar a la aplicacione de mantenimiento de perfil apliaciones a perfil", 5);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void transaccionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "AyudaFRM/AyudaFRM.chm", "MDI.html");
        }

        private void polizasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("1311", txtUsuario.Text) == 1)
            {
                bit.user(txtUsuario.Text);
                bit.insert("Ingreso a la aplicacion de polizas", 1311);
                CapaVistaBryan.Mantenimientos.frmPolizas Cuentas = new CapaVistaBryan.Mantenimientos.frmPolizas();
                Cuentas.MdiParent = this;
                Cuentas.Show();
            }
            else
            {
                bit.user(txtUsuario.Text);
                bit.insert("Trato de ingresar a la aplicacion de polizas", 1311);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void diarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("1312", txtUsuario.Text) == 1)
            {
                bit.user(txtUsuario.Text);
                bit.insert("Ingreso a la aplicacion de libro diario", 1312);
                CapaVistaBryan.Mantenimientos.frmLibroDiario Cuentas = new CapaVistaBryan.Mantenimientos.frmLibroDiario();
                Cuentas.MdiParent = this;
                Cuentas.Show();
            }
            else
            {
                bit.user(txtUsuario.Text);
                bit.insert("Trato de ingresar a la aplicacion de libro diario", 1312);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }
    }
}
