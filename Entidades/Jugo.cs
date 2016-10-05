using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugo : Producto
    {
        protected ESaborJugo _sabor;

        #region CONSTRUCTORES
        public Jugo(int codigo, float precio, EMarcaProducto marca, ESaborJugo sabor)
            : base(codigo, marca, precio)
        {
            this._sabor = sabor;
        }
        #endregion

        public string MostrarJugo()
        {
            return MostrarProducto(this) + "\nSabor: " + this._sabor.ToString();
        }
    }
}
