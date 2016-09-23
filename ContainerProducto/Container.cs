using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerProducto
{
    public class Container
    {
        private int _capacidad;
        private string _empresa;
        private List<Producto> _listaProductos;

        public Container(int capacidad, string Empresa)
        {
            this._capacidad = capacidad;
            this._empresa = Empresa;
            this._listaProductos = new List<Producto>();
        }

        public static bool operator ==(Container contenedor, Producto proUno)
        {
            foreach (var item in contenedor._listaProductos)
            {
                if (item == proUno)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Container contenedor, Producto proUno)
        {
            return !(contenedor == proUno);
        }

        public static List<Producto> operator -(Container ContenedorUno, eTipoComestible tipo)
        {
            List<Producto> lista = new List<Producto>();

            foreach (Producto item in ContenedorUno._listaProductos)
            {
                if (item == tipo)
                    lista.Add(item);
            }

            return lista;
        }

        public bool Agregar(Producto proUno)
        {
            if (this != proUno)
            { 
                if(this._capacidad > this._listaProductos.Count)
                {
                    this._listaProductos.Add(proUno);
                    return true;
                }
            }
            return false;
        }

        public static void Mostrar(Container contenedor)
        {
            Console.WriteLine("-__-__Contanainer__-__-");
            Console.WriteLine("Empresa:" + contenedor._empresa);
            Console.WriteLine("Capacidad:" + contenedor._capacidad);
            Console.WriteLine("Productos:");
            foreach (var item in contenedor._listaProductos)
            {
                item.mostrar();
            }
        }
    }
}
