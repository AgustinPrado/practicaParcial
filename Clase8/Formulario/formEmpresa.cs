using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Libreria;

namespace Formulario
{
    public partial class formEmpresa : Form
    {
        private Empresa _empresa;

        public Empresa Empresa
        {
            get { return this._empresa; }
        }

        public formEmpresa(Empresa empresa)
        {
            InitializeComponent();
            this._empresa = empresa;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            float ganancias = float.Parse(this.mtxtGanancias.Text.Replace(".", ",").Substring(1, mtxtGanancias.Text.Length - 1));
            if (this._empresa == null)
            {
                this._empresa = new Empresa(this.txtRazonSocial.Text, this.txtDireccion.Text, ganancias);
            }
            else
            {
                this._empresa.RazonSocial = this.txtRazonSocial.Text;
                this._empresa.Direccion = this.txtDireccion.Text;
                this._empresa.Ganancias = ganancias;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void formEmpresa_Load(object sender, EventArgs e)
        {
            if (this._empresa != null)
            {
                this.txtRazonSocial.Text = this.Empresa.RazonSocial;
                this.txtDireccion.Text = this.Empresa.Direccion;
                this.mtxtGanancias.Text = this.Empresa.Ganancias.ToString();
            }
        }
    }
}
