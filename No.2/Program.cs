using System;
using System.Collections.Generic;
using System.Xml;
Dictionary<string, Vehiculo> vehiculos = new Dictionary<string, Vehiculo>();
int op;
do
{
    Console.WriteLine("Bienvenido al menu");
    Console.WriteLine("1. Registrar vehiculo");
    Console.WriteLine("2. Modificar informacion de un vehiculo");
    Console.WriteLine("3. Eliminar un vehiculo");
    Console.WriteLine("4. Buscar un vehiculo");
    Console.WriteLine("5. Mostrar todos los vehiculos");
    Console.WriteLine("6. Registrar un alquiler");
    Console.WriteLine("7. Registrar devolucion");
    Console.WriteLine("8. Salir");
    Console.WriteLine("Seleccione la opcion que necesita");
    op = int.Parse(Console.ReadLine());
    switch (op)
    {
        case 1:
            string op1;
            do
            {
                bool correcto, correctoC, correctoA;
                Vehiculo v = new Vehiculo();
                Console.WriteLine("Ingrese el identificador del vehiculo");
                v.Identificador = Console.ReadLine();
                if (vehiculos.ContainsKey(v.Identificador))
                {
                    Console.WriteLine("Error, el identificador ya existe");
                }
                else
                {
                    Console.WriteLine("Ingrese la marca");
                    v.Marca = Console.ReadLine();
                    do
                    {
                        Console.WriteLine("Ingrese el modelo");
                        correcto = int.TryParse(Console.ReadLine(), out v.Modelo);
                    } while (!correcto || v.Modelo < 0);
                    do
                    {
                        Console.WriteLine("Ingrese el costo por dia");
                        correctoC = double.TryParse(Console.ReadLine(), out v.CostoPorDia);
                    } while (!correctoC || v.CostoPorDia < 0);
                    do
                    {
                        Console.WriteLine("Ingrese los dias alquilados");
                        correctoA = int.TryParse(Console.ReadLine(), out v.DiasAlquilado);
                    } while (!correctoA || v.DiasAlquilado < 0);
                    Console.WriteLine("Ingrese el estado (disponible o no)");
                    vehiculos.Add(v.Identificador, v);
                    v.Estado = Console.ReadLine();
                    vehiculos.Add(v.Identificador, v);

                }
                Console.WriteLine("Desea registrar otro vehiculo? (s/n)");
                op1 = Console.ReadLine();
            } while (op1 != "n" && op1 != "N");
            break;
        case 2:
            Console.WriteLine("Ingrese el identificador del vehiculo");
            string buscar = Console.ReadLine();
            if (vehiculos.ContainsKey(buscar))
            {
                Vehiculo ve = vehiculos[buscar];
                Console.WriteLine("Ingrese la marca");
                ve.Marca = Console.ReadLine();
                bool c3, c4, c5;
                do
                {
                    Console.WriteLine("Ingrese el modelo");
                    c3 = int.TryParse(Console.ReadLine(), out ve.Modelo);
                } while (!c3||ve.Modelo<0);
                do
                {
                    Console.WriteLine("Ingrese el costo por dia");
                    c4 = double.TryParse(Console.ReadLine(), out ve.CostoPorDia);
                } while (!c4 || ve.CostoPorDia < 0);
                do
                {
                    Console.WriteLine("Ingrese los dias alquilados");
                    c5 = int.TryParse(Console.ReadLine(), out ve.DiasAlquilado);
                } while (!c5||ve.DiasAlquilado<0);
                Console.WriteLine("Ingrese el estado (disponible o no)");
                ve.Estado = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("No se ha encontrado el vehiculo con ese identificador");
            }
            break;
        case 3:
            Console.WriteLine("Ingrese el identificador del vehiculo");
            string buscar2 = Console.ReadLine();
            if (vehiculos.ContainsKey(buscar2))
            {
                vehiculos.Remove(buscar2);
                Console.WriteLine("VEHICULO ELIMINADO CON EXITO");
            }
            break;
        case 4:
            Console.WriteLine("Ingrese el identificador del vehiculo");
            string buscar3 = Console.ReadLine();
            if (vehiculos.ContainsKey(buscar3))
            {
                Console.WriteLine("Vehiculo encotrado");
                Vehiculo ve = vehiculos[buscar3];
                Console.WriteLine(ve.Identificador);
                Console.WriteLine(ve.Marca);
                Console.WriteLine(ve.Modelo);
                Console.WriteLine(ve.CostoPorDia);
                Console.WriteLine(ve.DiasAlquilado);
                Console.WriteLine(ve.Estado);
            }
            else
            {
                Console.WriteLine("El identificador no ha sido encontrado");
            }
            break;
        case 5:
            Console.WriteLine("Vehiculos registrados");
            if(vehiculos.Count<0)
            {
                Console.WriteLine("No se han registrado vehiculos");
            }
            else
            {
                foreach(var ve in vehiculos.Values)
                {
                    Console.WriteLine($"identificador: {ve.Identificador}, marca {ve.Marca}, Modelo: {ve.Modelo}, Costo por dia: {ve.CostoPorDia}, dias alquilados: {ve.DiasAlquilado}, estado {ve.Estado}");
                }
            }
            break;
        case 6:
            Console.WriteLine("Ingrese el identificador del vehiculo");
            string identificador1= Console.ReadLine();
            if(vehiculos.ContainsKey(identificador1))
            {
                if (vehiculos[identificador1].Estado == "Disponible" || vehiculos[identificador1].Estado == "disponible")
                {
                    int dias;
                    bool dialsaq;
                    do
                    {
                        Console.WriteLine("Ingrese la cantidad de dias a reservar");
                        dialsaq = int.TryParse(Console.ReadLine(), out dias);
                    } while (!dialsaq||dias<0);
                    vehiculos[identificador1].DiasAlquilado = dias;
                    vehiculos[identificador1].Estado = "No disponible";
                    double total = dias * vehiculos[identificador1].CostoPorDia;
                    Console.WriteLine($"Total a pagar {total}");
                }
            }
            break;
        case 7:
            Console.WriteLine("Ingrese el identificador del vehiculo");
            string identificador2= Console.ReadLine();
            if(vehiculos.ContainsKey(identificador2))
            {
                vehiculos[identificador2].Estado = "Disponible";
                vehiculos[identificador2].DiasAlquilado=0;
                Console.WriteLine("Operacion realizada con exito");
            }
            else
            {
                Console.WriteLine("No se encontro el vehiculo");
            }
            break;
        default:
            Console.WriteLine("error, opcion invalida");
            break;
    }
} while (op != 8);
class Vehiculo
{
    public string Identificador;
    public string Marca;
    public int Modelo;
    public double CostoPorDia;
    public int DiasAlquilado;
    public string Estado;
}