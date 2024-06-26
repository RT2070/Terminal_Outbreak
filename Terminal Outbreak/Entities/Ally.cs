﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Entities
{
    internal class Ally
    {
        private int allyID;
        private string name = string.Empty;
        private string description = string.Empty;

        private bool isHired;

        private int allyWeaponDamageLR;
        private int allyWeaponDamageMR;
        private int allyTargetMultiLR;
        private int allyTargetMultiMR;
        
        public Ally(int ID) { 
            allyID = ID;
            isHired = false;

            switch (ID) 
            {
                case 0:
                    name = "Isabella \"Sheriff\" Barrett";
                    allyWeaponDamageLR = 10;
                    allyWeaponDamageMR = 10;
                    allyTargetMultiLR = 8;
                    allyTargetMultiMR = 8;
                    description = Utils.WrapText($"Some say she was born in the West, others say that's just how she's dressed. Regardless, Isabella's 8-shooter revolver: \"Lawful Evil\" packs a mean punch, causing {allyWeaponDamageLR} damage to {allyTargetMultiLR} enemies within both Long Range and Medium Range.");
                    

                    break;
                case 1:
                    name = "Dr Steven \"Boomstick\" Adams";
                    allyWeaponDamageLR = 0;
                    allyWeaponDamageMR = 5;
                    allyTargetMultiLR = 0;
                    allyTargetMultiMR = 10;
                    description = Utils.WrapText($"\"Open Wide, lets see what's inside!\" Steven was a dentist before he found his true calling in shotgun diplomacy. His shotgun: \"Lollipop\" will carefully deconstruct Zombies at Medium Range by dealing {allyWeaponDamageMR} damage to {allyTargetMultiMR} enemies.");
                    

                    break;
                case 2:
                    name = "Nathaniel \"Timmy\" Thomson";
                    allyWeaponDamageLR = 3;
                    allyWeaponDamageMR = 10;
                    allyTargetMultiLR = 20;
                    allyTargetMultiMR = 3;
                    description = Utils.WrapText($"Villain or hero, no one is certain, but it's heavily suspected that Nathaniel watched far too many mafia movies before the city lost power. His Thompson sub machine gun: \"Timothy\" proves that even the Apocalpyse can be classy by dishing out an appetiser of {allyWeaponDamageLR} damage to {allyTargetMultiLR} enemies at LR, and a full-auto full course of {allyWeaponDamageMR} damage to {allyTargetMultiMR} enemies within MR.");
                    

                    break;
                case 3:
                    name = "Maya \"Valkyrie\" Carter";
                    allyWeaponDamageLR = 50;
                    allyWeaponDamageMR = 0;
                    allyTargetMultiLR = 1;
                    allyTargetMultiMR = 0;
                    description = Utils.WrapText($"Hawk-eye, Eagle-eye, some people just have good eyes, okay?! Maya isn't one of those people, but she does have her 50-Cal Anti-material sniper rifle: \"Thor\" equipped with a 12x Thermal Scope to make up the difference, delivering {allyWeaponDamageLR} damage to {allyTargetMultiLR} enemy at Long Range.");
                    
                    break;
            }

        }

        public string GetName()
        {
            return name;
        }

        public string GetDiscription()
        {
            return description;
        }

        public int GetLRDamage()
        {
            return allyWeaponDamageLR;
        }

        public int GetLRTargetMulti()
        {
            return allyTargetMultiLR;
        }

        public int GetMRDamage()
        {
            return allyWeaponDamageMR;
        }

        public int GetMRTargetMulti()
        {
            return allyTargetMultiMR;
        }

        public bool GetIsHired()
        {
            return isHired;
        }
        public void SetIsHired(bool hired)
        {
            isHired = hired;
        }
    }
}
