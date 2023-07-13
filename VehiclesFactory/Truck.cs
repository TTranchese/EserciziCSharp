namespace VehiclesFactory;

public class Truck : IVehicle
{
    private int _chassis;
    private string _description;
    private string _color;
    private double _price;

    public Truck(int chassis)
    {
        _chassis = chassis;
    }

    public int Chassis
    {
        get => _chassis;
        set => _chassis = value;
    }

    public string Description
    {
        get => _description;
        set => _description = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Color
    {
        get => _color;
        set => _color = value ?? throw new ArgumentNullException(nameof(value));
    }

    public double Price
    {
        get => _price;
        set => _price = value;
    }

    public string stampaVeicolo()
    {
        return "Chassis number: " + _chassis + "\n"
               + "Description: " + _description + "\n"
               + "Color: " + _color + "\n"
               + "Price: " + _price + "\n"
            ;
    }
}