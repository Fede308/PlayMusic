namespace PlayMusic.Models
{
    public class Cancion
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int fkArtista { get; set; } // Clave for�nea a la tabla Artista
        public string Album { get; set; }
        public string Genero { get; set; }
        public int Duracion { get; set; } // Duraci�n en segundos
        public string Url { get; set; } // URL de la canci�n
    }
}