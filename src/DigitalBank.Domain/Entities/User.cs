using DigitalBank.Domain.Common;

namespace DigitalBank.Domain.Entities;

public class User : Entity<User>
{
    public string FirstName { get; protected set; } = string.Empty;
    public string MiddleName { get; protected set; } = string.Empty;
    public string LasName { get; protected set; } = string.Empty;
    public string Email { get; protected set; } = string.Empty;
    public string Password { get; protected set; } = string.Empty;
    public string DocumentNumber { get; protected set; } = string.Empty;
    public string PhoneNumber { get; protected set; } = string.Empty;

    protected User() { }

    public User(string firstName, string middleName, string lasName, string email, string password, string documentNumber, string phoneNumber)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LasName = lasName;
        Email = email;
        PhoneNumber = phoneNumber;
        Password = password;
        DocumentNumber = documentNumber;
    }

    public static User Create(string firstName, string middleName, string lasName, string email, string password, string documentNumber, string phoneNumber)
    {
        return new User(firstName, middleName, lasName, email, password, documentNumber, phoneNumber);
    }

    public void ChangeMainInformation(string firstName, string middleName, string lasName, string email, string phoneNumber)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LasName = lasName;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public override int GetIdentityHashCode()
    {
        return Id.GetHashCode();
    }

    public override bool SameIdentityAs(User other)
    {
        return other is not null && Id == other.Id;
    }

    public override string ToString()
    {
        return $"Usuário: {FirstName} {MiddleName} {LasName}, Email: {Email}, Documento: {DocumentNumber}";
    }
}
