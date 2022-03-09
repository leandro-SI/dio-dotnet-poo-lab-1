using System;
using System.Collections.Generic;
using Leandro.Bank.Classes;
using Leandro.Bank.Enum;

namespace Leandro.Bank
{
    class Program
    {

        static List<Conta> listaContas = new List<Conta>();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        CadastrarConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
						Depositar();
						break;
                    case "C":
						Console.Clear();
						break;
                    default:
                        
                        break;
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

        }


        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("");
            Console.WriteLine("================================");
            Console.WriteLine("BEM VINDO AO BANK LELEO");
            Console.WriteLine("================================");
            Console.WriteLine("================================");
            Console.WriteLine("Informe a opcao desejada: ");
            Console.WriteLine("1) Listar Contas");
            Console.WriteLine("2) Inserir nova conta");
			Console.WriteLine("3) Transferir");
			Console.WriteLine("4) Sacar");
			Console.WriteLine("5) Depositar");
            Console.WriteLine("C) Limpar Tela");
			Console.WriteLine("X) Sair");
			Console.WriteLine();

            string opcao = Console.ReadLine();

			Console.WriteLine();

            return opcao;
        }

        private static void ListarContas()
        {
            if (listaContas.Count == 0)
            {
                Console.WriteLine("Não existem contas cadastradas!");
            }
            else
            {
                for (int i = 0; i < listaContas.Count; i++)
                {
                    Console.WriteLine("==========================");
                    Console.WriteLine(listaContas[i].ToString());

                }
            }
        }

        private static void CadastrarConta() {

            Console.WriteLine("Tipo de Conta: ");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Numero: ");
            int numero = int.Parse(Console.ReadLine());

            Console.WriteLine("Saldo: ");
            double saldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Credito: ");
            double credito = double.Parse(Console.ReadLine());

            Conta conta = new Conta
            (
                tipoConta: (TipoConta) tipoConta,
                numeroConta: numero,
                saldo: saldo,
                credito: credito,
                nome: nome  
            );

            listaContas.Add(conta);

            Console.WriteLine("Conta cadastrada com sucesso");
        }

        private static void Sacar()
		{
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser sacado: ");
			double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
		}

		private static void Transferir()
		{
			Console.Write("Digite o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferencia(valorTransferencia, listaContas[indiceContaDestino]);
		}

        private static void Depositar()
		{
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
		}

        
    }
}
