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
    public partial class formEmpleado : Form
    {
        private Empresa _empresa;

        public formEmpleado()
        {
            InitializeComponent();
        }

        private void formEmpleado_Load(object sender, EventArgs e)
        {
            cmbPuesto.DataSource = Enum.GetValues(typeof(EPuestoJerarquico));
            btnEmpresa_Click(sender, e);
        }

        private void btnLimpiarForm_Click(object sender, EventArgs e)
        {
            this.txtNombre.Clear();
            this.txtApellido.Clear();
            this.mtxtLegajo.Clear();
            this.cmbPuesto.SelectedIndex = -1;
            this.mtxtSalario.Clear();
            this.rtxtConsola.Clear();
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            EPuestoJerarquico puesto;
            int salario;
            Persona persona;
            // Controlo que los valores ingresados respeten el tipo de dato
            if (!Enum.TryParse<EPuestoJerarquico>(cmbPuesto.SelectedValue.ToString(), out puesto))
            {
                MessageBox.Show("Error en el combo de Puesto del empleado.");
                return;
            }
            if (!Int32.TryParse(mtxtSalario.Text.Substring(1, mtxtSalario.Text.Length - 1), out salario))
            {
                MessageBox.Show("Error en el salario del empleado.");
                return;
            }

            if(puesto == EPuestoJerarquico.Accionista)
            {
                persona = new Accionista(this.txtNombre.Text, this.txtApellido.Text, salario);
            }
            else
            {
                persona = new Empleado(this.txtNombre.Text, this.txtApellido.Text, this.mtxtLegajo.Text, puesto, salario);
            }

            this._empresa += persona;

            this.rtxtConsola.Text = this._empresa.MostrarEmpresa();
        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            formEmpresa frm = new formEmpresa(this._empresa);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                this._empresa = frm.Empresa;
            }
            else
            {
                this.Close();
            }
        }
    }
}
