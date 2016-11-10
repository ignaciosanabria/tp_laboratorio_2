using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class PersonaGimnasio : Persona
    {
        private int _identificador;

        #region "Constructor"
        /// <summary>
        /// Constructor de PersonaGimnasio para poder serializar
        /// </summary>
        public PersonaGimnasio()
        { 
        
        }
        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._identificador = id;
        }
        #endregion

        #region "Metodos
        /// <summary>
        /// Metodo virtual que mostrara los datos de una persona
        /// </summary>
        /// <returns>Retornara todos los datos de una persona</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.ToString());
            sb.AppendFormat("\nCARNET NUMERO: {0}", this._identificador);
            sb.AppendLine("");
            return sb.ToString();
        }

        /// <summary>
        /// Metodo abstracto que retorna un string
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        /// <summary>
        /// Verifica si dos objetos son del mismo tipo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Retornara true si son del mismo tipo, caso contrario retornara false</returns>
        public override bool Equals(object obj)
        {
            if (obj is PersonaGimnasio)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica si dos personas son iguales por su identificador o DNI
        /// </summary>
        /// <param name="pg1">PersonaGimnasio a comparar</param>
        /// <param name="pg2">PersonaGimnasio a comparar</param>
        /// <returns></returns>
        public static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            if (!Object.ReferenceEquals(pg1, null) && !Object.ReferenceEquals(pg2, null))
            {
                if (pg1.Equals(pg2))
                {
                    if (pg1._identificador == pg2._identificador || pg1.DNI == pg2.DNI)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Verifica si dos personas son distintas por su identificador o DNI
        /// </summary>
        /// <param name="pg1">PersonaGimnasio a comparar</param>
        /// <param name="pg2">PersonaGimnasio a comparar</param>
        /// <returns></returns>
        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion

    }
}
