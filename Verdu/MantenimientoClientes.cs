using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diamond
{
    public partial class MantenimientoClientes : Form
    {
        public string Accion { get; set; }
        public int Id { get; set; }
        public int Usuario { get; set; }
        public MantenimientoClientes()
        {
            InitializeComponent();
        }
        private void Mantenimiento_Cliente_Load(object sender, EventArgs e)
        {
            try
            {
                if (Accion == "M" || Accion == "C")
                {
                    llenar();
                    if (Accion == "C")
                    {
                        this.groupBox1.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void llenar()
        {
            NCliente Negocios = new NCliente();
            EClientes Obj = new EClientes();
            Obj = Negocios.Mostrar().Where(x => x.Numero_Cliente == Id).FirstOrDefault();
            this.txt_cedula.Text = Obj.Cedula.ToString();
            this.txt_nombre.Text = Obj.Nombre;
            this.txt_apellido1.Text = Obj.Primer_Apellido;
            this.txt_apellido2.Text = Obj.Segundo_Apellido;
            this.txt_correo.Text = Obj.Correo;
            this.txt_telefono.Text = Obj.Telefono.ToString();
            this.txtDireccion.Text = Obj.Direccion.ToString();
        }
        private bool validar()
        {
            bool ok = false;
            try
            {
                if (this.txt_cedula.Text.Length < 9)
                {
                    errorProvider1.SetError(this.txt_cedula, "Formato de cedula invalido.");
                    ok = true;
                }
                if (this.txt_nombre.Text == "")
                {
                    errorProvider1.SetError(this.txt_nombre, "Debe ingresar el nombre");
                    ok = true;
                }
                if (this.txt_apellido1.Text == "")
                {
                    errorProvider1.SetError(this.txt_apellido1, "Debe ingresar el apellido");
                    ok = true;
                }
                if (this.txt_apellido2.Text == "")
                {
                    errorProvider1.SetError(this.txt_apellido2, "Debe ingresar el apellido");
                    ok = true;
                }
                if (this.txtDireccion.Text == "")
                {
                    errorProvider1.SetError(this.txtDireccion, "Debe ingresar la direccion");
                    ok = true;
                }
                if (this.txt_correo.Text == "")
                {
                    errorProvider1.SetError(this.txt_correo, "Debe ingresar el correo");
                    ok = true;
                }
                String expresion;
                expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                if (Regex.IsMatch(this.txt_correo.Text, expresion))
                {
                    if (Regex.Replace(this.txt_correo.Text, expresion, String.Empty).Length == 0)
                    {

                    }
                    else
                    {
                        errorProvider1.SetError(this.txt_correo, "Formato de correo invalido");
                        ok = true;
                    }
                }
                else
                {
                    errorProvider1.SetError(this.txt_correo, "Formato de correo invalido");
                    ok = true;
                }
                if (this.txt_telefono.Text.Length < 8)
                {
                    errorProvider1.SetError(this.txt_telefono, "Formato de telefono invalido");
                    ok = true;
                }
                if (this.txt_telefono.Text == "")
                {
                    errorProvider1.SetError(this.txt_telefono, "Debe ingresar el telefono");
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
                errorProvider1.SetError(txt_cedula, "");
                errorProvider1.SetError(txt_nombre, "");
                errorProvider1.SetError(txt_apellido1, "");
                errorProvider1.SetError(txt_apellido2, "");
                errorProvider1.SetError(txtDireccion, "");
                errorProvider1.SetError(txt_correo, "");
                errorProvider1.SetError(txt_telefono, "");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
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
                        NCliente Negocios = new NCliente();
                        EClientes Obj = new EClientes();
                        Obj.Cedula = this.txt_cedula.Text;
                        Obj.Nombre = this.txt_nombre.Text;
                        Obj.Primer_Apellido = this.txt_apellido1.Text;
                        Obj.Segundo_Apellido = this.txt_apellido2.Text;
                        Obj.Correo = this.txt_correo.Text;
                        Obj.Telefono = int.Parse(this.txt_telefono.Text);
                        Obj.Direccion = this.txtDireccion.Text;
                        Int32 FilasAfectadas = 0;
                        #region Agregar
                        if (Accion == "A")
                        {
                            FilasAfectadas = Negocios.Agregar(Obj, Usuario);
                            if (FilasAfectadas > 0)
                            {
                                MessageBox.Show("Cliente Agregado exitosamente!!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Error al agregar el Cliente!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        #endregion

                        #region Modificar
                        if (Accion == "M")
                        {
                            Obj.Numero_Cliente = Id;
                            FilasAfectadas = Negocios.Modificar(Obj, Usuario);
                            MessageBox.Show("Cliente modificado exitosamente!!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        if (Accion == "C")
                        {
                            this.Close();
                        }
                    }
                    #endregion

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
    }
}
