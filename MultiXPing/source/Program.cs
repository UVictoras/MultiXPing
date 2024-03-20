﻿using Pastel;
using Color = System.Drawing.Color;

namespace MultiXPing
{

    static class Constants
    {
        public const string PROJECTPATH = "..\\..\\..\\..\\";
        public const int WIDTH = 200;
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

            /*            GameManager gameManager = new GameManager();
                        gameManager.GameLoop();*/
            Console.WriteLine("ENTER".Pastel(Color.FromArgb(255, 0, 0)));

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