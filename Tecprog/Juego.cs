//Implementacion juego

try 
{
    Console.WriteLine("BIENVENIDO AL TORNEO DE GUERREROS!!!!");
    Console.WriteLine("Ingresa el nombre de tu Guerrero");
    string nombre = Console.ReadLine() ?? "";

    
} 
catch 
{ 
}

//Apartado de Funciones

static Guerrero SeleccionarClase() {
    while (true) 
        {
        try {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Selecciona tu clase");
            Console.WriteLine("1. Caballero");
            Console.WriteLine("2. Mago");
            Console.WriteLine("3. Arquero");
            Console.WriteLine("4. Guerrero Sombra");


            Console.WriteLine("Ingresa tu Selección");

            int opcion = int.Parse(Console.ReadLine() ?? "");

            switch (opcion) { }
        } catch { }
    }
}


//Definiciones de clases
public class Guerrero 
{
    //Atributos
    public string Nombre { get; set; }
    public int Vida { get; set; }
    public int Ataque { get; set; }

    //Constructor

    public Guerrero(string nombre, int vida, int ataque) 
    {
        Nombre = nombre;
        Vida = vida;
        Ataque = ataque;
    }

    //Metodos

    public virtual void Atacar(Guerrero enemigo) 
    {
        int danio = Ataque + new Random().Next(-3,5);
        //Recibir daño
        enemigo.RecibirDanio(danio);
        Console.WriteLine($"{Nombre} ataca a {enemigo.Nombre} y causa {danio} de daño");

    }

    public void RecibirDanio(int cantidad) 
    {
        Vida = Math.Max(Vida - cantidad, 0); 

    }

    //Sobrecarga de Operador +

    public static Guerrero operator +(Guerrero g1, Guerrero g2) 
    {
        Console.WriteLine($"{g1.Nombre} + {g2.Nombre} se fusiona con un nuevo guerrero");
        return new Guerrero($"{g1.Nombre}--{g2.Nombre}",(g1.Vida + g2.Vida)/2,(g1.Ataque + g2.Ataque)/2);
    }
}

//Clase Caballero

public class Caballero : Guerrero 
{
    //Constructor
    public Caballero(string nombre) : base(nombre, 120, 20) { }

    //Polimorfismo

    public override void Atacar(Guerrero enemigo) {
        Console.WriteLine($"{Nombre}(Caballero) usa golpe critico");
        base.Atacar(enemigo);
    }
}

//Clase Mago
public class Mago : Guerrero {
    //Constructor
    public Mago(string nombre) : base(nombre, 80, 25) { }

    //Polimorfismo

    public override void Atacar(Guerrero enemigo) {
        Console.WriteLine($"{Nombre}(Mago) usa Lanza hechizo de fuego");
        base.Atacar(enemigo);
    }
}

//Clase Arquero
public class Arquero : Guerrero {
    //Constructor
    public Arquero(string nombre) : base(nombre, 90, 15) { }

    //Polimorfismo

    public override void Atacar(Guerrero enemigo) {
        int probabilidad = new Random().Next(1,100);

        if(probabilidad < 30) {
            Console.WriteLine($"{Nombre}(Arquero) dispara una flecha y falla");
        }
        else {
            Console.WriteLine($"{Nombre}(Arquero) Lanza una flecha y acierta");
            base.Atacar(enemigo);
        }
    }
}

public class GuerreroSombra : Guerrero {
    //Constructor
    public GuerreroSombra(string nombre) : base(nombre, 110, 22) { }

    //Polimorfismo

    public override void Atacar(Guerrero enemigo) {
        int Chance = new Random().Next(1, 100);

        if (Chance < 20) {
            Console.WriteLine($"{Nombre}(Guerrero Sombra) desaparece");
        } else {
            Console.WriteLine($"{Nombre}(Guerrero SOmbra) ataca");
            base.Atacar(enemigo);
        }
    }
}

//Clase Guerrero Sombra