namespace MultiXPing
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeConsole();

            Hunter character = new Hunter();
            character.Initialize("Romain", "BipBoopBip");

            Console.WriteLine(character.Name + ", is type : " + character.Element);
            Console.ReadLine();
        }
        
        public static void InitializeConsole()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Title = "MultiXPing";
        }
    }
}