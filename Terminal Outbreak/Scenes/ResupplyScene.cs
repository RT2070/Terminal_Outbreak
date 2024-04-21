﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Items;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes
{
    internal class ResupplyScene : Scene
    {
        
        private List<Resource> resources;
        private List<Equipment> equipment;
        private bool failedRun;


        public ResupplyScene(TerminalOutbreakGame game) : base(game)
        {
            resources = new List<Resource>();
            equipment = new List<Equipment>();
            failedRun = false;
    }

        public override void Run()
        {
            string header = Utils.FrameText("Resupply Run");

            string enoughTime = "You prepare to head out on a resupply run. ";
            if(failedRun == true)
            {
                enoughTime = $"Not enough time! There is only {terminalOutbreakGame.baseManager.getTime()} hours left before nightfall. ";
            }

            string display = Utils.WrapText($"{Environment.NewLine}{enoughTime}How much time do you want to spend looking for supplies?{Environment.NewLine}");
             
            string[] options = { "Long Resupply Run - 8hrs", "Short Resupply Run - 4hrs", "Return"};
            Menu resupplyMenu = new Menu(display, options, header);
            int selectedIndex = resupplyMenu.RunHeaderVersion();

            switch (selectedIndex)
            {
                case 0: // Long Supply Run
                    SupplyRun(8.00f);
                    break;
                
                case 1: //Short Supply Run
                    SupplyRun(4.00f);
                    break;
                
                case 2:// resets failedRun and returns to previous menu
                    failedRun = false;
                    terminalOutbreakGame.baseScene.Run();
                    break;
            }

        }

        private void SupplyRun(float timeTaken)
        {
            float actionTime = timeTaken;
            if (terminalOutbreakGame.baseManager.getTime() >= actionTime)
            {
                failedRun = false;
                // terminalOutbreakGame.baseManager.reduceTime(actionTime);                             // TO DO----------- Turn this back on
                List<Resource> resultsList = terminalOutbreakGame.resourceManager.Resupply(actionTime); // fetches gathered resources with Long Resupply being true
                
                Dictionary<string, int> resourceCounts = new Dictionary<string, int>();
                
                foreach (Resource resource in resultsList)
                {
                    // If resource name exists in dictionary, increment its count
                    if (resourceCounts.ContainsKey(resource.GetResourceName()))
                    {
                        resourceCounts[resource.GetResourceName()]++;
                    }
                    // Otherwise, add the resource name to the dictionary with count 1
                    else
                    {
                        resourceCounts[resource.GetResourceName()] = 1;
                    }
                }
                string results = "";

                foreach (var kvp in resourceCounts) //                                              ============>>>>  TO DO: Use resourceCounts dictionary to update BaseManager Dictionary for total resources
                {
                    results += $"{Environment.NewLine}{kvp.Key}: {kvp.Value}";
                }


                string header = Utils.FrameText("Results");
                string display = $"Spent {actionTime} hours looking and found {results}";
                string[] options = { "Return To Outpost" };

                Menu resupplyResultsMenu = new Menu(display, options, header);
                int selectedIndex = resupplyResultsMenu.RunHeaderVersion();

                switch (selectedIndex) { case 0: terminalOutbreakGame.baseScene.Run(); break; };  
                            
            }
            else
            {
                failedRun = true;
                terminalOutbreakGame.resupplyScene.Run(); // calls the screen again with updated info
            }
        }

        //private void ShortSupplyRun()
        //{
        //    float actionTime = 4f;
        //    if (terminalOutbreakGame.baseManager.getTime() >= actionTime)
        //    {
        //        failedRun = false;
        //        terminalOutbreakGame.baseManager.reduceTime(actionTime);
        //        Console.WriteLine($"Spent {actionTime} hours looking");
        //        Utils.PressEnter();
        //        terminalOutbreakGame.baseScene.Run();                   // TO DO - change to a results screen
        //    }
        //    else
        //    {
        //        failedRun = true;
        //        terminalOutbreakGame.resupplyScene.Run(); // calls the screen again with updated info
        //    }
        //}


    }
}