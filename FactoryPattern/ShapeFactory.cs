namespace FactoryPattern;

public class ShapeFactory
{
    public enum TipoFigura
    {
        Cerchio,
        Quadrato,
        Rettangolo
    }

    private int _id = 1;

    public IFigura? getShape(TipoFigura tipo)
    {
        switch (tipo)
        {
            case (TipoFigura.Cerchio):
                return new Cerchio(this._id++);
                break;
            case (TipoFigura.Rettangolo):
                return new Rettangolo(this._id++);
                break;
            case (TipoFigura.Quadrato):
                return new Quadrato(this._id++);
            default:
                return null;
        }
    }
}