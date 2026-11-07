using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Inscripcion.Backend;

namespace Inscripcion_Partido
{
    public partial class Form1 : Form
    {
        private readonly Jugadores jugadores = new Jugadores();
        private TextBox txtEquipo;
        private TextBox txtJugador;
        private ComboBox cmbPuesto;
        private ComboBox cmbRol;
        private NumericUpDown nudCamiseta;
        private CheckBox chkLesionado;
        private DataGridView dgvJugadores;
        private Label lblSeleccionado;

        public Form1()
        {
            InitializeComponent();
            if (!EstaEnModoDiseno())
            {
                CrearInterfaz();
            }
        }

        private bool EstaEnModoDiseno()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime
                || (Site != null && Site.DesignMode);
        }

        private void CrearInterfaz()
        {
            Text = "Inscripción de equipo de fútbol";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1080, 650);
            MinimumSize = new Size(900, 600);

            Label titulo = new Label { Text = "Inscripción de equipo", Font = new Font("Segoe UI", 16, FontStyle.Bold), AutoSize = true, Location = new Point(20, 15) };
            Controls.Add(titulo);

            Controls.Add(CrearEtiqueta("Nombre equipo:", 20, 65));
            txtEquipo = new TextBox { Name = "txtEquipo", Location = new Point(130, 62), Width = 250 };
            Controls.Add(txtEquipo);

            Controls.Add(CrearEtiqueta("Nombre jugador:", 20, 105));
            txtJugador = new TextBox { Name = "txtJugador", Location = new Point(130, 102), Width = 250 };
            Controls.Add(txtJugador);

            Controls.Add(CrearEtiqueta("Puesto:", 20, 145));
            cmbPuesto = new ComboBox { Name = "cmbPuesto", Location = new Point(130, 142), Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbPuesto.DataSource = new[] { "Arquero", "Defensor", "Mediocampo", "Delantero" };
            Controls.Add(cmbPuesto);

            Controls.Add(CrearEtiqueta("Camiseta:", 20, 185));
            nudCamiseta = new NumericUpDown { Name = "nudCamiseta", Location = new Point(130, 182), Width = 80, Minimum = 1, Maximum = 99, Value = 1 };
            Controls.Add(nudCamiseta);

            Controls.Add(CrearEtiqueta("Rol:", 230, 185));
            cmbRol = new ComboBox { Name = "cmbRol", Location = new Point(275, 182), Width = 105, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbRol.DataSource = new[] { "Titular", "Suplente" };
            Controls.Add(cmbRol);

            chkLesionado = new CheckBox { Name = "chkLesionado", Text = "Lesionado", Location = new Point(130, 220), AutoSize = true };
            Controls.Add(chkLesionado);

            Button btnAgregar = CrearBoton("Agregar", 420, 62, AgregarJugador);
            Button btnActualizar = CrearBoton("Actualizar", 510, 62, ActualizarJugador);
            Button btnEliminar = CrearBoton("Eliminar", 610, 62, EliminarJugador);
            Button btnDesactivar = CrearBoton("Desactivar jugador", 700, 62, DesactivarJugador);
            Button btnBuscar = CrearBoton("Buscar", 420, 105, BuscarJugador);
            Button btnLimpiar = CrearBoton("Limpiar", 510, 105, LimpiarFormulario);
            Button btnTodos = CrearBoton("Listar todos", 610, 105, delegate { CargarTabla(jugadores.ListarTodos()); });
            Button btnActivos = CrearBoton("Listar activos", 700, 105, delegate { CargarTabla(jugadores.ListarActivos()); });
            Controls.AddRange(new Control[] { btnAgregar, btnActualizar, btnEliminar, btnDesactivar, btnBuscar, btnLimpiar, btnTodos, btnActivos });

            lblSeleccionado = new Label { Text = "Ningún jugador seleccionado", AutoSize = true, Location = new Point(20, 255), ForeColor = Color.DarkBlue };
            Controls.Add(lblSeleccionado);

            dgvJugadores = new DataGridView { Name = "dgvJugadores", Location = new Point(20, 285), Size = new Size(1035, 335), ReadOnly = true, AllowUserToAddRows = false, MultiSelect = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoGenerateColumns = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            dgvJugadores.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Id", DataPropertyName = "Id", Visible = false });
            dgvJugadores.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Equipo", DataPropertyName = "NombreEquipo" });
            dgvJugadores.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Jugador", DataPropertyName = "Nombre" });
            dgvJugadores.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Puesto", DataPropertyName = "Puesto" });
            dgvJugadores.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Camiseta", DataPropertyName = "NumeroCamiseta" });
            dgvJugadores.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Rol", DataPropertyName = "Rol" });
            dgvJugadores.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "Lesionado", DataPropertyName = "Lesionado" });
            dgvJugadores.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "Activo", DataPropertyName = "Activo" });
            dgvJugadores.SelectionChanged += SeleccionarJugador;
            Controls.Add(dgvJugadores);
            CargarTabla(jugadores.ListarTodos());
        }

        private Label CrearEtiqueta(string texto, int x, int y)
        {
            return new Label { Text = texto, AutoSize = true, Location = new Point(x, y + 3) };
        }

        private Button CrearBoton(string texto, int x, int y, EventHandler evento)
        {
            Button boton = new Button { Text = texto, Location = new Point(x, y), Size = new Size(125, 32) };
            boton.Click += evento;
            return boton;
        }

        private Jugador ObtenerDatos()
        {
            PuestoJugador puesto = (PuestoJugador)cmbPuesto.SelectedIndex;
            RolJugador rol = (RolJugador)cmbRol.SelectedIndex;
            return new Jugador
            {
                NombreEquipo = txtEquipo.Text,
                Nombre = txtJugador.Text,
                Puesto = puesto,
                NumeroCamiseta = (int)nudCamiseta.Value,
                Rol = rol,
                Lesionado = chkLesionado.Checked
            };
        }

        private int IdSeleccionado()
        {
            if (dgvJugadores.CurrentRow == null || dgvJugadores.CurrentRow.Cells[0].Value == null)
            {
                throw new InvalidOperationException("Seleccione un jugador de la lista.");
            }

            return (int)dgvJugadores.CurrentRow.Cells[0].Value;
        }

        private void AgregarJugador(object sender, EventArgs e)
        {
            Ejecutar(delegate { jugadores.Agregar(ObtenerDatos()); CargarTabla(jugadores.ListarTodos()); LimpiarFormulario(null, null); }, "Jugador agregado correctamente.");
        }

        private void ActualizarJugador(object sender, EventArgs e)
        {
            Ejecutar(delegate { Jugador jugador = ObtenerDatos(); jugador.Id = IdSeleccionado(); jugadores.Actualizar(jugador); CargarTabla(jugadores.ListarTodos()); }, "Jugador actualizado correctamente.");
        }

        private void EliminarJugador(object sender, EventArgs e)
        {
            Ejecutar(delegate { jugadores.Eliminar(IdSeleccionado()); CargarTabla(jugadores.ListarTodos()); LimpiarFormulario(null, null); }, "Jugador eliminado correctamente.");
        }

        private void DesactivarJugador(object sender, EventArgs e)
        {
            Ejecutar(delegate { jugadores.Desactivar(IdSeleccionado()); CargarTabla(jugadores.ListarTodos()); }, "Jugador desactivado correctamente.");
        }

        private void BuscarJugador(object sender, EventArgs e)
        {
            Jugador jugador = jugadores.Buscar(txtJugador.Text);
            if (jugador == null)
            {
                MessageBox.Show("No se encontró un jugador activo con ese nombre.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CargarTabla(new[] { jugador });
            dgvJugadores.Rows[0].Selected = true;
        }

        private void LimpiarFormulario(object sender, EventArgs e)
        {
            txtEquipo.Clear();
            txtJugador.Clear();
            cmbPuesto.SelectedIndex = 0;
            cmbRol.SelectedIndex = 0;
            nudCamiseta.Value = 1;
            chkLesionado.Checked = false;
            lblSeleccionado.Text = "Ningún jugador seleccionado";
        }

        private void SeleccionarJugador(object sender, EventArgs e)
        {
            if (dgvJugadores.CurrentRow == null || dgvJugadores.CurrentRow.Cells[0].Value == null)
            {
                return;
            }

            Jugador jugador = jugadores.ListarTodos().FirstOrDefault(item => item.Id == (int)dgvJugadores.CurrentRow.Cells[0].Value);
            if (jugador == null)
            {
                return;
            }

            txtEquipo.Text = jugador.NombreEquipo;
            txtJugador.Text = jugador.Nombre;
            cmbPuesto.SelectedIndex = (int)jugador.Puesto;
            cmbRol.SelectedIndex = (int)jugador.Rol;
            nudCamiseta.Value = jugador.NumeroCamiseta;
            chkLesionado.Checked = jugador.Lesionado;
            lblSeleccionado.Text = "Jugador seleccionado: " + jugador.Id + " - " + jugador.Nombre;
        }

        private void CargarTabla(System.Collections.IEnumerable lista)
        {
            dgvJugadores.DataSource = null;
            dgvJugadores.DataSource = lista;
        }

        private void Ejecutar(Action accion, string mensajeExito)
        {
            try
            {
                accion();
                MessageBox.Show(mensajeExito, "Operación realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se pudo completar la operación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
