using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanabria.Ignacio2D
{
    public abstract class Producto
    {
        protected int _codigoBarra;
        protected float _precio;
        protected EMarcaProducto _marca;

        public enum EMarcaProducto
        {
            Manaos,
            Pitusas,
            Naranjú,
            Diversión,
            Swift,
            Favorita
        }
        public enum ETipoProducto
        {
            Galletita,
            Harina,
            Jugo,
            Gaseosa,
            Todos
        }

        #region "Propiedades"
        public EMarcaProducto Marca
        {
            get
            {
                return this._marca;
            }
        }
        public float Precio
        {
            get
            {
                return this._precio;
            }
        }
        public abstract float CalcularCostoDeProduccion
        {
            get;
        }
        #endregion

        #region "Metodos"
        public Producto(int codigoBarra, EMarcaProducto marca, float precio)
        {
            this._codigoBarra = codigoBarra;
            this._marca = marca;
            this._precio = precio;
        }

        private static string Mostrar(Producto p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\nMARCA: {0} \n CODIGO: {1} \n PRECIO: {2}\n", p._marca, p._codigoBarra, p._precio);
            return sb.ToString();
        }

        public static bool operator ==(Producto prodUno, Producto prodDos)
        {
            if (!Object.ReferenceEquals(prodUno, null) && !Object.ReferenceEquals(prodDos, null))
            {
                if (prodUno._codigoBarra == prodDos._codigoBarra && prodUno._precio == prodDos._precio && string.Compare(prodUno._marca.ToString(), prodDos._marca.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public static bool operator !=(Producto prodUno, Producto prodDos)
        {
            return !(prodUno == prodDos);
        }
        public static bool operator ==(Producto prodUno, EMarcaProducto marca)
        {
            if (!Object.ReferenceEquals(prodUno, null))
            {
                if (prodUno._marca == marca)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public static bool operator !=(Producto prodUno, EMarcaProducto marca)
        {
            return !(prodUno == marca);
        }
        public static explicit operator int(Producto p)
        {
            return p._codigoBarra;
        }
        public static implicit operator string(Producto p)
        {
            return Producto.Mostrar(p);
        }

        public override bool Equals(object obj)
        {
            if (this._marca == ((Producto)obj)._marca)
            {
                return true;
            }
            return false;
        }

        public virtual string Consumir()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Parte de una mezcla");
            return sb.ToString();
        }
       


        #endregion


    }
}
