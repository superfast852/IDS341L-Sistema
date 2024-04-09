using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using Sistema.Negocios;

namespace Sistema.Presentacion
{
    public partial class frmArticulo : Form
    {
        string nombreAnterior;
        DataTable categorias;
        Dictionary<string, int> idRegistry;

        public frmArticulo()
        {
            InitializeComponent();
            Limpiar();
            idRegistry = new Dictionary<string, int>();
        }

        private void Buscar()
        {
            dgvListado.DataSource = NArticulos.Buscar(txtBuscar.Text);
            this.Formato();
            this.Limpiar();
            lblTotal.Text = $"Total de Registros: {dgvListado.Rows.Count}";
        }

        private void Listar()
        {
            try
            {
                dgvListado.DataSource = NArticulos.Listar();
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
            //dgvListado.Columns[3].HeaderText = "Categoria";
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
            txtUPC.Clear();
            txtVenta.Clear();
            txtStock.Clear();
            txtImagen.Clear();
        }

        private void frmArticulo_Load(object sender, EventArgs e)
        {
            this.Listar();
            //nombresCategorias = GetCategories();
            cmbCategoria.DataSource = GetCategories();
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

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Limpiar();
                btnActualizar.Visible = true;
                btnInsertar.Visible = false;
                DataGridViewCellCollection row = dgvListado.CurrentRow.Cells;
                txtID.Text = row["ID"].Value.ToString();
                txtNombre.Text = row["Nombre"].Value.ToString();
                txtDescripcion.Text = row["Descripcion"].Value.ToString();
                //GetCategories();
                //cmbCategoria.Text = idRegistry.FirstOrDefault(x => x.Value == Convert.ToInt32(row["idcategoria"].Value)).Key;
                cmbCategoria.Text = row["Categoria"].Value.ToString();
                txtUPC.Text = row["Codigo"].Value.ToString();
                txtImagen.Text = row["Imagen"].Value.ToString();
                txtVenta.Text = row["Precio_Venta"].Value.ToString();
                txtStock.Text = row["Stock"].Value.ToString();
                

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
                if (txtID.Text == string.Empty)
                {
                    if (!executed)
                    {
                        MensajeError("Ingrese los datos indicados.");
                        executed = true;
                    }
                    errorProvider1.SetError(txtID, "Falta el ID.");
                }
                if(txtVenta.Text == string.Empty)
                {
                    if (!executed)
                    {
                        MensajeError("Ingrese los datos indicados.");
                        executed = true;
                    }
                    errorProvider1.SetError(txtVenta, "Falta el Precio de venta.");
                }
                if (executed) return;

                respuesta = NArticulos.Actualizar(int.Parse(txtID.Text), nombreAnterior, txtNombre.Text, txtDescripcion.Text, idRegistry[cmbCategoria.Text], txtUPC.Text, Convert.ToDouble(txtVenta.Text), Convert.ToInt32(txtStock.Text), txtImagen.Text);
                if (respuesta == "OK")
                {
                    MensajeOK("La categoria se actualizo correctamente.");
                    Limpiar();
                    Listar();
                    tabGeneral.SelectedIndex = 0;
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

        private void btnInsertar_Click(object sender, EventArgs e)
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
                if (txtVenta.Text == string.Empty)
                {
                    if (!executed)
                    {
                        MensajeError("Ingrese los datos indicados.");
                        executed = true;
                    }
                    errorProvider1.SetError(txtVenta, "Falta el Precio de venta.");
                }
                if (executed) return;

                respuesta = NArticulos.Insertar(txtNombre.Text, txtDescripcion.Text, idRegistry[cmbCategoria.Text], txtUPC.Text, Convert.ToDouble(txtVenta.Text), Convert.ToInt32(txtStock.Text), txtImagen.Text);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            this.Listar();
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
            if (e.ColumnIndex == dgvListado.Columns["Seleccionar"].Index)
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

                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells["ID"].Value);
                            respuesta = NArticulos.Activar(codigo);
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
                            respuesta = NArticulos.Desactivar(codigo);
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
                            respuesta = NArticulos.Eliminar(codigo);
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

        // This seems dumb. The only way to update the list of categories is with the other tab.
        private string[] GetCategories()
        {
            this.categorias = NCategorias.Listar();
            string[] names = new string[categorias.Rows.Count];

            int i = 0;
            foreach (DataRow row in categorias.Rows)
            {
                names[i] = row["Nombre"].ToString();
                if (!idRegistry.ContainsKey(names[i]))
                {
                    idRegistry.Add(names[i], Convert.ToInt32(row["ID"]));
                }
                i++;
            }
            foreach (string category in idRegistry.Keys)
            {
                if (!names.Contains(category))
                {
                    idRegistry.Remove(category);
                }
            }
            return names;
        }

        private void btnDir_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                MessageBox.Show(openFileDialog1.FileName);
                txtImagen.Text = openFileDialog1.FileName;
                pbxImagen.ImageLocation = openFileDialog1.FileName;
                pbxImagen.Refresh();
            }
            
        }
    }
}
