namespace VehiclesFactory;

public static class VehicleFactory
{
    public enum VehicleType
    {
        Autovehicle,
        Truck,
        MotorBike
    }

    private static int _autovehicleId = 1;
    private static int _truckId = 1000;
    private static int _motorBikeId = 2000;

    public static IVehicle? getVehicle(VehicleType type)
    {
        switch (type)
        {
            case (VehicleType.Autovehicle):
                if (_autovehicleId <= 999)
                {
                    return new Autovehicle(VehicleFactory._autovehicleId++);
                } return null;
            case (VehicleType.Truck):
                if (_autovehicleId <= 1999)
                {
                    return new Truck(VehicleFactory._truckId++);
                } return null;    
            case (VehicleType.MotorBike):
                if (_autovehicleId <= 2999)
                {
                    return new MotorBike(VehicleFactory._motorBikeId++);
                } return null;
            default:
                return null;
        }
    }
}