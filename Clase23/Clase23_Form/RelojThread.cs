using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Clase23_Form
{
    public delegate void SegunderoReloj(DateTime tiempo);

    public class RelojThread
    {
        public event SegunderoReloj Segundero;

        public void DoWork()
        {
            while (true)
            {
                this.Segundero(DateTime.Now);

                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
