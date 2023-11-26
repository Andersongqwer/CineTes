namespace CineTes.Models
{
    public class Cine
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Pais { get; set; }
        public int Capacidad { get; set; }
        public string? NombreReservante { get; set; }
        public DateTime FechaYHora { get; set; } // Nueva propiedad
        public string? Asiento { get; set; } // Nueva propiedad
        // Agrega más propiedades según sea necesario
    }
}
