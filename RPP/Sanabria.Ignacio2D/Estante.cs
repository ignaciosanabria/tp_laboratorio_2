using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanabria.Ignacio2D
{
    public class Estante
    {
        protected byte _capacidad;
        protected List<Producto> _productos;
        private Estante()
        {
            this._productos = new List<Producto>();
        }
        public Estante(byte capacidad):this()
        {
            this._capacidad = capacidad;
        }
        #region "Propiedades"
        public float ValorEstanteTotal
        {
            get
            {
                return this.GetValorEstante();
            }
        }

        #endregion


        #region "Metodos

        public List<Producto> GetProductos()
        {
            return this._productos;
        }

        public static string MostrarEstante(Estante e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Capacidad: {0}", e._capacidad);
            foreach (Producto item in e._productos)
            {
                if (item is Gaseosa)
                {
                    sb.AppendFormat(((Gaseosa)item).ToString());
                }
                if (item is Galletita)
                {
                    sb.AppendFormat(((Galletita)item).ToString());
                }
                if (item is Jugo)
                {
                    sb.AppendFormat(((Jugo)item).ToString());
                }
                if (item is Harina)
                {
                    sb.AppendFormat(((Harina)item).ToString());
                }
            }
            return sb.ToString();
        }

        public static bool operator ==(Estante e, Producto prod)
        {
            if (!Object.ReferenceEquals(e, null) && !Object.ReferenceEquals(prod, null))
            {
                foreach (Producto item in e._productos)
                {
                    if (item == prod)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator !=(Estante e, Producto prod)
        {
            return !(e == prod);
        }

        public static bool operator +(Estante e, Producto prod)
        {
            if (!Object.ReferenceEquals(e, null) && !Object.ReferenceEquals(prod, null))
            {
                if (e._productos.Count < e._capacidad && e != prod)
                {
                    e._productos.Add(prod);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        
        public static Estante operator -(Estante e, Producto prod)
        {
            if (!Object.ReferenceEquals(e, null) && !Object.ReferenceEquals(prod, null))
            {
                if (e == prod)
                {
                    e._productos.Remove(prod);
                }
              
            }
            return e;
        }

        public static Estante operator -(Estante e, Producto.ETipoProducto tipo)
        {
            if (!Object.ReferenceEquals(e, null))
            {
                if (tipo == Producto.ETipoProducto.Galletita)
                {
                    for (int i = 0; i < e._productos.Count; i++)
                    {
                        if (e._productos[i] is Galletita)
                        {
                            e._productos.RemoveAt(i);
                        }
                    }
                }
                else
                {
                    if (tipo == Producto.ETipoProducto.Galletita)
                    {
                        for (int i = 0; i < e._productos.Count; i++)
                        {
                            if (e._productos[i] is Gaseosa)
                            {
                                e._productos.RemoveAt(i);
                            }
                        }
                    }
                    else
                    {
                        if (tipo == Producto.ETipoProducto.Harina)
                        {
                            for (int i = 0; i < e._productos.Count; i++)
                            {
                                if (e._productos[i] is Harina)
                                {
                                    e._productos.RemoveAt(i);
                                }
                            }

                        }
                        else
                        {
                            if (tipo == Producto.ETipoProducto.Jugo)
                            {
                                for (int i = 0; i < e._productos.Count; i++)
                                {
                                    if (e._productos[i] is Jugo)
                                    {
                                        e._productos.RemoveAt(i);
                                    }
                                }
                            }
                            else
                            {
                                e._productos.Clear();
                            }
                        }
                    }
                }
            }
            return e;
        }

        public float GetValorEstante(Producto.ETipoProducto tipo)
        {
            float retorno = 0, harina = 0, jugo = 0, gaseosa = 0, galletita = 0;
            foreach (Producto item in this._productos)
            {
                if (item is Harina)
                {
                    harina += ((Harina)item).Precio;
                }
                if (item is Jugo)
                {
                    jugo += ((Jugo)item).Precio;
                }
                if (item is Gaseosa)
                {
                    gaseosa += ((Gaseosa)item).Precio;
                }
                if (item is Galletita)
                {
                    galletita += ((Galletita)item).Precio;
                }
            }
            switch(tipo)
              {
                case Producto.ETipoProducto.Galletita:
                      retorno = galletita;
                      break;
                case Producto.ETipoProducto.Gaseosa:
                      retorno = gaseosa;
                      break;
                case Producto.ETipoProducto.Harina:
                      retorno = harina;
                      break;
                case Producto.ETipoProducto.Jugo:
                      retorno = jugo;
                      break;
                default:
                      retorno = galletita + gaseosa + harina + jugo;
                      break;
              }
             return retorno;
        }

        private float GetValorEstante()
        {
            return this.GetValorEstante(Producto.ETipoProducto.Todos);
        }
#endregion



    }
}
