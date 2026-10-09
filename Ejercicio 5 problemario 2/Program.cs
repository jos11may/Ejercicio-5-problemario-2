
using System;

// Clase que representa un servomotor
class Servomotor
{
    // Propiedades del servomotor
    public double PosicionActual { get; set; }
    public double PosicionObjetivo { get; set; }

    // Metodo para calcular el desplazamiento absoluto
    public double CalcularDesplazamiento()
    {
        return Math.Abs(PosicionObjetivo - PosicionActual);
    }

    // Metodo para determinar la direccion del movimiento
    public string ObtenerDireccion()
    {
        if (PosicionObjetivo > PosicionActual)
        {
            return "Movimiento hacia una posicion mayor";
        }
        else if (PosicionObjetivo < PosicionActual)
        {
            return "Movimiento hacia una posicion menor";
        }
        else
        {
            return "No hay movimiento";
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("==================================");
        Console.WriteLine(" CONTROL DE POSICION DE SERVOMOTOR");
        Console.WriteLine("==================================");

        // Crear un objeto de la clase Servomotor
        Servomotor motor1 = new Servomotor();

        // Capturar y validar la posicion actual
        do
        {
            Console.Write("Posicion actual (0 a 180 grados): ");

            if (!double.TryParse(Console.ReadLine(),
                out double posicion))
            {
                motor1.PosicionActual = -1;
                Console.WriteLine("Entrada invalida. Escriba un numero.");
            }
            else
            {
                motor1.PosicionActual = posicion;
            }

            if (motor1.PosicionActual < 0 ||
                motor1.PosicionActual > 180)
            {
                Console.WriteLine(
                    "Error: la posicion debe estar entre 0 y 180 grados.");
            }

        } while (motor1.PosicionActual < 0 ||
                 motor1.PosicionActual > 180);

        // Capturar y validar la posicion objetivo
        do
        {
            Console.Write("Posicion objetivo (0 a 180 grados): ");

            if (!double.TryParse(Console.ReadLine(),
                out double posicion))
            {
                motor1.PosicionObjetivo = -1;
                Console.WriteLine("Entrada invalida. Escriba un numero.");
            }
            else
            {
                motor1.PosicionObjetivo = posicion;
            }

            if (motor1.PosicionObjetivo < 0 ||
                motor1.PosicionObjetivo > 180)
            {
                Console.WriteLine(
                    "Error: la posicion debe estar entre 0 y 180 grados.");
            }

        } while (motor1.PosicionObjetivo < 0 ||
                 motor1.PosicionObjetivo > 180);

        // Mostrar resultados
        Console.WriteLine();
        Console.WriteLine("========== RESULTADOS ==========");
        Console.WriteLine(
            $"Posicion actual: {motor1.PosicionActual} grados");
        Console.WriteLine(
            $"Posicion objetivo: {motor1.PosicionObjetivo} grados");
        Console.WriteLine(
            $"Desplazamiento: {motor1.CalcularDesplazamiento()} grados");
        Console.WriteLine(
            $"Direccion: {motor1.ObtenerDireccion()}");

        Console.WriteLine("================================");
        Console.WriteLine("Presione una tecla para finalizar.");
        Console.ReadKey();
    }
}