using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
    class Pila
    {

        // Variables.
        public int Size { get; set; }    //Representa el tamaño de la cantidad de discos que hay en una pila.
        public int Top { get; set; }     //Representa el valor del disco que esté en la parte superior. Se actualiza cada vez que se quita y se pone un disco nuevo en una pila.
        public List<Disco> Elementos { get; set; }  //Almacena los discos de las pilas. Gestiona las pilas, es decir, si se añade, elimina, consulta, etc.



        //Constructor 1 vacio
        public Pila()
        {
            Size = 0;  //empieza sin discos la pila. 
            Elementos = new List<Disco>(); //Inicializa lista vacia.
            Top = 0; //No hay ningún disco en la pila.
        }

        //Constructor 2 
        public Pila(int Size)
        {
            this.Size = Size;           //asigna el tamaño de la pila.
            Elementos = new List<Disco>(); //Inicializa lista vacia.
            Top = -1; //para indicar que, inicialmente, no hay ningún disco en la pila.

            for (int i = this.Size; i > 0; i--) // se usa para agregar discos y disminuye i en cada iteración hasta llegar a 1.
            {
                Elementos.Add(new Disco(i));
                Top = Elementos.Last().Valor;//Top se actualiza con el valor del último disco añadido.
            }
        }

 
        public void push(Disco d)  //Añade un disco de valor d.
        {
            Elementos.Add(d);   //Hace un push, donde añade el disco d a la lista creada "Elementos".
            Top = Elementos.Last().Valor;  //Actualiza el valor top.
        }


        //Metodo para eliminar un disco de la pila
        public Disco pop()
        {
            Disco d = Elementos.Last(); //obtiene el último disco de la lista. 
            Elementos.Remove(d); //lo elimina.

            //Esto maneja cualquier excepción que pueda ocurrir al
            //intentar acceder al último elemento de la lista después
            //de haber eliminado un disco. Si la lista está vacía después
            //de eliminar el disco superior, se generaría una excepción.
            try
            {
                Top = Elementos.Last().Valor;
            }
            catch (Exception)
            {
                Top = 0;
            }
            return d;
        }


        //Metodo para saber si la lista elementos esta vacia.
        public bool isEmpty()
        {
            return !Elementos.Any();  //Si está vacia, devuelve true, sino, false.
        }

        public void MostrarContenidoEnPila()  //Muestra contenido.
        {

            if (Elementos.Count == 0)
            {
                Console.WriteLine("La Pila está vacia"); //Imprime si la lista elementos está vacia.
            }
            else
            {
                foreach (Disco disco in Elementos)
                {
                    Console.WriteLine($"{disco.Valor}");  //Recorre la lista elementos y devuelve el valor de cada disco.
                }
            }
            Console.WriteLine();
        }
    }
}


