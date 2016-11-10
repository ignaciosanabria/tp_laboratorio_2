using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : PersonaGimnasio
    {
        public enum EEstadoCuenta
        { 
        MesPrueba,
        AlDia,
        Deudor
        }

        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        #region "Constructores"
        /// <summary>
        /// Constructor de alumno para poder serializar
        /// </summary>
        public Alumno()
        {

        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma):base(id,nombre,apellido,dni,nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion
        
        #region "Metodos"

        /// <summary>
        /// Metodo sobreescrito que mostrara los datos de un Alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos();
        }
       

        /// <summary>
        /// Metodo sobreescrito de la clase Persona Gimnasio.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
           string mensaje = "TOMA CLASES DE:" + this._claseQueToma.ToString();
           return mensaje;
        }

        /// <summary>
        /// Metodo que hara publico los datos de un Alumno.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos() +this.ParticiparEnClase() + "\nESTADO DE CUENTA:" + this._estadoCuenta.ToString()+"\n";
        }

        /// <summary>
        /// Verifica si un alumno toma esa clase y su estado de estado no es deudor
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase que toma el alumno</param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            if (!Object.ReferenceEquals(a, null))
            {
                if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica si el alumno no toma esa clase
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase que no toma el alumno</param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            if (!Object.ReferenceEquals(a, null))
            {
                if (a._claseQueToma != clase)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

    }
}
