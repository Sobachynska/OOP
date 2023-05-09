public class CollectionType<T>
{
    private readonly List<T> _elements;
    public CollectionType()
    {
        _elements = new List<T>();
    }
    public void Add(T element)
    {
        _elements.Add(element);
    }
    public bool Remove(T element)
    {
        return _elements.Remove(element);
    }
    public T this[int index]
    {
        get => _elements[index];
        set => _elements[index] = value;
    }
    public int Count => _elements.Count;
}