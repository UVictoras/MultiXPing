﻿// See https://aka.ms/new-console-template for more information

using MultiXPing.source.Character;

namespace MultiXPing
{

    static class Constants
    {
        public const string PROJECTPATH = "..\\..\\..\\..\\";
        public const int WIDTH = 200;
        public const int HEIGHT = 100;


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

            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        }
    }
}