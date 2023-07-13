namespace DecoratorPattern;

public class HardDisk500Gb : ComputerDecorator
{
    private Computer computer;
    private string descrizione = "HardDisk500Gb";
    private int prezzo = 90;

    public HardDisk500Gb(Computer computer)
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