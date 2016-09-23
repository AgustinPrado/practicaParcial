using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parcial37_CuentaCorrienteBanco2011
{
    public class CuentaCorriente
    {
        private Usuario _dueño;
        public Usuario Dueño
        {
            get
            {
                return this._dueño;
            }
        }
        private int _nroCuenta;
        private double _saldo;
        public double Saldo
        {
            set
            {
                this._saldo += value;
            }
            get
            {
                return this._saldo;
            }
        }

        public CuentaCorriente(string apellido, string nombre, double dni, int numero, double saldo)
            : this(new Usuario(apellido, nombre, dni), numero, saldo)
        {
               
        }

        public CuentaCorriente(Usuario miDueño, int numero, double saldo)
        {
            this._dueño = miDueño;
            this._nroCuenta = numero;
            this._saldo = saldo;
        }

        public static bool operator == (CuentaCorriente CC1, CuentaCorriente CC2)
        {
            return (CC1.Dueño.Dni == CC2.Dueño.Dni);
        }

        public static bool operator !=(CuentaCorriente CC1, CuentaCorriente CC2)
        {
            return !(CC1 == CC2);
        }

        public static implicit operator CuentaCorriente(Usuario unUsuario)
        {
            return new CuentaCorriente(unUsuario, 0, 0);
        }

        public static explicit operator double(CuentaCorriente CC)
        {
            return CC.Saldo;
        }

    }
}
