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
    public partial class BitacoraMovimientos : Form
    {
        #region Variables
        public string Usuario { get; set; }
        #endregion
        public BitacoraMovimientos()
        {
            InitializeComponent();
        }

        private void BitacoraMovimientos_Load(object sender, EventArgs e)
        {
            try
            {
                NBitacora_Movimientos Negocios = new NBitacora_Movimientos();
                NUsuarios NegociosUsuarios = new NUsuarios();
                var datasource = Negocios.Mostrar().Select(x => new
                {
                    Usuario = NegociosUsuarios.Mostrar().Where(c => c.ID_Usuario == x.Id_Usuario).FirstOrDefault().Nombre_Usuario,
                    codigo_movimiento_usuario = x.codigo_movimiento_usuario,
                    modulo = x.modulo,
                    tipo_movimiento = x.tipo_movimiento,
                    fecha_hora_movimiento = x.fecha_hora_movimiento,
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
        private void btn_nombre_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txt_usuario.Text != "")
                {
                    NBitacora_Movimientos Negocios = new NBitacora_Movimientos();
                    NUsuarios NegociosUsuarios = new NUsuarios();
                    var datasource = Negocios.Mostrar().Select(x => new
                    {
                        Usuario = NegociosUsuarios.Mostrar().Where(c => c.ID_Usuario == x.Id_Usuario).FirstOrDefault().Nombre_Usuario,
                        codigo_movimiento_usuario = x.codigo_movimiento_usuario,
                        modulo = x.modulo,
                        tipo_movimiento = x.tipo_movimiento,
                        fecha_hora_movimiento = x.fecha_hora_movimiento,
                    }).Where(x => x.Usuario.Contains(this.txt_usuario.Text)).ToList();
                    //var datasource = Negocios.Mostrar().Where(x => x.Usuario.Contains(this.txt_usuario.Text)).ToList();
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

        private void btn_buscar_accion_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cbo_Accion.SelectedItem.ToString() != "")
                {
                    if (this.cbo_Accion.SelectedItem.ToString() == "Todas")
                    {
                        NBitacora_Movimientos Negocios = new NBitacora_Movimientos();
                        NUsuarios NegociosUsuarios = new NUsuarios();
                        var datasource = Negocios.Mostrar().Select(x => new
                        {
                            Usuario = NegociosUsuarios.Mostrar().Where(c => c.ID_Usuario == x.Id_Usuario).FirstOrDefault().Nombre_Usuario,
                            codigo_movimiento_usuario = x.codigo_movimiento_usuario,
                            modulo = x.modulo,
                            tipo_movimiento = x.tipo_movimiento,
                            fecha_hora_movimiento = x.fecha_hora_movimiento,
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
                    else
                    {
                        NBitacora_Movimientos Negocios = new NBitacora_Movimientos();
                        NUsuarios NegociosUsuarios = new NUsuarios();
                        var datasource = Negocios.Mostrar().Select(x => new
                        {
                            Usuario = NegociosUsuarios.Mostrar().Where(c => c.ID_Usuario == x.Id_Usuario).FirstOrDefault().Nombre_Usuario,
                            codigo_movimiento_usuario = x.codigo_movimiento_usuario,
                            modulo = x.modulo,
                            tipo_movimiento = x.tipo_movimiento,
                            fecha_hora_movimiento = x.fecha_hora_movimiento,
                        }).Where(j => j.tipo_movimiento == this.cbo_Accion.SelectedItem.ToString()).ToList();
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
                    NBitacora_Movimientos Negocios = new NBitacora_Movimientos();
                    NUsuarios NegociosUsuarios = new NUsuarios();
                    var datasource = Negocios.Mostrar().Select(x => new
                    {
                        Usuario = NegociosUsuarios.Mostrar().Where(c => c.ID_Usuario == x.Id_Usuario).FirstOrDefault().Nombre_Usuario,
                        codigo_movimiento_usuario = x.codigo_movimiento_usuario,
                        modulo = x.modulo,
                        tipo_movimiento = x.tipo_movimiento,
                        fecha_hora_movimiento = x.fecha_hora_movimiento,
                    }).Where(x => x.fecha_hora_movimiento >= FechaIni && x.fecha_hora_movimiento <= FechaFin).ToList();
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
    }
}
