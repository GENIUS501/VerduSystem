using Entidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diamond
{
    public partial class Visor_Factura : Form
    {
        #region Variables
        public string Usuario { get; set; }
        public string Total { get; set; }
        public string Num_Fact { get; set; }
        public string Cantidad_Lineas { get; set; }
        public string Cliente { get; set; }
        public string TipoPago { get; set; }
        public List<EReporte_Ventas_Detalles> ListaFina { get; set; }
        #endregion
        public Visor_Factura()
        {
            InitializeComponent();
        }

        private void Visor_Factura_Load(object sender, EventArgs e)
        {
            try
            {
                ReportDataSource Rds = new ReportDataSource("DataSet1", ListaFina);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(Rds);
                ReportParameter[] parameters = new ReportParameter[7];
                parameters[0] = new ReportParameter("Usuario", Usuario.ToString());
                parameters[1] = new ReportParameter("Total", Total.ToString());
                parameters[2] = new ReportParameter("Num_Fact", Num_Fact.ToString());
                parameters[3] = new ReportParameter("Cantidad_Lineas", Cantidad_Lineas.ToString());
                parameters[4] = new ReportParameter("FechaVenta", DateTime.Now.ToString());
                parameters[5] = new ReportParameter("Cliente", Cliente);
                parameters[6] = new ReportParameter("TipoPago", TipoPago);
                reportViewer1.LocalReport.SetParameters(parameters);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
