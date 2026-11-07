using System;
using System.Collections.Generic;
using System.Linq;

namespace Inscripcion.Backend
{
    public class Jugadores
    {
        private const int MaximoJugadores = 15;
        private const int MaximoTitulares = 11;
        private const int MaximoSuplentes = 4;
        private readonly List<Jugador> jugadores = new List<Jugador>();
        private int siguienteId = 1;

        public IReadOnlyList<Jugador> ListarTodos()
        {
            return jugadores.ToList().AsReadOnly();
        }

        public IReadOnlyList<Jugador> ListarActivos()
        {
            return jugadores.Where(jugador => jugador.Activo).ToList().AsReadOnly();
        }

        public Jugador Buscar(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return null;
            }

            return jugadores.FirstOrDefault(jugador =>
                jugador.Activo && jugador.Nombre.IndexOf(nombre.Trim(), StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public Jugador Agregar(Jugador jugador)
        {
            ValidarDatos(jugador);

            if (jugadores.Count(j => j.Activo) >= MaximoJugadores)
            {
                throw new InvalidOperationException("El equipo ya tiene los 15 jugadores permitidos.");
            }

            ValidarLimiteDeRol(jugador, null);
            ValidarCamiseta(jugador, null);

            jugador.Id = siguienteId++;
            jugador.Activo = true;
            jugadores.Add(jugador);
            return jugador;
        }

        public void Actualizar(Jugador jugador)
        {
            ValidarDatos(jugador);

            Jugador existente = jugadores.FirstOrDefault(item => item.Id == jugador.Id);
            if (existente == null || !existente.Activo)
            {
                throw new InvalidOperationException("No se encontró un jugador activo con ese identificador.");
            }

            ValidarLimiteDeRol(jugador, jugador.Id);
            ValidarCamiseta(jugador, jugador.Id);

            existente.NombreEquipo = jugador.NombreEquipo;
            existente.Nombre = jugador.Nombre;
            existente.Puesto = jugador.Puesto;
            existente.NumeroCamiseta = jugador.NumeroCamiseta;
            existente.Rol = jugador.Rol;
            existente.Lesionado = jugador.Lesionado;
        }

        public void Eliminar(int id)
        {
            Jugador jugador = ObtenerActivo(id);
            jugadores.Remove(jugador);
        }

        public void Desactivar(int id)
        {
            Jugador jugador = ObtenerActivo(id);
            jugador.Activo = false;
        }

        private Jugador ObtenerActivo(int id)
        {
            Jugador jugador = jugadores.FirstOrDefault(item => item.Id == id && item.Activo);
            if (jugador == null)
            {
                throw new InvalidOperationException("No se encontró un jugador activo con ese identificador.");
            }

            return jugador;
        }

        private void ValidarDatos(Jugador jugador)
        {
            if (jugador == null)
            {
                throw new ArgumentNullException("jugador");
            }

            if (string.IsNullOrWhiteSpace(jugador.NombreEquipo))
            {
                throw new ArgumentException("Debe indicar el nombre del equipo.");
            }

            if (string.IsNullOrWhiteSpace(jugador.Nombre))
            {
                throw new ArgumentException("Debe indicar el nombre del jugador.");
            }

            if (jugador.NumeroCamiseta < 1 || jugador.NumeroCamiseta > 99)
            {
                throw new ArgumentException("El número de camiseta debe estar entre 1 y 99.");
            }
        }

        private void ValidarLimiteDeRol(Jugador jugador, int? idIgnorado)
        {
            int cantidad = jugadores.Count(item => item.Activo
                && item.Rol == jugador.Rol
                && (!idIgnorado.HasValue || item.Id != idIgnorado.Value));

            if (jugador.Rol == RolJugador.Titular && cantidad >= MaximoTitulares)
            {
                throw new InvalidOperationException("El equipo no puede tener más de 11 titulares.");
            }

            if (jugador.Rol == RolJugador.Suplente && cantidad >= MaximoSuplentes)
            {
                throw new InvalidOperationException("El equipo no puede tener más de 4 suplentes.");
            }
        }

        private void ValidarCamiseta(Jugador jugador, int? idIgnorado)
        {
            bool repetida = jugadores.Any(item => item.Activo
                && item.NumeroCamiseta == jugador.NumeroCamiseta
                && (!idIgnorado.HasValue || item.Id != idIgnorado.Value));

            if (repetida)
            {
                throw new InvalidOperationException("El número de camiseta ya está asignado a otro jugador.");
            }
        }
    }
}
