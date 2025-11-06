namespace Rowing.Application.Exceptions;

public class DependencyException : Exception
{
    public DependencyException(string message) : base(message) { }

    public DependencyException(string entityType, int id) :
        base($"Cannot delete {entityType} eith ID {id}. It has dependent records") { }
}