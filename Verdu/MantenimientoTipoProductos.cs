using Entidades;
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
    public partial class MantenimientoTipoProductos : Form
    {
        #region 
        public int Usuario { get; set; }
        public string Accion { get; set; }
        public int Id { get; set; }
        #endregion
        public MantenimientoTipoProductos()
        {
            InitializeComponent();
        }
        private void llenar()
        {
            NTipo_Producto Negocios = new NTipo_Producto();
            ETipo_Productos Obj = new ETipo_Productos();
            Obj = Negocios.Mostrar().Where(x => x.ID_Tipo_Producto == Id).FirstOrDefault();
            this.txt_id.Enabled = false;
            this.txt_id.Text = Obj.ID_Tipo_Producto.ToString();
            this.txt_nombre.Text = Obj.Nombre;
            this.txt_descripcion.Text = Obj.Descripcion;
        }
        private void MantenimientoTipoProductos_Load(object sender, EventArgs e)
        {
            try
            {
                if (Accion == "A")
                {
                    this.lbl_id.Visible = false;
                    this.txt_id.Visible = false;
                }
                if (Accion == "M" || Accion == "C")
                {
                    llenar();
                    if (Accion == "C")
                    {
                        this.Grp_Tipo_Productos.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validar()
        {
            bool ok = false;
            try
            {
                if (this.txt_nombre.Text == "")
                {
                    errorProvider1.SetError(this.txt_nombre, "Debe ingresar el nombre");
                    ok = true;
                }
                if (this.txt_descripcion.Text == "")
                {
                    errorProvider1.SetError(this.txt_descripcion, "Debe ingresar la descripcion");
                    ok = true;
                }
                //
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ok;
        }
        private void borrar_error()
        {
            try
            {
                errorProvider1.SetError(txt_id, "");
                errorProvider1.SetError(txt_nombre, "");
                errorProvider1.SetError(txt_descripcion, "");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Accion == "C")
                {
                    this.Close();
                }
                borrar_error();
                if (!validar())
                {
                    if (Accion == "A" || Accion == "M")
                    {
                        NTipo_Producto Negocios = new NTipo_Producto();
                        ETipo_Productos Obj = new ETipo_Productos();
                        Obj.Nombre = this.txt_nombre.Text;
                        Obj.Descripcion = this.txt_descripcion.Text;
                        Int32 FilasAfectadas = 0;
                        #region Agregar
                        if (Accion == "A")
                        {
                            FilasAfectadas = Negocios.Agregar(Obj, Usuario);

                            if (FilasAfectadas > 0)
                            {
                                MessageBox.Show("Tipo de producto Agregada exitosamente!!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                if (FilasAfectadas == -1)
                                {
                                    MessageBox.Show("La Tipo de producto se ha agregado exitosamente pero no se a podido registrar la transaccion!!!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Error al agregar el Tipo de producto!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        #endregion

                        #region Modificar
                        if (Accion == "M")
                        {
                            Obj.ID_Tipo_Producto = int.Parse(this.txt_id.Text);
                            FilasAfectadas = Negocios.Modificar(Obj, Usuario);
                            if (FilasAfectadas > 0)
                            {
                                MessageBox.Show("Tipo de producto modificada exitosamente!!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                if (FilasAfectadas == -1)
                                {
                                    MessageBox.Show("La Tipo de producto se ha modificado exitosamente pero no se a podido registrar la transaccion!!!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Error al modificar la Tipo de producto!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
