namespace ObserverPattern;

public class Osservatore : IOsservatore
{
    private string _nome = "";
    private string _messaggio = "";

    public Osservatore(string nome)
    {
        _nome = nome;
    }

    public void Aggiorna(string s)
    {
        Console.WriteLine(this._nome + ", ricevuto: " + s);
        this._messaggio = s;
    }
}