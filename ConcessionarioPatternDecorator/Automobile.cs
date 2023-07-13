namespace ConcessionarioPatternDecorator;

public class Automobile
{
    private string descrizione = "Automobile base";
    private int prezzo = 2000;

    public virtual string Descrizione()
    {
        return descrizione;
    }

    public virtual int Prezzo()
    {
        return prezzo;
    }
}