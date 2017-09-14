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


        #region Metodos
        /// <summary>
        /// Valida el numero ingresado por el usuario
        /// </summary>
        /// <param name="numeroString">String</param>
        /// <returns>retorna el numero en tipo doble si se logra el parse, y 0 si es invalido el numero ingresado</returns>
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



        /// <summary>
        /// metodo para establecer el atributo "numero"
        /// </summary>
        /// <param name="numeroString">String</param>
        private void setNumero(String numeroString)
        {
            this.numero = validarNumero(numeroString);
        }

        #endregion
    }
}
