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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                NUsuarios Negocios = new NUsuarios();
                EUsuario Usu = new EUsuario();
                int Id_Session = 0;
                string pass = Helper.EncodePassword(string.Concat(this.txt_usuario.Text.ToString(), this.txt_pass.ToString()));
                Usu = Negocios.Login(this.txt_usuario.Text, pass);
                if (Usu != null)
                {
                    NBitacora_Sesiones Ses = new NBitacora_Sesiones();
                    EBitacora_Sesiones EntidadSesion = new EBitacora_Sesiones();
                    EntidadSesion.fecha_hora_ingreso = DateTime.Now;
                    EntidadSesion.Id_Usuario = Usu.ID_Usuario;
                    Id_Session = Ses.Agregar(EntidadSesion);
                    if (Id_Session > 0)
                    {
                        this.Hide();
                        Menu form = new Menu();
                        form.Idsession = Id_Session;
                        form.UsuarioLogueado = Usu;
                        MessageBox.Show("Bienvenido: " + Usu.Nombre_Usuario, "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        form.Show();
                    }
                    else
                    {
                        MessageBox.Show("Error al ingresar!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error usuario o contraseña invalido!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
