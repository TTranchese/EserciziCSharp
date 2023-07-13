namespace ConcessionarioPatternDecorator;

public class AutomobileSportiva : Decorator
{
    private Automobile automobile;
    private int prezzo = 3000;

    public AutomobileSportiva(Automobile automobile)
    {
        this.automobile = automobile;
    }

    public override string Descrizione()
    {
        return "Automobile sportiva";
    }

    public override int Prezzo()
    {
        return prezzo;
    }
}