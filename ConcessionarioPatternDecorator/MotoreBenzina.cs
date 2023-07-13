namespace ConcessionarioPatternDecorator;

public class MotoreBenzina : Decorator
{
    private Automobile automobile;
    private string descrizione = " con motore a benzina";
    private int prezzo = 1000;

    public MotoreBenzina(Automobile automobile)
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