// See https://aka.ms/new-console-template for more information

namespace MultiXPing
{

    static class Constants
    {
        public const string PROJECTPATH = "..\\..\\..\\..\\";
        public const int WIDTH = 240;
        public const int HEIGHT = 64;


    }
    
    class Program
    {
        static void Main(string[] args)
        {
            InitializeConsole();

            //Character character = new Character();
            //character.InitializeCharacter("Romain");
            //Console.WriteLine(character.Name);
            //Console.ReadLine();

            GameManager gameManager = new GameManager();
            gameManager.GameLoop();
           

        }
        
        public static void InitializeConsole()
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "MultiXPing";

            Console.SetWindowSize(Constants.WIDTH, Constants.HEIGHT);
            Console.SetBufferSize(Constants.WIDTH, Constants.HEIGHT);
        }
    }
}