using System.Data;
using System.Windows.Forms;
using Sistema.Negocios;

namespace Sistema.Presentacion
{
    public partial class frmRoles : Form
    {
        public frmRoles()
        {
            InitializeComponent();
            dgvRoles.DataSource = NUsuarios.Listar();
            
        }
    }
}
