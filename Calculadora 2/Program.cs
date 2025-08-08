using System;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variable para controlar el bucle del menú
            bool endApp = false;

            // Título de la aplicación
            Console.WriteLine("Calculadora de Consola en C#");
            Console.WriteLine("----------------------------\n");

            // Bucle principal que muestra el menú hasta que el usuario decida salir
            while (!endApp)
            {
                // Menú de opciones
                Console.WriteLine("Elige una operación de la siguiente lista:");
                Console.WriteLine("\t1 - Sumar");
                Console.WriteLine("\t2 - Restar");
                Console.WriteLine("\t3 - Multiplicar");
                Console.WriteLine("\t4 - Dividir");
                Console.WriteLine("\t5 - Potencia (Exponente)");
                Console.WriteLine("\t6 - Raíz Cuadrada");
                Console.Write("Tu opción: ");

                string op = Console.ReadLine();
                double result = 0;

                try
                {
                    // Lógica para las operaciones que requieren dos números
                    if (op == "1" || op == "2" || op == "3" || op == "4" || op == "5")
                    {
                        Console.Write("Escribe el primer número y presiona Enter: ");
                        double num1 = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Escribe el segundo número y presiona Enter: ");
                        double num2 = Convert.ToDouble(Console.ReadLine());

                        switch (op)
                        {
                            case "1":
                                result = num1 + num2;
                                break;
                            case "2":
                                result = num1 - num2;
                                break;
                            case "3":
                                result = num1 * num2;
                                break;
                            case "4":
                                // Manejo de la división por cero
                                if (num2 != 0)
                                {
                                    result = num1 / num2;
                                }
                                else
                                {
                                    Console.WriteLine("Error: No se puede dividir por cero.");
                                    continue; // Vuelve al inicio del bucle
                                }
                                break;
                            case "5":
                                // Math.Pow se usa para la exponenciación
                                result = Math.Pow(num1, num2);
                                break;
                        }
                        Console.WriteLine("Tu resultado: {0:0.##}\n", result);
                    }
                    // Lógica para la raíz cuadrada, que solo necesita un número
                    else if (op == "6")
                    {
                        Console.Write("Escribe el número para calcular su raíz y presiona Enter: ");
                        double num = Convert.ToDouble(Console.ReadLine());

                        // Math.Sqrt se usa para la raíz cuadrada
                        result = Math.Sqrt(num);
                        Console.WriteLine("Tu resultado: {0:0.##}\n", result);
                    }
                    else
                    {
                        Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: El formato de entrada no es válido. Por favor, introduce un número.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ha ocurrido un error inesperado: " + ex.Message + "\n");
                }

                // Pregunta al usuario si quiere cerrar la aplicación
                Console.Write("Presiona 's' y Enter para salir, o cualquier otra tecla y Enter para continuar: ");
                if (Console.ReadLine() == "s")
                {
                    endApp = true;
                }

                Console.WriteLine("\n"); // Línea en blanco para separar
            }
            return;
        }
    }
}