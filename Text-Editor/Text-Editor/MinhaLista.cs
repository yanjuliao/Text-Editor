using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Editor
{
    class MinhaLista
    {
        private No _cabeca, _cauda;

        //Inserir elemento no fim da lista
        public void insereFim(int elemento)
        {
            No novoNo = new No();
            novoNo.setValor(elemento);

            if (_cabeca == null)
            {
                _cabeca = novoNo;
            }
            else
            {
                _cauda.setP(novoNo);
            }
            _cauda = novoNo;
        }

        //Inserir elemento no inicio da lista
        public void insereInicio(int elemento)
        {
            No novo = new No();
            novo.setValor(elemento);

            if (_cabeca == null)
            {
                _cabeca = novo;
                _cauda = novo;
            }
            else
            {
                novo.setP(_cabeca);
            }
            _cabeca = novo;
        }

        //Retirar elemento do fim da lista
        public void retiraFim()
        {
            if (_cabeca == null)
                return;

            if (_cabeca.getProximo() == null)
            {
                Console.WriteLine("Elemento retirado: " + _cabeca.getValor());
                _cabeca = null;
            }
            else
            {
                No ultimo = _cabeca.getProximo();
                No penultimo = _cabeca;

                while (ultimo.getProximo() != null)
                {
                    penultimo = ultimo;
                    ultimo = ultimo.getProximo();
                }
                penultimo.setP(null);
                Console.WriteLine("Elemento retirado: " + ultimo.getValor());
            }
            this.exibir();
        }

        //Retirar elemento do inicio da lista
        public void retiraInicio()
        {
            if (_cabeca != null)
            {
                Console.WriteLine("Elemento retirado: " + _cabeca.getValor());
                _cabeca = _cabeca.getProximo();
            }
            exibir();
        }

        //Exibir elementos da lista
        public void exibir()
        {
            if (_cabeca != null)
            {
                No temp = _cabeca;
                while (temp != null)
                {
                    Console.Write(temp.getValor() + " ");
                    temp = temp.getProximo();
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("\nLista vazia");
            }
        }
    }

    public class No 
    {

        private No Proximo;

        private int Valor;

        public void setP(No Proximo) 
        {
            this.Proximo = Proximo;
        }

        public void setValor(int Valor)
        {
            this.Valor = Valor;
        }

        public No getProximo() 
        {
            return Proximo;
        }
  
        public int getValor() 
        {
            return Valor;
        }
      
    }
}