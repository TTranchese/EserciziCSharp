namespace FactoryPattern;

public class Rettangolo : IFigura
{
    private int _id = 0;

    public Rettangolo(int id)
    {
        _id = id;
    }

    public void disegna()
    {
        Console.WriteLine("Disegna rettangolo: "+_id);
    }
}