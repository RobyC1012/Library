
using Library.Models;
using Library.Utils.Visitor;

namespace Library.Utils;

public class GenList<T, K>
{
    private Dictionary<K, T> _genList = new Dictionary<K, T>();
    
    protected void AddElem(K key, T elem)
    {
        if (_genList.ContainsKey(key))
        {   
            Console.WriteLine("error");
            return;
        }
        _genList.Add(key, elem);
    }
    
    protected bool RemoveElem(T elem)
    {
        K key = GetById(elem);
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
        return _genList[key];
    }
    
    public int Size()
    {
        return _genList.Count;
    }
    
}

