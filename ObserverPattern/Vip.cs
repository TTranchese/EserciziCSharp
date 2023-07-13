namespace ObserverPattern;

public class Vip
{
    private string _nome = "";
    private string _messaggio = "";
    private List<IOsservatore> osservatori = new List<IOsservatore>();

    public Vip(string nome)
    {
        _nome = nome;
        this._messaggio = " sta seguendo "+this._nome;
    }

    public void addOsservatore(IOsservatore osservatore)
    {
        this.osservatori.Add(osservatore);
        osservatore.Aggiorna(this._messaggio);
    }

    public void removeOsservatore(IOsservatore osservatore)
    {
        this.osservatori.Remove(osservatore);
    }

    public void Notifica(string messaggio)
    {
        this._messaggio = messaggio;
        foreach(var o in this.osservatori)
        {
            o.Aggiorna(messaggio);
        }
    }
}