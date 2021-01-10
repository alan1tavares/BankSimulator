using System;
using classes;

namespace BankSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Joao", 1000);
            Console.WriteLine($"Account {account.Number} was created" +
                $" for {account.Owner} with {account.Balance} initial balance." );
        }
    }
}
