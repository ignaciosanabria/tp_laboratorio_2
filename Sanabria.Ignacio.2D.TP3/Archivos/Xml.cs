using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Metodo que guardara un objeto generico en un XML
        /// </summary>
        /// <param name="archivo">Ruta donde se guardara el archivo</param>
        /// <param name="datos">Objeto generico que se guardara</param>
        /// <returns></returns>
        public bool guardar(string archivo, T datos)
        {
            try
            {
                using (XmlTextWriter escritor = new XmlTextWriter(archivo, UTF8Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(escritor, datos);
                    escritor.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        /// <summary>
        /// Metodo que leera un archivo XML
        /// </summary>
        /// <param name="archivo">Ruta del archivo donde se leera</param>
        /// <param name="datos">Objeto generico que se va leer</param>
        /// <returns></returns>
        public bool leer(string archivo, out T datos)
        {
            try
            {
                using (XmlTextReader lector = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    datos = (T)ser.Deserialize(lector);
                    lector.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                datos = default(T);
                throw new ArchivosException(e);
            }
        }
    }
}
