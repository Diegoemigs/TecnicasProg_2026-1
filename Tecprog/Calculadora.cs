//Programa Principal

/*Calculadora calculadora = new Calculadora(10, 5);
Calculadora calculadora2 = new Calculadora(7, 5);
Console.WriteLine("Los números ingresados la calculadora 1 son:");
Console.WriteLine("Número 1: " + calculadora.Numero);
Console.WriteLine("Número 2: " + calculadora.Numero2);
Console.WriteLine();

Console.WriteLine("Número 1: " + calculadora2.Numero);
Console.WriteLine("Número 2: " + calculadora2.Numero2);
Console.WriteLine();

// Mostrar resultados de las operaciones
/Console.WriteLine("El resultado de la resta 1 es: " + calculadora.Resta());
Console.WriteLine("El resultado de la multiplicación 1 es: " + calculadora.Multiplicacion());
Console.WriteLine("El resultado de la división 1 es: " + calculadora.Division());

Console.WriteLine("El resultado de la suma 2 es: " + calculadora2.Suma());
Console.WriteLine("El resultado de la resta 2 es: " + calculadora2.Resta());
Console.WriteLine("El resultado de la multiplicación 2 es: " + calculadora2.Multiplicacion());
Console.WriteLine("El resultado de la división 2 es: " + calculadora2.Division());

//Clases


CalculadoraCientifica calculadoraCientifica = new CalculadoraCientifica(20, 15);
Console.WriteLine("El resultado de la suma en Calculadora Cientifica es: " + calculadoraCientifica.Suma());
Console.WriteLine("El resultado de la suma 1 es: " + calculadora.Suma());
Console.WriteLine("El resultado de la suma 2 es: " + calculadora.Suma(3));

Calculadora calculadora3 = calculadora + calculadora2;
Console.WriteLine($"Calculadora 3 ({calculadora3.Numero}, {calculadora3.Numero2})");*/

Console.WriteLine("Ingresa el primer numero:");
int Numero
switch () 
{ 
    case 0;
        break;
}
//Calculadora Basica

public class Calculadora 
{ 
    //Atributos
    public int Numero { get; set; }
    public int Numero2 { get; set; }

    //aTRIBUTO pRIVADO
    private int Resultado;

    //Constructor
    public Calculadora(int numero, int numero2)
    {
        Numero = numero;
        Numero2 = numero2;
    }
    //Metodos
    public virtual int Suma() 
    {
        Resultado = Numero + Numero2;
        return Resultado;
    }

    public virtual int Suma(int numero3) 
    {
        return Numero + Numero2 + numero3;
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

    //Sobrecarga del Operador

    public static Calculadora operator +(Calculadora calcl, Calculadora calc2) 
    {
        return new Calculadora(calcl.Numero + calc2.Numero,calcl.Numero2 + calc2.Numero2);
    }
}

//Clase Hija

public class CalculadoraCientifica : Calculadora 
{

    //Atributos
    //Contructor
    public CalculadoraCientifica(int numero, int numero2) : base(numero,numero2)
    {

    }
    //Metodos

    public double Logaritmo() 
    {
        return MathF.Log(Numero);
    }

    public double Raiz() 
    { 
        return MathF.
    }
    public override int Suma() 
    {
        int resultado = base.Suma();
        return resultado * resultado;
    }
    public float Factorial() {
        int f = Numero;

    if (Numero < 0) {
            Console.WriteLine("No se puede calcular f de un numero negativo");
            return 0;

        } else if (Numero == 0 || Numero == 1) {
            return 1;

        } else {
            int Fac = 1;

            for (int f = 2; f <= Numero; f++) 
            {
                Fac = Fac * f;
            }
            return Fac;
        }

    }
}