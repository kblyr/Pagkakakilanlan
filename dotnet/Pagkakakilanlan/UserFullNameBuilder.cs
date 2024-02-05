namespace Pagkakakilanlan;

public interface IUserFullNameBuilder
{
    string Build(string firstName, string lastName);
    string Build(IUserFullNameSource source);
}

public interface IUserFullNameSource
{
    string FirstName { get; }
    string LastName { get; }
}