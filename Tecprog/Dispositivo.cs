using System.Reflection;
using System.Text.RegularExpressions;

public class Dispositivo 
{
    //Atributos
    private string nombre;
    private bool encendido;
    private float consumo;

    //Atributos publicos 
    //Atributos Publicos con control

    public virtual string Nombre {
        get { return nombre; }
        set { nombre = value; }
    }

    public virtual bool Encendido {
        get { return encendido }
        set { encendido = value; }
    }

    public float Consumo {
        get { return consumo; }
        set {
            if (value < 0) {
                consumo = 0;
            } else {
                consumo = value;
            }
        }
    }
    //Constructor

    public Dispositivo(string nombre, bool encendido) 
    {
        this.nombre = nombre;
        this.encendido = encendido
    }
}
