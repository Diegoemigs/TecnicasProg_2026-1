//Programa principal

Festival festival = new Festival("KermesFI");
Console.WriteLine($"Bienvenido al festival de musica {festival.Nombre}");

//Crear banda y sus sets de canciones

Console.WriteLine("Registrando bandas y sets");

//Banda 1
Banda muse = new Banda("Muse", "UK", new TimeSpan(19,0,0), 4);
muse.CargaCancion(0,new Cancion("Starlight",4,"Rock"));
muse.CargaCancion(1, new Cancion("Hysteria", 3, "Rock"));
muse.CargaCancion(2, new Cancion("Unintended", 3, "Rock"));
muse.CargaCancion(3, new Cancion("Matness", 5, "Rock"));

//Banda 2
Banda djo = new Banda("DJO", "USA", new TimeSpan(17, 0, 0), 3);
djo.CargaCancion(0, new Cancion("Crux", 3, "Rock"));
djo.CargaCancion(1, new Cancion("End off begining", 3, "Rock"));
djo.CargaCancion(2, new Cancion("Back on you", 5, "Rock"));

//Banda 3
Banda bts = new Banda("BTS", "COR", new TimeSpan(21, 0, 0), 3);
bts.CargaCancion(0, new Cancion("Butter", 3, "K-Rock"));
bts.CargaCancion(1, new Cancion("Body to body", 3, "K-pop"));
bts.CargaCancion(2, new Cancion("Hooligan", 3, "Rock"));

//Banda 4
Banda calibre50 = new Banda("Calibre 50", "MEX", new TimeSpan(24, 0, 0), 3);
calibre50.CargaCancion(0, new Cancion("Si te pudiera mentir", 3, "Banda"));
calibre50.CargaCancion(1, new Cancion("El tierno se fue", 3, "Banda"));
calibre50.CargaCancion(2, new Cancion("El amor de mi vida", 3, "Banda"));

//Agregar al festival

festival.AgregarBanda(muse);
festival.AgregarBanda(djo);
festival.AgregarBanda(bts);
festival.AgregarBanda(calibre50);

//Duracion total de cada set

Console.WriteLine("DURACION DE SETS POR BANDA");
foreach (Banda b in festival.Cartel) 
{
    Console.WriteLine($"    {b.Nombre} - {b.DuracionTotalSet()}");
}

//Orden original de presentacion

Console.WriteLine("Reordenando show");
festival.ResumenCartel();

//Cambio de ultimo minuto banda invitada confirma MJ

//Banda 4
Banda mj = new Banda("Michel Jackson", "USA", new TimeSpan(1,0,0), 2);
mj.CargaCancion(0,new Cancion("Thriller", 5, "Pop"));
mj.CargaCancion(0, new Cancion("Beat it", 4, "Pop"));
Console.WriteLine($"Cambio de ultimo minuto {mj.Nombre} confirma como banda despues de BTS y antes de Calibre50");

//Insertar MJ

public class Cancion 
{
    //Atributos
    public string Titulo {  get; set; }
    public int Duracion {  get; set; }
    public string Genero { get; set; }
    //Constructor
    public Cancion(string titulo, int duracion, string genero) 
    {
    Titulo = titulo;
    Duracion = duracion;
    Genero = genero;
    }
    //Metodo
    public override string ToString()
    {
        return $"{Titulo}--{Duracion}min [{Genero}]";
    }
}

public class Banda 
{
    //Propiedade
    public string Nombre { get; set; }
    public string Origen { get; set; }
    public TimeSpan HoraPresentacion { get; set; }
    public Cancion[] SetCanciones { get; set; }
    //Constructor

    public Banda(string nombre, string origen, TimeSpan hora, int cantidadCanciones) {
        Nombre = nombre;
        Origen = origen;
        HoraPresentacion = hora;
        SetCanciones = new Cancion[cantidadCanciones];
    }

    //Metodos

    //Carga una canción en una posición específica

    public void CargaCancion(int posicion, Cancion cancion) 
    {
        if (posicion >= SetCanciones.Length || posicion < 0) 
        {
            throw new ArgumentOutOfRangeException($"Posicion invalida: {posicion}");
        }

        SetCanciones[posicion] = cancion;
    }


    public int DuracionTotalSet() 
    {
        //Recorrer el arreglo sumando duraciones

        int total = 0;

        foreach (Cancion cancion in SetCanciones)
        {
            if (cancion != null) 
            {
                total += cancion.Duracion;
            }
        }

        return total;
    }

    public override string ToString() 
    {
        return $"{Nombre} ({Origen}) | {HoraPresentacion:hh\\:mm}";
    }

}

public class Asistente 
{
    //Propiedades
    public string Nombre { get; set; }
    public int NumeroEntrada { get; set; }
    public TimeSpan HoraLlegada { get; set; }
    public bool YaIngreso { get; set; }

    //Constructor
    public Asistente(string nombre, int numeroEntrada, TimeSpan horaLlegada) 
    {
        Nombre = nombre;
        NumeroEntrada = numeroEntrada;
        HoraLlegada = horaLlegada;
        YaIngreso = false;
    }

    //Metodo
    public override string ToString()
    {
        return $"#{NumeroEntrada} {Nombre} llego a las {HoraLlegada:hh\\:mm}";
    }

}

public class Festival 
{
    public string Nombre { get; set; }
    public List<Banda> Cartel {  get; set; }
    public Stack<Banda> HistorialEscenario { get; set; }
    public Queue<Asistente> FilaIngreso { get; set; }
    public LinkedList<Banda> OrdenShow { get; set; }

    //Constructor
    public Festival(string nombre) 
    {
        Nombre = nombre;
        Cartel = new List<Banda>();
        HistorialEscenario = new Stack<Banda>();
        FilaIngreso = new Queue<Asistente>();
        OrdenShow = new LinkedList<Banda>();
    }

    //Metodos

    //Agregar banda
    public void AgregarBanda(Banda banda) 
    {
        //Agregando banda a la lista Cartel
        Cartel.Add(banda);
        //Agregar banda a lista enlazada del orden del show
        OrdenShow.AddLast(banda);
        Console.WriteLine($"[+] Banda confirmada: {banda.Nombre}");
    }

    //Cancelar banda
    public void CancelarBanda(string nombre) 
    {
        Banda encontrada = null;

        foreach (Banda b in Cartel) 
        {
            if (b.Nombre == nombre) 
            {
                encontrada = b;
                break;
            }
        }

        if (encontrada != null) 
        {
            Cartel.Remove(encontrada);
            OrdenShow.Remove(encontrada);
            Console.WriteLine($"[-] Banda cancelada: {nombre}");
        } 
        else
        {
            Console.WriteLine($"Banda{nombre} no se encontro");
        }
    }

    //Insertar banda despues de otra
    public void InsertarBandaDespuesDe(Banda nueva, LinkedListNode<Banda> despuesDe) 
    {
        OrdenShow.Remove(nueva);
        OrdenShow.AddAfter(despuesDe, nueva);
        Console.WriteLine($"[]: {nueva.Nombre} reubicada en el orden del show");
    }

    //Registrar presentacion
    public void RegistrarPresentacion(Banda banda) 
    {
        HistorialEscenario.Push(banda);
        Console.WriteLine($"[★] Presentación registrada: {banda.Nombre}");
    }

    //Ultima banda en tocar
    public Banda UltimaBandaEnTocar() 
    {
        return HistorialEscenario.Peek();
    }

    //Admitir siguiente asistente
    public Asistente AdmitirSiguiente() 
    {
        Asistente asistente = FilaIngreso.Dequeue();
        asistente.YaIngreso = true;
        return asistente;
    }

    //Resumen del cartel (ordenado por hora)
    public void ResumenCartel() 
    {
        List<Banda> ordenada = new List<Banda>(Cartel);

        // Ordenamiento burbuja
        int n = ordenada.Count;
        for (int i = 0; i < n-1; i++) 
        {
            for (int j = 0; j < n-i-1; j++) 
            {
                if (ordenada[j].HoraPresentacion > ordenada[j + 1].HoraPresentacion) 
                {
                    Banda temp = ordenada[j];
                    ordenada[j] = ordenada[j + 1];
                    ordenada[j + 1] = temp;
                }
            }
        }

        Console.WriteLine($"CARTEL OFICIAL — {Nombre}");
        foreach (Banda b in ordenada) 
        {
            Console.WriteLine($"{b.HoraPresentacion:hh\\:mm} {b.Nombre} {b.Origen}");
        }
    }
}