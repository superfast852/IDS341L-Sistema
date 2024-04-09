using System;
using System.Web;
using System.Windows.Forms;
using Sistema.Negocios;

namespace Sistema.Presentacion
{
    public partial class frmCategoria : Form
    {
        string nombreAnterior;

        public frmCategoria()
        {
            InitializeComponent();
            Limpiar();
        }

        private void Buscar()
        {
            dgvListado.DataSource = NCategorias.Buscar(txtBuscar.Text);
            this.Formato();
            this.Limpiar();
            lblTotal.Text = $"Total de Registros: {dgvListado.Rows.Count}";
        }

        private void Listar()
        {
            try
            {
                dgvListado.DataSource = NCategorias.Listar();
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
            dgvListado.Columns[2].Width = 150;
            dgvListado.Columns[3].Width = 300;
            dgvListado.Columns[3].HeaderText = "Descripcion";
            dgvListado.Columns[4].Width = 100;
        }

        private void Limpiar()
        {
            txtBuscar.Clear();
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
            btnEliminar.Visible = false;
            dgvListado.Columns[0].Visible = false;

            btnActualizar.Visible = false;
            btnInsertar.Visible = true;
            txtID.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
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
                if(txtNombre.Text == string.Empty)
                {
                    MensajeError("Favor introducir los datos indicados.");
                    errorProvider1.SetError(txtNombre, "Ingrese un nombre para la categoria");
                    //errorProvider1.SetError(txtID, "Ingrese un ID para la categoria");
                    return;
                }
                respuesta = NCategorias.Insertar(txtNombre.Text, txtDescripcion.Text);
                if (respuesta.Equals("OK"))
                {
                    MensajeOK("Se inserto la categoria correctamente.");
                    Limpiar();
                    Listar();
                }
            } catch (Exception ex)
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
                txtID.Text = dgvListado.CurrentRow.Cells["ID"].Value.ToString();
                txtNombre.Text = dgvListado.CurrentRow.Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = dgvListado.CurrentRow.Cells["Descripcion"].Value.ToString();

                tabGeneral.SelectedIndex = 1;
                nombreAnterior = txtNombre.Text;
            } catch (Exception ex)
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
                if(txtNombre.Text == string.Empty)
                {
                    MensajeError("Ingrese los datos indicados.");
                    executed = true;
                    errorProvider1.SetError(txtNombre, "Falta el nombre.");
                }
                if (txtID.Text == string.Empty)
                {
                    if (!executed)
                    {
                        MensajeError("Ingrese los datos indicados.");
                        executed = true;
                    }
                    errorProvider1.SetError(txtID, "Falta el ID.");
                }
                if (executed) return;
                
                respuesta = NCategorias.Actualizar(int.Parse(txtID.Text), nombreAnterior, txtNombre.Text, txtDescripcion.Text);
                if (respuesta == "OK")
                {
                    MensajeOK("La categoria se actualizo correctamente.");
                    Limpiar();
                    Listar();
                } else
                {
                    MessageBox.Show($"Received message: {respuesta}");
                }

            } catch (Exception ex)
            {
                DevMSG(ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Listar();
            txtNombre.Clear();
            txtID.Clear();
            txtDescripcion.Clear();
            tabGeneral.SelectedIndex = 0;

        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            bool state = chkSeleccionar.Checked;
            dgvListado.Columns[0].Visible = state;
            btnActivar.Visible = state;
            btnDesactivar.Visible = state;
            btnEliminar.Visible = state;
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dgvListado.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell chk = dgvListado.Rows[e.RowIndex].Cells["Seleccionar"] as DataGridViewCheckBoxCell;
                chk.Value = !Convert.ToBoolean(chk.Value);
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("Desea activar las categorias seleccionadas?", "Activar Categorias", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.OK)
                {
                    int codigo;
                    string respuesta = "";
                    bool errored = false;

                    foreach(DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells["ID"].Value);
                            respuesta = NCategorias.Activar(codigo);
                            if (respuesta != "OK")
                            {
                                errored = true;
                                this.MensajeError(respuesta + "\n\nAffected Row: " + row.Cells["Descripcion"]);
                            }
                        }
                    }
                    if (!errored)
                    {
                        MensajeOK("Las categorias fueron modificadas exitosamente.");
                    }
                }
            } catch (Exception ex)
            {
                DevMSG(ex);
            }
            this.Listar();
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("Desea desactivar las categorias seleccionadas?", "Desactivar Categorias", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
                            respuesta = NCategorias.Desactivar(codigo);
                            if (respuesta != "OK")
                            {
                                errored = true;
                                this.MensajeError(respuesta + "\n\nAffected Row: " + row.Cells["Descripcion"]);
                            }
                        }
                    }
                    if (!errored)
                    {
                        MensajeOK("Las categorias fueron modificadas exitosamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                DevMSG(ex);
            }
            this.Listar();
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
    }
}
