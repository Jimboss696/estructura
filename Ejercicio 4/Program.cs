using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana_6.Ejercicio_4
{
    // Definición de la clase Estudiante
    class Estudiante
    {
        public string Cedula;
        public string Nombre;
        public string Apellido;
        public string Correo;
        public double Nota;
        public Estudiante Siguiente;

        // Constructor que inicializa un estudiante con sus datos
        public Estudiante(string cedula, string nombre, string apellido, string correo, double nota)
        {
            Cedula = cedula;
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            Nota = nota;
            Siguiente = null;
        }
    }

    // Definición de la clase ListaEnlazada
    class ListaEnlazada
    {
        private Estudiante Cabeza;
        private int Aprobados;
        private int Reprobados;

        // Constructor que inicializa la lista vacía
        public ListaEnlazada()
        {
            Cabeza = null;
            Aprobados = 0;
            Reprobados = 0;
        }

        // Método para agregar un estudiante a la lista
        public void AgregarEstudiante(Estudiante nuevoEstudiante)
        {
            if (nuevoEstudiante.Nota >= 6)
            {
                // Insertar al inicio si el estudiante está aprobado
                nuevoEstudiante.Siguiente = Cabeza;
                Cabeza = nuevoEstudiante;
                Aprobados++;
            }
            else
            {
                // Insertar al final si el estudiante está reprobado
                if (Cabeza == null)
                {
                    Cabeza = nuevoEstudiante;
                }
                else
                {
                    Estudiante actual = Cabeza;
                    while (actual.Siguiente != null)
                    {
                        actual = actual.Siguiente;
                    }
                    actual.Siguiente = nuevoEstudiante;
                }
                Reprobados++;
            }
        }

        // Método para buscar un estudiante por cédula
        public Estudiante BuscarEstudiante(string cedula)
        {
            Estudiante actual = Cabeza;
            while (actual != null)
            {
                if (actual.Cedula == cedula)
                {
                    return actual;
                }
                actual = actual.Siguiente;
            }
            return null; // Retornar null si no se encuentra el estudiante
        }

        // Método para eliminar un estudiante por cédula
        public bool EliminarEstudiante(string cedula)
        {
            if (Cabeza == null)
            {
                return false; // La lista está vacía
            }

            if (Cabeza.Cedula == cedula)
            {
                if (Cabeza.Nota >= 6) Aprobados--;
                else Reprobados--;
                Cabeza = Cabeza.Siguiente; // Eliminar la cabeza de la lista
                return true;
            }

            Estudiante actual = Cabeza;
            while (actual.Siguiente != null && actual.Siguiente.Cedula != cedula)
            {
                actual = actual.Siguiente;
            }

            if (actual.Siguiente == null)
            {
                return false; // No se encontró el estudiante
            }

            if (actual.Siguiente.Nota >= 6) Aprobados--;
            else Reprobados--;
            actual.Siguiente = actual.Siguiente.Siguiente; // Eliminar el nodo encontrado
            return true;
        }

        // Método para obtener el total de estudiantes aprobados
        public int TotalAprobados()
        {
            return Aprobados;
        }

        // Método para obtener el total de estudiantes reprobados
        public int TotalReprobados()
        {
            return Reprobados;
        }

        // Método para imprimir todos los estudiantes
        public void ImprimirEstudiantes()
        {
            Estudiante actual = Cabeza;
            while (actual != null)
            {
                Console.WriteLine($"{actual.Nombre} {actual.Apellido}, Cédula: {actual.Cedula}, Correo: {actual.Correo}, Nota: {actual.Nota}");
                actual = actual.Siguiente;
            }
        }
    }

    // Clase principal para ejecutar el programa
    class Program
    {
        static void Main()
        {
            ListaEnlazada listaEstudiantes = new ListaEnlazada();

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Agregar estudiante");
                Console.WriteLine("2. Buscar estudiante por cédula");
                Console.WriteLine("3. Eliminar estudiante");
                Console.WriteLine("4. Total estudiantes aprobados");
                Console.WriteLine("5. Total estudiantes reprobados");
                Console.WriteLine("6. Imprimir todos los estudiantes");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        // Agregar estudiante
                        Console.Write("Ingrese la cédula: ");
                        string cedula = Console.ReadLine();
                        Console.Write("Ingrese el nombre: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Ingrese el apellido: ");
                        string apellido = Console.ReadLine();
                        Console.Write("Ingrese el correo: ");
                        string correo = Console.ReadLine();
                        Console.Write("Ingrese la nota definitiva (1-10): ");
                        double nota = double.Parse(Console.ReadLine());
                        Estudiante nuevoEstudiante = new Estudiante(cedula, nombre, apellido, correo, nota);
                        listaEstudiantes.AgregarEstudiante(nuevoEstudiante);
                        Console.WriteLine("Estudiante agregado exitosamente.");
                        break;

                    case 2:
                        // Buscar estudiante por cédula
                        Console.Write("Ingrese la cédula del estudiante a buscar: ");
                        cedula = Console.ReadLine();
                        Estudiante estudianteEncontrado = listaEstudiantes.BuscarEstudiante(cedula);
                        if (estudianteEncontrado != null)
                        {
                            Console.WriteLine($"Estudiante encontrado: {estudianteEncontrado.Nombre} {estudianteEncontrado.Apellido}, Correo: {estudianteEncontrado.Correo}, Nota: {estudianteEncontrado.Nota}");
                        }
                        else
                        {
                            Console.WriteLine("Estudiante no encontrado.");
                        }
                        break;

                    case 3:
                        // Eliminar estudiante
                        Console.Write("Ingrese la cédula del estudiante a eliminar: ");
                        cedula = Console.ReadLine();
                        if (listaEstudiantes.EliminarEstudiante(cedula))
                        {
                            Console.WriteLine("Estudiante eliminado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("Estudiante no encontrado.");
                        }
                        break;

                    case 4:
                        // Total estudiantes aprobados
                        Console.WriteLine($"Total de estudiantes aprobados: {listaEstudiantes.TotalAprobados()}");
                        break;

                    case 5:
                        // Total estudiantes reprobados
                        Console.WriteLine($"Total de estudiantes reprobados: {listaEstudiantes.TotalReprobados()}");
                        break;

                    case 6:
                        // Imprimir todos los estudiantes
                        Console.WriteLine("Lista de estudiantes:");
                        listaEstudiantes.ImprimirEstudiantes();
                        break;

                    case 7:
                        // Salir
                        return;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                } 
            }
        }
    }
}
