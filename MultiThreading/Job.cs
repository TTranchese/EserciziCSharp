namespace MultiThreading;

public class Job
{
    private string _nome;
    private Random _random;
    public Job(string nome, Random random)
    {
        _nome = nome;
        _random = random;
    }
    
    //Metodo da eseguire in parallelo al Main
    public void DoWork()
    {
        //10 step di lavoro fake
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(this._nome + ": "+i);
            Thread.Sleep(this._random.Next(3001));
        }
        Console.WriteLine(this._nome + ": finito!");
    }
}