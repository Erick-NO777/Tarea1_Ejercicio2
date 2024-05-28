using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tarea1_Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                // Valor 0 a las variables de las estadisticas
                int cantidadSol = 0, cantidadSombra = 0, cantidadPreferencial = 0;
                decimal acumuladoSol = 0, acumuladoSombra = 0, acumuladoPreferencial = 0;

                Console.WriteLine("BIENVENIDOS A TICKETSYSTEM CR");
                Console.WriteLine();

                while (true) // Crea otro Bucle para la pregunta interior
                {
                    // Variables del comprador
                    string factura, cedula, nombre;
                    string nombreLocalidad = "";
                    int localidad, cantidadEntradas;
                    decimal precioEntrada = 0, subtotal, cargosPorServicios, totalPagar;

                    // Datos del comprador
                    Console.Write("Digite el numero de factura: ");
                    factura = Console.ReadLine();

                    Console.Write("Digite su cedula: ");
                    cedula = Console.ReadLine();

                    Console.Write("Digite su nombre: ");
                    nombre = Console.ReadLine();

                    // Valida la localidad
                    Console.Write("Ingrese la localidad que desea comprar (1 = Sol Norte/Sur, 2 = Sombra Este/Oeste, 3 = Preferencial): ");
                    localidad = int.Parse(Console.ReadLine());
                    while (localidad < 1 || localidad > 3) // Muestra error en caso de que el numero no este entre el rango 1-3
                    {
                        Console.WriteLine();
                        Console.Write("ERROR...localidad no encontrada. Intente de nuevo (1 = Sol Norte/Sur, 2 = Sombra Este/Oeste, 3 = Preferencial): ");
                        localidad = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                    }

                    // Asigna el precio y nombre de localidad
                    if (localidad == 1)
                    {
                        precioEntrada = 10500;
                        nombreLocalidad = "Sol Norte/Sur";
                    }
                    else if (localidad == 2)
                    {
                        precioEntrada = 20500;
                        nombreLocalidad = "Sombra Este/Oeste";
                    }
                    else if (localidad == 3)
                    {
                        precioEntrada = 25500;
                        nombreLocalidad = "Preferencial";
                    }

                    // Valida la cantidad de entradas
                    Console.Write("Ingrese la cantidad de entradas que desea comprar (maximo 4): ");
                    cantidadEntradas = int.Parse(Console.ReadLine());
                    while (cantidadEntradas < 1 || cantidadEntradas > 4)
                    {
                        Console.WriteLine(); 
                        Console.Write("Lo sentimos, solo se puede hasta 4 entradas por factura. Intente de nuevo: ");
                        cantidadEntradas = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                    }

                    // Subtotal, cargos por servicios y total a pagar
                    subtotal = cantidadEntradas * precioEntrada;
                    cargosPorServicios = cantidadEntradas * 1000;
                    totalPagar = subtotal + cargosPorServicios;

                    // Mostrar resultados de la venta
                    Console.WriteLine();
                    Console.WriteLine("RESUMEN DE COMPRA");
                    Thread.Sleep(1000); // Espera un segundo para continuar
                    Console.WriteLine();
                    Console.WriteLine($"Numero de Factura: {factura}");
                    Console.WriteLine($"Cedula: {cedula}");
                    Console.WriteLine($"Nombre del Comprador: {nombre}");
                    Console.WriteLine($"Localidad: {nombreLocalidad}");
                    Console.WriteLine($"Cantidad de Entradas: {cantidadEntradas}");
                    Console.WriteLine($"Subtotal: {subtotal:F2}");
                    Console.WriteLine($"Cargos por Servicios: {cargosPorServicios:F2}");
                    Console.WriteLine($"Total a Pagar: {totalPagar:F2}");
                    Thread.Sleep(2000);

                    // Actualiza las estadisticas segun el tipo de localidad
                    if (localidad == 1)
                    {
                        cantidadSol += cantidadEntradas;
                        acumuladoSol += subtotal;
                    }
                    else if (localidad == 2)
                    {
                        cantidadSombra += cantidadEntradas;
                        acumuladoSombra += subtotal;
                    }
                    else if (localidad == 3)
                    {
                        cantidadPreferencial += cantidadEntradas;
                        acumuladoPreferencial += subtotal;
                    }

                    // Pregunta si desea continuar con otra compra
                    Console.WriteLine();
                    Console.Write("¿Desea hacer otra compra? (S/N): ");
                    char respuesta = char.ToUpper(Console.ReadKey().KeyChar);
                    Console.WriteLine();
                    continuar = respuesta == 'S';

                    if (!continuar)
                    {
                        break;
                    }

                    // Esperar 1 segundo antes de continuar
                    Thread.Sleep(1000);

                    Console.WriteLine();
                }

                // Mostrar estadisticas finales
                Console.WriteLine();
                Console.WriteLine("ESTADISTICAS FINALES");
                Thread.Sleep(1000);
                Console.WriteLine();
                Console.WriteLine($"Cantidad de Entradas Localidad Sol Norte/Sur: {cantidadSol}");
                Console.WriteLine($"Acumulado de Dinero Localidad Sol Norte/Sur: {acumuladoSol:F2}");
                Console.WriteLine($"Cantidad de Entradas Localidad Sombra Este/Oeste: {cantidadSombra}");
                Console.WriteLine($"Acumulado de Dinero Localidad Sombra Este/Oeste: {acumuladoSombra:F2}");
                Console.WriteLine($"Cantidad de Entradas Localidad Preferencial: {cantidadPreferencial}");
                Console.WriteLine($"Acumulado de Dinero Localidad Preferencial: {acumuladoPreferencial:F2}");
                Console.WriteLine();
                Thread.Sleep(2000);

                // Preguntar si desea continuar
                Console.Write("¿Desea volver a empezar? (S/N): ");
                char reiniciar = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();
                continuar = reiniciar == 'S';
                    
                if (continuar)
                {
                    Console.WriteLine("Reiniciando el programa...");
                    Thread.Sleep(2500); // Esperar 2.5 segundo antes de continuar
                    Console.Clear(); // Limpiar la consola para empezar de nuevo
                }
                
                Console.WriteLine();
                
            }
        }
    }
}