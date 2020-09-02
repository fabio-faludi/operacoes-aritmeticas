using System;

namespace OperacoesAritmeticas
{

    public class Calculo
    {
        private readonly double _numero1;
        private readonly double _numero2;
        private readonly OpcaoMenu _opcaoMenu;

        public double numero1
        {
            get { return _numero1; }
        }

        public double numero2
        {
            get { return _numero2; }
        }

        public OpcaoMenu opcaoMenu
        {
            get { return _opcaoMenu; }
        }

        public Calculo(OpcaoMenu opcaoMenu, double numero1, double numero2)
        {
            this._numero1 = numero1;
            this._numero2 = numero2;
            this._opcaoMenu = opcaoMenu;
        }

        public double Executar()
        { 
            double resultado = 0;

            switch (opcaoMenu)
            {
                case OpcaoMenu.Adição: 
                    resultado = Adicionar(); 
                    break;
                case OpcaoMenu.Subtração:
                    resultado = Subtrair();
                    break;
                case OpcaoMenu.Multiplicação:
                    resultado = Multiplicar();
                    break;
                case OpcaoMenu.Divisão:
                    resultado = Dividir();
                    break;
                case OpcaoMenu.Potenciação:
                    resultado = Potencia(numero1, numero2);
                    break;
                case OpcaoMenu.Radiciação:
                    resultado = Potencia(numero1, 1/numero2);
                    break;
            }

            return resultado;
        }

        public double Adicionar()
        {
            double resultado = numero1 + numero2;
            return resultado; 
        }

       public double Subtrair()
        {
            double resultado = numero1 - numero2;
            return resultado;
       }

        public double Multiplicar()
        {
            double resultado = numero1 * numero2;
            return resultado;
        }

        public double Dividir()
        {
            double resultado = 0;

            try
            {
                // validar o denominador da divisão
                if (numero2 == 0)
                    throw new ArgumentException("\nNão podemos realizar DIVISÃO por 0  !!!");

                resultado = numero1 / numero2;
                return resultado;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public double Potencia(double numero1, double numero2)
        {
            double resultado = Math.Pow(numero1, numero2);
            return resultado;
        }
    }

}