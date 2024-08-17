using Microsoft.Reporting.WinForms;
using Negocios;
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
    public partial class ReporteVentas : Form
    {
        #region Variables
        public string Usuario { get; set; }
        #endregion
        public ReporteVentas()
        {
            InitializeComponent();
        }

        private void ReporteVentas_Load(object sender, EventArgs e)
        {
            try
            {
                NVentas Negocios = new NVentas();
                NCliente NegociosClientes = new NCliente();
                var datasource = Negocios.Mostrar().Select(x => new
                {
                    NumeroFactura = x.Numero_factura,
                    Nombre = NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.ID_Cliente).FirstOrDefault().Nombre,
                    PrimerApellido = NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.ID_Cliente).FirstOrDefault().Primer_Apellido,
                    SegundoApellido = NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.ID_Cliente).FirstOrDefault().Segundo_Apellido,
                    Cedula = NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.ID_Cliente).FirstOrDefault().Cedula,
                    Direccion = NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.ID_Cliente).FirstOrDefault().Direccion,
                    Telefono = NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.ID_Cliente).FirstOrDefault().Telefono,
                    Correo = NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.ID_Cliente).FirstOrDefault().Correo,
                    TipoVenta = x.Tipo_pago,
                    Monto = x.Total
                }).ToList();
                ReportDataSource Rds = new ReportDataSource("DataSet1", datasource);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(Rds);
                ReportParameter[] parameters = new ReportParameter[2];
                parameters[0] = new ReportParameter("Usuario", Usuario);
                parameters[1] = new ReportParameter("Fecha", DateTime.Now.ToString());
                reportViewer1.LocalReport.SetParameters(parameters);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_buscar_fact_click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtnumerofactura.Text != "")
                {
                    var NumeroFactura = int.Parse(this.txtnumerofactura.Text);
                    NVentas Negocios = new NVentas();
                    NCliente NegociosClientes = new NCliente();
                    var datasource = Negocios.Mostrar().Select(x => new
                    {
                        NumeroFactura = x.Numero_factura,
                        Nombre = NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.ID_Cliente).FirstOrDefault().Nombre,
                        PrimerApellido = NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.ID_Cliente).FirstOrDefault().Primer_Apellido,
                        SegundoApellido = NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.ID_Cliente).FirstOrDefault().Segundo_Apellido,
                        Cedula = NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.ID_Cliente).FirstOrDefault().Cedula,
                        Direccion = NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.ID_Cliente).FirstOrDefault().Direccion,
                        Telefono = NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.ID_Cliente).FirstOrDefault().Telefono,
                        Correo = NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.ID_Cliente).FirstOrDefault().Correo,
                        TipoVenta = x.Tipo_pago,
                        Monto = x.Total
                    }).Where(d => d.NumeroFactura == NumeroFactura).ToList();
                    ReportDataSource Rds = new ReportDataSource("DataSet1", datasource);
                    this.reportViewer1.LocalReport.DataSources.Clear();
                    this.reportViewer1.LocalReport.DataSources.Add(Rds);
                    ReportParameter[] parameters = new ReportParameter[2];
                    parameters[0] = new ReportParameter("Usuario", Usuario);
                    parameters[1] = new ReportParameter("Fecha", DateTime.Now.ToString());
                    reportViewer1.LocalReport.SetParameters(parameters);
                    this.reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_fecha_Click(object sender, EventArgs e)
        {
            try
            {
                NVentas Negocios = new NVentas();
                NCliente NegociosClientes = new NCliente();
                var FechaIni = Convert.ToDateTime(this.txt_fecha_ini.Text);
                var FechaFin = Convert.ToDateTime(this.txt_fecha_fin.Text);
                var datasource = Negocios.Mostrar().Where(d => d.Fecha_venta >= FechaIni && d.Fecha_venta <= FechaFin).Select(x => new
                {
                    NumeroFactura = x.Numero_factura,
                    Nombre = NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.ID_Cliente).FirstOrDefault().Nombre,
                    PrimerApellido = NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.ID_Cliente).FirstOrDefault().Primer_Apellido,
                    SegundoApellido = NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.ID_Cliente).FirstOrDefault().Segundo_Apellido,
                    Cedula = NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.ID_Cliente).FirstOrDefault().Cedula,
                    Direccion = NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.ID_Cliente).FirstOrDefault().Direccion,
                    Telefono = NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.ID_Cliente).FirstOrDefault().Telefono,
                    Correo = NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.ID_Cliente).FirstOrDefault().Correo,
                    TipoVenta = x.Tipo_pago,
                    Monto = x.Total
                }).ToList();
                ReportDataSource Rds = new ReportDataSource("DataSet1", datasource);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(Rds);
                ReportParameter[] parameters = new ReportParameter[2];
                parameters[0] = new ReportParameter("Usuario", Usuario);
                parameters[1] = new ReportParameter("Fecha", DateTime.Now.ToString());
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
