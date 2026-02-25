//Programa Principal

Lampara lampara = new Lampara("Lamparita",80,40);
Ventilador ventilador = new Ventilador("Aire", 500, 50);

//eNCENDER

lampara.Encender();
ventilador.Encender();

//mOSTRAR INfrormacion

Console.WriteLine(lampara.MostrarInfo());
Console.WriteLine(ventilador.MostrarInfo());

//aJUSTAR Consumo
lampara.AjustarConsumo();
ventilador.AjustarConsumo(150);

//mOSTRAR INfrormacion

Console.WriteLine(lampara.MostrarInfo());
Console.WriteLine(ventilador.MostrarInfo());

//cOMPARACION

if (lampara > ventilador) {
    Console.WriteLine("Lampara consume más");
} else if (lampara < ventilador) {
    Console.WriteLine("Ventilador concume más");
} else 
{
    Console.WriteLine("Ambos consumen la misma energía");
}


public class Dispositivo 
{
    //Atributos
    private string nombre;
    private bool encendido;
    private int consumo;

    //Atributos publicos 
    //Atributos Publicos con control

    public string Nombre {
        get { return nombre; }
        set { nombre = value; }
    }

    public bool Encendido {
        get { return encendido; }
        set { encendido = value; }
    }

    public int Consumo {
        get { return encendido ? consumo : 0; }
        set {
            if (value < 0) {
                consumo = 0;
            } else {
                consumo = value;
            }
        }
    }
    //Constructor

    public Dispositivo(string nombre, int consumo) 
    {
        this.nombre = nombre;
        this.consumo = consumo;
        this.encendido = false;
    }


    //Metodos

    public void Encender() 
    {
        Encendido = true;
    }

    public void Apagar() 
    {
        Encendido = false;
    }

    //Sobrecarga

    public void AjustarConsumo() 
    {
        Consumo = 100;
    }
    public void AjustarConsumo(int nuevoConsumo) 
    {
        Consumo = nuevoConsumo;
    }


    public virtual string MostrarInfo() 
    {
        return $"Dispositivo: {Nombre} \nEncendido: {Encendido} \nConsumo: {Consumo} W";
    }

    //Sobrecarga Operador

    public static bool operator >(Dispositivo d1, Dispositivo d2) 
    {
        return d1.Consumo > d2.Consumo;
    }

    public static bool operator <(Dispositivo d1, Dispositivo d2)
    {
        return d1.Consumo < d2.Consumo;
    }

    public static bool operator == (Dispositivo d1, Dispositivo d2) 
    {
        return d1.Consumo == d2.Consumo;
    }

    public static bool operator != (Dispositivo d1, Dispositivo d2) {
        return d1.Consumo != d2.Consumo;
    }
}



public class Lampara : Dispositivo {
    //Atributos

    private int intensidad;//nivel de brillo

    //Constructor

    public Lampara(string nombre, int consumo, int intensidad) : base(nombre, consumo) {
        this.intensidad = intensidad;
    }
    //Metodos

    public override string MostrarInfo() {
        return $"Lampara: {base.MostrarInfo()} \nIntensidad: {intensidad}";
    }
}

public class Ventilador : Dispositivo {
    //Atributos

    private int velocidad;//nivel de velocidad

    //Constructor

    public Ventilador(string nombre, int consumo, int velocidad) : base(nombre, consumo) {
        this.velocidad = velocidad;
    }
    //Metodos

    public override string MostrarInfo() {
        return $"Ventilador: {base.MostrarInfo()} \nVelocidad: {velocidad}";
    }
}
    