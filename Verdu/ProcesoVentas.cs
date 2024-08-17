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
using System.Transactions;
using System.Windows.Forms;

namespace Diamond
{
    public partial class ProcesoVentas : Form
    {
        #region Variables
        public int Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Accion { get; set; }
        public int Id { get; set; }
        private int IDCliente { get; set; }
        private double Total { get; set; }
        private List<EVentas_Detalles> Productos = new List<EVentas_Detalles>();
        #endregion
        public ProcesoVentas()
        {
            InitializeComponent();
        }
        private void ProcesoVentas_Load(object sender, EventArgs e)
        {
            try
            {
                lst_productos.Items.Clear();
                this.txt_impuesto.Text = "13";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_buscar_codigo_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txt_codigo.Text != "")
                {
                    NProductos Negocios = new NProductos();
                    var Codigo = int.Parse(this.txt_codigo.Text);
                    this.dat_resultado.DataSource = Negocios.Mostrar().Where(x => x.ID_Producto == Codigo).ToList();
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
                if (this.txt_nombre_producto.Text != "")
                {
                    NProductos Negocios = new NProductos();
                    this.dat_resultado.DataSource = Negocios.Mostrar().Where(x => x.Nombre.Contains(this.txt_nombre_producto.Text)).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_add_cliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txt_cedula.Text != null)
                {
                    NCliente Negocios = new NCliente();
                    var Cliente = Negocios.Mostrar().Where(x => x.Cedula == this.txt_cedula.Text).FirstOrDefault();
                    if (Cliente.Nombre != "")
                    {
                        IDCliente = Cliente.Numero_Cliente;
                        this.lbl_cliente.Text = "Nombre del cliente: " + Cliente.Nombre + " " + Cliente.Primer_Apellido + " " + Cliente.Segundo_Apellido;
                        this.lbl_cliente.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dat_resultado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dat_resultado.Rows[e.RowIndex].Cells[1].Value.ToString() == "" || this.txt_impuesto.Text == "")
                {
                    if (this.txt_impuesto.Text == "")
                    {
                        MessageBox.Show("Debe ingresar el impuesto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    ListViewItem lista = new ListViewItem("");
                    lista.SubItems.Add(this.dat_resultado.Rows[e.RowIndex].Cells[0].Value.ToString());
                    lista.SubItems.Add(this.dat_resultado.Rows[e.RowIndex].Cells[1].Value.ToString());
                    lista.SubItems.Add(this.dat_resultado.Rows[e.RowIndex].Cells[4].Value.ToString());

                    double Impuesto = double.Parse(this.txt_impuesto.Text) / 100;
                    double Impuestodeltotal = Convert.ToDouble(this.dat_resultado.Rows[e.RowIndex].Cells[4].Value.ToString()) * Impuesto;
                    double ProductoconImpuesto = Convert.ToDouble(this.dat_resultado.Rows[e.RowIndex].Cells[4].Value.ToString()) + Impuestodeltotal;
                    this.txt_total.Text = Convert.ToString(Total + ProductoconImpuesto);
                    Total += ProductoconImpuesto;
                    lista.SubItems.Add(ProductoconImpuesto.ToString());
                    Productos.Add(new EVentas_Detalles
                    {
                        ID_Producto = int.Parse(this.dat_resultado.Rows[e.RowIndex].Cells[0].Value.ToString()),
                        // Codigo = this.dat_resultado.Rows[e.RowIndex].Cells[1].Value.ToString()
                    });
                    lst_productos.Items.Add(lista);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lst_productos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lst_productos_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                foreach (ListViewItem lista in lst_productos.CheckedItems)
                {
                    //double Impuesto = double.Parse(this.txt_impuesto.Text) / 100;
                    //double Impuestodeltotal = double.Parse(lista.SubItems[4].Text) * Impuesto;
                    Total = Total - double.Parse(lista.SubItems[4].Text)/*+Impuestodeltotal*/;
                    if (Total < 0)
                    {
                        Total = 0;
                    }
                    var IDProducto = int.Parse(lista.SubItems[1].Text);
                    var Prod = Productos.Where(x => x.ID_Producto == IDProducto).FirstOrDefault();
                    Productos.Remove(Prod);
                    lista.Remove();
                    this.txt_total.Text = Total.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_impuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {

            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Productos.Count > 0 && IDCliente != 0 && this.txt_impuesto.Text != "")
                {
                    NVentas Negocios = new NVentas();
                    EVentas Entidad_Ventas = new EVentas();
                    List<EVentas_Detalles> Detalle = new List<EVentas_Detalles>();
                    int linea = 0;
                    Entidad_Ventas.ID_Cliente = IDCliente;
                    Entidad_Ventas.ID_Usuario = Usuario;
                    Entidad_Ventas.CantidadProducto = lst_productos.Items.Count;
                    if (this.cbo_tipo_pago.Text == "")
                    {
                        Entidad_Ventas.Tipo_pago = "Efectivo";
                    }
                    else
                    {
                        Entidad_Ventas.Tipo_pago = this.cbo_tipo_pago.Text;
                    }
                    //  Entidad_Ventas.Impuesto = double.Parse(this.txt_impuesto.Text);
                    Entidad_Ventas.Total = Total;
                    using (TransactionScope Ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        try
                        {
                            foreach (var Item in Productos)
                            {
                                Detalle.Add(new EVentas_Detalles
                                {
                                    ID_Producto = Item.ID_Producto,
                                    Numero_factura = 0,
                                    Linea = linea
                                });
                                Negocios.Afectar_Inventario(Item.ID_Producto);
                                linea++;
                            }
                            Ts.Complete();
                        }
                        catch (Exception ex)
                        {
                            Ts.Dispose();
                            throw ex;
                        }
                    }
                    int FilasAfectadas = Negocios.Agregar(Entidad_Ventas, Detalle, Usuario);
                    if (FilasAfectadas > 0)
                    {
                        MessageBox.Show("Venta realizada exitosamente!!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Visor_Factura frm = new Visor_Factura();
                        NProductos NegProductos = new NProductos();
                        List<EReporte_Ventas_Detalles> Reporte = new List<EReporte_Ventas_Detalles>();
                        foreach (var Item in Detalle)
                        {
                            Reporte.Add(new EReporte_Ventas_Detalles
                            {
                                CodigoProducto = NegProductos.Mostrar().Where(x => x.ID_Producto == Item.ID_Producto).FirstOrDefault().ID_Producto.ToString(),
                                NombreProducto = NegProductos.Mostrar().Where(x => x.ID_Producto == Item.ID_Producto).FirstOrDefault().Nombre,
                                Costo = double.Parse(NegProductos.Mostrar().Where(x => x.ID_Producto == Item.ID_Producto).FirstOrDefault().Precio.ToString()),
                                ID = Item.ID_Producto,
                                IdVenta = FilasAfectadas,
                                // ProductoExento = NegProductos.Mostrar().Where(x => x.ID_Producto == Item.ID_Producto).FirstOrDefault().ProductoExento,
                            });
                        }
                        frm.Num_Fact = FilasAfectadas.ToString();
                        frm.Usuario = Nombre_Usuario;
                        frm.ListaFina = Reporte;
                        frm.Total = Total.ToString();
                        frm.Cliente = this.lbl_cliente.Text;
                        frm.Cantidad_Lineas = linea.ToString();
                        frm.TipoPago = Entidad_Ventas.Tipo_pago;
                        frm.MdiParent = this.MdiParent;
                        frm.Show();
                        ProcesoVentas_Load(null, null);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo realizar la venta!!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
                else
                {
                    if (IDCliente == 0)
                    {
                        MessageBox.Show("Debe agregar un cliente!!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (lst_productos.Items.Count == 0)
                    {
                        MessageBox.Show("Debe agregar productos!!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
