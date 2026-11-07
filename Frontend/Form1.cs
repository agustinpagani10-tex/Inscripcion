using System;
using System.Linq;
using System.Windows.Forms;
using Inscripcion.Backend;

namespace Inscripcion_Partido
{
    public partial class Form1 : Form
    {
        private readonly Jugadores jugadores = new Jugadores();

        public Form1()
        {
            InitializeComponent();
            cmbPuesto.DataSource = new[] { "Arquero", "Defensor", "Mediocampo", "Delantero" };
            cmbRol.DataSource = new[] { "Titular", "Suplente" };
            CargarTabla(jugadores.ListarTodos());
        }

        private Jugador ObtenerDatos()
        {
            return new Jugador
            {
                NombreEquipo = txtEquipo.Text,
                Nombre = txtJugador.Text,
                Puesto = (PuestoJugador)cmbPuesto.SelectedIndex,
                NumeroCamiseta = ObtenerNumeroCamiseta(),
                Rol = (RolJugador)cmbRol.SelectedIndex,
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

        private int ObtenerNumeroCamiseta()
        {
            int numero;
            if (!int.TryParse(txtNumeroCamiseta.Text, out numero))
            {
                throw new ArgumentException("El número de camiseta debe ser numérico.");
            }

            return numero;
        }

        private void AgregarJugador(object sender, EventArgs e)
        {
            Ejecutar(delegate
            {
                jugadores.Agregar(ObtenerDatos());
                CargarTabla(jugadores.ListarTodos());
                LimpiarFormulario(null, null);
            }, "Jugador agregado correctamente.");
        }

        private void ActualizarJugador(object sender, EventArgs e)
        {
            Ejecutar(delegate
            {
                Jugador jugador = ObtenerDatos();
                jugador.Id = IdSeleccionado();
                jugadores.Actualizar(jugador);
                CargarTabla(jugadores.ListarTodos());
            }, "Jugador actualizado correctamente.");
        }

        private void EliminarJugador(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro de que desea eliminar el jugador seleccionado?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            Ejecutar(delegate
            {
                jugadores.Eliminar(IdSeleccionado());
                CargarTabla(jugadores.ListarTodos());
                LimpiarFormulario(null, null);
            }, "Jugador eliminado correctamente.");
        }

        private void DesactivarJugador(object sender, EventArgs e)
        {
            Ejecutar(delegate
            {
                jugadores.Desactivar(IdSeleccionado());
                CargarTabla(jugadores.ListarTodos());
            }, "Jugador desactivado correctamente.");
        }

        private void BuscarJugador(object sender, EventArgs e)
        {
            Jugador jugador = jugadores.Buscar(txtBuscar.Text);
            if (jugador == null)
            {
                MessageBox.Show("No se encontró un jugador activo con ese nombre.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CargarTabla(new[] { jugador });
        }

        private void ListarTodos(object sender, EventArgs e)
        {
            CargarTabla(jugadores.ListarTodos());
        }

        private void ListarActivos(object sender, EventArgs e)
        {
            CargarTabla(jugadores.ListarActivos());
        }

        private void LimpiarFormulario(object sender, EventArgs e)
        {
            txtEquipo.Clear();
            txtJugador.Clear();
            txtBuscar.Clear();
            cmbPuesto.SelectedIndex = 0;
            cmbRol.SelectedIndex = 0;
            txtNumeroCamiseta.Clear();
            chkLesionado.Checked = false;
            dgvJugadores.ClearSelection();
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
            txtNumeroCamiseta.Text = jugador.NumeroCamiseta.ToString();
            chkLesionado.Checked = jugador.Lesionado;
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
