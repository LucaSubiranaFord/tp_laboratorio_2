using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_Calculadora
{
 
    public class Calculadora
    {
        #region Metodos
        /// <summary>
        /// Realiza las operaciones entre los valores ingresados por el usuario.
        /// </summary>
        /// <param name="numero1">Numero</param>
        /// <param name="numero2">Numero</param>
        /// <param name="operador">String</param>
        /// <returns>Retorna el resultado de la operacion a realizarse. Retorna 0 por default o si "numero2" es 0</returns>
        public static double Operar(Numero numero1, Numero numero2, String operador)
        {
            switch(validarOperador(operador))
            {
                case "+":
                    return (numero1.numero+numero2.numero);
                case "-":
                    return (numero1.numero-numero2.numero);
                case "*":
                    return (numero1.numero*numero2.numero);
                case "/":
                    if(numero2.numero == 0)
                    {
                        return 0;
                    }else
                    {
                        return (numero1.numero / numero2.numero);
                    }
                    
                default:
                    return 0;
            }
        }




        /// <summary>
        /// Verifica si es valido el operador ingresado por el usuario
        /// </summary>
        /// <param name="operador">String</param>
        /// <returns>Retorna el operador ingresado por el usuario. Si es invalido, retorna el operador "+"</returns>
        public static String validarOperador(String operador)
        {
            switch (operador)
            {
                case "+":
                    return operador;
                case "-":
                    return operador;
                case "*":
                    return operador;
                case "/":
                    return operador;
                default:
                    return "+";
            } 
        }

        #endregion
    }
}
