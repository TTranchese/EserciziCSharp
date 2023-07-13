namespace DecoratorPattern;

public abstract class ComputerDecorator : Computer
{
    public abstract override string Descrizione();
    public abstract override int Prezzo();
}