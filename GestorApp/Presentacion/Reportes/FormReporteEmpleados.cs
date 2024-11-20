using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorApp.Presentacion.Reportes
{
    public partial class FormReporteEmpleados : Form
    {
        public FormReporteEmpleados()
        {
            InitializeComponent();
        }

        private void FormReporteEmpleados_Load(object sender, EventArgs e)
        {
            this.sP_LISTAR_EMPLEADOSTableAdapter.Fill(this.dataSet.SP_LISTAR_EMPLEADOS, cBusqueda: textFiltrar.Text);
            this.reportViewer1.RefreshReport();
        }
    }
}
