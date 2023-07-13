namespace ConcessionarioPatternDecorator;

public class Aria : Decorator
{
    private Automobile automobile;
    private string descrizione = " con Aria Condizionata";
    private int prezzo = 200;

    public Aria(Automobile automobile)
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