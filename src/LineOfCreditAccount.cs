using System;

namespace classes
{
  class LineOfCrediAccount : BankAccount
  {
    public LineOfCrediAccount(string name, decimal initialBalance, decimal creditLimit)
      : base(name, initialBalance, -creditLimit)
    {

    }

    public override void PerformMonthEndTransaction()
    {
      if (Balance < 0)
      {
        var interest = -Balance * 0.07m;
        MakeWithdrawal(interest, DateTime.Now, "Charge montly interest");
      }
    }

    #nullable enable
    protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn)
    {
      if (isOverdrawn)
      {
        return new Transaction(-20, DateTime.Now, "Appy overdraf fee");
      }
      else
      {
        return default;
      }
    }
  }
}