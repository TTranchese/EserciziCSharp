namespace ConcessionarioPatternDecorator;

public class Tettuccio : Decorator
{
    private Automobile automobile;
    private string descrizione = " con tettuccio apribile";
    private int prezzo = 1000;

    public Tettuccio(Automobile automobile)
    {
        this.automobile = automobile;
    }

    public override string Descrizione()
    {
        return automobile.Descrizione() + "" + descrizione;
    }

    public override int Prezzo()
    {
        return automobile.Prezzo() + prezzo;
    }
}