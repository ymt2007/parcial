using System;
using System.Collections.Generic;
Dictionary<string, Habitacion> habitaciones = new Dictionary<string, Habitacion>();
bool correcto;
int op;
do
{
    Console.WriteLine("MENU HOTEL");
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
    Console.Write("Ingrese la opcion: ");
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
                do
                {
                    Habitacion h = new Habitacion();
                    Console.WriteLine("Ingrese el codigo de habitacion");
                    h.Codigo = Console.ReadLine();
                    if (habitaciones.ContainsKey(h.Codigo))
                    {
                        Console.WriteLine("Error, el codigo ya existe");
                    }
                    else
                    {
                        Console.WriteLine("Ingrese el tipo de habitacion");
                        h.Tipo = Console.ReadLine();
                        bool pCorrecto;
                        do
                        {
                            Console.WriteLine("Ingrese el precio por noche");
                            pCorrecto = double.TryParse(Console.ReadLine(), out h.PrecioporNoche);
                        } while (!pCorrecto || h.PrecioporNoche < 0);
                        bool nCorrecto;
                        do
                        {
                            Console.WriteLine("Cantidad de noches reservadas");
                            nCorrecto = int.TryParse(Console.ReadLine(), out h.CantidaddeNoches);
                        } while (!nCorrecto || h.CantidaddeNoches < 0);
                        Console.WriteLine("Estado de la habitacion");
                        h.Estado = Console.ReadLine();
                        habitaciones.Add(h.Codigo, h);
                        Console.WriteLine("SE HA AGREGADO CON EXITO");
                    }
                    Console.WriteLine("Desea ingresar otra habitacion? (s/n)");
                    op1 = Console.ReadLine();
                } while (op1 != "n" && op1 != "N");
                break;
            case 2:
                Console.WriteLine("Ingrese el codigo a modificar");
                string buscar = Console.ReadLine();
                if (habitaciones.ContainsKey(buscar))
                {
                    Console.WriteLine("Nuevo tipo:");
                    habitaciones[buscar].Tipo = Console.ReadLine();
                    double pMod;
                    do 
                    { 
                        Console.WriteLine("Nuevo precio:"); 
                    }while (!double.TryParse(Console.ReadLine(), out pMod) || pMod < 0);
                    habitaciones[buscar].PrecioporNoche = pMod;
                    int nMod;
                    do 
                    {
                        Console.WriteLine("Nuevas noches:"); 
                    }while (!int.TryParse(Console.ReadLine(), out nMod) || nMod < 0);
                    habitaciones[buscar].CantidaddeNoches = nMod;
                    Console.WriteLine("Nuevo estado:");
                    habitaciones[buscar].Estado = Console.ReadLine();
                    Console.WriteLine("MODIFICADO CON EXITO");
                }
                else 
                {
                    Console.WriteLine("No encontrado"); 
                }
                break;
            case 3:
                Console.WriteLine("Codigo a eliminar:");
                string eliminar = Console.ReadLine();
                if (habitaciones.ContainsKey(eliminar))
                {
                    habitaciones.Remove(eliminar);
                    Console.WriteLine("ELIMINADO");
                }
                else 
                {
                    Console.WriteLine("No encontrado"); 
                }
                break;
            case 4:
                Console.WriteLine("Codigo a buscar:");
                string bCod = Console.ReadLine();
                if (habitaciones.ContainsKey(bCod))
                {
                    Habitacion hab = habitaciones[bCod];
                    Console.WriteLine($"Codigo: {hab.Codigo}, Tipo: {hab.Tipo}, Precio: {hab.PrecioporNoche}, Noches: {hab.CantidaddeNoches}, Estado: {hab.Estado}");
                }
                else 
                {
                    Console.WriteLine("No existe"); 
                }
                break;
            case 5:
                foreach (var hab in habitaciones.Values)
                {
                    Console.WriteLine($"Hab: {hab.Codigo} {hab.Tipo}  Q{hab.PrecioporNoche} {hab.Estado}");
                }
                break;
            case 6:
                Console.WriteLine("Codigo para reserva:");
                string cRes = Console.ReadLine();
                if (habitaciones.ContainsKey(cRes))
                {
                    if (habitaciones[cRes].Estado == "Disponible" || habitaciones[cRes].Estado == "disponible")
                    {
                        Console.WriteLine("Cuantas noches?");
                        int nuevas;
                        int.TryParse(Console.ReadLine(), out nuevas);
                        habitaciones[cRes].CantidaddeNoches += nuevas;
                        habitaciones[cRes].Estado = "Ocupada";
                        Console.WriteLine($"Subtotal: {nuevas * habitaciones[cRes].PrecioporNoche}");
                    }
                    else 
                    {
                        Console.WriteLine("No esta disponible"); 
                    }
                }
                else 
                {
                    Console.WriteLine("No encontrada"); 
                }
                break;
            case 7:
                Console.WriteLine("Codigo para salida:");
                string cSal = Console.ReadLine();
                if (habitaciones.ContainsKey(cSal))
                {
                    habitaciones[cSal].Estado = "Disponible";
                    habitaciones[cSal].CantidaddeNoches = 0;
                    Console.WriteLine("Salida registrada");
                }
                break;
            case 8:
                if (habitaciones.Count > 0)
                {
                    Habitacion max = new Habitacion();
                    bool esPrimero = true;
                    foreach (var h in habitaciones.Values)
                    {
                        if (esPrimero) 
                        {
                            max = h; 
                            esPrimero = false; 
                        }
                        else if (h.PrecioporNoche > max.PrecioporNoche) 
                        {
                            max = h; 
                        }
                    }
                    Console.WriteLine($"La mas cara es {max.Codigo} (${max.PrecioporNoche})");
                }
                break;
            case 9:
                if (habitaciones.Count > 0)
                {
                    Habitacion min = new Habitacion();
                    bool esPrimero = true;
                    foreach (var h in habitaciones.Values)
                    {
                        if (esPrimero) 
                        {
                            min = h; 
                            esPrimero = false; 
                        }
                        else if (h.CantidaddeNoches < min.CantidaddeNoches) 
                        {
                            min = h; 
                        }
                    }
                    Console.WriteLine($"Menos noches: {min.Codigo} ({min.CantidaddeNoches} noches)");
                }
                break;
            case 10:
                double suma = 0;
                foreach (var h in habitaciones.Values)
                {
                    suma += h.ValorEstimado();
                }
                Console.WriteLine($"Total estimado: ${suma}");
                break;
            case 11:
                Console.WriteLine("Saliendo...");
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