using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class Empresa
    {
        private List<Persona> _nominaEmpleados;
        private string _razonSocial;
        private string _direccion;
        private float _ganancias;

        public string RazonSocial
        {
            set { this._razonSocial = value; }
            get { return this._razonSocial; }
        }
        public string Direccion
        {
            set { this._direccion = value; }
            get { return this._direccion; }
        }
        public float Ganancias
        {
            set { this._ganancias = value; }
            get { return this._ganancias; }
        }

        private Empresa()
        {
            this._nominaEmpleados = new List<Persona>();
        }
        public Empresa(string razon, string direccion, float ganancias)
            : this()
        {
            this.RazonSocial = razon;
            this.Direccion = direccion;
            this.Ganancias = ganancias;
        }

        public static Empresa operator + (Empresa empresa, Persona empleado)
        {
            foreach (Persona item in empresa._nominaEmpleados)
            {
                if (item is Empleado && empleado is Empleado)
                {
                    if ((Empleado)item == (Empleado)empleado)
                        return empresa;
                }
                else if (item is Accionista && empleado is Accionista)
                {
                    if ((Accionista)item == (Accionista)empleado)
                        return empresa;
                }

            }
            empresa._nominaEmpleados.Add(empleado);
            return empresa;
        }

        public string MostrarEmpresa()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("La empresa {0} sita en la calle {1} cuenta con ganancias por ${2} y con {3} empleados:\n",
                this.RazonSocial,
                this.Direccion,
                this.Ganancias,
                this._nominaEmpleados.Count);
            foreach (Persona item in this._nominaEmpleados)
            {
                sb.AppendLine(item.ToString());
                sb.AppendLine("------------------");
            }

            return sb.ToString();
        }

    }
}
