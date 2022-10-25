using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaEnlazada
{
    internal class ListaEnlazada
    {
        public Nodo Inicio; //aqui se crea el nodo inicio

        public Nodo BuscarUltimo(Nodo unNodo) // se va a usar para cambiar el nodo siguiente por el final
        { 
            if (unNodo.Siguiente == null)
            {
                return unNodo;
            }
            else
            {
                return BuscarUltimo(unNodo.Siguiente);
            }
        }

        public void AgregarInicio(Nodo unNodo) //procedimiento para agregar un nodo al inicio
        {
            if(Inicio == null)
            {
                Inicio = unNodo;
            }
            else
            {
                Nodo rem = Inicio; // rem rs el nodo para remplazar al que ya esta en el inicio
                Inicio = unNodo;
                Inicio.Siguiente = rem;
            }
        }

        public void AgregarFinal(Nodo unNodo)
        {
            if(Inicio == null) // si no hay nada pues se tiene que cargar al inicio
            {
                Inicio = unNodo;
            }
            else
            {
                Nodo rem = BuscarUltimo(Inicio);
                rem.Siguiente = unNodo;
            }
        }
    }
}
