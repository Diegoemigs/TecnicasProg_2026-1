public class Robot {
    public float Peso { get; set; }
    public string Modelo { get; set; }
    public bool Estado { get; set; }
    public int Energía { get; set; }

    Robot () {
        Modelo = "Robot Generico";
        Peso = 5;
        Energía = 100;
        Estado = false
    }

    Robot (string modelo, float peso, int energia, bool estado) {
        Modelo = modelo;
        Peso = peso;
        Energía = energia;
        Estado = false;
    }

    public void Encender() {
        Estado = true;
    }

    public void Apagar() {
        Estado = false;
    }
     public int VerificarEnergia () {
        return Energía;
    }

    public void Recargarener(int newEner ) {
        Energía = Energía + newEner;
    }
    public bool MostrarEstado() {
        return Estado;
    }

    public string MostrarInfo() {
        return $"Modelo: {Modelo}, Peso: {Peso}";
    }
 }

public class RobotMovil : Robot {
    public float Velocidad { get; set; }
    public string Direccion { get; set; }
    public int MotorIzq { get; set; }
    public int MotorDer { get; set; }
    public bool SensorUltra { get; set; }

    RobotMovil() {
        Direccion = "Detenido";
        Velocidad = 0;
        SensorUltra = true;
    }

    pu

}