using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Instructor : PersonaGimnasio
    {
        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;
        
        #region "Constructores
        /// <summary>
        /// Constructor para serializar 
        /// </summary>
        public Instructor()
        { }

        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(id,nombre,apellido,dni,nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this.RandomClases();
            this.RandomClases();
        }

        static Instructor()
        {
            Instructor._random = new Random();
        }
#endregion

        #region "Metodos"

        /// <summary>
        /// Metodo que asigna una clase al azar
        /// </summary>
        private void RandomClases()
        {
            this._clasesDelDia.Enqueue((Gimnasio.EClases)_random.Next(0, 3));
        }

        /// <summary>
        /// Metodo que retornara un string con las clases que tiene el Instructor
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            string mensaje = "CLASES DEL DIA:\n";
            string aux = "";
            foreach (Gimnasio.EClases item in this._clasesDelDia)
            {
                aux += item.ToString()+"\n";
            }
            return mensaje + aux;
        }

        /// <summary>
        /// Metodo que retornara los datos de un Instructor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos();
        }
        /// <summary>
        /// Metodo que hara publico los datos de un instructor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos() + this.ParticiparEnClase()+"\n";
        }

        /// <summary>
        /// Verifica si el instructor da esa clase
        /// </summary>
        /// <param name="i">Instructor a comparar</param>
        /// <param name="clase">Clase que da el instructor</param>
        /// <returns></returns>
        public static bool operator ==(Instructor i, Gimnasio.EClases clase)
        {
            if (!Object.ReferenceEquals(i, null))
            {     
                foreach (Gimnasio.EClases item in i._clasesDelDia)
                {
                    if (item == clase)
                    {
                        return true;
                    }

                }
            }
            return false;
        }

        /// <summary>
        /// Verifica si el instructor no da esa clase
        /// </summary>
        /// <param name="i">Instructor a comparar</param>
        /// <param name="clase">Clase que no da el instructor</param>
        /// <returns></returns>
        public static bool operator !=(Instructor i, Gimnasio.EClases clase)
        {
            return !(i == clase);
        }

        #endregion
    }
}
