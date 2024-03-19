// See https://aka.ms/new-console-template for more information

namespace MultiXPing
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeConsole();

            Character character = new Character();
            character.InitializeCharacter("Romain");

            Console.WriteLine(character.Name);
            Console.ReadLine();
        }
        
        public static void InitializeConsole()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Title = "MultiXPing";
        }
    }
}