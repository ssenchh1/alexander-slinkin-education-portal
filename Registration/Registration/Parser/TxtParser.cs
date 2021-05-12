namespace Registration
{
    public class TxtParser : IParser
    {
        public string Parse<T>(T obj)
        {
            var str = "";
            foreach (var property in obj.GetType().GetProperties())
            {
                str += property.GetValue(obj);
                str += ";";
            }

            return str;
        }
    }
}