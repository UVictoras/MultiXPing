namespace MultiXPing
{

    static class Constants
    {
        public const string PROJECTPATH = "..\\..\\..\\..\\";
        public const int WIDTH = 100;
        public const int HEIGHT = 50;


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

            CharacterStats Stats = new CharacterStats();
            Stats.InitializeCSVStats(Constants.PROJECTPATH + "MultiXPing\\source\\Data\\InitStats.csv", Constants.PROJECTPATH + "MultiXPing\\source\\Data\\LevelUpMultiplicator.csv");

            GameManager gameManager = new GameManager();
            gameManager.GameLoop();
            //Console.WriteLine("ENTER".Pastel(Color.FromArgb(255, 0, 0)));

        }

        public static void InitializeConsole()
        {

            Console.ForegroundColor = ConsoleColor.Black;
            Console.Title = "MultiXPing";

            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        }
    }
}