using System;
using Leandro.Bank.Enum;

namespace Leandro.Bank.Classes
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        public int NumeroConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, int numeroConta, double saldo, double credito, string nome) 
        {
            this.TipoConta = tipoConta;
            this.NumeroConta = numeroConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if (valorSaque > (this.Saldo + this.Credito))
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

        }

        public void Transferencia(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            Console.WriteLine("Nome: {0}", this.Nome);
            Console.WriteLine("Tipo: {0}", this.TipoConta);
            Console.WriteLine("Numero: {0}", this.NumeroConta);
            Console.WriteLine("Saldo: {0}", this.Saldo);
            Console.WriteLine("Crédito: {0}", this.Credito);

            return base.ToString();
        }

    }
}