namespace RobotLibrary 
{
    public class Robot {
        // Atributos privados
        public string modelo { get; set; }
        public float peso { get; set; }
        public bool estado { get; set; }
        public int energiaDisponible { get; set; }

        /* Encapsulación con get y set
        public string Modelo {
            get { return modelo; }
            set { modelo = value; }
        }

        public float Peso {
            get { return peso; }
            set { peso = value; }
        }

        public bool Estado {
            get { return estado; }
            set { estado = value; }
        }

        public int EnergiaDisponible {
            get { return energiaDisponible; }
            set {
                if (value < 0) energiaDisponible = 0;
                else if (value > 100) energiaDisponible = 100;
                else energiaDisponible = value;
            }
        }*/

        // Constructor sin parámetros (valores por defecto)
        public Robot() {
            modelo = "Robot Genérico";
            peso = 5.0f;
            energiaDisponible = 100;
            estado = false;
        }

        // Constructor con parámetros
        public Robot(string modelo, float peso, int energiaDisponible, bool estado) {
            this.modelo = modelo;
            this.peso = peso;
            this.energiaDisponible = energiaDisponible;
            this.estado = estado;
        }

        // Métodos virtuales (pueden ser sobrescritos)
        public virtual void Encender() {

            if (estado == true) {
                Console.WriteLine($"[Robot] {modelo} ya se encuentra encendido.");

            } else {
                estado = true;
                Console.WriteLine($"[Robot] {modelo} ha sido encendido.");
            }

        }

        public virtual void Apagar() {
            if (estado == false) {
                Console.WriteLine($"[Robot] {modelo} ya se encuentra apagado.");

            } else {
                estado = false;
                Console.WriteLine($"[Robot] {modelo} ha sido apagdo.");
            }

        }

        public virtual int VerificarEnergia() {
            Console.WriteLine($"[Robot] Energía disponible: {energiaDisponible}%");
            return energiaDisponible;
        }

        public virtual void RecargarEnergia(int cantidad) {
            energiaDisponible = Math.Min(energiaDisponible + cantidad, 100);
            Console.WriteLine($"[Robot] Energía recargada. Energía actual: {energiaDisponible}%");
        }

        public virtual void MostrarEstado() {
            string estadoTexto = estado ? "Encendido" : "Apagado";
            Console.WriteLine($"[Robot] Estado actual: {estadoTexto}");
        }

        public void MostrarInformacion() {
            Console.WriteLine($"[Robot] Modelo: {modelo} | Peso: {peso} kg");
        }
    }




    public class RobotMovil : Robot {
        // Atributos propios
        public float velocidad { get; set; }
        public string direccion { get; set; }
        public int motorIzquierdo { get; set; }
        public int motorDerecho { get; set; }
        public bool sensorUltrasonico { get; set; }

        /* Encapsulación con get y set
        public float Velocidad {
            get { return velocidad; }
            set {
                if (value < 0) velocidad = 0;
                else if (value > 100) velocidad = 100;
                else velocidad = value;
            }
        }

        public string Direccion {
            get { return direccion; }
            set { direccion = value; }
        }

        public int MotorIzquierdo {
            get { return motorIzquierdo; }
            set { motorIzquierdo = value; }
        }

        public int MotorDerecho {
            get { return motorDerecho; }
            set { motorDerecho = value; }
        }

        public bool SensorUltrasonico {
            get { return sensorUltrasonico; }
            set { sensorUltrasonico = value; }
        }*/

        // Constructor
        public RobotMovil(string modelo, float peso, int energiaDisponible, bool estado)
            : base(modelo, peso, energiaDisponible, estado) {
            velocidad = 0;
            direccion = "detenido";
            sensorUltrasonico = true;
            motorIzquierdo = 0;
            motorDerecho = 0;
        }

        // Sobrescritura de métodos virtuales
        public override void Encender() {
            estado = true;
            Console.WriteLine($"[RobotMovil] {modelo} encendido. Iniciando sistemas...");
            Console.WriteLine($"[RobotMovil] Motores listos. Sensor ultrasónico activo.");
        }

        public override void Apagar() {
            estado = false;
            Detener();
            sensorUltrasonico = false;
            Console.WriteLine($"[RobotMovil] {modelo} apagado. Sensores desactivados.");
        }

        public override int VerificarEnergia() {
            Console.WriteLine($"[RobotMovil] Batería al {energiaDisponible}% | " +
                              $"{(energiaDisponible > 20 ? "Nivel OK" : "¡BATERÍA BAJA!")}");
            return energiaDisponible;
        }

        public override void RecargarEnergia(int cantidad) {
            energiaDisponible += cantidad;
            Console.WriteLine($"[RobotMovil] Recarga completada. Batería: {energiaDisponible}%");
        }

        public override void MostrarEstado() {
            string estadoTexto = estado ? "Encendido" : "Apagado";
            Console.WriteLine($"[RobotMovil] Estado: {estadoTexto} | " +
                              $"Velocidad: {velocidad} cm/s | Dirección: {direccion}");
        }

        // Métodos adicionales
        public void ConsumirEnergia(int cantidad) {
            energiaDisponible -= cantidad;
            Console.WriteLine($"[RobotMovil] Energía consumida: {cantidad}%. Restante: {energiaDisponible}%");
        }

        public void Mover(float vel, string dir) {
            if (!estado) {
                Console.WriteLine("[RobotMovil] El robot debe estar encendido para moverse.");
                return;
            }
            velocidad = vel;
            direccion = dir;
            motorIzquierdo = (int)vel;
            motorDerecho = (int)vel;
            ConsumirEnergia(5);
            Console.WriteLine($"[RobotMovil] Moviéndose {dir} a {velocidad} cm/s.");
        }

        public void Detener() {
            velocidad = 0;
            direccion = "detenido";
            motorIzquierdo = 0;
            motorDerecho = 0;
            Console.WriteLine("[RobotMovil] Robot detenido.");
        }

        public void GiroPorDiferencia(string dir) {
            if (!estado) {
                Console.WriteLine("[RobotMovil] El robot debe estar encendido para girar.");
                return;
            }
            if (dir == "izquierda") {
                motorIzquierdo = 0;
                motorDerecho = (int)velocidad;
                direccion = "izquierda";
                Console.WriteLine("[RobotMovil] Giro curvo a la izquierda (motor izq. apagado).");
            } else if (dir == "derecha") {
                motorDerecho = 0;
                motorIzquierdo = (int)velocidad;
                direccion = "derecha";
                Console.WriteLine("[RobotMovil] Giro curvo a la derecha (motor der. apagado).");
            } else {
                Console.WriteLine("[RobotMovil] Dirección no válida. Use 'izquierda' o 'derecha'.");
                return;
            }
            ConsumirEnergia(3);
        }

        public void GiroPorContrarrotacion(string dir) {
            if (!estado) {
                Console.WriteLine("[RobotMovil] El robot debe estar encendido para girar.");
                return;
            }
            if (dir == "izquierda") {
                motorIzquierdo = -(int)velocidad;
                motorDerecho = (int)velocidad;
                direccion = "izquierda-cerrado";
                Console.WriteLine("[RobotMovil] Giro cerrado a la izquierda (contrarrotación).");
            } else if (dir == "derecha") {
                motorIzquierdo = (int)velocidad;
                motorDerecho = -(int)velocidad;
                direccion = "derecha-cerrado";
                Console.WriteLine("[RobotMovil] Giro cerrado a la derecha (contrarrotación).");
            } else {
                Console.WriteLine("[RobotMovil] Dirección no válida. Use 'izquierda' o 'derecha'.");
                return;
            }
            ConsumirEnergia(4);
        }

        public void ObtenerDistanciaSensor() {
            if (!sensorUltrasonico) {
                Console.WriteLine("[RobotMovil] El sensor ultrasónico está desactivado.");
                return;
            }
            int distancia = new Random().Next(5, 300);
            Console.WriteLine($"[RobotMovil] Sensor ultrasónico: distancia medida = {distancia} cm.");
            if (distancia < 30)
                Console.WriteLine("[RobotMovil] ¡ADVERTENCIA! Obstáculo cercano.");
        }

        public void AumentarVelocidad(int incremento) {
            if (!estado) {
                Console.WriteLine("[RobotMovil] El robot debe estar encendido.");
                return;
            }
            velocidad = Math.Min(velocidad + incremento, 100);
            ConsumirEnergia(2);
            Console.WriteLine($"[RobotMovil] Velocidad aumentada a {velocidad} cm/s.");
        }

        public void ReducirVelocidad(int incremento) {
            if (!estado) {
                Console.WriteLine("[RobotMovil] El robot debe estar encendido.");
                return;
            }
            velocidad = Math.Max(velocidad - incremento, 0);
            ConsumirEnergia(1);
            Console.WriteLine($"[RobotMovil] Velocidad reducida a {velocidad} cm/s.");
        }
    }
}


