namespace DecoratorPattern;

public class Ram16Gb : ComputerDecorator
{
    private Computer computer;
    private string descrizione = "Ram 16GB";
    private int prezzo = 170;

    public Ram16Gb(Computer computer)
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