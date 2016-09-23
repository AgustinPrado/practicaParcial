using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parcial37_CuentaCorrienteBanco2011
{
    public class Banco
    {
        private DateTime _fechaInicio;
        private List<CuentaCorriente> _listaCuentaCorriente;
        private string _razonSocial;

        public Banco(string razonSocial, DateTime fechaInicio)
        {
            this._razonSocial = razonSocial;
            this._fechaInicio = fechaInicio;
            this._listaCuentaCorriente = new List<CuentaCorriente>();
        }

        public void MostrarBanco()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Razon Social: " + this._razonSocial);
            sb.AppendLine("Fecha Inicio Actividades: " + this._fechaInicio.ToString());
            sb.AppendLine("---------------------------------------");
            sb.AppendLine("Lista de Usuarios:");

            foreach (CuentaCorriente item in this._listaCuentaCorriente)
            {
                sb.AppendLine("::::::::::::::::::::::::::::::");
                sb.Append(Usuario.Mostrar(item.Dueño));
                sb.AppendLine("Saldo: " + item.Saldo);
            }

            Console.WriteLine(sb.ToString());
        }

        public static Banco operator -(Banco unBanco, CuentaCorriente unaCuenta)
        {
            foreach (CuentaCorriente item in unBanco._listaCuentaCorriente)
            {
                if(item == unaCuenta)
                {
                    Console.WriteLine("Se ha eliminado una cuenta corriente");
                    unBanco._listaCuentaCorriente.Remove(item);
                    return unBanco;
                }
            }
            Console.WriteLine("No existe actualmente esta cuenta");
            return unBanco;
        }

        public static Banco operator +(Banco unBanco, CuentaCorriente unaCuenta)
        {
            foreach (CuentaCorriente item in unBanco._listaCuentaCorriente)
            {
                if (item == unaCuenta)
                {
                    Console.WriteLine("Ya existe una cuenta corriente para el usuario");
                    return unBanco;
                }
            }
            Console.WriteLine("Se ha agregado una cuenta corriente");
            unBanco._listaCuentaCorriente.Add(unaCuenta);
            return unBanco;
        }
    }
}
