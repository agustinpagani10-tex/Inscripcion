using System;

namespace Inscripcion.Backend
{
    public enum PuestoJugador
    {
        Arquero,
        Defensor,
        Mediocampo,
        Delantero
    }

    public enum RolJugador
    {
        Titular,
        Suplente
    }

    public class Jugador
    {
        public int Id { get; set; }
        public string NombreEquipo { get; set; }
        public string Nombre { get; set; }
        public PuestoJugador Puesto { get; set; }
        public int NumeroCamiseta { get; set; }
        public RolJugador Rol { get; set; }
        public bool Lesionado { get; set; }
        public bool Activo { get; set; }

        public Jugador()
        {
            Activo = true;
        }
    }
}
