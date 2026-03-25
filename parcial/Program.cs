using System;
using System.Collections.Generic;

Dictionary<string, Habitacion> habitaciones = new Dictionary<string, Habitacion>();
bool correcto;
int op;
do
{
    Console.WriteLine("Bienvenido al menu");
    Console.WriteLine("1. Agregar habitacion");
    Console.WriteLine("2. Modificar habitacion");
    Console.WriteLine("3. Eliminar habitacion");
    Console.WriteLine("4. Buscar habitacion");
    Console.WriteLine("5. Mostrar todas las habitaciones");
    Console.WriteLine("6. Registrar reservacion");
    Console.WriteLine("7. Registrar salida de huesped");
    Console.WriteLine("8. Mostrar la habitacion mas cara");
    Console.WriteLine("9. Mostrar la habitacion con menor cantidad de noches reservada");
    Console.WriteLine("10. Mostrar el valor total estimado de reservaciones");
    Console.WriteLine("11. Salir");
    Console.WriteLine("Ingrese la opcion en numeros");
    correcto = int.TryParse(Console.ReadLine(), out op);
    if (!correcto)
    {
        Console.WriteLine("Debe ingresar la opcion en numero enteros");
    }
    else
    {
        switch (op)
        {
            case 1:
                string op1;
                bool correcto1, correcto2;
                do
                {
                    Habitacion h = new Habitacion();
                    Console.WriteLine("Ingrese el codigo de habitacion");
                    Codigo = Console.ReadLine();
                    if (habitaciones.ContainsKey(Codigo))
                    {
                        Console.WriteLine("Error, el codigo ya existe en otra habitacion");
                    }
                    else
                    {
                        Console.WriteLine("Ingrese el tipo de habitacion");
                        h.Tipo = Console.ReadLine();
                        Console.WriteLine("Ingrese el precio por noche");
                        correcto2 = double.TryParse(Console.ReadLine(), out h.PrecioporNoche);
                        if (!correcto)
                        {
                            Console.WriteLine("Error debe ingresar los numeros enteros");
                        }
                        else
                        {
                            Console.WriteLine("Cantidad de noches reservadas");
                            correcto1 = int.TryParse(Console.ReadLine(), out h.CantidaddeNoches);
                            if (!correcto1)
                            {
                                Console.WriteLine("Debe ingresar la cantidad en numero enteros");
                            }
                            else
                            {
                                Console.WriteLine("Estado de la habitacion");
                                h.Estado = Console.ReadLine();
                            }
                        }
                    }
                    Codigo = h.Codigo;
                    habitaciones.Add(Codigo, h);
                    Console.WriteLine("SE HA AGREGADO CON EXITO");
                    Console.WriteLine("Desea ingresar otra habitacion? (s/n)");
                    op1 = Console.ReadLine();
                } while (op1 != "n");
                break;
            case 2:
                Console.WriteLine("Ingrese el codigo de la habitacion que desea modificar");
                string buscar = Console.ReadLine();
                if (habitaciones.ContainsKey(buscar))
                {
                    Console.WriteLine("Ingrese el nuevo tipo de habitacion");
                    habitaciones[buscar].Tipo = Console.ReadLine();
                    Console.WriteLine("Ingrese el precio por noche");
                    habitaciones[buscar].PrecioporNoche = double.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese la cantidad de noches");
                    habitaciones[buscar].CantidaddeNoches = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el estado");
                    habitaciones[buscar].Estado = Console.ReadLine();
                    Console.WriteLine("SE HA MODIFICADO CON EXITO");
                }
                else
                {
                    Console.WriteLine("No se ha encontrado un producto con ese codigo");
                }
                break;
            case 3:
                string buscar1;
                Console.WriteLine("Ingrese el codigo de habitacion");
                buscar1 = Console.ReadLine();
                if (habitaciones.ContainsKey(buscar1))
                {
                    habitaciones.Remove(buscar1);
                    Console.WriteLine("SE HA ELIMINADO CON EXITO");
                }
                else
                {
                    Console.WriteLine("No se ha encontrado un producto con ese nombre");
                }
                break;
            case 4:
                {
                    Console.WriteLine("Ingrese el codigo de la habitacion");
                    string buscar2 = Console.ReadLine();
                    if (habitaciones.ContainsKey(buscar2))
                    {
                        Habitacion h = habitaciones[buscar2];
                        Console.WriteLine($"Codigo {h.Codigo}");
                        Console.WriteLine($"Tipo {h.Tipo}");
                        Console.WriteLine($"precio por noche {h.PrecioporNoche}");
                        Console.WriteLine($"Cantidad de noches {h.CantidaddeNoches}");
                        Console.WriteLine($"Estado {h.Estado}");
                    }
                }
                break;
            case 5:
                foreach (var h in habitaciones)
                {
                    Console.WriteLine(h);
                }
                break;
            case 6:

                break;
            case 7:
                break;
            case 8:

                break;
            case 9:
                break;
            case 10:
                double suma = 0;
                foreach (var h in habitaciones)
                {
                    suma += h.ValorEstimado();
                }
                Console.WriteLine($"Eltotal es {suma}");
                break;
            case 11:
                Console.WriteLine("Saliendo...");
                break;
            default:
                Console.WriteLine("Error, opcion invalida");
                break;
        }
    }
} while (op != 11);
class Habitacion
{
    public string Codigo;
    public string Tipo;
    public double PrecioporNoche;
    public int CantidaddeNoches;
    public string Estado;
    public double ValorEstimado()
    {
        return PrecioporNoche * CantidaddeNoches;
    }
}

