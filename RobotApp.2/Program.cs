using RobotLibrary;
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("=== Bienvenido a RobotApp ===");
Console.ResetColor();

RobotMovil robot = new RobotMovil("MóvilX1", 12.5f, 100, false);
robot.MostrarInformacion();

bool salir = false;

while (!salir) {
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("\n--- Menú de Comandos ---");
    Console.ResetColor();
    Console.WriteLine(" 1  - Encender robot");
    Console.WriteLine(" 2  - Apagar robot");
    Console.WriteLine(" 3  - Mostrar estado");
    Console.WriteLine(" 4  - Verificar energía");
    Console.WriteLine(" 5  - Recargar energía");
    Console.WriteLine(" 6  - Mover adelante");
    Console.WriteLine(" 7  - Mover atrás");
    Console.WriteLine(" 8  - Giro por diferencia");
    Console.WriteLine(" 9  - Giro por contrarrotación");
    Console.WriteLine(" 10 - Detener robot");
    Console.WriteLine(" 11 - Medir distancia con sensor ultrasónico");
    Console.WriteLine(" 12 - Aumentar velocidad");
    Console.WriteLine(" 13 - Reducir velocidad");
    Console.WriteLine(" 0  - Salir");
    Console.Write("Ingresa un comando: ");

    try {
        int opcion = int.Parse(Console.ReadLine() ?? "");

        switch (opcion) {
            case 1:
                robot.Encender();
                break;

            case 2:
                robot.Apagar();
                break;

            case 3:
                robot.MostrarEstado();
                break;

            case 4:
                robot.VerificarEnergia();
                break;

            case 5:
                Console.Write("¿Cuánta energía recargar? (1-100): ");
                int carga = int.Parse(Console.ReadLine() ?? "0");
                robot.RecargarEnergia(carga);
                break;

            case 6:
                Console.Write("Ingresa la velocidad (0-100): ");
                float velAd = float.Parse(Console.ReadLine() ?? "0");
                robot.Mover(velAd, "adelante");
                break;

            case 7:
                Console.Write("Ingresa la velocidad (0-100): ");
                float velAt = float.Parse(Console.ReadLine() ?? "0");
                robot.Mover(velAt, "atrás");
                break;

            case 8:
                Console.Write("Dirección del giro (izquierda/derecha): ");
                string dirDif = Console.ReadLine() ?? "";
                robot.GiroPorDiferencia(dirDif.ToLower());
                break;

            case 9:
                Console.Write("Dirección del giro (izquierda/derecha): ");
                string dirCon = Console.ReadLine() ?? "";
                robot.GiroPorContrarrotacion(dirCon.ToLower());
                break;

            case 10:
                robot.Detener();
                break;

            case 11:
                robot.ObtenerDistanciaSensor();
                break;

            case 12:
                Console.Write("¿Cuánto aumentar la velocidad?: ");
                int incA = int.Parse(Console.ReadLine() ?? "0");
                robot.AumentarVelocidad(incA);
                break;

            case 13:
                Console.Write("¿Cuánto reducir la velocidad?: ");
                int incR = int.Parse(Console.ReadLine() ?? "0");
                robot.ReducirVelocidad(incR);
                break;

            case 0:
                salir = true;
                Console.WriteLine("Saliendo de RobotApp. ¡Hasta luego!");
                break;

            default:
                Console.WriteLine("Comando no válido. Intenta de nuevo.");
                break;
        }
    } catch (Exception ex) {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
