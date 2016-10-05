using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        protected int _codigoDeBarra;
        protected EMarcaProducto _marca;
        public EMarcaProducto Marca
        {
            get
            {
                return this._marca;
            }
        }
        protected float _precio;
        public float Precio
        {
            get
            {
                return this._precio;
            }
        }

        #region CONSTRUCTORES
        public Producto(int codigo, EMarcaProducto marca, float precio)
        {
            this._codigoDeBarra = codigo;
            this._marca = marca;
            this._precio = precio;
        }
        #endregion

        protected static string MostrarProducto(Producto prod)
        {
            return "Código de Barra: " + (int)prod + " Marca: " + prod.Marca + " Precio unitario: " + prod.Precio;
        }

        #region SOBRECARGA DE OPERADORES
        public static bool operator ==(Producto prodUno, EMarcaProducto marca)
        {
            return (prodUno.Marca == marca);
        }

        public static bool operator !=(Producto prodUno, EMarcaProducto marca)
        {
            return !(prodUno == marca);
        }

        public static bool operator ==(Producto prodUno, Producto prodDos)
        {
            return (prodUno == prodDos.Marca);
        }

        public static bool operator !=(Producto prodUno, Producto prodDos)
        {
            return !(prodUno == prodDos);
        }

        public static explicit operator int(Producto prod)
        {
            return prod._codigoDeBarra;
        }
        #endregion
    }
}
