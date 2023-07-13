namespace ConcessionarioPatternDecorator;

public class Cerchi : Decorator
{
    private Automobile automobile;
    private string descrizione = " con Cerchi in Lega";
    private int prezzo = 300;

    public Cerchi(Automobile automobile)
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