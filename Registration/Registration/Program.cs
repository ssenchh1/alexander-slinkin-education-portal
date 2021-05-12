namespace Registration
{
    class Program
    {
        //не все успел реализовать и правильно оформить. Также архитектура не до конца продумана
        static void Main(string[] args)
        {
            var manager = new DBManager(new TxtParser());
            var auth = new Autorisator(manager);
            auth.Run();
        }
    }
}
