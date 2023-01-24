using Pelis_API.Models;
namespace Pelis_API.Services;

public static class PeliService
{
    static List<Peli> Pelis {get;}
    static int nextId = 3;
    //static DateTime date;

    //Cosa de la fecha de estreno
    public static DateTime fecha_estreno(int dd, int mm, int yyyy){
        return new DateTime(dd, mm, yyyy);
    }

    static PeliService()
    {
        Pelis = new List<Peli>
        {
            new Peli {Id = 1, Titulo = "Midway", Duracion = 138, Valoracion = 5.8m, Estreno = fecha_estreno(8,11,2019)},
            new Peli {Id = 2, Titulo = "Le Mans '66", Duracion = 152, Valoracion = 7.1m, Estreno = fecha_estreno(30,08,2019)},
            new Peli {Id = 3, Titulo = "La Milla verde", Duracion = 188, Valoracion = 7.9m, Estreno = fecha_estreno(18,02,2000)},
            new Peli {Id = 4, Titulo = "Una cuestión de tiempo", Duracion = 123, Valoracion = 7.0m, Estreno = fecha_estreno(18,09,2013)}
            
        };
    }

//MÉTODOS DE GET
    public static List<Peli> GetAll() => Pelis;

    // De cada Peli p, coges el parámetro Id y se lo pasas a la variable id
    public static Peli? Get(int id) => Pelis.FirstOrDefault(p => p.Id == id);
    
//MÉTODOS DE POST
    public static void Add(Peli peli)
    {
        peli.Id = nextId++;
        Pelis.Add(peli);
    }

//MÉTODOS DE DELETE
    public static void Delete(int id)
    {
        var peli = Get(id);
        if (peli is null)
        {
            return;
        }else{
            Pelis.Remove(peli);
        }
    }

//METODOS DE PUT
    public static void Update(Peli peli)
    {
        var index = Pelis.FindIndex(p => p.Id == peli.Id);
        if(index == -1)
            return;

        Pelis[index] = peli;
    }
}