namespace Ares.Domain.Exceptions;

public class DomainException : Exception
{
    public DomainException(string code, params (string Key, object Value)[] parameters)
        : base(code)
    {
        foreach (var parameter in parameters)
            Data.Add(parameter.Key, parameter.Value);
    }
}
