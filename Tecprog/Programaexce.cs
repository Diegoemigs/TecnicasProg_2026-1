using System.Globalization;

//Programa Principal

Inventario innventario = new Inventario();

bool salir = false;
while (!salir) {
    Console.ForegroundColor = ConsoleColor.Green;

    Console.WriteLine("Menu de suministros");
    Console.WriteLine("1. Mostrar");
    Console.WriteLine("2. Buscar");
    Console.WriteLine("3. Ordenar por Nombre");
    Console.WriteLine("4. Invertir Orden");
    Console.WriteLine("5. Vaciar Inventario");
    Console.WriteLine("6. Agregar Suministro");
    Console.WriteLine("7. Eliminar Suministro");
    Console.WriteLine("8. Salir");

    Console.WriteLine("Ingresa tu Selección");

    int opcion = int.Parse(Console.ReadLine() ?? "");

    switch (opcion) { }

}

public class Suministro { 
    //Atributos
    public string Nombre { get; set; }
    public int CantDisp { get; set; }
    public int Nivel { get; set; }

    public Suministro(string nombre, int cantdisp, int nivel) {
        Nombre = nombre;
        CantDisp = cantdisp;
        Nivel = nivel;
    }

    public Suministro(string nombreb) {
        Nombre = nombreb;
        CantDisp = 1;
        Nivel = 2;
    }

    //Metodos

    public void MostrarInfo() {
        Console.WriteLine($"{Nombre}|Cantidad: {CantDisp}|Nivel: {Nivel}");
    }
}

public class Inventario {
    private Suministro[] suministros;

    //Constructor
    public Inventario() {
        suministros = new Suministro[] {
            new Suministro("Oxigeno",15,1),
            new Suministro("Gasolina"),
            new Suministro("Comida",30,1),
            new Suministro("Almohada",15,3)
        };
    }
} 
