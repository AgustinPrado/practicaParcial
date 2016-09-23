using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerProducto
{
    public class Producto
    {
        private int _codigoDeBarra;
        private string _nombre;
        private double _precio;
        private eTipoComestible _tipo;

        private Producto(int codigoDeBarra)
        {
            this._codigoDeBarra = codigoDeBarra;
        }
        public Producto(int codigoDeBarra, string nombre, eTipoComestible tipo)
            : this(codigoDeBarra)
        {
            this._nombre = nombre;
            this._tipo = tipo;
        }
        public Producto(int codigoDeBarra, string nombre, eTipoComestible tipo, double precio)
            : this(codigoDeBarra, nombre, tipo)
        {
            this._precio = precio;
        }

        public static bool operator ==(Producto proUno, eTipoComestible tipo)
        {
            return proUno._tipo == tipo;
        }

        public static bool operator !=(Producto proUno, eTipoComestible tipo)
        {
            return !(proUno == tipo);
        }

        public static bool operator ==(Producto proUno, Producto proDos)
        {
            return proUno._codigoDeBarra == proDos._codigoDeBarra;
        }

        public static bool operator !=(Producto proUno, Producto proDos)
        {
            return !(proUno == proDos);
        }


        public void mostrar()
        {
            Console.WriteLine("Nombre: " + this._nombre);
            Console.WriteLine("Tipo: " + this._tipo.ToString());
            Console.WriteLine("Codigo: " + this._codigoDeBarra);
            Console.WriteLine("Precio: " + this._precio);
        }
                                
    }
}
