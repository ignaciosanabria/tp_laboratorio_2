using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanabria.Ignacio2D
{
    public class Galletita : Producto
    {
        protected float _peso;
        protected static bool DeConsumo;

        public override float CalcularCostoDeProduccion
        {
            get { return this._peso*0.40f ; }
        }

        static Galletita()
        {
            Galletita.DeConsumo = true;
        }
        public Galletita(int codigo, float precio, EMarcaProducto marca, float peso)
            : base(codigo, marca, precio)
        {
            this._peso = peso;
        }

        private static string MostrarGalletita(Galletita g)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(g);
            sb.AppendFormat("PESO: {0}", g._peso);
            return sb.ToString();
        }

        public override string Consumir()
        {
            return "Comestible";
        }

        public override string ToString()
        {
            return MostrarGalletita(this);
        }



        
    }
}
