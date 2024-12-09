namespace Registration
{
    public interface IParser
    {
        public string Parse<T>(T obj);
    }
}