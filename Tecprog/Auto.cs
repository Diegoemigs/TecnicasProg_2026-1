
//Programa Principal con instrucciones de nivel superior

Auto auto1 = new Auto();
auto1.Marca = "Chevrolet" ;
auto1.Modelo = "Cruze" ;
auto1.VelocidadActual = 100f;
Console.WriteLine($"La marca del auto es: {auto1.Marca}");
auto1.Acelerar(10f);
Console.WriteLine($"La velocidad es: {auto1.VelocidadActual}");
auto1.Frenar(50f);
Console.WriteLine($"La velocidad es: {auto1.VelocidadActual}");

public class Vehiculo 
{
    //Atributos
    protected string marca;
    protected string modelo;
    protected float velocidadActual;

    //Atributos Publicos con control

    public virtual string Marca {
        get { return marca; }
        set { marca = value; }
    }

    public virtual string Modelo {
        get { return modelo; }
        set { modelo = value; }
    }

    public float VelocidadActual {
        get { return velocidadActual; }
        set {
            if (value < 0) {
                velocidadActual = 0;
            } else {
                velocidadActual = value;
            }
        }
    }
    //Constructor

    public Vehiculo(string marca, string modelo) 
    {
        this.marca = marca;
        this.modelo = modelo;
        this.velocidadActual = 0.0f;
    }

    //Metodos

    public void Acelerar(float incremento) {
        VelocidadActual += incremento;

    }

    public void Frenar(float decremento) {
        VelocidadActual -= decremento;
    }

    //Sobrecarga de los operadores > < == para comparar velocidades

    public static bool operator > (Vehiculo v1, Vehiculo v2) 
    {
        return v1.velocidadActual > v2.velocidadActual;
    }

    public static bool operator < (Vehiculo v1, Vehiculo v2) {
        return v1.velocidadActual < v2.velocidadActual;
    }

    public static bool operator == (Vehiculo v1, Vehiculo v2) {
        return v1.velocidadActual == v2.velocidadActual;
    }

    public static bool operator != (Vehiculo v1, Vehiculo v2) {
        return v1.velocidadActual != v2.velocidadActual;
    }
}

public class AutoH : Vehiculo 
{
    public AutoH(string marca, string modelo) : base(marca, modelo) { }

    public override string Marca {
        get { return marca; }
        set { marca = value; }
    }

    public override string Modelo {
        get { return modelo; }
        set { modelo = value; }
    }
}

public class Motocicleta : Vehiculo 
{
    public Motocicleta(string marca, string modelo) : base(marca, modelo) 
    {
        
    }
}

public class Auto {
    //Atributos
    private string marca;
    private string modelo;
    private float velocidadActual;

    //Atributos Publicos con control

    public string Marca {
        get { return marca; }
        set { marca = value; }
    }

    public string Modelo {
        get { return modelo; }
        set { modelo = value; }
    }

    public float VelocidadActual {
        get { return velocidadActual; }
        set {
            if (value < 0) {
                velocidadActual = 0;
            } else {
                velocidadActual = value;
            }
        }
    }
    //Constructor


    //Metodos

    public void Acelerar(float incremento) 
    {
        VelocidadActual += incremento;

    }

    public void Frenar(float decremento) 
    {
        VelocidadActual -= decremento;
    }
}
