using CorsaCavalliAsyncAwait;

Random random = new Random(DateTime.Now.Millisecond);

CancellationTokenSource cts = new CancellationTokenSource();
var token = cts.Token;

Console.WriteLine("Quanti cavalli devono correre?");
int cavalli = Convert.ToInt32(Console.ReadLine());
List<Cavallo> listCavalli = new List<Cavallo>();
List<Task> listTask = new List<Task>();
for (int i = 0; i < cavalli; i++)
{
    Cavallo cavallo = new Cavallo("Cavallo" + (i + 1), random);
    
    listCavalli.Add(cavallo);
    listTask.Add(Task.Factory.StartNew(
        (() => cavallo.DoWork()), token
    ));
}
Task.WhenAll(listTask.ToArray());
Console.WriteLine("Premi un tasto per uscire");
Console.ReadLine();
cts.Cancel();
Console.WriteLine("Uscita...");