using System;

namespace Text_Editor
{
    public class No
    {

        private No Proximo;

        private Object elemento;

        public void setProx(No Proximo)
        {
            this.Proximo = Proximo;
        }

        public void setElemento(Object elemento)
        {
            this.elemento = elemento;
        }

        public No getProx()
        {
            return Proximo;
        }

        public Object getElemento()
        {
            return elemento;
        }

    }
}
