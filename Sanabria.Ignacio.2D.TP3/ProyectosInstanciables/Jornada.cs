using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace EntidadesInstanciables
{
    [Serializable]
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Gimnasio.EClases _clase;
        private Instructor _instructor;

        #region "Constructores"

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }
        public Jornada(Gimnasio.EClases clase, Instructor instructor):this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion


        #region "Propiedades"
        /// <summary>
        /// Propiedad get que serializara las clases
        /// </summary>
        public Gimnasio.EClases Clase
        {
            get
            {
                return this._clase;
            }
        }
        /// <summary>
        /// Propiedad get que serializar el instructor
        /// </summary>
        public Instructor Instructor
        {
            get
            {
                return this._instructor;
            }
        }
        #endregion


        #region "Metodos"

        /// <summary>
        /// Verifica si el alumno participa de la clase
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno a buscar en la clase</param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            if (!Object.ReferenceEquals(j, null) && !Object.ReferenceEquals(a, null))
            {
                foreach (Alumno item in j._alumnos)
                {
                    if (item == a)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Verifica si el alumno no participa en la clase
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno que no esta en la clase</param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a la clase si el mismo no participa de la clase
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno a agregar en la clase</param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (!Object.ReferenceEquals(j, null) && !Object.ReferenceEquals(a, null))
            {
                if (j != a)
                {
                    j._alumnos.Add(a);
                }
            }
            return j;
        }
        /// <summary>
        /// Metodo que hara publico los datos de una Jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\nJORNADA:");
            sb.AppendLine("");
            sb.AppendFormat("CLASE DE {0} POR {1} \n", this._clase.ToString(), this._instructor.ToString());
            sb.AppendFormat("ALUMNOS:");
            foreach (Alumno item in this._alumnos)
            {
                sb.AppendFormat("\n"+item.ToString());
            }
            sb.AppendLine("");
            sb.AppendFormat("<-------------------------->");
            return sb.ToString();
        }
        /// <summary>
        /// Metodo que guardara una jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada">Jornada a guardar en archivo de texto</param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto text = new Texto();
            if (text.guardar(@"C:\Jornada.txt", jornada.ToString()))
            {
              return true;
            }
            return false;
        }

        /// <summary>
        /// Metodo que leera un archivo de texto y lo mostrara por Consola
        /// </summary>
        /// <param name="jornada">Jornada a leer</param>
        /// <returns></returns>
        public static bool Leer(Jornada jornada)
        {
            Texto text = new Texto();
            string datos;
            if (text.leer(@"C:\Jornada.txt", out datos))
            {
            Console.WriteLine(datos);
            return true;
            }
            return false;
        }

        
        #endregion
    }
}
