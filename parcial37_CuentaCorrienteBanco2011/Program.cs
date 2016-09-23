using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parcial37_CuentaCorrienteBanco2011
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instancia de la clase Usuario: 
            Usuario uno = new Usuario("Agua", "Rogelio", 111);
            //Instancia de la clase Usuario: 
            Usuario dos = new Usuario("Mercurio", "Alfredo", 222);
            //Instancia de la clase Banco: 
            Banco unBanco = new Banco("Santander Rio", (DateTime.Today));
            //Instancia de la clase CuentaCorriente: 
            CuentaCorriente objCC1 = new CuentaCorriente(uno, 789, 1000);
            //Instancia de la clase CuentaCorriente: 
            CuentaCorriente objCC2 = new CuentaCorriente("Jorge", "Miguel", 333, 798, 5000);
            //Instancia de la clase CuentaCorriente:
            CuentaCorriente objCC3 = new CuentaCorriente(uno, 799, 1000);
            //Instancia de la clase CuentaCorriente: 
            CuentaCorriente objCC4 = dos; 
            unBanco += objCC1;
            unBanco += objCC2;
            unBanco += objCC3;
            Console.WriteLine("***********************************");
            Console.WriteLine("Elimino una cuenta del banco ");
            unBanco -= objCC4;
            Console.WriteLine("***********************************");
            Console.WriteLine("Agrego una Cuenta al banco: ");
            unBanco += objCC4;
            Console.WriteLine("***********************************");
            Console.WriteLine("Incremento el saldo del cliente Mercurio, Alfredo: ");
            objCC4.Saldo = 1000;
            Console.WriteLine("Incremento el saldo del cliente Jorge, Miguel: ");
            objCC2.Saldo =7000;
            Console.WriteLine("***********************************");
            Console.WriteLine("Elimino una cuenta del banco ");
            unBanco -= objCC1;
            
            Console.WriteLine("***********************************");
            Console.WriteLine("Muestro los datos del banco: ");
            unBanco.MostrarBanco();
            Console.ReadKey();
        }
    }
}
