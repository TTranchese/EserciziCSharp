using System.Drawing;
using System.Reflection;
using VehiclesFactory;
//Inizializzo la lista di veicoli
List<IVehicle> vehiclesList = new List<IVehicle>();
//Inizializzo un Random per generarmi le cose random
Random r = new Random();
//Prendo i veicoli dalla factory
Autovehicle a1 = (Autovehicle)VehicleFactory.getVehicle(VehicleFactory.VehicleType.Autovehicle);
Autovehicle a2 = (Autovehicle)VehicleFactory.getVehicle(VehicleFactory.VehicleType.Autovehicle);
Autovehicle a3 = (Autovehicle)VehicleFactory.getVehicle(VehicleFactory.VehicleType.Autovehicle);

Truck t1 = (Truck)VehicleFactory.getVehicle(VehicleFactory.VehicleType.Truck);
Truck t2 = (Truck)VehicleFactory.getVehicle(VehicleFactory.VehicleType.Truck);
Truck t3 = (Truck)VehicleFactory.getVehicle(VehicleFactory.VehicleType.Truck);

MotorBike m1 = (MotorBike)VehicleFactory.getVehicle(VehicleFactory.VehicleType.MotorBike);
MotorBike m2 = (MotorBike)VehicleFactory.getVehicle(VehicleFactory.VehicleType.MotorBike);
MotorBike m3 = (MotorBike)VehicleFactory.getVehicle(VehicleFactory.VehicleType.MotorBike);
//Inserisco i veicoli nella lista
vehiclesList.Add(a1);
vehiclesList.Add(a2);
vehiclesList.Add(a3);
vehiclesList.Add(t1);
vehiclesList.Add(t2);
vehiclesList.Add(t3);
vehiclesList.Add(m1);
vehiclesList.Add(m2);
vehiclesList.Add(m3);
//
foreach (IVehicle vehicle in vehiclesList)
{
    vehicle.Color = colorPicker();
    vehicle.Price = r.Next(0, 10000);
    vehicle.Description = descriptionPicker(vehicle);
}

double sommaTotale = 0;
foreach (IVehicle vehicle in vehiclesList)
{
    Console.WriteLine(vehicle.stampaVeicolo());
    sommaTotale += vehicle.Price;
}

Console.WriteLine(sommaTotale);
//Random description
string descriptionPicker(IVehicle vehicle)
{
    return "This is the description of a " + vehicle.GetType().ToString().Replace("VehiclesFactory.", "");
}

//Funzione per far ritornare un colore a random in rgb
string  colorPicker()
{
    return Color.FromArgb(r.Next(0, 256), 
        r.Next(0, 256), r.Next(0, 256)).ToString();
}