using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Editor
{
    class MinhaLista
    {
        private No cabeca, cauda;

        //Inserir elemento no cauda da lista
        public void insereFim(Object elemento)
        {
            No novoNo = new No();
            novoNo.setElemento(elemento);

            if (cabeca == null)
            {
                cabeca = novoNo;
            }
            else
            {
                cauda.setProx(novoNo);
            }
            cauda = novoNo;
        }

        //Inserir elemento no cabeca da lista
        public void insereInicio(Object elemento)
        {
            No novo = new No();
            novo.setElemento(elemento);

            if (cabeca == null)
            {
                cabeca = novo;
                cauda = novo;
            }
            else
            {
                novo.setProx(cabeca);
            }
            cabeca = novo;
        }

        // Verifica se a lista contém o elemento
        public bool Contains(Object elemento)
        {
            cabeca.setElemento(elemento);
            if (cabeca.getElemento() == null) 
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Retirar elemento do cauda da lista
        public void retiraFim()
        {
            if (cabeca == null)
                return;

            if (cabeca.getProx() == null)
            {
                Console.WriteLine("Elemento retirado: " + cabeca.getElemento());
                cabeca = null;
            }
            else
            {
                No ultimo = cabeca.getProx();
                No penultimo = cabeca;

                while (ultimo.getProx() != null)
                {
                    penultimo = ultimo;
                    ultimo = ultimo.getProx();
                }
                penultimo.setProx(null);
                Console.WriteLine("Elemento retirado: " + ultimo.getElemento());
            }
            this.exibir();
        }

        //Retirar elemento do cabeca da lista
        public void retiraInicio()
        {
            if (cabeca != null)
            {
                Console.WriteLine("Elemento retirado: " + cabeca.getElemento());
                cabeca = cabeca.getProx();
            }
            exibir();
        }

        //Exibir elementos da lista
        public void exibir()
        {
            if (cabeca != null)
            {
                No temp = cabeca;
                while (temp != null)
                {
                    Console.Write(temp.getElemento() + " ");
                    temp = temp.getProx();
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("\nLista vazia");
            }
        }
    }
}