using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico1
{
    public class Numero
    {
        private double numero;
        /// <summary>
        /// CONSTRUCTOR SIN PARAMETROS. INICIALIZA EL ATRIBUTO PRIVADO NUMERO EN 0.
        /// </summary>
        public Numero():this(0)
        {
          
        }

        /// <summary>
        /// CONSTRUCTOR CON PARAMETRO STRING. LE DA VALOR AL ATRIBUTO PRIVADO NUMERO CON UN PARSEO DOUBLE DEL STRING NUMERO. 
        /// </summary>
        /// <param name="numero"></param>
        public Numero(string numero):this(double.Parse(numero))
        {
            
        }

        /// <summary>
        /// CONSTRUCTOR CON PARAMETRO DOUBLE. LE DA VALOR AL ATRIBUTO PRIVADO NUMERO CON LA ASIGNACION DEL PARAMETRO.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// METODO QUE VALIDA EL STRING numeroString Y RETORNA UN NUMERO DOUBLE SI ES QUE SE PUDO PARSEAR.
        /// </summary>
        /// <param name="numeroString"></param>
        /// <returns></returns>
        private static double validarNumero(string numeroString)
        {

            bool pudo;
            double result;
            double numero;
             
            pudo = double.TryParse(numeroString,out result);

            if(pudo == true)
            {
                numero = result;
            }
            else
            {
                numero = 0;
            }

            return numero;
        }

        /// <summary>
        /// METODO SETTER QUE ASIGNA AL ATRIBUTO NUMERO DE LA CLASE LA VALIDACION DEL METODO PRIVADO STATICO validarNumero.
        /// </summary>
        /// <param name="numero"></param>
        private void setNumero(string numero)
        {
            this.numero = validarNumero(numero);
        }

       /// <summary>
       /// METODO GETTER QUE RETORNA EL NUMERO PRIVADO DE LA CLASE.
       /// </summary>
       /// <returns></returns>
        public double getNumero()
        {
            return this.numero;
        }

    }
}
