using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diamond
{
    public partial class ListaProductos : Form
    {
        int valorcelda = -1;
        public int Usuario { get; set; }
        public int Id_Rol { get; set; }
        public ListaProductos()
        {
            InitializeComponent();
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            try
            {
                Renderizar("A");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                Renderizar("M");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (valorcelda != -1)
                {
                    DialogResult dr = MessageBox.Show("Realmente desea eliminar el Producto?", "Eliminar el Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        Int32 FilasAfectadas = 0;
                        NProductos Negocios = new NProductos();
                        FilasAfectadas = Negocios.Eliminar(valorcelda, Usuario);
                        if (FilasAfectadas > 0)
                        {
                            MessageBox.Show("Producto eliminado satisfactoriamente", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (FilasAfectadas == -1)
                            {
                                MessageBox.Show("Producto eliminado satisfactoriamente", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MessageBox.Show("Error al registrar la transaccion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("Error al eliminar el Producto!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        valorcelda = -1;
                        ListaProductos_Load(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un Producto!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("El registro que esta tratando de eliminar esta relacionado con otro.\nPor favor verifique antes de borrar este registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            try
            {
                Renderizar("C");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txt_buscar_codigo.Text != "")
                {
                    NProductos Negocios = new NProductos();
                    this.dat_principal.DataSource = Negocios.Mostrar().Select(x => new {
                        ID_Producto = x.ID_Producto,
                        ID_Tipo_Producto = x.ID_Tipo_Producto,
                        Nombre = x.Nombre,
                        Descripcion = x.Descripcion,
                        Precio = "₡" + x.Precio,
                        Cantidad = x.Cantidad,
                        Imagen = x.Imagen,
                    }).Where(x => x.ID_Producto == int.Parse(this.txt_buscar_codigo.Text)).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_buscar_nombre_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txt_nombre.Text != "")
                {
                    NProductos Negocios = new NProductos();
                    this.dat_principal.DataSource = Negocios.Mostrar().Select(x => new {
                        ID_Producto = x.ID_Producto,
                        ID_Tipo_Producto = x.ID_Tipo_Producto,
                        Nombre = x.Nombre,
                        Descripcion = x.Descripcion,
                        Precio = "₡" + x.Precio,
                        Cantidad = x.Cantidad,
                        Imagen = x.Imagen,
                    }).Where(x => x.Nombre.Contains(this.txt_nombre.Text)).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListaProductos_Load(object sender, EventArgs e)
        {
            try
            {
                NProductos Negocios = new NProductos();
                dat_principal.DataSource = Negocios.Mostrar().Select(x => new {
                    ID_Producto = x.ID_Producto,
                    ID_Tipo_Producto = x.ID_Tipo_Producto,
                    Nombre = x.Nombre,
                    Descripcion = x.Descripcion,
                    Precio = "₡" + x.Precio,
                    Cantidad = x.Cantidad,
                    Imagen = x.Imagen,
                }).ToList();
                valorcelda = -1;
                this.dat_principal.ReadOnly = true;
                NRoles NegociosRoles = new NRoles();
                List<EPermisos> perm = new List<EPermisos>();
                perm = NegociosRoles.llenar_Permisos(Id_Rol, "Productos");
                if (perm.Where(x => x.Accion == "Agregar").FirstOrDefault() != null)
                {
                    this.btn_agregar.Enabled = true;
                }
                if (perm.Where(x => x.Accion == "Modificar").FirstOrDefault() != null)
                {
                    this.btn_editar.Enabled = true;
                }
                if (perm.Where(x => x.Accion == "Eliminar").FirstOrDefault() != null)
                {
                    this.btn_eliminar.Enabled = true;
                }
                if (perm.Where(x => x.Accion == "Consultar").FirstOrDefault() != null)
                {
                    this.btn_consultar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dat_principal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dat_principal.Rows[e.RowIndex].Cells[0].Value.ToString() == "")
                {
                    ListaProductos_Load(null, null);
                }
                else
                {
                    valorcelda = int.Parse(this.dat_principal.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Renderizar(string Accion)
        {
            try
            {

                if (Accion != "A" && Accion == "M" && valorcelda != -1 || Accion != "A" && Accion == "E" && valorcelda != -1 || Accion != "A" && Accion == "C" && valorcelda != -1)
                {
                    //valorcelda = dat_Productos.CurrentRow.Index;
                    MantenimientoProductos frm = new MantenimientoProductos();
                    frm.Accion = Accion;
                    frm.Id = valorcelda;
                    frm.Usuario = Usuario;
                    frm.ShowDialog();
                    valorcelda = -1;
                    ListaProductos_Load(null, null);
                }
                else
                {
                    if (Accion == "A")
                    {
                        MantenimientoProductos frm = new MantenimientoProductos();
                        frm.Accion = Accion;
                        frm.Id = valorcelda;
                        frm.Usuario = Usuario;
                        frm.ShowDialog();
                        valorcelda = -1;
                        ListaProductos_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un Producto!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dat_principal.Columns[e.ColumnIndex].Name == "Imagen")
            {
                if (e.Value != null)
                {
                    Image originalImage = null;
                    byte[] imgData = (byte[])e.Value;
                    using (MemoryStream ms = new MemoryStream(imgData, 0, imgData.Length))
                    {
                        ms.Write(imgData, 0, imgData.Length);
                        originalImage = Image.FromStream(ms, true);
                    }
                    // Image originalImage = (Image)e.Value;
                    int desiredWidth = 50; // Anchura deseada para la imagen
                    int desiredHeight = 50; // Altura deseada para la imagen

                    Image resizedImage = new Bitmap(originalImage, desiredWidth, desiredHeight);
                    e.Value = resizedImage;
                }
            }
        }
    }
}
