using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanabria.Ignacio2D
{
    public class Gaseosa : Producto
    {
        protected float _litros;
        protected static bool DeConsumo;

        public override float CalcularCostoDeProduccion
        {
            get { return this._precio * 0.42f; }
        }

        static Gaseosa()
        {
            Gaseosa.DeConsumo = true;
        }
        public Gaseosa(int codigoBarra, float precio, EMarcaProducto marca, float litros)
            : base(codigoBarra, marca, precio)
        {
            this._litros = litros;
        }

        public Gaseosa(Producto p, float litros)
            : this((int)p, p.Precio, p.Marca, litros)
        { 
        
        }

        private string MostrarGalletita()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(this);
            sb.AppendFormat("LITROS: {0}", this._litros);
            return sb.ToString();
        }

        public override string Consumir()
        {
            return "Bebible";
        }
        public override string ToString()
        {
            return MostrarGalletita();
        }

    }
}
