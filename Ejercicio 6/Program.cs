using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana_6
{
    // Definición de la clase Nodo
    class Nodo
    {
        public int Dato; // Valor del nodo
        public Nodo Siguiente; // Referencia al siguiente nodo

        // Constructor que inicializa el nodo con un dato
        public Nodo(int dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    // Definición de la clase ListaEnlazada
    class ListaEnlazada
    {
        public Nodo Cabeza; // Referencia al primer nodo de la lista

        // Constructor que inicializa la lista vacía
        public ListaEnlazada()
        {
            Cabeza = null;
        }

        // Método para insertar un nuevo nodo al final de la lista
        public void Insertar(int dato)
        {
            Nodo nuevoNodo = new Nodo(dato);
            if (Cabeza == null)
            {
                Cabeza = nuevoNodo; // Si la lista está vacía, el nuevo nodo es la cabeza
            }
            else
            {
                Nodo actual = Cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente; // Recorrer hasta el último nodo
                }
                actual.Siguiente = nuevoNodo; // Añadir el nuevo nodo al final
            }
        }

        // Método para eliminar nodos cuyo valor esté fuera del rango especificado
        public void EliminarNodosFueraDeRango(int min, int max)
        {
            // Eliminar nodos de la cabeza si están fuera del rango
            while (Cabeza != null && (Cabeza.Dato < min || Cabeza.Dato > max))
            {
                Cabeza = Cabeza.Siguiente;
            }

            if (Cabeza == null) return; // Si la lista queda vacía, terminar el método

            Nodo actual = Cabeza;
            while (actual.Siguiente != null)
            {
                if (actual.Siguiente.Dato < min || actual.Siguiente.Dato > max)
                {
                    // Eliminar el nodo que está fuera del rango
                    actual.Siguiente = actual.Siguiente.Siguiente;
                }
                else
                {
                    actual = actual.Siguiente; // Avanzar al siguiente nodo
                }
            }
        }

        // Método para imprimir todos los valores de los nodos en la lista
        public void Imprimir()
        {
            Nodo actual = Cabeza;
            while (actual != null)
            {
                Console.Write(actual.Dato + " "); // Imprimir el dato del nodo
                actual = actual.Siguiente; // Avanzar al siguiente nodo
            }
            Console.WriteLine(); // Nueva línea al final de la impresión
        }
    }

    // Clase principal para ejecutar el programa
    class Program
    {
        static void Main()
        {
            ListaEnlazada lista = new ListaEnlazada();
            Random rand = new Random();

            // Generar y añadir 50 números aleatorios a la lista
            for (int i = 0; i < 50; i++)
            {
                lista.Insertar(rand.Next(1, 1000)); // Números entre 1 y 999
            }

            Console.WriteLine("Lista original:");
            lista.Imprimir(); // Imprimir la lista original

            // Leer el rango de valores desde el teclado
            Console.Write("Ingrese el valor mínimo del rango: ");
            int min = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el valor máximo del rango: ");
            int max = int.Parse(Console.ReadLine());

            // Eliminar nodos fuera del rango especificado
            lista.EliminarNodosFueraDeRango(min, max);

            Console.WriteLine("Lista después de eliminar nodos fuera del rango:");
            lista.Imprimir(); // Imprimir la lista después de la eliminación
            Console.Read();
        }
    }
}
