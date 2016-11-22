using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _rutaArchivo;

        public Texto(string archivo)
        {
            this._rutaArchivo = archivo;
        }

        public bool guardar(string datos)
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(this._rutaArchivo))
                {
                    escritor.WriteLine(datos);
                    escritor.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool leer(out List<string> datos)
        {
            datos = new List<string>();
            try
            {
                using (StreamReader lector = new StreamReader(this._rutaArchivo))
                {
                    while (!lector.EndOfStream)
                    {
                        datos.Add(lector.ReadLine());
                    }
                    lector.Close();
                }
                return true;
            }
            catch(Exception)
            {
            datos = default(List<string>);
            return false;
            }
        }
    }
}
