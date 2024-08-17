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
    public partial class MantenimientoUsuarios : Form
    {
        public string Accion { get; set; }
        public int Id { get; set; }
        public int Usuario { get; set; }
        private string UsuarioViniente = string.Empty;
        public MantenimientoUsuarios()
        {
            InitializeComponent();
        }
        private void llenar()
        {
            NUsuarios Negocios = new NUsuarios();
            EUsuario Obj = new EUsuario();
            Obj = Negocios.Mostrar().Where(x => x.ID_Usuario == Id).FirstOrDefault();
            this.txt_cedula.Text = Obj.Cedula.ToString();
            this.txt_nombre.Text = Obj.Nombre;
            this.txt_apellido1.Text = Obj.Primer_Apellido;
            this.txt_apellido2.Text = Obj.Segundo_Apellido;
            this.txt_correo.Text = Obj.Correo;
            this.txt_telefono.Text = Obj.Telefono.ToString();
            this.txt_clave.Text = "********";
            this.txt_user.Text = Obj.Nombre_Usuario;
            this.cbo_rol.SelectedValue = Obj.Id_Rol;
            UsuarioViniente = Obj.Nombre_Usuario;
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
                if (this.txt_user.Text == "")
                {
                    errorProvider1.SetError(this.txt_user, "Debe ingresar el nombre de usuario");
                    ok = true;
                }
                if (this.txt_nombre.Text == "")
                {
                    errorProvider1.SetError(this.txt_nombre, "Debe ingresar el nombre");
                    ok = true;
                }
                if (this.txt_apellido1.Text == "")
                {
                    errorProvider1.SetError(this.txt_apellido1, "Debe ingresar el primer apellido");
                    ok = true;
                }
                if (this.txt_apellido2.Text == "")
                {
                    errorProvider1.SetError(this.txt_apellido2, "Debe ingresar el segundo apellido");
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
                if (this.txt_clave.Text != this.txt_cclave.Text && Accion == "A")
                {
                    errorProvider1.SetError(this.txt_cclave, "Las contraseñas no coinciden.");
                    ok = true;
                }
                Regex Regexa = new Regex(@"^(?=.*[\d])(?=.*[A-Z])(?=.*[a-z])[\w\d]{8,}$");
                Match Match = Regexa.Match(this.txt_clave.Text);
                if (Match.Success || this.txt_clave.Text == "********")
                {

                }
                else
                {
                    errorProvider1.SetError(this.txt_clave, "La contraseña debe de tener un mínimo de 8 caracteres, con lo siguiente: " +
                    "\n Al menos una mayúscula" +
                    "\n Al menos una minúscula" +
                    "\n Al menos un número" +
                    "\n No debe tener caracteres especiales ni espacios");
                    ok = true;
                }
                if (this.cbo_rol.SelectedValue == null)
                {
                    errorProvider1.SetError(this.cbo_rol, "Debe seleccionar un rol");
                    ok = true;
                }
                if (this.txt_user.Text != UsuarioViniente && Accion == "M" && this.txt_clave.Text == "********")
                {
                    errorProvider1.SetError(this.txt_clave, "Debe cambiar la clave necesariamente si cambia el usuario.");
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
                errorProvider1.SetError(txt_apellido1,"");
                errorProvider1.SetError(txt_apellido2, "");
                errorProvider1.SetError(txt_clave, "");
                errorProvider1.SetError(txt_cclave, "");
                errorProvider1.SetError(txt_correo, "");
                errorProvider1.SetError(txt_user, "");
                errorProvider1.SetError(cbo_rol, "");
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
                        NUsuarios Negocios = new NUsuarios();
                        EUsuario Obj = new EUsuario();
                        Obj.Cedula = this.txt_cedula.Text;
                        Obj.Nombre_Usuario = this.txt_user.Text;
                        Obj.Nombre = this.txt_nombre.Text;
                        Obj.Primer_Apellido = this.txt_apellido1.Text;
                        Obj.Segundo_Apellido = this.txt_apellido2.Text;
                        Obj.Id_Rol = int.Parse(this.cbo_rol.SelectedValue.ToString());
                        Obj.Correo = this.txt_correo.Text;
                        Obj.Telefono = this.txt_telefono.Text;
                        //Obj.Correo = this.txt_correo.Text;
                        Obj.Nombre = this.txt_nombre.Text;
                        Int32 FilasAfectadas = 0;
                        #region Agregar
                        if (Accion == "A")
                        {
                            Obj.Contrasena = Helper.EncodePassword(string.Concat(this.txt_user.Text.ToString(), this.txt_clave.ToString()));
                            FilasAfectadas = Negocios.Agregar(Obj, Usuario);
                            if (FilasAfectadas > 0)
                            {
                                MessageBox.Show("Usuario Agregado exitosamente!!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Error al agregar el Usuario!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        #endregion

                        #region Modificar
                        if (Accion == "M")
                        {
                            Obj.ID_Usuario = Id;
                            Obj.Contrasena = this.txt_clave.Text;
                            if (this.txt_clave.Text != "********" || this.txt_user.Text != UsuarioViniente)
                            {
                                Obj.Contrasena = Helper.EncodePassword(string.Concat(this.txt_user.Text.ToString(), this.txt_clave.ToString()));
                            }
                            FilasAfectadas = Negocios.Modificar(Obj, Usuario);
                            MessageBox.Show("Usuario modificado exitosamente!!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void MantenimientoUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                NRoles NegociosRoles = new NRoles();
                this.cbo_rol.DisplayMember = "Text";
                this.cbo_rol.ValueMember = "Value";

                var RolesDataSource = NegociosRoles.Mostrar().Select(x => new
                {
                    Text = x.Nombre_Rol,
                    Value = x.Id_Rol
                }
                );
                this.cbo_rol.DataSource = RolesDataSource.ToArray();
                if (Accion == "M" || Accion == "C")
                {
                    this.txt_cclave.Visible = false;
                    this.lbl_cclave.Visible = false;
                    llenar();
                    if (Accion == "C")
                    {
                        this.groupBox1.Enabled = false;
                        //  this.groupBox3.Enabled = false;
                        // this.lst_telefono.Enabled = true;
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
