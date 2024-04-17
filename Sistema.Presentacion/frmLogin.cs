using System;
using System.Data;
using System.Windows.Forms;
using Sistema.Entidad;
using Sistema.Negocios;

namespace Sistema.Presentacion
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnAcceso_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tabla = new DataTable();
                tabla = NUsuarios.Login(txtEmail.Text, txtClave.Text);
                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("El Email o la clave es invalida.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (Convert.ToBoolean(tabla.Rows[0][4]) == false)
                    {
                        MessageBox.Show("El Usuario esta desactivado.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else
                    {
                        frmPrincipal frm = new frmPrincipal();
                        frm.IdUsuario = Convert.ToInt32(tabla.Rows[0][0]);
                        frm.IdRol = Convert.ToInt32(tabla.Rows[0][1]);
                        frm.Rol = tabla.Rows[0][2].ToString();
                        frm.Nombre = tabla.Rows[0][3].ToString();
                        frm.Estado = Convert.ToBoolean(tabla.Rows[0][4]);
                        frm.Show();
                        this.Hide();
                        Variables.IdUsuario = frm.IdUsuario;
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
