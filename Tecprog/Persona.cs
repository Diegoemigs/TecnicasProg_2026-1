public class Persona
{
	//Atributos
	public string Nombre { get; set; } //Encapsulamiento
	public int Edad { get; set; }

	//Atributo static


	//Variable de clase
	int i = 0;

	// Constructor

	public Persona(string nombre, int edad)
	{
		Nombre = nombre;
		Edad = edad;
	}
	//Metodos

	public void MostrarDatos() 
	{
		Console.WriteLine($"Nombre objeto: {Nombre}");
		Console.WriteLine($"Edad objeto: {Edad}");
       
    }
}
