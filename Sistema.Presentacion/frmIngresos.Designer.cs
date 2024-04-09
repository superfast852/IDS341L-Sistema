namespace Sistema.Presentacion
{
    partial class frmIngresos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabGeneral = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnAnular = new System.Windows.Forms.Button();
            this.chkSeleccionar = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCompNum = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTipoComp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCompSerie = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProvA = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtImp = new System.Windows.Forms.TextBox();
            this.txtProvB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscarProv = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtArticulo = new System.Windows.Forms.TextBox();
            this.btnBuscarArticulo = new System.Windows.Forms.Button();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.txtSub = new System.Windows.Forms.TextBox();
            this.txtImpTotal = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabGeneral.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.tabPage1);
            this.tabGeneral.Controls.Add(this.tabPage2);
            this.tabGeneral.Location = new System.Drawing.Point(16, 15);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.SelectedIndex = 0;
            this.tabGeneral.Size = new System.Drawing.Size(911, 582);
            this.tabGeneral.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblTotal);
            this.tabPage1.Controls.Add(this.btnAnular);
            this.tabPage1.Controls.Add(this.chkSeleccionar);
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Controls.Add(this.txtBuscar);
            this.tabPage1.Controls.Add(this.dgvListado);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(903, 553);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(653, 399);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(44, 16);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "Total: ";
            // 
            // btnAnular
            // 
            this.btnAnular.Location = new System.Drawing.Point(317, 386);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(133, 43);
            this.btnAnular.TabIndex = 6;
            this.btnAnular.Text = "Anular";
            this.btnAnular.UseVisualStyleBackColor = true;
            // 
            // chkSeleccionar
            // 
            this.chkSeleccionar.AutoSize = true;
            this.chkSeleccionar.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkSeleccionar.Location = new System.Drawing.Point(6, 398);
            this.chkSeleccionar.Name = "chkSeleccionar";
            this.chkSeleccionar.Size = new System.Drawing.Size(101, 20);
            this.chkSeleccionar.TabIndex = 3;
            this.chkSeleccionar.Text = "Seleccionar";
            this.chkSeleccionar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(645, 18);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(205, 47);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(28, 34);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(592, 22);
            this.txtBuscar.TabIndex = 1;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToOrderColumns = true;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.dgvListado.Location = new System.Drawing.Point(6, 71);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersWidth = 51;
            this.dgvListado.RowTemplate.Height = 24;
            this.dgvListado.Size = new System.Drawing.Size(891, 309);
            this.dgvListado.TabIndex = 0;
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.MinimumWidth = 6;
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            this.Seleccionar.Width = 125;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.btnCancelar);
            this.tabPage2.Controls.Add(this.btnInsertar);
            this.tabPage2.Controls.Add(this.btnActualizar);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(903, 553);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBuscarProv);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtCompNum);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtImp);
            this.groupBox1.Controls.Add(this.txtProvA);
            this.groupBox1.Controls.Add(this.cmbTipoComp);
            this.groupBox1.Controls.Add(this.txtCompSerie);
            this.groupBox1.Controls.Add(this.txtProvB);
            this.groupBox1.Location = new System.Drawing.Point(17, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(862, 138);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cabecera";
            // 
            // txtCompNum
            // 
            this.txtCompNum.Location = new System.Drawing.Point(437, 80);
            this.txtCompNum.Name = "txtCompNum";
            this.txtCompNum.Size = new System.Drawing.Size(145, 22);
            this.txtCompNum.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 16);
            this.label8.TabIndex = 25;
            this.label8.Text = "Proveedor(*)";
            // 
            // cmbTipoComp
            // 
            this.cmbTipoComp.FormattingEnabled = true;
            this.cmbTipoComp.Items.AddRange(new object[] {
            "Administrador",
            "Vendedor",
            "Almacen"});
            this.cmbTipoComp.Location = new System.Drawing.Point(146, 80);
            this.cmbTipoComp.Name = "cmbTipoComp";
            this.cmbTipoComp.Size = new System.Drawing.Size(140, 24);
            this.cmbTipoComp.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Comprobante(*)";
            // 
            // txtCompSerie
            // 
            this.txtCompSerie.Location = new System.Drawing.Point(299, 80);
            this.txtCompSerie.Name = "txtCompSerie";
            this.txtCompSerie.Size = new System.Drawing.Size(132, 22);
            this.txtCompSerie.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(654, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Impuesto(*)";
            // 
            // txtProvA
            // 
            this.txtProvA.Location = new System.Drawing.Point(146, 30);
            this.txtProvA.Name = "txtProvA";
            this.txtProvA.ReadOnly = true;
            this.txtProvA.Size = new System.Drawing.Size(140, 22);
            this.txtProvA.TabIndex = 14;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(308, 517);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(140, 30);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(163, 517);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(140, 30);
            this.btnInsertar.TabIndex = 12;
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(17, 517);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(140, 30);
            this.btnActualizar.TabIndex = 11;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(321, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Serie";
            // 
            // txtImp
            // 
            this.txtImp.Location = new System.Drawing.Point(745, 85);
            this.txtImp.Name = "txtImp";
            this.txtImp.Size = new System.Drawing.Size(97, 22);
            this.txtImp.TabIndex = 5;
            // 
            // txtProvB
            // 
            this.txtProvB.Location = new System.Drawing.Point(299, 30);
            this.txtProvB.Name = "txtProvB";
            this.txtProvB.ReadOnly = true;
            this.txtProvB.Size = new System.Drawing.Size(283, 22);
            this.txtProvB.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 485);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(279, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Los campos con asterisco(*) son obligatorios.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(452, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero";
            // 
            // txtBuscarProv
            // 
            this.txtBuscarProv.Location = new System.Drawing.Point(588, 27);
            this.txtBuscarProv.Name = "txtBuscarProv";
            this.txtBuscarProv.Size = new System.Drawing.Size(76, 28);
            this.txtBuscarProv.TabIndex = 27;
            this.txtBuscarProv.Text = "Buscar";
            this.txtBuscarProv.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtTotal);
            this.groupBox2.Controls.Add(this.txtImpTotal);
            this.groupBox2.Controls.Add(this.txtSub);
            this.groupBox2.Controls.Add(this.dgvDetalle);
            this.groupBox2.Controls.Add(this.btnBuscarArticulo);
            this.groupBox2.Controls.Add(this.txtArticulo);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(17, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(862, 318);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalle";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Articulo";
            // 
            // txtArticulo
            // 
            this.txtArticulo.Location = new System.Drawing.Point(63, 32);
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Size = new System.Drawing.Size(468, 22);
            this.txtArticulo.TabIndex = 1;
            // 
            // btnBuscarArticulo
            // 
            this.btnBuscarArticulo.Location = new System.Drawing.Point(544, 32);
            this.btnBuscarArticulo.Name = "btnBuscarArticulo";
            this.btnBuscarArticulo.Size = new System.Drawing.Size(85, 23);
            this.btnBuscarArticulo.TabIndex = 2;
            this.btnBuscarArticulo.Text = "Buscar";
            this.btnBuscarArticulo.UseVisualStyleBackColor = true;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(6, 74);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.RowHeadersWidth = 51;
            this.dgvDetalle.RowTemplate.Height = 24;
            this.dgvDetalle.Size = new System.Drawing.Size(623, 227);
            this.dgvDetalle.TabIndex = 3;
            // 
            // txtSub
            // 
            this.txtSub.Location = new System.Drawing.Point(756, 106);
            this.txtSub.Name = "txtSub";
            this.txtSub.ReadOnly = true;
            this.txtSub.Size = new System.Drawing.Size(100, 22);
            this.txtSub.TabIndex = 4;
            // 
            // txtImpTotal
            // 
            this.txtImpTotal.Location = new System.Drawing.Point(756, 151);
            this.txtImpTotal.Name = "txtImpTotal";
            this.txtImpTotal.ReadOnly = true;
            this.txtImpTotal.Size = new System.Drawing.Size(100, 22);
            this.txtImpTotal.TabIndex = 5;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(756, 199);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 22);
            this.txtTotal.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(654, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Subtotal";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(654, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "Impuestos";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(654, 202);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 16);
            this.label10.TabIndex = 9;
            this.label10.Text = "Total";
            // 
            // frmIngresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 603);
            this.Controls.Add(this.tabGeneral);
            this.Name = "frmIngresos";
            this.Text = "Ingresos";
            this.tabGeneral.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabGeneral;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.CheckBox chkSeleccionar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCompNum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbTipoComp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCompSerie;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProvA;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtImp;
        private System.Windows.Forms.TextBox txtProvB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button txtBuscarProv;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtImpTotal;
        private System.Windows.Forms.TextBox txtSub;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Button btnBuscarArticulo;
        private System.Windows.Forms.TextBox txtArticulo;
        private System.Windows.Forms.Label label6;
    }
}