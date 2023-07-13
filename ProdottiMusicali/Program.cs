
using ProdottiMusicali.Models;

string risposta = "";
ProdottiMusicaliContext context = new ProdottiMusicaliContext();
while (risposta != "5")
{
    Console.WriteLine("1-Visualizza CD");
    Console.WriteLine("2-Inserisci CD");
    Console.WriteLine("3-Elimina CD");
    Console.WriteLine("4-Modifica CD");
    Console.WriteLine("5-Esci");
    Console.WriteLine("Cosa vuoi fare?");
    risposta = Console.ReadLine();


    switch (risposta)
    {
        case "1":
            Console.WriteLine("Visualizzo tutti i cd");
            VisualizzaCd();
            break;
        case "2":
            Console.WriteLine("Inserisci un CD");
            InserisciCd();
            break;
        case "3":
            Console.WriteLine("Elimina CD");
            EliminaCd();
            break;
        case "4":
            Console.WriteLine("Modifica CD");
            ModificaCd();
            break;
        case "5":
            break;

    }

    void VisualizzaCd()
    {
        var cdList = from n in context.Cd1s select n;
        foreach (var cd in cdList)
        {
            Console.WriteLine(cd.ToString());
        }
    }

    void InserisciCd()
    {
        Cd1 cdToInsert = new Cd1();
        Console.WriteLine("Inserisci il titolo: ");
        cdToInsert.Titolo = Console.ReadLine();

        Console.WriteLine("Inserisci l'artista: ");
        cdToInsert.Artista = Console.ReadLine();

        Console.WriteLine("Inserisci l'anno: ");
        cdToInsert.Anno = int.Parse(Console.ReadLine() ?? new string("0"));

        context.Cd1s.Add(cdToInsert);
        context.SaveChanges();
    }

    void EliminaCd()
    {
        Console.WriteLine("Inserisci il nome del cd da eliminare: ");
        string cdToDelete = Console.ReadLine();
        
        var cdFromDbToDelete = (from n in context.Cd1s where n.Titolo.Contains(cdToDelete) select n).First();
        context.Cd1s.Remove(cdFromDbToDelete);
        context.SaveChanges();
    }

    void ModificaCd()
    {
        Console.WriteLine("Inserisci il titolo del cd da modificare: ");
        string titolo = Console.ReadLine();

        var cdFromDbToModify = (from n in context.Cd1s where n.Titolo.Contains(titolo) select n).First();
        
        Console.WriteLine("Modifica titolo: ");
        cdFromDbToModify.Titolo = Console.ReadLine();
        Console.WriteLine("Modifica artista: ");
        cdFromDbToModify.Artista = Console.ReadLine();
        Console.WriteLine("Modifica anno: ");
        cdFromDbToModify.Anno = int.Parse(Console.ReadLine() ?? new string("0"));
        
        context.Cd1s.Update(cdFromDbToModify);
        context.SaveChanges();
    }
}