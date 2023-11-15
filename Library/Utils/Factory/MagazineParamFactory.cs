namespace Library.Utils.Factory;

public class MagazineParamFactory : ParamFactory
{
    public int Number;

    public MagazineParamFactory(string? title, int number)
    {
        this.Title = title;
        this.Number = number;
    }
}