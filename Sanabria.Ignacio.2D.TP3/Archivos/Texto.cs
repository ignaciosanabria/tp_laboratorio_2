using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto: IArchivo<string>
    {
        /// <summary>
        /// Metodo que guardara un string en un archivo de texto
        /// </summary>
        /// <param name="archivo">Ruta donde se guardara el archivo</param>
        /// <param name="datos">Dato que se va a guardar en el archivo</param>
        /// <returns></returns>
        public bool guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, true))
                {
                    sw.WriteLine(datos);
                }
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        /// <summary>
        /// Metodo que leera un archivo de texto
        /// </summary>
        /// <param name="archivo">Ruta donde se leera el archivo</param>
        /// <param name="datos">Dato que se va leer </param>
        /// <returns></returns>
        public bool leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    datos = sr.ReadToEnd();
                }
                return true;
            }
            catch (Exception e)
            {
                datos = "";
                throw new ArchivosException(e);
            }

        }
    }
}
