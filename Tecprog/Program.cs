// Programa de forma secuencial

Console.WriteLine("Ingresa el Nombre");
String nombre = Console.ReadLine() ?? "";

Console.WriteLine("Ingresa la Edad");
int edad = int.Parse( Console.ReadLine() ?? "");

Console.WriteLine($"Nombre: {nombre}");
Console.WriteLine($"Edad: {edad}");

//Programa Orientado a Objetos

Persona humano1 = new Persona(nombre, edad); //Instancia un nuevo Objeto tipo persona

Console.WriteLine($"Nombre objeto: {humano1. Nombre}");
Console.WriteLine($"Edad objeto: {humano1. Edad }");