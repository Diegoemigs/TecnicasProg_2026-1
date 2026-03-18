// García Saldaña Diego Emiliano

//Programa Principal
bool continuar = true;
SimuladorBillar simulador = new SimuladorBillar();

while (continuar) {
    try {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n=== SIMULADOR DE TIROS DE BILLAR ===");
        Console.ResetColor();

        Console.WriteLine("1. Crear Bola");
        Console.WriteLine("2. Registrar Tiro");
        Console.WriteLine("3. Cambiar Criterio de Cálculo");
        Console.WriteLine("4. Simular Tiros");
        Console.WriteLine("5. Mostrar Resultados");
        Console.WriteLine("6. Salir");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\nIngresa tu selección: ");
        Console.ResetColor();

        string opcion = Console.ReadLine() ?? "";

        switch (opcion) {
            case "1":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n--- CREAR BOLA ---");
                Console.ResetColor();

                Console.WriteLine("Selecciona el tipo de bola:");
                Console.WriteLine("1. Bola Normal (μ = 1.2)");
                Console.WriteLine("2. Bola Profesional (μ = 0.6)");
                Console.Write("Opción: ");

                string tipoBola = Console.ReadLine() ?? "";

                Console.Write("Ingresa la masa de la bola (en gramos): ");
                double masaGramos = double.Parse(Console.ReadLine() ?? "0");
                double masaKg = masaGramos / 1000.0;

                if (tipoBola == "1") {
                    simulador.CrearBola(new BolaNormal(masaKg));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"✓ Bola NORMAL creada con masa {masaGramos}g");
                    Console.ResetColor();
                } else if (tipoBola == "2") {
                    simulador.CrearBola(new BolaProfesional(masaKg));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"✓ Bola PROFESIONAL creada con masa {masaGramos}g");
                    Console.ResetColor();
                } else {
                    throw new ArgumentException("Tipo de bola no válido");
                }
                break;

            case "2":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n--- REGISTRAR TIRO ---");
                Console.ResetColor();

                Console.Write("Ingresa el impulso (I): ");
                double impulso = double.Parse(Console.ReadLine() ?? "0");

                Console.Write("Ingresa la dirección X: ");
                double dirX = double.Parse(Console.ReadLine() ?? "0");

                Console.Write("Ingresa la dirección Y: ");
                double dirY = double.Parse(Console.ReadLine() ?? "0");

                Tiro tiro = new Tiro(impulso, dirX, dirY);
                simulador.RegistrarTiro(tiro);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"✓ Tiro registrado: I={impulso}, ({dirX},{dirY})");
                Console.ResetColor();
                break;

            case "3":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n--- CAMBIAR CRITERIO DE CÁLCULO ---");
                Console.ResetColor();

                Console.WriteLine("Selecciona el criterio:");
                Console.WriteLine("1. Cálculo Físico (fórmula MRUA)");
                Console.WriteLine("2. Cálculo Simple (impulso * 2)");
                Console.Write("Opción: ");

                string criterio = Console.ReadLine() ?? "";

                if (criterio == "1") {
                    simulador.CambiarEstrategia(new CalculoFisico());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Criterio cambiado a FÍSICO");
                    Console.ResetColor();
                } else if (criterio == "2") {
                    simulador.CambiarEstrategia(new CalculoSimple());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Criterio cambiado a SIMPLE");
                    Console.ResetColor();
                } else {
                    throw new ArgumentException("Criterio no válido");
                }
                break;

            case "4":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n--- SIMULAR TIROS ---");
                Console.ResetColor();

                simulador.Simular();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Simulación completada");
                Console.ResetColor();
                break;

            case "5":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n--- RESULTADOS ---");
                Console.ResetColor();

                simulador.MostrarResultado();
                break;

            case "6":
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n¡Hasta luego!");
                Console.ResetColor();
                continuar = false;
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opción no válida");
                Console.ResetColor();
                break;
        }
    } catch (Exception ex) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($" Error: {ex.Message}");
        Console.ResetColor();
    }

    if (continuar) {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ResetColor();
        Console.ReadKey();
    }
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
