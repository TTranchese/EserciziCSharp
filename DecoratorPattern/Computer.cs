namespace DecoratorPattern;
//Classe base della catena dei decoratori
public class Computer
{
    private string descrizione = "Computer base";
    private int prezzo = 300;

    public virtual string Descrizione()
    {
        return descrizione;
    }

    public virtual int Prezzo()
    {
        return prezzo;
    }
}