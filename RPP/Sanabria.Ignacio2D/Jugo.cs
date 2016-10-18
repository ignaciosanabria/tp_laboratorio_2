using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanabria.Ignacio2D
{
    public class Jugo : Producto
    {
        protected ESaborJugo _sabor;
        protected static bool DeConsumo;

        public enum ESaborJugo
        {
            Asqueroso,
            Pasable,
            Rico
        }


        static Jugo()
        {
            Jugo.DeConsumo = true;
        }
        public Jugo(int codigoBarra, float precio, EMarcaProducto marca, ESaborJugo sabor)
            : base(codigoBarra, marca, precio)
        {
            this._sabor = sabor;
        }

        public override float CalcularCostoDeProduccion
        {
            get
            {
                return this.Precio * 0.40f;
            }
        }

        private string MostrarJugo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(this);
            sb.AppendFormat("Sabor: {0}", this._sabor);
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarJugo();
        }

        public override string Consumir()
        {
            return "Bebible";
        }

    }
}
