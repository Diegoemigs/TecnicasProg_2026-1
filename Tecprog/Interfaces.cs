//Programa Principal

bool continua = true;

List<IPago> list = new List<IPago>();

do {
    Console.WriteLine("Ingresa el monto a pagar");
    try {
        string montoTexto = Console.ReadLine() ?? "";
    } catch { }
} while (continua);

//Interfaz y clases

public interface IPago {
    void ProcesarPago();
}

public class PagoenEfectivo : IPago {

    //Atributos
    public double Monto { get; set; }

    public PagoenEfectivo(double monto) {
        Monto = monto;
    }

    //mETODODS
    public void ProcesarPago() {
        Console.WriteLine($"Pago en efectivo de {Monto} procesado");
    }
}

public class PagoTarjeta : IPago { 
    public string NumeroTarjeta { get; set; }
    public double Monto { get; set; }

    public PagoTarjeta(string numeroTarjeta, double monto) {
        NumeroTarjeta = numeroTarjeta;
        Monto = monto;
    }

    //mETODODS
    public void ProcesarPago() {
        if (NumeroTarjeta.Length == 16) {
            Console.WriteLine($"Pago con tarjeta de {Monto} procesado");
        }else {
            Console.WriteLine($"Tarjeta Invalida");

        }
    }
}
