namespace ConcessionarioPatternDecorator;

public class MotoreDiesel : Decorator
{
    private Automobile automobile;
    private string descrizione = " con motore a diesel";
    private int prezzo = 1500;

    public MotoreDiesel(Automobile automobile)
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