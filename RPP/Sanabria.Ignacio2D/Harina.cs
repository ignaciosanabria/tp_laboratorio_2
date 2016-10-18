using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanabria.Ignacio2D
{
    public class Harina : Producto
    {
        protected ETipoHarina _tipo;
        protected static bool DeConsumo;

        public enum ETipoHarina
        {
            TresCeros,
            CuatroCeros,
            Integral
        }

        public override float CalcularCostoDeProduccion
        {
            get { return this._precio * 0.60f; }
        }

        static Harina()
        {
            Harina.DeConsumo = false;
        }
        public Harina(int codigoBarra, float precio,EMarcaProducto marca, ETipoHarina tipo):base(codigoBarra, marca, precio)
        {
            this._tipo = tipo;
        }

        private string MostrarHarina()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(this);
            sb.AppendFormat("TIPO: {0}", this._tipo);
            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarHarina();
        }


        
    }
}
