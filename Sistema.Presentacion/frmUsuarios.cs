using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Negocios;

namespace Sistema.Presentacion
{
    public partial class frmUsuarios : Form
    {
        string nombreAnterior;

        public frmUsuarios()
        {
            InitializeComponent();
            Limpiar();
            Listar();
        }

        private void Buscar()
        {
            dgvListado.DataSource = NUsuarios.Buscar(txtBuscar.Text);
            this.Formato();
            this.Limpiar();
            lblTotal.Text = $"Total de Registros: {dgvListado.Rows.Count}";
        }

        private void Listar()
        {
            try
            {
                dgvListado.DataSource = NUsuarios.Listar();
                this.Formato();
                lblTotal.Text = $"Total de Registros: {dgvListado.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Source}: {ex.Message}");
            }
        }

        // Auxiliary methods.

        private void Formato()
        {
            dgvListado.Columns[0].Visible = false;
            dgvListado.Columns[1].Visible = false;
            dgvListado.Columns[2].Visible = false;

            dgvListado.Columns[5].Width = 150;
            dgvListado.Columns[6].Width = 200;
            dgvListado.Columns[7].Width = 300;
            dgvListado.Columns[9].Width = 200;

            dgvListado.Columns[5].HeaderText = "Tipo de Documento";
            dgvListado.Columns[6].HeaderText = "Documento";
        }

        private void Limpiar()
        {
            txtBuscar.Clear();
            btnEliminar.Visible = false;
            dgvListado.Columns[0].Visible = false;

            btnActualizar.Visible = false;
            btnInsertar.Visible = true;
            txtNombre.Clear();
            txtDocumento.Clear();
            txtDireccion.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            cmbRol.SelectedIndex = -1;
            cmbTipos.SelectedIndex = -1;
            txtClave.Clear();

            tabGeneral.SelectedIndex = 0;
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void MensajeError(string msg)
        {
            MessageBox.Show(msg, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MensajeOK(string msg)
        {
            MessageBox.Show(msg, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DevMSG(Exception msg)
        {
            MessageBox.Show(msg.ToString() + ":" + msg.Message + " At: " + msg.TargetSite, "[ERROR] DEV DETAILS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
        }
        
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                bool errored = false;
                if (txtNombre.Text == string.Empty)
                {
                    errored = true;
                    errorProvider1.SetError(txtNombre, "Ingrese un nombre para la categoria");
                    //errorProvider1.SetError(txtID, "Ingrese un ID para la categoria");
                }
                if (cmbRol.SelectedIndex == -1)
                {
                    errored = true;
                    errorProvider1.SetError(cmbRol, "Seleccione un rol.");
                }
                if (txtEmail.Text == string.Empty)
                {
                    errored = true;
                    errorProvider1.SetError(txtEmail, "Ingrese su correo.");
                }
                if (txtClave.Text == string.Empty)
                {
                    errored = true;
                    errorProvider1.SetError(txtClave, "Ingrese una clave.");
                }
                if (cmbTipos.SelectedIndex == -1)
                {
                    errored = true;
                    errorProvider1.SetError(cmbTipos, "Seleccione un tipo de documento.");
                }
                if (txtDocumento.Text  == string.Empty)
                {
                    errored = true;
                    errorProvider1.SetError(txtDocumento, "Inserte su documento.");
                }
                MessageBox.Show("Made it through the wall of checks.");

                if (errored)
                {
                    MensajeError("Favor introducir los datos indicados.");
                    return;
                }

                respuesta = NUsuarios.Insertar(txtNombre.Text, cmbRol.SelectedIndex+1, txtEmail.Text, txtClave.Text, cmbTipos.Text, txtDocumento.Text, txtTelefono.Text, txtDireccion.Text);
                if (respuesta.Equals("OK"))
                {
                    MensajeOK("Se inserto la categoria correctamente.");
                    Limpiar();
                    Listar();
                } else
                {
                    MensajeError(respuesta);
                }
            }
            catch (Exception ex)
            {
                DevMSG(ex);
            }
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Limpiar();
                btnActualizar.Visible = true;
                btnInsertar.Visible = false;
                DataGridViewCellCollection row = dgvListado.CurrentRow.Cells;
                txtNombre.Text = row["Nombre"].Value.ToString();
                cmbRol.Text = row["Rol"].Value.ToString();
                cmbTipos.Text = row["tipo_documento"].Value.ToString();
                txtDocumento.Text = row["num_documento"].Value.ToString();
                txtDireccion.Text = row["Direccion"].Value.ToString();
                txtTelefono.Text = row["Telefono"].Value.ToString();
                txtEmail.Text = row["Email"].Value.ToString();

                tabGeneral.SelectedIndex = 1;
                nombreAnterior = txtNombre.Text;
            }
            catch (Exception ex)
            {
                DevMSG(ex);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";

                bool executed = false;
                if (txtNombre.Text == string.Empty)
                {
                    MensajeError("Ingrese los datos indicados.");
                    executed = true;
                    errorProvider1.SetError(txtNombre, "Falta el nombre.");
                }
                if (txtDocumento.Text == string.Empty)
                {
                    if (!executed)
                    {
                        MensajeError("Ingrese los datos indicados.");
                        executed = true;
                    }
                    errorProvider1.SetError(txtDocumento, "Falta el ID.");
                }
                if (executed) return;

                respuesta = NUsuarios.Actualizar(int.Parse(dgvListado.CurrentRow.Cells["ID"].Value.ToString()), nombreAnterior, txtNombre.Text, int.Parse(dgvListado.CurrentRow.Cells["idrol"].Value.ToString()), txtEmail.Text, txtClave.Text, cmbTipos.Text, txtDocumento.Text, txtTelefono.Text, txtDireccion.Text);
                if (respuesta == "OK")
                {
                    MensajeOK("La categoria se actualizo correctamente.");
                    Limpiar();
                    Listar();
                }
                else
                {
                    MessageBox.Show($"Received message: {respuesta}");
                }

            }
            catch (Exception ex)
            {
                DevMSG(ex);
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Listar();
            txtNombre.Clear();
            txtDocumento.Clear();
            txtDireccion.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            tabGeneral.SelectedIndex = 0;

        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            bool state = chkSeleccionar.Checked;
            dgvListado.Columns[0].Visible = state;
            btnEliminar.Visible = state;
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvListado.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell chk = dgvListado.Rows[e.RowIndex].Cells["Seleccionar"] as DataGridViewCheckBoxCell;
                chk.Value = !Convert.ToBoolean(chk.Value);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("Desea eliminar las categorias seleccionadas?", "Eliminar Categorias", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.OK)
                {
                    int codigo;
                    string respuesta = "";
                    bool errored = false;

                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells["ID"].Value);
                            respuesta = NCategorias.Eliminar(codigo);
                            if (respuesta != "OK")
                            {
                                errored = true;
                                this.MensajeError(respuesta + "\n\nAffected Row: " + row.Cells["Descripcion"]);
                            }
                        }
                    }
                    if (!errored)
                    {
                        MensajeOK("Las categorias fueron eliminadas exitosamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                DevMSG(ex);
            }
            this.Listar();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private int getRoleID()
        {
            return 0;
        }

    }
}
