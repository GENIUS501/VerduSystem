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
    public partial class BitacoraSesiones : Form
    {
        #region Variables
        public string Usuariologueado { get; set; }
        #endregion
        public BitacoraSesiones()
        {
            InitializeComponent();
        }

        private void BitacoraSesiones_Load(object sender, EventArgs e)
        {
            try
            {
                NBitacora_Sesiones Negocios = new NBitacora_Sesiones();
                NUsuarios NegociosUsuarios = new NUsuarios();
                var datasource = Negocios.Mostrar().Select(x => new
                {
                    x.fecha_hora_salida,
                    x.fecha_hora_ingreso,
                    x.codigo_ingreso_salida,
                    Usuario = NegociosUsuarios.Mostrar().Where(c => c.ID_Usuario == x.Id_Usuario).FirstOrDefault().Nombre_Usuario
                }).ToList();
                ReportDataSource Rds = new ReportDataSource("DataSet1", datasource);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(Rds);
                ReportParameter[] parameters = new ReportParameter[2];
                parameters[0] = new ReportParameter("Usuario", Usuariologueado);
                parameters[1] = new ReportParameter("Fecha", DateTime.Now.ToString());
                reportViewer1.LocalReport.SetParameters(parameters);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_nombre_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txt_usuario.Text != "")
                {
                    NBitacora_Sesiones Negocios = new NBitacora_Sesiones();
                    NUsuarios NegociosUsuarios = new NUsuarios();
                    var datasource = Negocios.Mostrar().Select(x => new
                    {
                        x.fecha_hora_salida,
                        x.fecha_hora_ingreso,
                        x.codigo_ingreso_salida,
                        Usuario = Enumerable.Where<Entidades.EUsuario>(NegociosUsuarios.Mostrar(), c => c.ID_Usuario == x.Id_Usuario).FirstOrDefault().Nombre_Usuario
                    }).Where(y => y.Usuario.Contains(this.txt_usuario.Text)).ToList();
                    ReportDataSource Rds = new ReportDataSource("DataSet1", datasource);
                    this.reportViewer1.LocalReport.DataSources.Clear();
                    this.reportViewer1.LocalReport.DataSources.Add(Rds);
                    ReportParameter[] parameters = new ReportParameter[2];
                    parameters[0] = new ReportParameter("Usuario", Usuariologueado);
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
                if (this.txt_fecha_ini.Text != "" && this.txt_fecha_fin.Text != "")
                {
                    var FechaIni = Convert.ToDateTime(this.txt_fecha_ini.Text);
                    var FechaFin = Convert.ToDateTime(this.txt_fecha_fin.Text).AddHours(23).AddMinutes(59).AddSeconds(59);
                    NBitacora_Sesiones Negocios = new NBitacora_Sesiones();
                    NUsuarios NegociosUsuarios = new NUsuarios();
                    var datasource = Negocios.Mostrar().Select(x => new
                    {
                        x.fecha_hora_salida,
                        x.fecha_hora_ingreso,
                        x.codigo_ingreso_salida,
                        Usuario = Enumerable.Where<Entidades.EUsuario>(NegociosUsuarios.Mostrar(), c => c.ID_Usuario == x.Id_Usuario).FirstOrDefault().Nombre_Usuario
                    }).Where(x => x.fecha_hora_ingreso >= FechaIni && x.fecha_hora_ingreso <= FechaFin).ToList();
                    ReportDataSource Rds = new ReportDataSource("DataSet1", datasource);
                    this.reportViewer1.LocalReport.DataSources.Clear();
                    this.reportViewer1.LocalReport.DataSources.Add(Rds);
                    ReportParameter[] parameters = new ReportParameter[2];
                    parameters[0] = new ReportParameter("Usuario", Usuariologueado);
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
    }
}
