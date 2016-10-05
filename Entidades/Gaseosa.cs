using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Gaseosa : Producto
    {
        protected float _litros;

        #region CONSTRUCTORES
        public Gaseosa(int codigo, float precio, EMarcaProducto marca, float litros)
            : base(codigo, marca, precio)
        {
            this._litros = litros;
        }

        public Gaseosa(Producto prod, float litros)
            : this((int)prod, prod.Precio, prod.Marca, litros)
        {
            // Reutilización de código.
        }
        #endregion

        public string MostrarGaseosa()
        {
            return MostrarProducto(this) + "\nLitros: " + this._litros;
        }
    }
}
