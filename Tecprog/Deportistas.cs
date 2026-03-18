// García Saldaña Diego Emiliano

//Programa Principal
try {
    Console.WriteLine(" SIMULADOR DE TIROS DE BILLAR ");

    SimuladorBillar simulador = new SimuladorBillar();

    Console.WriteLine("Ingresa el número de operaciones:");
    int operaciones = int.Parse(Console.ReadLine() ?? "0");

    for (int i = 0; i < operaciones; i++) {
        Console.WriteLine($"\n--- Operación {i + 1} ---");
        string[] entrada = (Console.ReadLine() ?? "").Split("", StringSplitOptions.RemoveEmptyEntries);

        if (entrada.Length == 0) continue;

        string comando = entrada[0];

        try {
            switch (comando) {
                case "BOLA":
                    if (entrada.Length >= 3) {
                        string tipo = entrada[1];
                        double masaGramos = double.Parse(entrada[2]);
                        double masaKg = masaGramos / 1000.0; // Convertir gramos a kg

                        if (tipo == "NORMAL") {
                            simulador.CrearBola(new BolaNormal(masaKg));
                            Console.WriteLine($"Bola NORMAL creada con masa {masaGramos}g");
                        } else if (tipo == "PRO") {
                            simulador.CrearBola(new BolaProfesional(masaKg));
                            Console.WriteLine($"Bola PROFESIONAL creada con masa {masaGramos}g");
                        } else {
                            throw new ArgumentException("Tipo de bola no válido");
                        }
                    }
                    break;

                case "TIRO":
                    if (entrada.Length >= 4) {
                        double impulso = double.Parse(entrada[1]);
                        double dirX = double.Parse(entrada[2]);
                        double dirY = double.Parse(entrada[3]);

                        Tiro tiro = new Tiro(impulso, dirX, dirY);
                        simulador.RegistrarTiro(tiro);
                        Console.WriteLine($"Tiro registrado: Impulso={impulso}, Dirección=({dirX},{dirY})");
                    }
                    break;

                case "CRITERIO":
                    if (entrada.Length >= 2) {
                        string criterio = entrada[1];
                        if (criterio == "FISICA") {
                            simulador.CambiarEstrategia(new CalculoFisico());
                            Console.WriteLine("Criterio cambiado a FÍSICA");
                        } else if (criterio == "SIMPLE") {
                            simulador.CambiarEstrategia(new CalculoSimple());
                            Console.WriteLine("Criterio cambiado a SIMPLE");
                        } else {
                            throw new ArgumentException("Criterio no válido");
                        }
                    }
                    break;

                case "SIMULAR":
                    Console.WriteLine("Ejecutando simulación...");
                    simulador.Simular();
                    Console.WriteLine("Simulación completada");
                    break;

                case "RESULTADO":
                    Console.WriteLine("\n--- RESULTADOS ---");
                    simulador.MostrarResultado();
                    break;

                default:
                    throw new InvalidOperationException($"Comando no válido: {comando}");
            }
        } catch (Exception ex) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error en operación {i + 1}: {ex.Message}");
            Console.ResetColor();
        }
    }
} catch (Exception ex) {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Error fatal: {ex.Message}");
    Console.ResetColor();
}

// Definiciones de clases

// Clase Bola (similar a Dispositivo, Guerrero)
public class Bola {
    // Atributos protegidos
    protected double x;
    protected double y;
    protected double masa;
    protected double distanciaRecorrida;

    // Propiedades públicas con control (como en los ejemplos)
    public double X {
        get { return x; }
        set { x = value; }
    }

    public double Y {
        get { return y; }
        set { y = value; }
    }

    public double Masa {
        get { return masa; }
        set {
            if (value <= 0) {
                throw new ArgumentException("La masa debe ser positiva");
            }
            masa = value;
        }
    }

    public double DistanciaRecorrida {
        get { return distanciaRecorrida; }
        set { distanciaRecorrida = value; }
    }

    // Constructor
    public Bola(double masa) {
        this.Masa = masa;
        this.X = 0;
        this.Y = 0;
        this.DistanciaRecorrida = 0;
    }

    // Métodos
    public void Mover(double deltaX, double deltaY) {
        this.X += deltaX;
        this.Y += deltaY;
        Console.WriteLine($"Bola se movió: Δx={deltaX:F2}, Δy={deltaY:F2}");
    }

    // Método virtual 
    public virtual double ObtenerCoeficienteFriccion() {
        return 0;
    }

    // Sobrecarga de operadores 
    public static bool operator >(Bola b1, Bola b2) {
        return b1.DistanciaRecorrida > b2.DistanciaRecorrida;
    }

    public static bool operator <(Bola b1, Bola b2) {
        return b1.DistanciaRecorrida < b2.DistanciaRecorrida;
    }

    public static bool operator ==(Bola b1, Bola b2) {
        return b1.DistanciaRecorrida == b2.DistanciaRecorrida;
    }

    public static bool operator !=(Bola b1, Bola b2) {
        return b1.DistanciaRecorrida != b2.DistanciaRecorrida;
    }

    // Necesario cuando se sobrecargan == y !=
    public override bool Equals(object obj) {
        if (obj is Bola otraBola) {
            return this.DistanciaRecorrida == otraBola.DistanciaRecorrida;
        }
        return false;
    }

    public override int GetHashCode() {
        return DistanciaRecorrida.GetHashCode();
    }
}

// Clase BolaNormal 
public class BolaNormal : Bola {
    private const double MU = 1.2;

    public BolaNormal(double masa) : base(masa) {
    }

    public override double ObtenerCoeficienteFriccion() {
        return MU;
    }
}

// Clase BolaProfesional 
public class BolaProfesional : Bola {
    private const double MU = 0.6;

    public BolaProfesional(double masa) : base(masa) {
    }

    public override double ObtenerCoeficienteFriccion() {
        return MU;
    }
}

// Clase Tiro
public class Tiro {
    // Atributos privados
    private double impulso;
    private double dirX;
    private double dirY;

    // Propiedades públicas
    public double Impulso {
        get { return impulso; }
    }

    public double DirX {
        get { return dirX; }
    }

    public double DirY {
        get { return dirY; }
    }

    // Constructor
    public Tiro(double impulso, double dirX, double dirY) {
        if (impulso < 0) {
            throw new ArgumentException("El impulso no puede ser negativo");
        }
        if (dirX == 0 && dirY == 0) {
            throw new ArgumentException("El vector dirección no puede ser (0,0)");
        }

        this.impulso = impulso;
        this.dirX = dirX;
        this.dirY = dirY;
    }
}

// Interfaz IEstrategiaCalculo
public interface IEstrategiaCalculo {
    double CalcularDistancia(Tiro tiro, Bola bola);
}

// Estrategia CalculoFisico 
public class CalculoFisico : IEstrategiaCalculo {
    private const double G = 9.81;

    public double CalcularDistancia(Tiro tiro, Bola bola) {
        // v0 = I / m
        double v0 = tiro.Impulso / bola.Masa;
        Console.WriteLine($"  v0 = {tiro.Impulso} / {bola.Masa} = {v0:F2} m/s");

        // a = mu * g
        double aceleracion = -bola.ObtenerCoeficienteFriccion() * G;
        Console.WriteLine($"  a = {bola.ObtenerCoeficienteFriccion()} * {G} = {aceleracion:F2} m/s²");

        // d = v0² / (2*a)
        double distancia = -(v0 * v0) / (2 * aceleracion);
        Console.WriteLine($"  d = ({v0:F2}²) / (2 * {aceleracion:F2}) = {distancia:F2} m");

        if (distancia < 0) {
            throw new InvalidOperationException("La distancia calculada es negativa");
        }

        return distancia;
    }
}

// Estrategia CalculoSimple 
public class CalculoSimple : IEstrategiaCalculo {
    public double CalcularDistancia(Tiro tiro, Bola bola) {
        // distancia = impulso * 2
        double distancia = tiro.Impulso * 2;
        Console.WriteLine($"  d = {tiro.Impulso} * 2 = {distancia:F2} m");
        return distancia;
    }
}

// Clase SimuladorBillar 
public class SimuladorBillar {
    // Atributos privados
    private Bola bolaActual;
    private List<Tiro> tirosRegistrados;
    private IEstrategiaCalculo estrategiaActiva;
    private double distanciaTotal;

    // Propiedades públicas 
    public Bola BolaActual {
        get { return bolaActual; }
    }

    public double DistanciaTotal {
        get { return distanciaTotal; }
    }

    // Constructor
    public SimuladorBillar() {
        this.tirosRegistrados = new List<Tiro>();
        this.estrategiaActiva = new CalculoFisico(); 
        this.distanciaTotal = 0;
        Console.WriteLine("Simulador de billar inicializado");
    }

    // Métodos
    public void CrearBola(Bola bola) {
        if (bola == null) {
            throw new ArgumentNullException("La bola no puede ser nula");
        }

        this.bolaActual = bola;
        this.distanciaTotal = 0;
        this.tirosRegistrados.Clear();
        Console.WriteLine($"Bola creada en posición ({bolaActual.X}, {bolaActual.Y})");
    }

    public void RegistrarTiro(Tiro tiro) {
        if (tiro == null) {
            throw new ArgumentNullException("El tiro no puede ser nulo");
        }

        this.tirosRegistrados.Add(tiro);
    }

    public void CambiarEstrategia(IEstrategiaCalculo estrategia) {
        if (estrategia == null) {
            throw new ArgumentNullException("La estrategia no puede ser nula");
        }

        this.estrategiaActiva = estrategia;
    }

    public void Simular() {
        if (bolaActual == null) {
            throw new InvalidOperationException("No hay una bola creada para simular");
        }

        if (tirosRegistrados.Count == 0) {
            throw new InvalidOperationException("No hay tiros registrados para simular");
        }

        Console.WriteLine($"Simulando {tirosRegistrados.Count} tiros...");
        Console.WriteLine($"Posición inicial: ({bolaActual.X}, {bolaActual.Y})");
        Console.WriteLine($"Estrategia activa: {estrategiaActiva.GetType().Name}");
        

        int contador = 1;
        foreach (Tiro tiro in tirosRegistrados) {
            Console.WriteLine($"\nTiro #{contador}:");
            Console.WriteLine($"  Impulso: {tiro.Impulso}, Dirección: ({tiro.DirX}, {tiro.DirY})");

            // Calcular distancia según estrategia
            double distancia = estrategiaActiva.CalcularDistancia(tiro, bolaActual);

            // Calcular desplazamiento
            double magnitud = Math.Sqrt(tiro.DirX * tiro.DirX + tiro.DirY * tiro.DirY);
            double deltaX = (distancia * tiro.DirX) / magnitud;
            double deltaY = (distancia * tiro.DirY) / magnitud;

            Console.WriteLine($"  Desplazamiento: ({deltaX:F2}, {deltaY:F2})");

            // Mover la bola y acumular distancia
            bolaActual.Mover(deltaX, deltaY);
            distanciaTotal += distancia;

            Console.WriteLine($"  Posición actual: ({bolaActual.X:F2}, {bolaActual.Y:F2})");
            Console.WriteLine($"  Distancia acumulada: {distanciaTotal:F2} m");

            contador++;
        }

        Console.WriteLine("Simulación finalizada");
        tirosRegistrados.Clear();
    }

    public void MostrarResultado() {
        if (bolaActual == null) {
            Console.WriteLine("No hay resultados para mostrar");
            return;
        }

        // Mostrar distancia total
        Console.WriteLine($"Distancia = {distanciaTotal}");

        // Mostrar coordenadas finales
        Console.WriteLine($"( {bolaActual.X}, {bolaActual.Y})");
    }
}