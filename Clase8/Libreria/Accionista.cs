using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class Accionista : Persona
    {
        private int _porcionAccionaria;

        public Accionista(string nombre, string apellido, int porcionAccionaria) 
            : base(nombre, apellido)
        {
            this.PorcionAccionaria = porcionAccionaria;
        }

        public int PorcionAccionaria
        {
            set
            {
                if (value >= 1 && value <= 100)
                    this._porcionAccionaria = value;
            }
            get { return this._porcionAccionaria; }
        }

        public override string PosicionSocietaria()
        {
            return "Accionista con el " + this.PorcionAccionaria + "% de la porción accionaria";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Persona.Mostrar(this));
            sb.AppendLine(this.PosicionSocietaria());

            return sb.ToString();
        }

        public static bool operator ==(Accionista accUno, Accionista accDos)
        {
            if (!object.ReferenceEquals(accUno, null) && !object.ReferenceEquals(accDos, null))
            {
                if (accUno.Nombre == accDos.Nombre)
                {
                    if(accUno.Apellido == accDos.Apellido)
                    {
                        if (accUno.PorcionAccionaria == accDos.PorcionAccionaria)
                            return true;
                    }
                }
            }
            return false;
        }

        public static bool operator !=(Accionista accUno, Accionista accDos)
        {
            return !(accUno == accDos);
        }
    }
}
