namespace FactoryPattern;

public class Quadrato : IFigura
{
    private int _id = 0;

    public Quadrato(int id)
    {
        _id = id;
    }

    public void disegna()
    {
        Console.WriteLine("Disegna quadrato: "+_id);
    }
}