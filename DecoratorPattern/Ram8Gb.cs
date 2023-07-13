namespace DecoratorPattern;

public class Ram8Gb : ComputerDecorator
{
    private Computer computer;
    private string descrizione = "Ram 8GB";
    private int prezzo = 90;

    public Ram8Gb(Computer computer)
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