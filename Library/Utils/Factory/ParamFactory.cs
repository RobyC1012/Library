using Library.Models;

namespace Library.Utils.Factory;

public abstract class ParamFactory
{
    public int Id;
    public String Title;
    
    protected ParamFactory() {}
    
    public ParamFactory(string? title)
    {
        this.Title = title;
    }
    
}