using Library.Models;

namespace Library.Utils.Factory;

public abstract class ParamFactory
{
    public string Title;
    public int InRoom;
    public float Tax;

    public ParamFactory(string? title, int inRoom, float tax)
    {
        Title = title;
        InRoom = inRoom;
        Tax = tax;
    }
}