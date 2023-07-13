namespace FactoryPattern;

public class Cerchio : IFigura
{
    private int _id = 0;

    public Cerchio(int id)
    {
        _id = id;
    }

    public void disegna()
    {
        Console.WriteLine("Disegna cerchio: "+_id);
    }
}