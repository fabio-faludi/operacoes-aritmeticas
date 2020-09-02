using System;
using Figgle;

namespace OperacoesAritmeticas
{

    public enum OpcaoMenu { Adição = 1, Subtração, Multiplicação, Divisão, Potenciação, Radiciação, Sair = 9 }

    class Program
    {
        static void Main(string[] args)
        {
            bool continua = true;
            OpcaoMenu opcao;
            double numero1, numero2, resultado;

            while (continua) 
            {
                ExibirMenuDeOpcoes();

                try 
                {   
                    // Obter opção de menu do usuário
                    opcao = (OpcaoMenu)Convert.ToInt32(Console.ReadLine());

                    // Validar opção de Menu
                    if (!ExisteOpcaoMenu(opcao))
                        throw new ArgumentException("\nOpção inválida");

                    if (opcao == OpcaoMenu.Sair)
                    {
                        continua = false;
                        throw new ArgumentException("\nSistema finalizado !");
                    }

                    // Obter operandos para o cálculo
                    Console.WriteLine($"\nDigite os Números da Operacao: \n");
                    Console.Write("Operando 1: ");
                    numero1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Operando 2: ");
                    numero2 = Convert.ToDouble(Console.ReadLine());
                    Calculo calculo = new Calculo(opcao, numero1, numero2);

                    // Realizar cálculo 
                    resultado = calculo.Executar();

                    // Exibir o resultado do cálculo
                    Console.Write($"Resultado da Operação: {resultado}");
                }    
                catch (ArgumentException e)
                {
                    Console.Write(e.Message);
                }
                finally
                {
                    if (continua)
                    {
                        Console.Write("\n\nDeseja realizar outra operação ? (S/N): ");
                        continua = (Console.ReadLine().ToUpper() == "S");
                        Console.Clear();
                    }
                }

            }

            Console.Write("\n\nDesenvolvido por: Fábio Luiz Dias\n");
        }

        public static void ExibirMenuDeOpcoes()
        {
            Console.Clear();
            Console.WriteLine(
                Figgle.FiggleFonts.Standard.Render("\nOperações Artitméticas"));
            Console.WriteLine("Escolha a opção desejada e tecle <ENTER>: \n");
            Console.WriteLine("1 - Adição");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Multiplicação");
            Console.WriteLine("4 - Divisão");
            Console.WriteLine("5 - Potenciação");
            Console.WriteLine("6 - Radiciação");
            Console.WriteLine("9 - Sair do Programa");
            Console.Write("\nOpção: ");
        }

        public static bool ExisteOpcaoMenu(OpcaoMenu opcao)
        {
            bool resultado = false;

            resultado = ((opcao == OpcaoMenu.Adição) ||
                        (opcao == OpcaoMenu.Subtração) || 
                        (opcao == OpcaoMenu.Multiplicação) ||
                        (opcao == OpcaoMenu.Divisão) || 
                        (opcao == OpcaoMenu.Potenciação) || 
                        (opcao == OpcaoMenu.Radiciação) ||
                        (opcao == OpcaoMenu.Sair)); 

            return resultado;
        }

    }
}
