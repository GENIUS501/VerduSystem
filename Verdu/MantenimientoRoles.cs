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
    public partial class MantenimientoRoles : Form
    {
        public int Usuario { get; set; }
        public int Id { get; set; }
        public string Accion { get; set; }
        public MantenimientoRoles()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                BorrarMensajesError();
                if (this.ValidarCampos())
                {
                    if (Accion == "A" || Accion == "M")
                    {
                        NRoles Negocios = new NRoles();
                        ERoles Rol = new ERoles();
                        Int32 FilasAfectadas = 0;
                        Rol.Nombre_Rol = this.txt_nombre_perfil.Text;
                        if (Accion == "A")
                        {
                            FilasAfectadas = Negocios.Agregar(Rol, Usuario);
                            if (FilasAfectadas > 0)
                            {
                                var Permi = Permisos(FilasAfectadas);
                                Negocios.AgregarPermisos(Permi, FilasAfectadas);
                                MessageBox.Show("Rol agregado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Error al agregar el rol!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        if (Accion == "M")
                        {
                            Rol.Id_Rol = int.Parse(this.txt_id_perfil.Text);
                            FilasAfectadas = Negocios.Modificar(Rol, Usuario);
                            var Permi = Permisos(int.Parse(this.txt_id_perfil.Text));
                            Negocios.AgregarPermisos(Permi, int.Parse(this.txt_id_perfil.Text));
                            MessageBox.Show("Rol modificado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    if (Accion == "C")
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region llenar Permisos
        private void Llenar()
        {
            try
            {
                NRoles Negocios = new NRoles();
                List<EPermisos> Permisos = new List<EPermisos>();
                ERoles Rol = new ERoles();
                Permisos = Negocios.llenar_Permisos(Id);
                Rol = Negocios.Mostrar().Where(x => x.Id_Rol == Id).FirstOrDefault();
                this.txt_id_perfil.Text = Rol.Id_Rol.ToString();
                this.txt_nombre_perfil.Text = Rol.Nombre_Rol.ToString();
                #region Roles 1
                ////////Roles//1////////////////////////////////////
                if (Permisos.Where(x => x.Modulo == "Roles").FirstOrDefault() != null)
                {
                    this.grp_roles.Enabled = true;
                    this.chb_rol.Checked = true;
                    if (Permisos.Where(x => x.Modulo == "Roles" && x.Accion == "Agregar").FirstOrDefault() != null)
                    {
                        this.chk_rol_agregar.Checked = true;
                    }
                    else
                    {
                        this.chk_rol_agregar.Checked = false;
                    }
                    ///
                    if (Permisos.Where(x => x.Modulo == "Roles" && x.Accion == "Consultar").FirstOrDefault() != null)
                    {
                        this.chk_rol_consultar.Checked = true;
                    }
                    else
                    {
                        this.chk_rol_consultar.Checked = false;
                    }
                    /////
                    if (Permisos.Where(x => x.Modulo == "Roles" && x.Accion == "Eliminar").FirstOrDefault() != null)
                    {
                        this.chk_rol_eliminar.Checked = true;
                    }
                    else
                    {
                        this.chk_rol_eliminar.Checked = false;
                    }
                    /////
                    if (Permisos.Where(x => x.Modulo == "Roles" && x.Accion == "Modificar").FirstOrDefault() != null)
                    {
                        this.chk_rol_modificar.Checked = true;
                    }
                    else
                    {
                        this.chk_rol_modificar.Checked = false;
                    }
                }
                else
                {

                }
                #endregion
                #region Usuarios 2
                ////////Usuarios//2////////////////////////////////////
                if (Permisos.Where(x => x.Modulo == "Usuarios").FirstOrDefault() != null)
                {
                    this.grp_usuarios.Enabled = true;
                    this.chb_usuarios.Checked = true;
                    if (Permisos.Where(x => x.Modulo == "Usuarios" && x.Accion == "Agregar").FirstOrDefault() != null)
                    {
                        this.chk_usuarios_agregar.Checked = true;
                    }
                    else
                    {
                        this.chk_usuarios_agregar.Checked = false;
                    }
                    ///
                    if (Permisos.Where(x => x.Modulo == "Usuarios" && x.Accion == "Consultar").FirstOrDefault() != null)
                    {
                        this.chk_usuarios_consultar.Checked = true;
                    }
                    else
                    {
                        this.chk_usuarios_consultar.Checked = false;
                    }
                    /////
                    if (Permisos.Where(x => x.Modulo == "Usuarios" && x.Accion == "Eliminar").FirstOrDefault() != null)
                    {
                        this.chk_usuarios_eliminar.Checked = true;
                    }
                    else
                    {
                        this.chk_usuarios_eliminar.Checked = false;
                    }
                    /////
                    if (Permisos.Where(x => x.Modulo == "Usuarios" && x.Accion == "Modificar").FirstOrDefault() != null)
                    {
                        this.chk_usuarios_modificar.Checked = true;
                    }
                    else
                    {
                        this.chk_usuarios_modificar.Checked = false;
                    }
                }
                else
                {

                }
                #endregion
                #region Tipo_Producto 3
                ////////Tipo_Producto//3////////////////////////////////////
                if (Permisos.Where(x => x.Modulo == "Tipo_Producto").FirstOrDefault() != null)
                {
                    this.grp_Tipo_Producto.Enabled = true;
                    this.chb_Tipo_Producto.Checked = true;
                    if (Permisos.Where(x => x.Modulo == "Tipo_Producto" && x.Accion == "Agregar").FirstOrDefault() != null)
                    {
                        this.chk_Tipo_Producto_agregar.Checked = true;
                    }
                    else
                    {
                        this.chk_Tipo_Producto_agregar.Checked = false;
                    }
                    ///
                    if (Permisos.Where(x => x.Modulo == "Tipo_Producto" && x.Accion == "Consultar").FirstOrDefault() != null)
                    {
                        this.chk_Tipo_Producto_consultar.Checked = true;
                    }
                    else
                    {
                        this.chk_Tipo_Producto_consultar.Checked = false;
                    }
                    /////
                    if (Permisos.Where(x => x.Modulo == "Tipo_Producto" && x.Accion == "Eliminar").FirstOrDefault() != null)
                    {
                        this.chk_Tipo_Producto_eliminar.Checked = true;
                    }
                    else
                    {
                        this.chk_Tipo_Producto_eliminar.Checked = false;
                    }
                    /////
                    if (Permisos.Where(x => x.Modulo == "Tipo_Producto" && x.Accion == "Modificar").FirstOrDefault() != null)
                    {
                        this.chk_Tipo_Producto_modificar.Checked = true;
                    }
                    else
                    {
                        this.chk_Tipo_Producto_modificar.Checked = false;
                    }
                }
                else
                {

                }
                #endregion
                #region Clientes
                ////////Clientes//////////////////////////////////////
                if (Permisos.Where(x => x.Modulo == "Clientes").FirstOrDefault() != null)
                {
                    this.grp_clientes.Enabled = true;
                    this.chb_clientes.Checked = true;
                    if (Permisos.Where(x => x.Modulo == "Clientes" && x.Accion == "Agregar").FirstOrDefault() != null)
                    {
                        this.chk_clientes_agregar.Checked = true;
                    }
                    else
                    {
                        this.chk_clientes_agregar.Checked = false;
                    }
                    ///
                    if (Permisos.Where(x => x.Modulo == "Clientes" && x.Accion == "Consultar").FirstOrDefault() != null)
                    {
                        this.chk_clientes_consultar.Checked = true;
                    }
                    else
                    {
                        this.chk_clientes_consultar.Checked = false;
                    }
                    /////
                    if (Permisos.Where(x => x.Modulo == "Clientes" && x.Accion == "Eliminar").FirstOrDefault() != null)
                    {
                        this.chk_clientes_eliminar.Checked = true;
                    }
                    else
                    {
                        this.chk_clientes_eliminar.Checked = false;
                    }
                    /////
                    if (Permisos.Where(x => x.Modulo == "Clientes" && x.Accion == "Modificar").FirstOrDefault() != null)
                    {
                        this.chk_clientes_modificar.Checked = true;
                    }
                    else
                    {
                        this.chk_clientes_modificar.Checked = false;
                    }
                }
                else
                {

                }
                #endregion
                #region Productos 5
                ////////Productos//5////////////////////////////////////
                if (Permisos.Where(x => x.Modulo == "Productos").FirstOrDefault() != null)
                {
                    this.grp_productos.Enabled = true;
                    this.chb_productos.Checked = true;
                    if (Permisos.Where(x => x.Modulo == "Productos" && x.Accion == "Agregar").FirstOrDefault() != null)
                    {
                        this.chk_productos_agregar.Checked = true;
                    }
                    else
                    {
                        this.chk_productos_agregar.Checked = false;
                    }
                    ///
                    if (Permisos.Where(x => x.Modulo == "Productos" && x.Accion == "Consultar").FirstOrDefault() != null)
                    {
                        this.chk_productos_consultar.Checked = true;
                    }
                    else
                    {
                        this.chk_productos_consultar.Checked = false;
                    }
                    /////
                    if (Permisos.Where(x => x.Modulo == "Productos" && x.Accion == "Eliminar").FirstOrDefault() != null)
                    {
                        this.chk_productos_eliminar.Checked = true;
                    }
                    else
                    {
                        this.chk_productos_eliminar.Checked = false;
                    }
                    /////
                    if (Permisos.Where(x => x.Modulo == "Productos" && x.Accion == "Modificar").FirstOrDefault() != null)
                    {
                        this.chk_productos_modificar.Checked = true;
                    }
                    else
                    {
                        this.chk_productos_modificar.Checked = false;
                    }
                }
                else
                {

                }
                #endregion
                #region Reporte de Producto
                if (Permisos.Where(x => x.Modulo == "ReporteProducto").FirstOrDefault() != null)
                {
                    this.chb_productos_reporte.Checked = true;
                }
                else
                {

                }
                #endregion
                #region Reporte de Clientes
                if (Permisos.Where(x => x.Modulo == "ReporteClientes").FirstOrDefault() != null)
                {
                    this.chb_Clientes_reporte.Checked = true;
                }
                else
                {

                }
                #endregion
                #region Reporte de ventas
                if (Permisos.Where(x => x.Modulo == "ReporteVentas").FirstOrDefault() != null)
                {
                    this.chb_venta_reporte.Checked = true;
                }
                else
                {

                }
                #endregion
                #region Bitacora de sesiones
                if (Permisos.Where(x => x.Modulo == "BitacoraSesiones").FirstOrDefault() != null)
                {
                    this.chb_bit_sesiones.Checked = true;
                }
                else
                {

                }
                #endregion              
                #region Bitacora de Movimientos
                if (Permisos.Where(x => x.Modulo == "BitacoraMovimientos").FirstOrDefault() != null)
                {
                    this.chb_bit_movimientos.Checked = true;
                }
                else
                {

                }
                #endregion
                #region Procesos
                if (Permisos.Where(x => x.Modulo == "ProcesoVentas").FirstOrDefault() != null)
                {
                    this.chb_ventas.Checked = true;
                }
                else
                {

                }
                if (Permisos.Where(x => x.Modulo == "ProcesoDevoluciones").FirstOrDefault() != null)
                {
                    this.chb_devoluciones.Checked = true;
                }
                else
                {

                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Agregar Permisos
        private List<EPermisos> Permisos(int Id_Rol)
        {
            try
            {
                List<EPermisos> Lista_Permisos = new List<EPermisos>();
                EPermisos Permisos = new EPermisos();
                ///////////////////Roles/////////////////////////////////////////////////////////////////////////////
                if (this.chb_rol.Checked == true)
                {
                    Permisos.Id_Rol = Id_Rol;
                    Permisos.Modulo = "Roles";
                    Permisos.Accion = "Roles";
                    Lista_Permisos.Add(Permisos);
                    Permisos = new EPermisos();
                    if (this.grp_roles.Enabled == true)
                    {
                        if (chk_rol_agregar.Checked == true)
                        {
                            Permisos.Id_Rol = Id_Rol;
                            Permisos.Modulo = "Roles";
                            Permisos.Accion = "Agregar";
                            Lista_Permisos.Add(Permisos);
                            Permisos = new EPermisos();
                        }
                        if (chk_rol_modificar.Checked == true)
                        {
                            Permisos.Id_Rol = Id_Rol;
                            Permisos.Modulo = "Roles";
                            Permisos.Accion = "Modificar";
                            Lista_Permisos.Add(Permisos);
                            Permisos = new EPermisos();
                        }
                        if (chk_rol_eliminar.Checked == true)
                        {
                            Permisos.Id_Rol = Id_Rol;
                            Permisos.Modulo = "Roles";
                            Permisos.Accion = "Eliminar";
                            Lista_Permisos.Add(Permisos);
                            Permisos = new EPermisos();
                        }
                        if (chk_rol_consultar.Checked == true)
                        {
                            Permisos.Id_Rol = Id_Rol;
                            Permisos.Modulo = "Roles";
                            Permisos.Accion = "Consultar";
                            Lista_Permisos.Add(Permisos);
                            Permisos = new EPermisos();
                        }
                    }
                }

                /////////Usuarios/////////////////////////////////////////////////////////////////////////////
                if (this.chb_usuarios.Checked == true)
                {
                    Permisos.Id_Rol = Id_Rol;
                    Permisos.Modulo = "Usuarios";
                    Permisos.Accion = "Usuarios";
                    Lista_Permisos.Add(Permisos);
                    Permisos = new EPermisos();
                    if (this.grp_usuarios.Enabled == true)
                    {
                        if (chk_usuarios_agregar.Checked == true)
                        {
                            Permisos.Id_Rol = Id_Rol;
                            Permisos.Modulo = "Usuarios";
                            Permisos.Accion = "Agregar";
                            Lista_Permisos.Add(Permisos);
                            Permisos = new EPermisos();
                        }
                        if (chk_usuarios_modificar.Checked == true)
                        {
                            Permisos.Id_Rol = Id_Rol;
                            Permisos.Modulo = "Usuarios";
                            Permisos.Accion = "Modificar";
                            Lista_Permisos.Add(Permisos);
                            Permisos = new EPermisos();
                        }
                        if (chk_usuarios_eliminar.Checked == true)
                        {
                            Permisos.Id_Rol = Id_Rol;
                            Permisos.Modulo = "Usuarios";
                            Permisos.Accion = "Eliminar";
                            Lista_Permisos.Add(Permisos);
                            Permisos = new EPermisos();
                        }
                        if (chk_usuarios_consultar.Checked == true)
                        {
                            Permisos.Id_Rol = Id_Rol;
                            Permisos.Modulo = "Usuarios";
                            Permisos.Accion = "Consultar";
                            Lista_Permisos.Add(Permisos);
                            Permisos = new EPermisos();
                        }
                    }
                }
                /////////Clientes//////3///////////////////////////////////////////////////////////////////////
                if (this.chb_clientes.Checked == true)
                {
                    Permisos.Id_Rol = Id_Rol;
                    Permisos.Modulo = "Clientes";
                    Permisos.Accion = "Clientes";
                    Lista_Permisos.Add(Permisos);
                    Permisos = new EPermisos();
                    if (this.grp_clientes.Enabled == true)
                    {
                        if (chk_clientes_agregar.Checked == true)
                        {
                            Permisos.Id_Rol = Id_Rol;
                            Permisos.Modulo = "Clientes";
                            Permisos.Accion = "Agregar";
                            Lista_Permisos.Add(Permisos);
                            Permisos = new EPermisos();
                        }
                        if (chk_clientes_modificar.Checked == true)
                        {
                            Permisos.Id_Rol = Id_Rol;
                            Permisos.Modulo = "Clientes";
                            Permisos.Accion = "Modificar";
                            Lista_Permisos.Add(Permisos);
                            Permisos = new EPermisos();
                        }
                        if (chk_clientes_eliminar.Checked == true)
                        {
                            Permisos.Id_Rol = Id_Rol;
                            Permisos.Modulo = "Clientes";
                            Permisos.Accion = "Eliminar";
                            Lista_Permisos.Add(Permisos);
                            Permisos = new EPermisos();
                        }
                        if (chk_clientes_consultar.Checked == true)
                        {
                            Permisos.Id_Rol = Id_Rol;
                            Permisos.Modulo = "Clientes";
                            Permisos.Accion = "Consultar";
                            Lista_Permisos.Add(Permisos);
                            Permisos = new EPermisos();
                        }
                    }
                }
                /////////Productos/////////////////////////////////////////////////////////////////////////////
                if (this.chb_productos.Checked == true)
                {
                    Permisos.Id_Rol = Id_Rol;
                    Permisos.Modulo = "Productos";
                    Permisos.Accion = "Productos";
                    Lista_Permisos.Add(Permisos);
                    Permisos = new EPermisos();
                    if (this.grp_productos.Enabled == true)
                    {
                        if (chk_productos_agregar.Checked == true)
                        {
                            Permisos.Id_Rol = Id_Rol;
                            Permisos.Modulo = "Productos";
                            Permisos.Accion = "Agregar";
                            Lista_Permisos.Add(Permisos);
                            Permisos = new EPermisos();
                        }
                        if (chk_productos_modificar.Checked == true)
                        {
                            Permisos.Id_Rol = Id_Rol;
                            Permisos.Modulo = "Productos";
                            Permisos.Accion = "Modificar";
                            Lista_Permisos.Add(Permisos);
                            Permisos = new EPermisos();
                        }
                        if (chk_productos_eliminar.Checked == true)
                        {
                            Permisos.Id_Rol = Id_Rol;
                            Permisos.Modulo = "Productos";
                            Permisos.Accion = "Eliminar";
                            Lista_Permisos.Add(Permisos);
                            Permisos = new EPermisos();
                        }
                        if (chk_productos_consultar.Checked == true)
                        {
                            Permisos.Id_Rol = Id_Rol;
                            Permisos.Modulo = "Productos";
                            Permisos.Accion = "Consultar";
                            Lista_Permisos.Add(Permisos);
                            Permisos = new EPermisos();
                        }
                    }
                }
                /////////Tipo_Producto//////5///////////////////////////////////////////////////////////////////////
                if (this.chb_Tipo_Producto.Checked == true)
                {
                    Permisos.Id_Rol = Id_Rol;
                    Permisos.Modulo = "Tipo_Producto";
                    Permisos.Accion = "Tipo_Producto";
                    Lista_Permisos.Add(Permisos);
                    Permisos = new EPermisos();
                    if (this.grp_Tipo_Producto.Enabled == true)
                    {
                        if (chk_Tipo_Producto_agregar.Checked == true)
                        {
                            Permisos.Id_Rol = Id_Rol;
                            Permisos.Modulo = "Tipo_Producto";
                            Permisos.Accion = "Agregar";
                            Lista_Permisos.Add(Permisos);
                            Permisos = new EPermisos();
                        }
                        if (chk_Tipo_Producto_modificar.Checked == true)
                        {
                            Permisos.Id_Rol = Id_Rol;
                            Permisos.Modulo = "Tipo_Producto";
                            Permisos.Accion = "Modificar";
                            Lista_Permisos.Add(Permisos);
                            Permisos = new EPermisos();
                        }
                        if (chk_Tipo_Producto_eliminar.Checked == true)
                        {
                            Permisos.Id_Rol = Id_Rol;
                            Permisos.Modulo = "Tipo_Producto";
                            Permisos.Accion = "Eliminar";
                            Lista_Permisos.Add(Permisos);
                            Permisos = new EPermisos();
                        }
                        if (chk_Tipo_Producto_consultar.Checked == true)
                        {
                            Permisos.Id_Rol = Id_Rol;
                            Permisos.Modulo = "Tipo_Producto";
                            Permisos.Accion = "Consultar";
                            Lista_Permisos.Add(Permisos);
                            Permisos = new EPermisos();
                        }
                    }
                }
                if (this.chb_productos_reporte.Checked == true)
                {
                    Permisos.Id_Rol = Id_Rol;
                    Permisos.Modulo = "ReporteProducto";
                    Permisos.Accion = "ReporteProducto";
                    Lista_Permisos.Add(Permisos);
                    Permisos = new EPermisos();
                }
                ////////Reportes_Clientes////10//////////////////////////////////////////////////////////////////////////////////
                if (this.chb_Clientes_reporte.Checked == true)
                {
                    Permisos.Id_Rol = Id_Rol;
                    Permisos.Modulo = "ReporteClientes";
                    Permisos.Accion = "ReporteClientes";
                    Lista_Permisos.Add(Permisos);
                    Permisos = new EPermisos();
                }
                ////////Reporte_Ventas//////////////////////////////////////////////////////////////////////////////////////
                if (this.chb_venta_reporte.Checked == true)
                {
                    Permisos.Id_Rol = Id_Rol;
                    Permisos.Modulo = "ReporteVentas";
                    Permisos.Accion = "ReporteVentas";
                    Lista_Permisos.Add(Permisos);
                    Permisos = new EPermisos();
                }
                ////////Bitacora_sesiones//////////////////////////////////////////////////////////////////////////////////////
                if (this.chb_bit_sesiones.Checked == true)
                {
                    Permisos.Id_Rol = Id_Rol;
                    Permisos.Modulo = "BitacoraSesiones";
                    Permisos.Accion = "BitacoraSesiones";
                    Lista_Permisos.Add(Permisos);
                    Permisos = new EPermisos();
                }
                ////////Bitacora_movimientos//////////////////////////////////////////////////////////////////////////////////////
                if (this.chb_bit_movimientos.Checked == true)
                {
                    Permisos.Id_Rol = Id_Rol;
                    Permisos.Modulo = "BitacoraMovimientos";
                    Permisos.Accion = "BitacoraMovimientos";
                    Lista_Permisos.Add(Permisos);
                    Permisos = new EPermisos();
                }
                ///////////////////////////////////////////////
                if (this.chb_ventas.Checked == true)
                {
                    Permisos.Id_Rol = Id_Rol;
                    Permisos.Modulo = "ProcesoVentas";
                    Permisos.Accion = "ProcesoVentas";
                    Lista_Permisos.Add(Permisos);
                    Permisos = new EPermisos();
                }
                ///////////////////////////////////////////////
                if (this.chb_devoluciones.Checked == true)
                {
                    Permisos.Id_Rol = Id_Rol;
                    Permisos.Modulo = "ProcesoDevoluciones";
                    Permisos.Accion = "ProcesoDevoluciones";
                    Lista_Permisos.Add(Permisos);
                    Permisos = new EPermisos();
                }
                return Lista_Permisos;
            }
            catch (Exception)
            {
                return new List<EPermisos>();
            }
        }
        #endregion
        private void BorrarMensajesError()
        {
            try
            {
                errorProvider1.SetError(txt_nombre_perfil, "");
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        private bool ValidarCampos()
        {
            try
            {
                bool ok = true;

                if (txt_nombre_perfil.Text == "")
                {
                    ok = false;
                    errorProvider1.SetError(txt_nombre_perfil, "Ingrese el nombre del perfil");
                }

                return ok;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void chb_rol_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chb_rol.Checked == true)
                {
                    grp_roles.Enabled = true;
                }
                else
                {
                    grp_roles.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chb_usuarios_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chb_usuarios.Checked == true)
                {
                    grp_usuarios.Enabled = true;
                }
                else
                {
                    grp_usuarios.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chb_Clientes_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chb_clientes.Checked == true)
                {
                    grp_clientes.Enabled = true;
                }
                else
                {
                    grp_clientes.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chb_Productos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chb_productos.Checked == true)
                {
                    grp_productos.Enabled = true;
                }
                else
                {
                    grp_productos.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chb_Tipo_Producto_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chb_Tipo_Producto.Checked == true)
                {
                    grp_Tipo_Producto.Enabled = true;
                }
                else
                {
                    grp_Tipo_Producto.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MantenimientoRoles_Load(object sender, EventArgs e)
        {
            try
            {
                if (Accion == "A")
                {
                    this.Lbl_Perfil.Visible = false;
                    this.txt_id_perfil.Visible = false;
                }
                if (Accion == "M" || Accion == "C")
                {
                    Llenar();
                    this.txt_id_perfil.Enabled = false;
                    if (Accion == "C")
                    {
                        this.groupBox1.Enabled = false;
                        this.groupBox2.Enabled = false;
                        this.groupBox3.Enabled= false;
                        this.groupBox5.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
