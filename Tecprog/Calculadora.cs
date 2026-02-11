//Programa Principal
Calculadora calculadora = new Calculadora();
float resultado = calculadora.Division();

Console.WriteLine(resultado);

//Clases


//Calculadora Basica

public class Calculadora 
{ 
    //Atributos
    public int Numero { get; set; }
    public int Numero2 { get; set; }

    //Constructor
    public Calculadora(int numero, int numero2);

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