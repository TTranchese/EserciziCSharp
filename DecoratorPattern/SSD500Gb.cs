namespace DecoratorPattern;

public class SSD500Gb : ComputerDecorator
{
    private Computer computer;
    private string descrizione = "SSD500Gb";
    private int prezzo = 250;

    public SSD500Gb(Computer computer)
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