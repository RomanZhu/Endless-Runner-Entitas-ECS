public class IdService : Service
{
    private int _id;

    public IdService(Contexts contexts) : base(contexts)
    {
    }

    public int GetNext()
    {
        _id++;
        return _id;
    }

    public void Reset()
    {
        _id = 0;
    }
}