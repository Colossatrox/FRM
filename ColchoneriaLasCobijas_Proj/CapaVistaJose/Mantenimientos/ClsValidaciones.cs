using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVistaJose.Mantenimientos
{
    class ClsValidaciones
    {

        public void funcSoloLetras(KeyPressEventArgs validar)
        {

            try
            {
                if (Char.IsLetter(validar.KeyChar))
                {
                    validar.Handled = false;
                }
                else if (Char.IsControl(validar.KeyChar))
                {
                    validar.Handled = false;
                }
                else if (Char.IsSeparator(validar.KeyChar))
                {
                    validar.Handled = false;
                }
                else
                {
                    validar.Handled = true;
                    MessageBox.Show("Ingrese solo letras", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("validacion de letras fallo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void funcSoloNumeros(KeyPressEventArgs validar)
        {

            try
            {
                if (Char.IsNumber(validar.KeyChar))
                {
                    validar.Handled = false;
                }
                else if (Char.IsControl(validar.KeyChar))
                {
                    validar.Handled = false;
                }
                else if (Char.IsSeparator(validar.KeyChar))
                {
                    validar.Handled = false;
                }
                else if (Char.IsUpper(validar.KeyChar))
                {
                    validar.Handled = false;
                }
                else
                {
                    validar.Handled = true;
                    MessageBox.Show("Ingrese solo numeros", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("validacion de letras fallo" + ex);
            }
        }

        public void funcNumerosYpuntos(KeyPressEventArgs validar)
        {
            if ((validar.KeyChar >= 32 && validar.KeyChar <= 47) || (validar.KeyChar >= 59 && validar.KeyChar <= 255))
            {
                MessageBox.Show("Debe ingresar solo Numeros", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MessageBox.Show("");
                validar.Handled = true;
                return;
            }


        }

        public void funcSueldo(KeyPressEventArgs validar)
        {
            if ((validar.KeyChar >= 32 && validar.KeyChar <= 45) || (validar.KeyChar == 47) || (validar.KeyChar >= 58 && validar.KeyChar <= 255))
            {
                MessageBox.Show("Debe ingresar solo Numeros", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                validar.Handled = true;
                return;
            }


        }

        public void funcTelefono(KeyPressEventArgs validar)
        {
            if ((validar.KeyChar >= 32 && validar.KeyChar <= 39) || (validar.KeyChar == 42) || (validar.KeyChar == 44) || (validar.KeyChar >= 46 && validar.KeyChar <= 47) || (validar.KeyChar >= 58 && validar.KeyChar <= 255))
            {
                MessageBox.Show("Debe ingresar solo Numeros", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                validar.Handled = true;
                return;
            }


        }




    }

}

