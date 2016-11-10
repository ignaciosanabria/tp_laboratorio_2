using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;
using System.Xml;
using System.Xml.Serialization;


namespace EntidadesInstanciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Instructor))]
    [XmlInclude(typeof(Jornada))]
    public class Gimnasio
    {
        public enum EClases
        { 
        Pilates = 0,
        Natacion = 1,
        CrossFit = 2,
        Yoga = 3
        }
        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        private List<Jornada> _jornada;

        #region "Propiedades"
        /// <summary>
        /// Indexador que permite acceder a una jornada especifica
        /// </summary>
        /// <param name="indice"></param>
        /// <returns></returns>
        public Jornada this[int indice]
        {
            get
            {
                if (indice < this._jornada.Count || indice > this._jornada.Count)
                    return this._jornada[indice];
                else
                    return null;
            }
        }

        /// <summary>
        /// Propiedad get para poder serializar
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this._alumnos;
            }
        }
        /// <summary>
        /// Propiedad get para poder serializar
        /// </summary>
        public List<Instructor> Instructores
        {
            get
            {
                return this._instructores;
            }
        }
        /// <summary>
        /// Propiedad get para poder serializar
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this._jornada;
            }
        }
        #endregion


        #region "Metodos"

        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }
        /// <summary>
        /// Metodo que guardara un gimnasio en un archivo xml
        /// </summary>
        /// <param name="gim">Gimnasio a guardar</param>
        /// <returns></returns>
        public static bool Guardar(Gimnasio gim)
        {
            Xml<Gimnasio> xml = new Xml<Gimnasio>();
            if (xml.guardar(@"C:\Gimnasio.xml", gim))
            {
                
                return true;
            }
            return false;
        }
       /// <summary>
       /// Metodo que leera un gimnasio y mostrara por consola sus datos
       /// </summary>
       /// <param name="gim">Gimnasio a leer</param>
       /// <returns></returns>
       public static bool Leer(Gimnasio gim)
        {
            Xml<Gimnasio> xml = new Xml<Gimnasio>();
            Gimnasio aux;
            if(xml.leer(@"C:\Gimnasio.xml",out aux))
            {
             Console.WriteLine(aux.ToString());
             return true;
            }
            return false;
        }

       /// <summary>
       /// Verifica si el alumno esta inscripto en el gimnasio
       /// </summary>
       /// <param name="g">Gimnasio</param>
       /// <param name="a">Alumno a buscar</param>
       /// <returns></returns>
 
       public static bool operator ==(Gimnasio g, Alumno a)
        {
            if (!Object.ReferenceEquals(g, null) && !Object.ReferenceEquals(a, null))
            {
                foreach (Alumno item in g._alumnos)
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
       /// Verifica si el alumno no esta inscripto en el gimnasio
       /// </summary>
       /// <param name="g">Gimnasio</param>
       /// <param name="a">Alumno que no esta en el gimnasio</param>
       /// <returns></returns>
 
       public static bool operator !=(Gimnasio g, Alumno a)
        {
            return !(g == a);
        }

       /// <summary>
       /// Verifica si el instructor se encuentra dando clases en el gimnasio
       /// </summary>
       /// <param name="g">Gimnasio</param>
       /// <param name="i">Instructor que esta en el gimnasio</param>
       /// <returns></returns>
 
       public static bool operator ==(Gimnasio g, Instructor i)
        {
            if (!Object.ReferenceEquals(g, null) && !Object.ReferenceEquals(i, null))
            {
                foreach (Instructor item in g._instructores)
                {
                    if (item == i)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

       /// <summary>
       /// Verifica si el instructor no se encuentra dando clases en el gimnasio
       /// </summary>
       /// <param name="g">Gimnasio</param>
       /// <param name="i">Instructor que no esta en el gimnasio</param>
       /// <returns></returns>
       public static bool operator !=(Gimnasio g, Instructor i)
        {
            return !(g == i);
        }

       /// <summary>
       /// Agregara un alumno siempre y cuando no se encuentre en el gimnasio
       /// </summary>
       /// <param name="g">Gimnasio</param>
       /// <param name="a">Alumno a agregar</param>
       /// <returns></returns>
 
       public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            if (!Object.ReferenceEquals(g, null) && !Object.ReferenceEquals(a, null))
            {
                if (g != a)
                {
                    g._alumnos.Add(a);
                }
                else
                {
                    throw new AlumnoRepetidoException();
                }
            }
            return g;
        }

       /// <summary>
       /// Agregara un instructor al gimnasio siempre y cuando no se encuentre en el gimnasio
       /// </summary>
       /// <param name="g">Gimnasio</param>
       /// <param name="i">Instructor que se va a agregar</param>
       /// <returns></returns>
 
       public static Gimnasio operator +(Gimnasio g, Instructor i)
        {
            if (!Object.ReferenceEquals(g, null) && !Object.ReferenceEquals(i, null))
            {
                if (g != i)
                {
                    g._instructores.Add(i);
                }
            }
            return g;
        }

       /// <summary>
       /// Metodo que mostrara los datos del gimnasio
       /// </summary>
       /// <param name="gim"></param>
       /// <returns></returns>
       private static string MostrarDatos(Gimnasio gim)
        {
            string mensaje = "";
            foreach (Jornada item in gim._jornada)
            {
                mensaje += ((Jornada)item).ToString();
            }
            return mensaje;
        }

       /// <summary>
       /// Metodo que hara publico los datos del gimnasio
       /// </summary>
       /// <returns></returns>
 
       public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }

       /// <summary>
       /// Verifica si hay al menos un instructor que pueda dar la clase en el gimnasio
       /// </summary>
       /// <param name="gim">Gimnasio</param>
       /// <param name="clase">Clase que espera un instructor que pueda darla</param>
       /// <returns></returns>
        public static Instructor operator ==(Gimnasio gim, Gimnasio.EClases clase)
       {
           
           if (!Object.ReferenceEquals(gim, null))
           {
               foreach (Instructor item in gim._instructores)
               {
                   if (item == clase)
                   {
                       return item;
                   }
               }
           }
           throw new SinInstructorException();
       }

      /// <summary>
      /// Verifica si no hay un instructor que no pueda dar esa clase
      /// </summary>
      /// <param name="gim">Gimnasio</param>
      /// <param name="clase"></param>
      /// <returns></returns>
      public static Instructor operator !=(Gimnasio gim, Gimnasio.EClases clase)
       {
           if (!Object.ReferenceEquals(gim, null))
           {
               foreach (Instructor item in gim._instructores)
               {
                   if (item != clase)
                   {
                       return item;
                   }
               }
           }
           return null;
       }
       /// <summary>
       /// Agregara una nueva clase a la jornada del gimnasio siempre cuando haya un instructor que pueda darla y que tenga alumnos que la tomen
       /// </summary>
       /// <param name="gim">Gimnasio</param>
       /// <param name="clase">Clase a agregar en jornada</param>
       /// <returns></returns>
       public static Gimnasio operator +(Gimnasio gim, Gimnasio.EClases clase)
       {
           if (!Object.ReferenceEquals(gim, null))
           {
               switch (clase)
               { 
                   case Gimnasio.EClases.CrossFit:
                       Jornada aux = new Jornada(clase, gim == clase);
                       foreach (Alumno item in gim._alumnos)
                       {
                           if (item == clase)
                           {
                               aux += item;
                           }
                       }
                       gim._jornada.Add(aux);
                       return gim;
                   case Gimnasio.EClases.Natacion:
                       Jornada aux2 = new Jornada(clase, gim == clase);
                       foreach (Alumno item in gim._alumnos)
                       {
                           if (item == clase)
                           {
                               aux2 += item;
                           }
                       }
                       gim._jornada.Add(aux2);
                       return gim;
                   case Gimnasio.EClases.Pilates:
                       Jornada aux3 = new Jornada(clase, gim == clase);
                       foreach (Alumno item in gim._alumnos)
                       {
                           if (item == clase)
                           {
                               aux3 += item;
                           }
                       }
                       gim._jornada.Add(aux3);
                       return gim;
                   case Gimnasio.EClases.Yoga:
                       Jornada aux4 = new Jornada(clase, gim == clase);
                       foreach (Alumno item in gim._alumnos)
                       {
                           if (item == clase)
                           {
                               aux4 += item;
                           }
                       }
                       gim._jornada.Add(aux4);
                       return gim;
               }
           }
           return null;
       }
        #endregion
    }
}
