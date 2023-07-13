namespace VehiclesFactory;

public interface IVehicle
{
    int Chassis { get; set; }
    string Description { get; set; }
    string Color { get; set; }
    double Price { get; set; }
    string stampaVeicolo();
}