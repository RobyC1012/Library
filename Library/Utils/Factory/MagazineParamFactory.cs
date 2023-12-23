namespace Library.Utils.Factory;

public class MagazineParamFactory : ParamFactory
{
    public int Number;

    public MagazineParamFactory(string title, int number, int inRoom, float withTax) : base(title, inRoom, withTax)
    {
        Title = title;
        Number = number;
        InRoom = inRoom;
        Tax = withTax;
    }
}