using Library.Models;

namespace Library.Utils.Visitor;

public interface Show
{
    public void show(Book book, int type = 1);
    public void show(Magazine magazine, int type = 1);
    public void show(Member member, int type = 1);
    public void show(Retention retention, int type = 1);

    public void show(Member member, AbstractElem elem, int type = 1);
    
}