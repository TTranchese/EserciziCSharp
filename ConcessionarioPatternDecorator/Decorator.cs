namespace ConcessionarioPatternDecorator;

public abstract class Decorator : Automobile
{
    public abstract override string Descrizione();
    public abstract override int Prezzo();
}