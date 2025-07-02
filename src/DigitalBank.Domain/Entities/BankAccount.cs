using DigitalBank.Domain.Common;

namespace DigitalBank.Domain.Entities;

public class BankAccount : Entity<BankAccount>
{
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }

    protected BankAccount() { }

    public BankAccount(string accountNumber, decimal initialBalance, int userId)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
        UserId = userId;
    }

    public static BankAccount Create(string accountNumber, decimal initialBalance, int userId)
    {
        return new BankAccount(accountNumber, initialBalance, userId);
    }

    public override int GetIdentityHashCode()
    {
        return Id.GetHashCode();
    }

    public override bool SameIdentityAs(BankAccount other)
    {
        return other is not null && Id == other.Id;
    }

    public override string ToString()
    {
        return $"BankAccount(Id={Id}, AccountNumber={AccountNumber}, Balance={Balance:C})";
    }
}
