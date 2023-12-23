using Library.Models;
using Library.Utils.Visitor;

namespace Library.Utils;

public class GenList<T, K>
{
    private Dictionary<K, T> _genList = new();

    protected void AddElem(K key, T elem)
    {
        if (Contains(key))
        {
            Console.WriteLine("Element already exists!");
            return;
        }

        _genList.Add(key, elem);
    }

    protected bool RemoveElem(T elem)
    {
        var key = GetById(elem);
        if (key == null)
            return false;
        _genList.Remove(key);
        return true;
    }

    protected List<T> GetAll()
    {
        return _genList.Values.ToList();
    }

    private bool Contains(K key)
    {
        return _genList.ContainsKey(key);
    }

    private K GetById(T elem)
    {
        return _genList.FirstOrDefault(x => x.Value!.Equals(elem)).Key;
    }

    protected T Get(K key)
    {
        if(Contains(key))
            return _genList[key];
        return default;
    }

    public int Size()
    {
        return _genList.Count;
    }
}