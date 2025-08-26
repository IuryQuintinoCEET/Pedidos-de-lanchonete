using System;
using System.Globalization;

namespace PedidoLanchonete
{
    class Program
    {
        static double AdicionarItem(string nomeItem, double precoUnitario)
        {
            Console.Write($"\n- Você selecionou {nomeItem}.");
            Console.Write("\n- Digite a quantidade desejada: ");

            string? inputQuantidade = Console.ReadLine();
            int quantidade;

            if (int.TryParse(inputQuantidade, out quantidade) && quantidade > 0)
            {
                double subtotal = quantidade * precoUnitario;
                Console.WriteLine($"=> {quantidade}x {nomeItem}(s) adicionado(s) ao pedido. (Subtotal: {subtotal:C})");
                return subtotal;
            }
            else
            {
                Console.WriteLine("=> Quantidade inválida! Nenhum item foi adicionado.");
                return 0; 
            }
        }

        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("pt-BR", false);

            double valorTotal = 0.0;
            bool finalizarPedido = false;

            Console.WriteLine("==============================================");
            Console.WriteLine("   Bem-vindo ao Sistema de Pedidos da Lanchonete!   ");
            Console.WriteLine("==============================================");

            while (!finalizarPedido)
            {
                Console.WriteLine("\n--- CARDÁPIO ---");
                Console.WriteLine("1. Refrigerante - R$ 5,00");
                Console.WriteLine("2. Suco Natural  - R$ 7,00");
                Console.WriteLine("3. Água Mineral  - R$ 3,00");
                Console.WriteLine("4. Café Expresso - R$ 4,00");
                Console.WriteLine("5. Sair/Finalizar Pedido");
                Console.WriteLine("------------------");
                Console.Write("\nDigite o número da bebida desejada: ");

                string? input = Console.ReadLine();
                int escolha;

                if (int.TryParse(input, out escolha))
                {
                    switch (escolha)
                    {
                        case 1:
                            valorTotal += AdicionarItem("Refrigerante", 5.00);
                            break;

                        case 2:
                            valorTotal += AdicionarItem("Suco Natural", 7.00);
                            break;

                        case 3:
                            valorTotal += AdicionarItem("Água Mineral", 3.00);
                            break;

                        case 4:
                            valorTotal += AdicionarItem("Café Expresso", 4.00);
                            break;

                        case 5:
                            finalizarPedido = true;
                            Console.WriteLine("Finalizando o seu pedido...");
                            break;

                        default:
                            Console.WriteLine("Opção inválida! Por favor, escolha um número do cardápio.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida! Por favor, digite apenas o número correspondente à opção.");
                }

                if (!finalizarPedido)
                {
                    Console.WriteLine($"\n>>> Total atual do pedido: {valorTotal:C}");
                    Console.WriteLine("----------------------------------------------");
                }
            }

            Console.WriteLine("\n==============================================");
            Console.WriteLine("             PEDIDO FINALIZADO              ");
            Console.WriteLine($"   O valor total da sua compra é: {valorTotal:C}");
            Console.WriteLine("==============================================");
            Console.WriteLine("\nObrigado pela preferência e volte sempre!");
        }
    }
}