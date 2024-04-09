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
    public partial class frmProveedores : Form
    {
        string nombreAnterior;
        public frmProveedores()
        {
            InitializeComponent();
            Listar();
            Limpiar();
        }

        private void Buscar()
        {
            dgvListado.DataSource = NPersona.BuscarProveedores(txtBuscar.Text);
            this.Formato();
            this.Limpiar();
            lblTotal.Text = $"Total de Registros: {dgvListado.Rows.Count}";
        }

        private void Listar()
        {
            try
            {
                dgvListado.DataSource = NPersona.ListarProveedores();
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

            dgvListado.Columns[4].Width = 150;
            dgvListado.Columns[5].Width = 200;
            dgvListado.Columns[6].Width = 300;
            dgvListado.Columns[8].Width = 200;

            dgvListado.Columns[4].HeaderText = "Tipo de Documento";
            dgvListado.Columns[5].HeaderText = "Documento";
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

            tabGeneral.SelectedIndex = 0;
            cmbTipos.SelectedIndex = -1;
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

        // TODO: Add the proper checks.
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                bool executed = false;
                if (txtNombre.Text == string.Empty)
                {
                    executed = true;
                    errorProvider1.SetError(txtNombre, "Inserte su nombre.");
                }
                if (txtDocumento.Text == string.Empty)
                {
                    executed = true;
                    errorProvider1.SetError(txtDocumento, "Inserte su documento.");
                }
                if (cmbTipos.SelectedIndex == -1)
                {
                    executed = true;
                    errorProvider1.SetError(cmbTipos, "Seleccione un tipo de documento.");
                }
                if (executed)
                {
                    MensajeError("Ingrese los datos indicados.");
                    return;
                }
                respuesta = NPersona.Insertar("Proveedor", txtNombre.Text, cmbTipos.Text, txtDocumento.Text, txtDireccion.Text, txtTelefono.Text, txtEmail.Text);
                if (respuesta.Equals("OK"))
                {
                    MensajeOK("Se inserto la categoria correctamente.");
                    Limpiar();
                    Listar();
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
                    executed = true;
                    errorProvider1.SetError(txtNombre, "Inserte su nombre.");
                }
                if (txtDocumento.Text == string.Empty)
                {
                    executed = true;
                    errorProvider1.SetError(txtDocumento, "Inserte su documento.");
                }
                if (cmbTipos.SelectedIndex == -1)
                {
                    executed = true;
                    errorProvider1.SetError(cmbTipos, "Seleccione un tipo de documento.");
                }
                if (executed)
                {
                    MensajeError("Ingrese los datos indicados.");
                    return;
                }

                respuesta = NPersona.Actualizar(getUserID(nombreAnterior), "Proveedor", nombreAnterior, txtNombre.Text, cmbTipos.Text, txtDocumento.Text, txtDireccion.Text, txtTelefono.Text, txtEmail.Text);
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
                            respuesta = NPersona.Eliminar(codigo);
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

        private int getUserID(string name)
        {
            return int.Parse(dgvListado.CurrentRow.Cells["ID"].Value.ToString());
        }

    }
}
