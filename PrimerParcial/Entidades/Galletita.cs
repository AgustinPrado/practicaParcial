using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Galletita : Producto
    {
        protected float _peso;

        public Galletita(int codigo, float precio, EMarcaProducto marca, float peso)
            : base(codigo, marca, precio)
        {
            this._peso = peso;
        }

        public static string MostrarGalletita(Galletita galleta)
        {
            return Producto.MostrarProducto(galleta) + " " + galleta._peso;
        }
    }
}
