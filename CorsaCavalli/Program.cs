using CorsaCavalli;

Random random = new Random(DateTime.Now.Millisecond);

Console.WriteLine("Quanti cavalli devono correre?");
int cavalli = Convert.ToInt32(Console.ReadLine());
List<Cavallo> listCavalli = new List<Cavallo>();
List<Thread> listThread = new List<Thread>();
for (int i = 0; i < cavalli; i++)
{
    Cavallo cavallo = new Cavallo("Cavallo" + (i + 1), random);
    
    listCavalli.Add(cavallo);
    listThread.Add(new Thread(cavallo.DoWork));
}
foreach (Thread thread in listThread)
{   
    thread.Start();
}

foreach (Thread thread in listThread)
{
    thread.Join();
}

foreach (Cavallo cavallo in listCavalli)
{
    cavallo.Arrivo += Stampa;
    cavallo.StampaCavallo("");
}
void Stampa(string msg)
{
    Console.WriteLine(msg);
}
