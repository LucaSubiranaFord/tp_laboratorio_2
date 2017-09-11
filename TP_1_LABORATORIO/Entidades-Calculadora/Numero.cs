using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_Calculadora
{
    public class Numero
    {
        public double numero;

        #region Constructores
        public Numero()
        {
            numero = 0;
        }

        public Numero(String numeroString) :this()
        {
            setNumero(numeroString);
        }

        public Numero(double numero) : this()
        {
            this.numero = numero;
        }
        #endregion

        private static double validarNumero(String numeroString)
        {
            double numeroDouble = 0;

            if(double.TryParse(numeroString, out numeroDouble))
            {
                return numeroDouble;
            }else
            {
                return 0;
            }
        }

        private void setNumero(String numeroString)
        {
            this.numero = validarNumero(numeroString);
        }
    }
}
