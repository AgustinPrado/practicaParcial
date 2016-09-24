using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parcial39_FabricaOperarioArray
{
    public class Fabrica
    {
        private string _razonSocial;
        private Operario[] _operarios;

        public Fabrica()
        {
            this._operarios = new Operario[5];
        }

        public Fabrica(string razonSocial)
            : this()
        {
            this._razonSocial = razonSocial;
        }

        public static bool operator == (Fabrica fbr, Operario op)
        {
            foreach (Operario item in fbr._operarios)
            {
                if(item != (object)null)
                {
                    if (item == op)
                        return true;
                }
            }
            return false;
        }

        public static bool operator != (Fabrica fbr, Operario op)
        {
            return !(fbr == op);
        }

        public static Fabrica operator + (Fabrica fbr, Operario op)
        {
            int indice = fbr.ObtenerIndice();
            if ((indice != -1) && (fbr != op))
            {
                fbr._operarios[indice] = op;
            }
            else
                Console.WriteLine("No hay mas cupo!!!");
            return fbr;
        }

        public static Fabrica operator - (Fabrica fbr, Operario op)
        {
            int indice = fbr.ObtenerIndice(op);
            if (indice != -1)
            {
                fbr._operarios[indice] = null;
            }
            else
                Console.WriteLine("No se encontro al empleado!!!");
            return fbr;
        }

        private int ObtenerIndice()
        {
            for (int i = 0; i < this._operarios.Length; i++)
            {
                if (this._operarios[i] == (object)null)
                    return i;
            }
            return -1;
        }

        private int ObtenerIndice(Operario op)
        {
            for (int i = 0; i < this._operarios.Length; i++)
            {
                if (this._operarios[i] == op)
                    return i;
            }
            return -1;
        }

        private float RetornarCostos()
        {
            float aux = 0;
            for (int i = 0; i < this._operarios.Length; i++)
            {
                if (this._operarios[i] != (object)null)
                    aux += this._operarios[i].getSalario();
            }
            return aux;
        }

        private string MostrarOperarios()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this._operarios.Length; i++)
            {
                if (this._operarios[i] != (object)null)
                    sb.AppendLine(Operario.Mostrar(this._operarios[i]));
            }
            return sb.ToString();
        }

        public string Mostrar()
        {
            return this.MostrarOperarios();
        }

        public static void MostrarCosto(Fabrica fbr)
        {
            Console.WriteLine(fbr.RetornarCostos());
        }
    }
}
