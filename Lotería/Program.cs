using System;
using System.Collections.Generic;
using System.Linq;

// Define el espacio de nombres del proyecto. El tuyo podría ser diferente.
namespace Loteria
{
    // Clase principal del programa.
    class Program
    {
        // El método Main es el punto de entrada de la aplicación.
        static void Main(string[] args)
        {
            // Muestra un mensaje de bienvenida.
            Console.WriteLine("--- 🎰 BIENVENIDO A LA LOTERÍA 🎰 ---");
            Console.WriteLine("Reglas: Acierta los números en las posiciones correctas para ganar.");
            Console.WriteLine("1er Premio: 1000 veces tu apuesta.");
            Console.WriteLine("2do Premio: 100 veces tu apuesta.");
            Console.WriteLine("3er Premio: 10 veces tu apuesta.");
            Console.WriteLine("-----------------------------------------");

            // 1. SOLICITAR LA CANTIDAD A JUGAR
            decimal apuesta = 0;
            while (true)
            {
                Console.Write("Ingresa la cantidad de dinero a jugar: $");
                // Intenta convertir la entrada del usuario a un número decimal.
                if (decimal.TryParse(Console.ReadLine(), out apuesta) && apuesta > 0)
                {
                    break; // Si es un número válido y positivo, sale del bucle.
                }
                else
                {
                    Console.WriteLine("Error: Debes ingresar un número positivo. Inténtalo de nuevo.");
                }
            }

            // 2. SOLICITAR LOS TRES NÚMEROS AL USUARIO
            List<int> numerosUsuario = new List<int>();
            while (numerosUsuario.Count < 3)
            {
                Console.Write($"Ingresa tu número #{numerosUsuario.Count + 1} (entre 0 y 100): ");
                // Intenta convertir la entrada a un número entero.
                if (int.TryParse(Console.ReadLine(), out int numero) && numero >= 0 && numero <= 100)
                {
                    numerosUsuario.Add(numero); // Si es válido, lo agrega a la lista.
                }
                else
                {
                    Console.WriteLine("Error: Debes ingresar un número entero entre 0 y 100.");
                }
            }

            // 3. GENERAR LOS TRES NÚMEROS ALEATORIOS GANADORES
            Random generadorAleatorio = new Random();
            List<int> numerosGanadores = new List<int>
            {
                generadorAleatorio.Next(0, 101), // Genera un número entre 0 y 100
                generadorAleatorio.Next(0, 101),
                generadorAleatorio.Next(0, 101)
            };

            // 4. CALCULAR LOS PREMIOS
            decimal montoGanado = 0;
            int[] multiplicadores = { 1000, 100, 10 }; // Multiplicadores para 1er, 2do y 3er premio.

            // Se usa .Distinct() para que si el usuario juega (5, 5, 8) y sale el 5,
            // no se cuente el premio del 5 dos veces por la entrada del usuario.
            foreach (int numeroJugado in numerosUsuario.Distinct())
            {
                // Se revisa cada número del usuario contra cada posición ganadora.
                for (int i = 0; i < numerosGanadores.Count; i++)
                {
                    // Si el número del usuario coincide con un número ganador en cualquier posición...
                    if (numeroJugado == numerosGanadores[i])
                    {
                        // Se calcula el premio según la posición (i) y se suma al total.
                        // Esta lógica cumple la regla "si el numero repite lo paga en los dos premios".
                        montoGanado += apuesta * multiplicadores[i];
                    }
                }
            }

            // 5. MOSTRAR LOS RESULTADOS
            Console.WriteLine("\n---------- RESULTADOS DEL SORTEO ----------");
            Console.WriteLine($"Tus números jugados: {string.Join(", ", numerosUsuario)}");
            Console.WriteLine($"SALIDA NUMEROS: {numerosGanadores[0]} (1ro) - {numerosGanadores[1]} (2do) - {numerosGanadores[2]} (3ro)");
            Console.WriteLine("-------------------------------------------");

            if (montoGanado > 0)
            {
                Console.WriteLine("🎉 ¡FELICIDADES! HAS GANADO. 🎉");
                // Muestra el monto ganado formateado como moneda local (ej: $1,000.00)
                Console.WriteLine($"MONTO GANADO: {montoGanado:C}");
            }
            else
            {
                Console.WriteLine("😔 Lo sentimos, no has ganado esta vez. ¡Mejor suerte la próxima!");
            }

            Console.WriteLine("\nPresiona cualquier tecla para salir.");
            Console.ReadKey(); // Espera a que el usuario presione una tecla para cerrar.
        }
    }
}