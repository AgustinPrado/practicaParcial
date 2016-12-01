using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase17_App
{
    public class MiLista<T> : IEnumerable<T>
    {
        public T[] lista;

        public MiLista()
        {
            this.lista = new T[0];
        }
        
        public int Count
        {
            get { return this.lista.Length; }
        } 

        public void Add(T item)
        {
            Array.Resize(ref this.lista, this.lista.Length + 1);
            this.lista[this.lista.Length - 1] = item;
        }

        public void Remove(T item)
        {
            for (int i = 0; i < this.lista.Length; i++)
            {
                if(this.lista[i].Equals(item))
                {
                    for (int j = i; j < this.lista.Length - 1; j++)
                    {
                        this.lista[j] = this.lista[j + 1];
                    }
                    Array.Resize(ref this.lista, this.lista.Length - 1);
                    break;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < this.lista.Length; i++)
            {
                yield return this.lista[i];
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach (T item in this.lista)
            {
                yield return item;
            }
        }
    }
}
