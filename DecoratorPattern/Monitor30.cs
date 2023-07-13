namespace DecoratorPattern;

public class Monitor30 : ComputerDecorator
{
    private Computer computer;
    private string descrizione = "Monitor 30 \"";
    private int prezzo = 400;

    public Monitor30(Computer computer)
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