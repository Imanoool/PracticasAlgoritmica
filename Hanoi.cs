using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace Torres_de_Hanoi
    {
        class Hanoi
        {
            
            public int movimientos { get; set; }  // Almacena el número total de movimientos realizados para resolver el problema.


        public Hanoi()
            {
                movimientos = 0; // Contador empieza en 0.
            }

          
            public void Mover_disco(Pila a, Pila b)
            {
         
            // Si la pila 'a' está vacía, mueve el disco de 'b' a 'a'.
            if (a.Top == 0)
                {
                    if (b.Top > 0)  
                    {
                        a.push(b.pop());
                   
                }
                }
                
                else if (b.Top == 0)  //Aquí es al revés, si la pila 'b' está vacía, mueve el disco de 'a' a 'b'.
            {
                    if (a.Top > 0)
                    {
                        b.push(a.pop());
                    
                }
                }
                // Si el disco en la cima de 'a' es más pequeño que el de 'b', mueve el disco de 'a' a 'b',
                else if (a.Top < b.Top)
                {
                    b.push(a.pop());
               
            }
                // En caso contrario, mueve el disco de 'b' a 'a',
                else
                {
                    a.push(b.pop());
                
            }
           
          
          
        }

            // Método iterativo para resolver las Torres de Hanoi
            public int iterativo(int n, Pila ini, Pila fin, Pila aux)
            {
                
                if ((n % 2) == 0)     // Si el valor de n es par: Hace el bucle do while hasta que todos los discos lleguen a la pila fin.
                {                     
                Hanoi.MostrarEstado(ini, fin, aux); /// Muestra el estado inicial de las pilas.

                do
                    { 
                        Mover_disco(ini, aux); // Movimiento 1: Mueve un disco de la pila ini a la aux.
                        movimientos++;        // Incrementa el contador de moviemientos.
                        Hanoi.MostrarEstado(ini, fin, aux); // Muestra el estado después del movimiento.

                        Mover_disco(ini, fin); // Movimiento 2: Mueve un disco de la pila ini a la fin
                        movimientos++;        // Incrementa el contador de moviemientos.
                    Hanoi.MostrarEstado(ini, fin, aux); // Muestra el estado después del movimiento.

                    if (fin.Elementos.Count < n) // Si aún no todos los discos están en fin.
                    {
                            Mover_disco(aux, fin); // Movimiento 3: Mueve un disco de la pila aux a la fin.
                            movimientos++;        // Incrementa el contador de movimientos.
                        Hanoi.MostrarEstado(ini, fin, aux);  // Muestra el estado después del movimiento.
                    }
                    } while (fin.Elementos.Count < n); // Repite hasta que todos los discos estén en fin.
            }
                else  // Por otro lado, si el valor de n es impar.
                {
                    do
                    {
                        Mover_disco(ini, fin); // Movimiento 1:Mueve un disco de la pila ini a la fin.
                    movimientos++;            // Incrementa el contador de moviemientos.
                    Hanoi.MostrarEstado(ini, fin, aux); // Muestra el estado después del movimiento.

                    if (fin.Elementos.Count < n)  // Si aún no todos los discos están en fin.
                    {
                            Mover_disco(ini, aux); // Movimiento 2: Mueve un disco de la pila ini a la aux.
                        movimientos++;            // Incrementa el contador de moviemientos.
                        Hanoi.MostrarEstado(ini, fin, aux); // Muestra el estado después del movimiento.

                        Mover_disco(aux, fin); // Movimiento 3: Mueve un disco de la pila aux a la fin.
                        movimientos++;        // Incrementa el contador de movimientos.
                        Hanoi.MostrarEstado(ini, fin, aux); // Muestra el estado después del movimiento.
                    }
                    } while (fin.Elementos.Count < n);  // Repite hasta que todos los discos estén en fin.
            }
                return movimientos; // Devuelve la cantidad de movimientos han sido necesarios para resolverlo.
            }

            // Método recursivo para resolver las Torres de Hanoi
            public int recursivo(int n, Pila ini, Pila fin, Pila aux)
            {
                if (n == 1)  // Usamos el valor de n = 1, como caso base.
                {
                    Hanoi.MostrarEstado(ini, fin, aux); // Muestra el estado actual de las pilas.

                Mover_disco(ini, fin);  // Mueve el disco de ini a fin.
                movimientos++;  // Incrementa el contador de moviemientos.
                Hanoi.MostrarEstado(ini, fin, aux); // Muestra el estado después del movimiento.

            }
            else // Caso general: Si hay más de un disco.
            {
                    recursivo(n - 1, ini, aux, fin); // Mueve n-1 discos de ini a aux
                    Mover_disco(ini, fin); // Movimiento: mueve un disco de ini a fin
                    movimientos++;
                    Hanoi.MostrarEstado(ini, fin, aux);
                    recursivo(n - 1, aux, fin, ini); // Mueve los n-1 discos restantes de aux a fin
                }
                return movimientos; // Devuelve el número total de movimientos realizados
            }
        public static void MostrarEstado(Pila ini, Pila fin, Pila aux)
        {
            Console.WriteLine("INI:");
            ini.MostrarContenidoEnPila();

            Console.WriteLine("AUX:");
            aux.MostrarContenidoEnPila();

            Console.WriteLine("FIN:");
            fin.MostrarContenidoEnPila();

            Console.WriteLine("..............................");
        }
    }
    }
