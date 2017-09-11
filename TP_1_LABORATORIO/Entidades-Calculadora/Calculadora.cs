using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_Calculadora
{
 
    public class Calculadora
    {
        public static double Operar(Numero numero1, Numero numero2, String operador)
        {
            switch(operador)
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

        /*public static String validarOperador(String operador)
        {

        }*/
    }
}
