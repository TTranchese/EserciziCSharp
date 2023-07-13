using ConcessionarioPatternDecorator;

Automobile automobile = new Automobile();

Console.WriteLine("Vuoi un auto base(b) o sportiva(s)");
string risposta = Console.ReadLine().ToLower();
if (risposta.StartsWith("s"))
    automobile = new AutomobileSportiva(automobile);

Console.WriteLine("Vuoi l'aria condizionata?(s/n)");
risposta = Console.ReadLine().ToLower();
if (risposta.StartsWith("s"))
    automobile = new Aria(automobile);

Console.WriteLine("Vuoi i cerchi in lega?(s/n)");
risposta = Console.ReadLine().ToLower();
if (risposta.StartsWith("s"))
    automobile = new Cerchi(automobile);

Console.WriteLine("Vuoi un motore a benzina(b) o a diesel(d)?");
risposta = Console.ReadLine().ToLower();
if (risposta.StartsWith("d"))
    automobile = new MotoreDiesel(automobile);
else if (risposta.StartsWith("b"))
    automobile = new MotoreBenzina(automobile);
    
    Console.WriteLine("Riepilogo: \n");
    Console.WriteLine("Descrizione: "+automobile.Descrizione()+"\n");
    Console.WriteLine("Prezzo: "+automobile.Prezzo()+"\n");