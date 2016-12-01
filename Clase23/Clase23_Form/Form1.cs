using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Clase23_Form
{
    public partial class Form1 : Form
    {
        private RelojThread hilo;
        private Thread hiloThread;

        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        public delegate void CambiarHoraCallback(DateTime tiempo);

        public Form1()
        {
            InitializeComponent();
            this.hilo = new RelojThread();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.hiloThread = new Thread(this.hilo.DoWork);
            this.hilo.Segundero += new SegunderoReloj(this.CambiarHora);
            this.hiloThread.Start();
        }

        public void CambiarHora(DateTime tiempo)
        {
            if (this.lblTiempo.InvokeRequired)
            {
                CambiarHoraCallback d = new CambiarHoraCallback(CambiarHora);
                this.Invoke(d, tiempo);
            }
            else
            {
                this.lblTiempo.Text = tiempo.ToLongTimeString();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.hiloThread.Interrupt();
        }
    }
}
