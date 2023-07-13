using System.Data;

namespace CorsaCavalli;

public delegate void DelegateCavallo(string messaggio);

public class Cavallo
{
    private string _nome;
    private Random _random;
    public event DelegateCavallo Arrivo;
    public int somma = 0;
    public Cavallo(string nome, Random random)
    {
        _nome = nome;
        _random = random;
    }

    public void DoWork()
    {
        somma = 0;
        for (int i = 0; i < 10; i++)
        {
            int random = this._random.Next(250, 750);
            somma += random;
            Console.WriteLine(this._nome + " posizione: " + (i + 1) + "||delay: " + (somma - random));
            Thread.Sleep(this._random.Next(250, 750));
        }
    }

    public void StampaCavallo(string msg)
    {
        if (Arrivo!=null)
        {
            Arrivo(_nome + ": ha tagliato il traguardo in " + ((double)somma / 1000) + " s!");
        }
    }
}