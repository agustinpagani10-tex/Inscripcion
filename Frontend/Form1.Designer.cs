namespace Inscripcion_Partido
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblEquipo;
        private System.Windows.Forms.TextBox txtEquipo;
        private System.Windows.Forms.Label lblJugador;
        private System.Windows.Forms.TextBox txtJugador;
        private System.Windows.Forms.Label lblPuesto;
        private System.Windows.Forms.ComboBox cmbPuesto;
        private System.Windows.Forms.Label lblCamiseta;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.CheckBox chkLesionado;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnDesactivar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnListarTodos;
        private System.Windows.Forms.Button btnListarActivos;
        private System.Windows.Forms.DataGridView dgvJugadores;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblEquipo = new System.Windows.Forms.Label();
            this.txtEquipo = new System.Windows.Forms.TextBox();
            this.lblJugador = new System.Windows.Forms.Label();
            this.txtJugador = new System.Windows.Forms.TextBox();
            this.lblPuesto = new System.Windows.Forms.Label();
            this.cmbPuesto = new System.Windows.Forms.ComboBox();
            this.lblCamiseta = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.chkLesionado = new System.Windows.Forms.CheckBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnDesactivar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnListarTodos = new System.Windows.Forms.Button();
            this.btnListarActivos = new System.Windows.Forms.Button();
            this.dgvJugadores = new System.Windows.Forms.DataGridView();
            this.txtNumeroCamiseta = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJugadores)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEquipo
            // 
            this.lblEquipo.AutoSize = true;
            this.lblEquipo.Location = new System.Drawing.Point(30, 61);
            this.lblEquipo.Name = "lblEquipo";
            this.lblEquipo.Size = new System.Drawing.Size(121, 20);
            this.lblEquipo.TabIndex = 0;
            this.lblEquipo.Text = "Nombre equipo:";
            // 
            // txtEquipo
            // 
            this.txtEquipo.Location = new System.Drawing.Point(157, 55);
            this.txtEquipo.Name = "txtEquipo";
            this.txtEquipo.Size = new System.Drawing.Size(258, 26);
            this.txtEquipo.TabIndex = 1;
            // 
            // lblJugador
            // 
            this.lblJugador.AutoSize = true;
            this.lblJugador.Location = new System.Drawing.Point(30, 97);
            this.lblJugador.Name = "lblJugador";
            this.lblJugador.Size = new System.Drawing.Size(126, 20);
            this.lblJugador.TabIndex = 2;
            this.lblJugador.Text = "Nombre jugador:";
            // 
            // txtJugador
            // 
            this.txtJugador.Location = new System.Drawing.Point(157, 87);
            this.txtJugador.Name = "txtJugador";
            this.txtJugador.Size = new System.Drawing.Size(258, 26);
            this.txtJugador.TabIndex = 3;
            // 
            // lblPuesto
            // 
            this.lblPuesto.AutoSize = true;
            this.lblPuesto.Location = new System.Drawing.Point(30, 136);
            this.lblPuesto.Name = "lblPuesto";
            this.lblPuesto.Size = new System.Drawing.Size(63, 20);
            this.lblPuesto.TabIndex = 4;
            this.lblPuesto.Text = "Puesto:";
            // 
            // cmbPuesto
            // 
            this.cmbPuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPuesto.Location = new System.Drawing.Point(131, 124);
            this.cmbPuesto.Name = "cmbPuesto";
            this.cmbPuesto.Size = new System.Drawing.Size(116, 28);
            this.cmbPuesto.TabIndex = 5;
            // 
            // lblCamiseta
            // 
            this.lblCamiseta.AutoSize = true;
            this.lblCamiseta.Location = new System.Drawing.Point(265, 130);
            this.lblCamiseta.Name = "lblCamiseta";
            this.lblCamiseta.Size = new System.Drawing.Size(98, 20);
            this.lblCamiseta.TabIndex = 6;
            this.lblCamiseta.Text = "Nº camiseta:";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(485, 131);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(64, 20);
            this.lblEstado.TabIndex = 8;
            this.lblEstado.Text = "Estado:";
            // 
            // cmbRol
            // 
            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.Location = new System.Drawing.Point(551, 124);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(119, 28);
            this.cmbRol.TabIndex = 9;
            // 
            // chkLesionado
            // 
            this.chkLesionado.AutoSize = true;
            this.chkLesionado.Location = new System.Drawing.Point(686, 127);
            this.chkLesionado.Name = "chkLesionado";
            this.chkLesionado.Size = new System.Drawing.Size(109, 24);
            this.chkLesionado.TabIndex = 10;
            this.chkLesionado.Text = "Lesionado";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(131, 176);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(74, 32);
            this.btnAgregar.TabIndex = 11;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.AgregarJugador);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(193, 176);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(118, 32);
            this.btnActualizar.TabIndex = 12;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.ActualizarJugador);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(328, 176);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(73, 32);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.EliminarJugador);
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.Location = new System.Drawing.Point(424, 176);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(125, 32);
            this.btnDesactivar.TabIndex = 14;
            this.btnDesactivar.Text = "Desactivar";
            this.btnDesactivar.Click += new System.EventHandler(this.DesactivarJugador);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(584, 176);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(73, 32);
            this.btnLimpiar.TabIndex = 15;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.LimpiarFormulario);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(32, 235);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(63, 20);
            this.lblBuscar.TabIndex = 16;
            this.lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(98, 219);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(248, 26);
            this.txtBuscar.TabIndex = 17;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(370, 216);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(73, 32);
            this.btnBuscar.TabIndex = 18;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.BuscarJugador);
            // 
            // btnListarTodos
            // 
            this.btnListarTodos.Location = new System.Drawing.Point(455, 216);
            this.btnListarTodos.Name = "btnListarTodos";
            this.btnListarTodos.Size = new System.Drawing.Size(110, 32);
            this.btnListarTodos.TabIndex = 19;
            this.btnListarTodos.Text = "Listar todos";
            this.btnListarTodos.Click += new System.EventHandler(this.ListarTodos);
            // 
            // btnListarActivos
            // 
            this.btnListarActivos.Location = new System.Drawing.Point(580, 216);
            this.btnListarActivos.Name = "btnListarActivos";
            this.btnListarActivos.Size = new System.Drawing.Size(125, 32);
            this.btnListarActivos.TabIndex = 20;
            this.btnListarActivos.Text = "Listar activos";
            this.btnListarActivos.Click += new System.EventHandler(this.ListarActivos);
            // 
            // dgvJugadores
            // 
            this.dgvJugadores.AllowUserToAddRows = false;
            this.dgvJugadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJugadores.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvJugadores.ColumnHeadersHeight = 34;
            this.dgvJugadores.ColumnHeadersVisible = false;
            this.dgvJugadores.Location = new System.Drawing.Point(30, 272);
            this.dgvJugadores.MultiSelect = false;
            this.dgvJugadores.Name = "dgvJugadores";
            this.dgvJugadores.ReadOnly = true;
            this.dgvJugadores.RowHeadersVisible = false;
            this.dgvJugadores.RowHeadersWidth = 62;
            this.dgvJugadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJugadores.Size = new System.Drawing.Size(917, 359);
            this.dgvJugadores.TabIndex = 21;
            this.dgvJugadores.SelectionChanged += new System.EventHandler(this.SeleccionarJugador);
            // 
            // txtNumeroCamiseta
            // 
            this.txtNumeroCamiseta.Location = new System.Drawing.Point(384, 127);
            this.txtNumeroCamiseta.Name = "txtNumeroCamiseta";
            this.txtNumeroCamiseta.Size = new System.Drawing.Size(83, 26);
            this.txtNumeroCamiseta.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1008, 650);
            this.Controls.Add(this.txtNumeroCamiseta);
            this.Controls.Add(this.lblEquipo);
            this.Controls.Add(this.txtEquipo);
            this.Controls.Add(this.lblJugador);
            this.Controls.Add(this.txtJugador);
            this.Controls.Add(this.lblPuesto);
            this.Controls.Add(this.cmbPuesto);
            this.Controls.Add(this.lblCamiseta);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.chkLesionado);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnDesactivar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnListarTodos);
            this.Controls.Add(this.btnListarActivos);
            this.Controls.Add(this.dgvJugadores);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inscripción de equipo de fútbol";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJugadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtNumeroCamiseta;
    }
}
