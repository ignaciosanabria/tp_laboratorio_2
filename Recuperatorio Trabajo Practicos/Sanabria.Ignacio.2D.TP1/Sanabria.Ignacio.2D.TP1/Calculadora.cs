using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanabria.Ignacio._2D.TP1
{
    public class Calculadora
    {
        /// <summary>
        /// Metodo que realizara un operacion matematica entre dos numero
        /// </summary>
        /// <param name="numero1">Numero a operar</param>
        /// <param name="numero2">Numero a operar</param>
        /// <param name="operador">Operador de la operacion</param>
        /// <returns>Retornara el valor de la operacion</returns>
        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            double retorno = 0;
            switch (Calculadora.validarOperador(operador))
            { 
                case "+":
                    retorno = numero1 + numero2;
                    break;
                case "-":
                    retorno = numero1 - numero2;
                    break;
                case "*":
                    retorno = numero1 * numero2;
                    break;
                case "/":
                    if (numero2.GetNumero() == 0)
                    {
                        retorno = 0;
                    }
                    else
                    {
                        retorno = numero1 / numero2;
                    }
                    break;
            }
            return retorno;
        }

        /// <summary>
        /// Metodo que validara el operador
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns>Retornara un operador valido en caso de exito o + en caso que no sea ninguno</returns>
        public static string validarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                return operador;
            }
            else
            {
                return "+";
            }
        }
    }
}
