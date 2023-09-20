public record Client(Guid Id, string Name, string CellPhone)
{
    public Client() : this (Guid.NewGuid(), "", "") { }
}