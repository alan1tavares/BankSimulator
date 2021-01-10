using System;
using System.Collections.Generic;

namespace classes
{
  public class BankAccount
  {
    private static int accountNumberSeed = 123456789;
    private readonly decimal minimumBalance;
    private List<Transaction> allTransaction = new List<Transaction>();
    public string Number { get; }
    public string Owner { get; set; }

    public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0)
    {

    }

    public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
    {
      this.Number = accountNumberSeed.ToString();
      accountNumberSeed++;

      this.Owner = name;
      this.minimumBalance = minimumBalance;
      if (initialBalance > 0)
      {
        MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
      }


    }

    public decimal Balance
    {
      get
      {
        decimal balance = 0;
        foreach (var item in allTransaction)
        {
          balance += item.Amount;
        }

        return balance;
      }
    }

    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
      if (amount <= 0)
      {
        throw new ArgumentOutOfRangeException(
          nameof(amount),
          "Amount of deposit must be positive"
        );
      }

      var deposit = new Transaction(amount, date, note);
      allTransaction.Add(deposit);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
      if (amount <= 0)
      {
        throw new ArgumentOutOfRangeException(
          nameof(amount),
          "Amount of withdrawal must be positive"
        );
      }

      var overdraftTransaction = CheckWithdrawalLimit(Balance - amount < minimumBalance);
      var withdrawal = new Transaction(-amount, date, note);
      allTransaction.Add(withdrawal);

      if (overdraftTransaction != null)
      {
        allTransaction.Add(overdraftTransaction);
      }
    }

    #nullable enable
    protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
    {
      if (isOverdrawn)
      {
        throw new InvalidOperationException("Not sufficient funds for this withdrawal");
      }
      else
      {
        return default;
      }
    }


    public string GetAccountHistory()
    {
      var report = new System.Text.StringBuilder();

      decimal balance = 0;
      report.AppendLine("Date\tAmount\tBalance\tNote");

      foreach (var item in allTransaction)
      {
        balance += item.Amount;
        report.AppendLine($"{item.Date.ToShortDateString()}\t" +
          $"{item.Amount}\t{balance}\t{item.Notes}"
        );
      }

      return report.ToString();
    }

    public virtual void PerformMonthEndTransaction()
    {

    }

  }
}