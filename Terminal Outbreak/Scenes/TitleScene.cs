﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes
{
    internal class TitleScene : Scene
    {
        
        public TitleScene(TerminalOutbreakGame game) : base(game) 
        {
                       
        }

        public override void Run()
        {
            string mainTitle = ($"{Environment.NewLine}▄▄▄█████▓█████ ██▀███  ███▄ ▄███▓██▓███▄    █ ▄▄▄      ██▓    {Environment.NewLine}▓  ██▒ ▓▓█   ▀▓██ ▒ ██▓██▒▀█▀ ██▓██▒██ ▀█   █▒████▄   ▓██▒    {Environment.NewLine}▒ ▓██░ ▒▒███  ▓██ ░▄█ ▓██    ▓██▒██▓██  ▀█ ██▒██  ▀█▄ ▒██░    {Environment.NewLine}░ ▓██▓ ░▒▓█  ▄▒██▀▀█▄ ▒██    ▒██░██▓██▒  ▐▌██░██▄▄▄▄██▒██░    {Environment.NewLine}  ▒██▒ ░░▒████░██▓ ▒██▒██▒   ░██░██▒██░   ▓██░▓█   ▓██░██████▒{Environment.NewLine}  ▒ ░░  ░░ ▒░ ░ ▒▓ ░▒▓░ ▒░   ░  ░▓ ░ ▒░   ▒ ▒ ▒▒   ▓▒█░ ▒░▓  ░{Environment.NewLine}    ░    ░ ░  ░ ░▒ ░ ▒░  ░      ░▒ ░ ░░   ░ ▒░ ▒   ▒▒ ░ ░ ▒  ░{Environment.NewLine}  ░        ░    ░░   ░░      ░   ▒ ░  ░   ░ ░  ░   ▒    ░ ░   {Environment.NewLine} ▒█████  █ ░  ██▄▄▄█████▓▄▄▄▄░  ██▀███ ▓█████▄▄▄   ░  ██ ▄█▀ ░{Environment.NewLine}▒██▒  ██▒██  ▓██▓  ██▒ ▓▓█████▄▓██ ▒ ██▓█   ▒████▄    ██▄█▒   {Environment.NewLine}▒██░  ██▓██  ▒██▒ ▓██░ ▒▒██▒ ▄█▓██ ░▄█ ▒███ ▒██  ▀█▄ ▓███▄░   {Environment.NewLine}▒██   ██▓▓█  ░██░ ▓██▓ ░▒██░█▀ ▒██▀▀█▄ ▒▓█  ░██▄▄▄▄██▓██ █▄   {Environment.NewLine}░ ████▓▒▒▒█████▓  ▒██▒ ░░▓█  ▀█░██▓ ▒██░▒████▓█   ▓██▒██▒ █▄  {Environment.NewLine}░ ▒░▒░▒░░▒▓▒ ▒ ▒  ▒ ░░  ░▒▓███▀░ ▒▓ ░▒▓░░ ▒░ ▒▒   ▓▒█▒ ▒▒ ▓▒  {Environment.NewLine}  ░ ▒ ▒░░░▒░ ░ ░    ░   ▒░▒   ░  ░▒ ░ ▒░░ ░  ░▒   ▒▒ ░ ░▒ ▒░  {Environment.NewLine}░ ░ ░ ▒  ░░░ ░ ░  ░      ░    ░  ░░   ░   ░   ░   ▒  ░ ░░ ░   {Environment.NewLine}    ░ ░    ░             ░        ░       ░  ░    ░  ░  ░     {Environment.NewLine}");
            string display = ($"In a world ravaged by an unknown plague, society has crumbled, and the streets teem with the undead. {Environment.NewLine}As a survivor, you must navigate through the chaos, scavenge for resources, and fight to stay alive. {Environment.NewLine}Welcome to Terminal Outbreak, and prepare to make every effort to OUTLIVE the UNDEAD.{Environment.NewLine}{Environment.NewLine}(Use the Arrow Keys to cycle through options and Enter to select){Environment.NewLine}");
            string[] options = { "Play", "About", "Exit" };

            Menu mainMenu = new Menu(display, options, mainTitle);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.Clear();
                    
                    Console.WriteLine("------------------");
                    Console.WriteLine("| Character Name |");
                    Console.WriteLine("------------------");
                    Console.WriteLine();
                    Console.CursorVisible = true;
                    string? playerName = Console.ReadLine();
                    
                    while (String.IsNullOrEmpty(playerName))
                    {
                        Console.WriteLine($"Please enter chacter name and then press enter: {Environment.NewLine}");
                        playerName = Console.ReadLine();
                    }
                    terminalOutbreakGame.player.SetName(playerName);
                    Console.CursorVisible = false;

                    PlayGame();
                    break;

                case 1:
                    DisplayAboutInformation();
                    break;

                case 2:
                    ExitGame();
                    break;
            }
        }

        private void PlayGame()
        {
            Console.Clear();
            terminalOutbreakGame.creditScene.Run();
        }

        private void ExitGame()
        {
            Environment.Exit(0);
        }

        private void DisplayAboutInformation()
        {
            Console.Clear();
            Console.WriteLine("---------");
            Console.WriteLine("| About |");
            Console.WriteLine("---------");
            Console.WriteLine("This game was created by Swift_Kogarashi (Komorebi) for the April 19-27th 2024 Text Jam.");
            Console.WriteLine("Credit goes to Chris Condon's \"The Last Stand\" games for inspiration for this project, and to Michael Hadley on YouTube for menu and interactions guides.");
            Console.WriteLine($"{Environment.NewLine}The goal of the game is to either repair the helicopter to escape, or to survive 20 nights against an ever-increasing zombie threat, while scavanging from the ruins of the city and building up your defenses and allies. You can trade for more weapons and resources using food rations, but beware, as running out could spell disaster.");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine($"{Environment.NewLine}<< Return to Main Menu >>");
            Utilities.PressEnter();
            Console.ResetColor();
            this.Run();

        }
    }
}