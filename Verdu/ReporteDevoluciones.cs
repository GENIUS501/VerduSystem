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
    public partial class ReporteDevoluciones : Form
    {
        #region Variables
        public string Usuario { get; set; }
        #endregion
        public ReporteDevoluciones()
        {
            InitializeComponent();
        }

        private void ReporteDevoluciones_Load(object sender, EventArgs e)
        {
            try
            {
                NDevoluciones Negocios = new NDevoluciones();
                NCliente NegociosClientes = new NCliente();
                NUsuarios NegociosUsuarios = new NUsuarios();
                var datasource = Negocios.MostrarDev().Select(x => new
                {
                    Cliente = NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.IDCliente).FirstOrDefault().Nombre + " " +
                    NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.IDCliente).FirstOrDefault().Primer_Apellido + " " +
                    NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.IDCliente).FirstOrDefault().Segundo_Apellido,
                    CantidadProducto = x.CantidadProducto,
                    Fecha = x.FechaDevolucion,
                    IdDevolucion = x.IdDevolucion,
                    Usuario = NegociosUsuarios.Mostrar().Where(c => c.ID_Usuario == x.IdUsuario).FirstOrDefault().Nombre_Usuario,
                    IdVenta = x.IdVenta,
                    Monto = x.Monto
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
                    NDevoluciones Negocios = new NDevoluciones();
                    NCliente NegociosClientes = new NCliente();
                    NUsuarios NegociosUsuarios = new NUsuarios();
                    var datasource = Negocios.MostrarDev().Select(x => new
                    {
                        Cliente = NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.IDCliente).FirstOrDefault().Nombre + " " +
                        NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.IDCliente).FirstOrDefault().Primer_Apellido + " " +
                        NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.IDCliente).FirstOrDefault().Segundo_Apellido,
                        CantidadProducto = x.CantidadProducto,
                        Fecha = x.FechaDevolucion,
                        IdDevolucion = x.IdDevolucion,
                        Usuario = NegociosUsuarios.Mostrar().Where(c => c.ID_Usuario == x.IdUsuario).FirstOrDefault().Nombre_Usuario,
                        IdVenta = x.IdVenta,
                        Monto = x.Monto
                    }).Where(d => d.IdDevolucion == NumeroFactura).ToList();
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
                var FechaIni = Convert.ToDateTime(this.txt_fecha_ini.Text);
                var FechaFin = Convert.ToDateTime(this.txt_fecha_fin.Text);
                NDevoluciones Negocios = new NDevoluciones();
                NCliente NegociosClientes = new NCliente();
                NUsuarios NegociosUsuarios = new NUsuarios();
                var datasource = Negocios.MostrarDev().Where(d => d.FechaDevolucion >= FechaIni && d.FechaDevolucion <= FechaFin).Select(x => new
                {
                    Cliente = NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.IDCliente).FirstOrDefault().Nombre + " " +
                    NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.IDCliente).FirstOrDefault().Primer_Apellido + " " +
                    NegociosClientes.Mostrar().Where(c => c.Numero_Cliente == x.IDCliente).FirstOrDefault().Segundo_Apellido,
                    CantidadProducto = x.CantidadProducto,
                    Fecha = x.FechaDevolucion,
                    IdDevolucion = x.IdDevolucion,
                    Usuario = NegociosUsuarios.Mostrar().Where(c => c.ID_Usuario == x.IdUsuario).FirstOrDefault().Nombre_Usuario,
                    IdVenta = x.IdVenta,
                    Monto = x.Monto
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
