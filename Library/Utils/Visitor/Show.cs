using Library.Models;

namespace Library.Utils.Visitor;

public interface Show
{
    public void showBook(Book book);
    public void showMagazine(Magazine magazine);
    public void showMember(Member member);
    void showRetention(Retention retention);
}