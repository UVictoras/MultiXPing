// See https://aka.ms/new-console-template for more information

using MultiXPing.source.Character;

namespace MultiXPing
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeConsole();

            Tank character = new Tank("Romain");
            Console.WriteLine(character.Name);
            Console.ReadLine();
            character.GainExp(9);
            character.GainExp(5);

        }
        
        public static void InitializeConsole()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Title = "MultiXPing";
        }
    }
}