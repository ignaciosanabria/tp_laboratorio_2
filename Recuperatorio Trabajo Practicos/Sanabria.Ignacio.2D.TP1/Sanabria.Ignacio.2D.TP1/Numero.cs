using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanabria.Ignacio._2D.TP1
{
    public class Numero
    {
        private double _numero;

        #region "Constructores"
        /// <summary>
        /// Constructor sin parametros. Inicializa el atributo Numero en 0
        /// </summary>
        public Numero():this(0)
        { 
        
        }
        /// <summary>
        /// Inicializa el atributo Numero con el valor del parametro numero
        /// </summary>
        /// <param name="numero">Numero a asignar</param>
        public Numero(double numero)
        {
            this._numero = numero;
        }

        /// <summary>
        /// Inicializa el valor del numero con el parametro string que se le pasa. Se lo valida primero si es un numero valido o 0 en caso de error
        /// </summary>
        /// <param name="numero">Numero a Asignar</param>
        public Numero(string numero)
        {
            this.setNumero(numero);
        }

        #endregion

        #region "Metodos"
        /// <summary>
        /// Metodo que validara un numero en string que se le pasa como parametro
        /// </summary>
        /// <param name="numero">Numero a validar</param>
        /// <returns>Retornara un numero validado o 0 en caso de error</returns>
        private static double ValidarNumero(string numero)
        {
            double retorno;
            if(double.TryParse(numero,out retorno))
            {
            return retorno;
            }
            return 0;
        }

        private void setNumero(string numero)
        {
            this._numero = Numero.ValidarNumero(numero);
        }

        public double GetNumero()
        {
            return this._numero;
        }

        #endregion

        #region "Operadores"
        /// <summary>
        /// Operador Suma. Sumara dos numeros
        /// </summary>
        /// <param name="num1">Primer numero</param>
        /// <param name="num2">Segundo numero</param>
        /// <returns></returns>
        public static double operator +(Numero num1, Numero num2)
        {
            if (!Object.ReferenceEquals(num1, null) && !Object.ReferenceEquals(num2, null))
            {
                return num1.GetNumero() + num2.GetNumero();
            }
            return 0;
        }

        /// <summary>
        /// Operador Resta. Restara dos numeros
        /// </summary>
        /// <param name="num1">Primer numero</param>
        /// <param name="num2">Segundo numero</param>
        /// <returns></returns>
        public static double operator -(Numero num1, Numero num2)
        {
            if (!Object.ReferenceEquals(num1, null) && !Object.ReferenceEquals(num2, null))
            {
                return num1.GetNumero() - num2.GetNumero();
            }
            return 0;
        }

        /// <summary>
        /// Operador Multiplicacion. Multiplicara dos numeros
        /// </summary>
        /// <param name="num1">Primer numero</param>
        /// <param name="num2">Segundo numero</param>
        /// <returns></returns>
        public static double operator *(Numero num1, Numero num2)
        {
            if (!Object.ReferenceEquals(num1, null) && !Object.ReferenceEquals(num2, null))
            {
                return num1.GetNumero() * num2.GetNumero();
            }
            return 0;
        }

        /// <summary>
        /// Operador Division. Dividara dos numeros
        /// </summary>
        /// <param name="num1">Primer numero</param>
        /// <param name="num2">Segundo numero</param>
        /// <returns></returns>
        public static double operator /(Numero num1, Numero num2)
        {
            if (!Object.ReferenceEquals(num1, null) && !Object.ReferenceEquals(num2, null))
            {
                return num1.GetNumero() / num2.GetNumero();
            }
            return 0;
        }

        #endregion
    }
}
