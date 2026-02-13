//Programa Principal
Calculadora calculadora = new Calculadora(10, 5);
Console.WriteLine("Los números ingresados son:");
Console.WriteLine("Número 1: " + calculadora.Numero);
Console.WriteLine("Número 2: " + calculadora.Numero2);
Console.WriteLine();

// Mostrar resultados de las operaciones
Console.WriteLine("El resultado de la suma es: " + calculadora.Suma());
Console.WriteLine("El resultado de la resta es: " + calculadora.Resta());
Console.WriteLine("El resultado de la multiplicación es: " + calculadora.Multiplicacion());
Console.WriteLine("El resultado de la división es: " + calculadora.Division());

//Clases


//Calculadora Basica

public class Calculadora 
{ 
    //Atributos
    public int Numero { get; set; }
    public int Numero2 { get; set; }

    //Constructor
    public Calculadora(int numero, int numero2)
    {
        Numero = numero;
        Numero2 = numero2;
    }
    //Metodos
    public int Suma() 
    { 
        return Numero + Numero2;
    }

    public int Resta()
    {
        return Numero - Numero2;
    }

    public int Multiplicacion() 
    {
        return Numero * Numero2;
    }

    public float Division() 
    {
        if (Numero2 == 0) 
        { 
            Console.WriteLine("MathError");
            return 0;
        }
        return (float) Numero / Numero2;
    }
}
