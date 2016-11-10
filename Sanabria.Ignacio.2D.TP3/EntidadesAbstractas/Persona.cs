using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string _apellido;
        private int _dni;
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        private ENacionalidad _nacionalidad;
        private string _nombre;

        /// <summary>
        /// Constructor de persona para poder serializar 
        /// </summary>
        public Persona()
        { }

        #region "Propiedades"
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }

        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = Persona.ValidarNombreApellido(value);
            }
        }
        public int DNI
        {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni = Persona.ValidarDni(this.Nacionalidad, value);
            }
        }

        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = Persona.ValidarNombreApellido(value);
            }
        }
        public string StringToDNI
        {
            set
            {
                this._dni = Persona.ValidarDni(this.Nacionalidad, value);
            }
        }

        #endregion

        #region "Constructores"
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region "Metodos"
        
       /// <summary>
       /// Validara que el DNI este dentro del rango numerico permitido segun la nacionalidad.
       /// </summary>
       /// <param name="nacionalidad">Nacionalidad del dni</param>
       /// <param name="dato">DNI numerico a validar</param>
       /// <returns>DNI validado si todo esta correcto, o 0(cero) en caso de error</returns>
       private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            { 
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                    {
                        throw new NacionalidadInvalidaException(dato.ToString());
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 89999999 || dato > 99999999)
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
            }
            return dato;
        }

      
        /// <summary>
        /// Validara que el string que se le pase sea un numero de DNI valido
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Retornara un int parseado y validado correctamente</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        { 
            //Quito los . que pueda tener el dni
            dato = dato.Replace(".","");
           // Compruebo que el dni tenga por lo menos un 1 numero y no más de 8.
            if(dato.Length < 1 || dato.Length > 8)
                throw new DniInvalidoException(dato.ToString());
            int numeroRetorno;
            try
            {
                numeroRetorno = int.Parse(dato);
            }
            catch(Exception e)
            {
             throw new DniInvalidoException(dato.ToString(),e);
            }

            return Persona.ValidarDni(nacionalidad,numeroRetorno);
        }

        /// <summary>
        /// Validara que el nombre o apellido este compuesto por letras de la a a la z.
        /// </summary>
        /// <param name="dato">Nombre o apellido a validar</param>
        /// <returns>Nombre o apellido validado si todo esta correcto, o un string vacio en caso de error</returns>
        private static string ValidarNombreApellido(string dato)
        {
            //Expresión regular que sirve para buscar caracteres de a a la z minúsculas y mayúsculas con infinita repeticiones.
            Regex regex = new Regex(@"[a-zA-Z]*");
            //Valido el dato 
            Match match = regex.Match(dato);

            if (match.Success)
            {
                return match.Value;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Metodo que mostrara los datos de una Persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO:{0} , {1}", this._nombre, this._apellido);
            sb.AppendFormat("NACIONALIDAD: {0}", this._nacionalidad);
            return sb.ToString();
        }
        #endregion

    }
}
