namespace Pelis_API.Models;

public class Peli
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
    public int Duracion { get; set; } // (min)
    public decimal Valoracion { get; set; }
    public DateTime Estreno { get; set; }

}