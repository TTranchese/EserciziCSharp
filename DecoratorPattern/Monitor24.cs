namespace DecoratorPattern;

public class Monitor24 : ComputerDecorator
{
    private Computer computer;
    private string descrizione = "Monitor 24 \"";
    private int prezzo = 100;

    public Monitor24(Computer computer)
    {
        this.computer = computer;
    }

    public override string Descrizione()
    {
        return this.computer.Descrizione()+" e "+this.descrizione;
    }

    public override int Prezzo()
    {
        return this.computer.Prezzo() + this.prezzo;
    }
}