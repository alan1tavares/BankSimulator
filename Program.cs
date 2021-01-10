using System;
using classes;

namespace BankSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Joao", 1000);            
            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine("---Normal accoutn---");
            Console.WriteLine(account.GetAccountHistory());
            
            var giftCard = new GiftCardAccount("gift card", 100, 50);
            giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffe");
            giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
            giftCard.PerformMonthEndTransaction();
            giftCard.MakeDeposit(27.50m, DateTime.Now, 
                "add some additional spending money");
            Console.WriteLine("---Gif card account---");
            Console.WriteLine(giftCard.GetAccountHistory());

            var savings = new InterestEarningAccount("savings account", 10000);
            savings.MakeDeposit(750, DateTime.Now, "save some money");
            savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
            savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
            savings.PerformMonthEndTransaction();            
            Console.WriteLine("---Interest earning account");
            Console.WriteLine(savings.GetAccountHistory());

            var lineOfCredit = new LineOfCrediAccount("line of credit", 0, 2000);
            lineOfCredit.MakeWithdrawal(1000, DateTime.Now, "Take out monthly advance");
            lineOfCredit.MakeDeposit(50, DateTime.Now, "Pay back small amount");
            lineOfCredit.MakeWithdrawal(5000, DateTime.Now, "Emergency funds for repairs");
            lineOfCredit.MakeDeposit(150, DateTime.Now, "Partial restore on repairs");
            lineOfCredit.PerformMonthEndTransaction();
            Console.WriteLine("---Line of credit---");
            Console.WriteLine(lineOfCredit.GetAccountHistory());
        }
    }
}
