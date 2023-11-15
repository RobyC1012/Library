
namespace Library.Utils;

public class GenList<T, K>
{
    private Dictionary<K, T> _dictionary = new Dictionary<K, T>();
    
    protected void AddElem(K key, T elem)
    {
        if (_dictionary.ContainsKey(key))
        {   
            Console.WriteLine("error");
            return;
        }
        _dictionary.Add(key, elem);
    }
    
    protected bool RemoveElem(T elem)
    {
        K key = GetById(elem);
        if (key == null)
            return false;
        _dictionary.Remove(key);
        return true;
    }
    
    protected List<T> GetAll()
    {
        return _dictionary.Values.ToList();
    }
    
    private bool Contains(K key)
    {
        return _dictionary.ContainsKey(key);
    }
    
    private K GetById(T elem)
    {
        return _dictionary.FirstOrDefault(x => x.Value!.Equals(elem)).Key;
    }
    
    protected T Get(K key)
    {
        return _dictionary[key];
    }
    
    public int Size()
    {
        return _dictionary.Count;
    }
    
}

