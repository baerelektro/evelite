﻿using System;

using System.Collections.Generic;

namespace EverliteData
{

    public class PlanetDescriptor
    {
        public static string Name(uint[] seed)
        {
            String GenWord = "'@@LEXEGEZACEBISOUSESARMAINDIREA'ERATENBERALAVETIEDORQUANTEISRION";

            uint w0 = seed[0];
            uint w1 = seed[1];
            uint w2 = seed[2];
            uint B = (w0 + w1 + w2) % 65536;
            uint C = (w1 + w2 + B) % 65536;
            uint D = (w2 + B + C) % 65536;

            string Name = "";
            int NameLange = (int)((w0 % 256) / 64) % 2 == 0 ? 3 : 4;

            if (NameLange == 4)
            {
                Name = GenWord.Substring((int)((w2 / 256 % 32) * 2 + 1), 2) +
                       GenWord.Substring((int)((B / 256 % 32) * 2 + 1), 2) +
                       GenWord.Substring((int)((C / 256 % 32) * 2 + 1), 2) +
                       GenWord.Substring((int)((D / 256 % 32) * 2 + 1), 2);
            }

            if (NameLange == 3)
            {
                Name = GenWord.Substring((int)((w2 / 256 % 32) * 2 + 1), 2) +
                       GenWord.Substring((int)((B / 256 % 32) * 2 + 1), 2) +
                       GenWord.Substring((int)((C / 256 % 32) * 2 + 1), 2);
            }

            Name = Name.Replace("@", "");
            Name = Name.Replace("'", "");


            return (Name);

        }

        public static string Inhabitansname(uint[] seed)
        {
            String GenWord = "'@@LEXEGEZACEBISOUSESARMAINDIREA'ERATENBERALAVETIEDORQUANTEISRION";

            uint w0 = seed[0];
            uint w1 = seed[1];
            uint w2 = seed[2];
            uint B = (w0 + w1 + w2) % 65536;
            uint C = (w1 + w2 + B) % 65536;
            uint D = (w2 + B + C) % 65536;

            string name = "";
            int nameLange = (int)((w0 % 256) / 64) % 2 == 0 ? 3 : 4;

            if (nameLange == 4)
            {
                name = GenWord.Substring((int)((w2 / 256 % 32) * 2 + 1), 2) +
                       GenWord.Substring((int)((B / 256 % 32) * 2 + 1), 2) +
                       GenWord.Substring((int)((C / 256 % 32) * 2 + 1), 2) +
                       GenWord.Substring((int)((D / 256 % 32) * 2 + 1), 2);
            }

            if (nameLange == 3)
            {
                name = GenWord.Substring((int)((w2 / 256 % 32) * 2 + 1), 2) +
                       GenWord.Substring((int)((B / 256 % 32) * 2 + 1), 2) +
                       GenWord.Substring((int)((C / 256 % 32) * 2 + 1), 2);
            }

            name = name.Replace("@", "");
            name = name.Replace("'", "");

            string s = name.Substring(name.Length - 1);

            switch (s)
            {
                case "A":
                    name  = name + "N";
                    break;
                case "E":
                    name = name + "SE";
                    break;
                case "I":
                    name = name + "AN";
                    break;
                case "O":
                    name = name + "ESE";
                    break;
                case "U":
                    name = name + "AN";
                    break;
                default:
                    name = name + "IAN";
                    break;
            }

            return (name);

        }

        public static string Inhabitans(uint[] seed)
        {
            String inhabitans1 = "";
            String inhabitans2 = "";
            String inhabitans3 = "";

            uint w0 = seed[0];
            uint w1 = seed[1];
            uint w2 = seed[2];
            uint B = (w0 + w1 + w2) % 65536;
            uint C = (w1 + w2 + B) % 65536;
            uint D = (w2 + B + C) % 65536;

            uint i = (w2 / 256) / 4 % 8 + 1;
            switch (i)
            {
                case 1:
                    inhabitans1 = "Large";
                    break;
                case 2:
                    inhabitans1 = "Fierce";
                    break;
                case 3:
                    inhabitans1 = "Small";
                    break;
                default:
                    inhabitans1 = "";
                    break;
            }

            uint j = (w2 / 256) / 32 + 1;
            switch (j)
            {
                case 1:
                    inhabitans2 = "Green";
                    break;
                case 2:
                    inhabitans2 = "Red";
                    break;
                case 3:
                    inhabitans2 = "Yellow";
                    break;
                case 4:
                    inhabitans2 = "Blue";
                    break;
                case 5:
                    inhabitans2 = "Black";
                    break;
                case 6:
                    inhabitans2 = "Harmless";
                    break;
                default:
                    inhabitans2 = "";
                    break;
            }

            uint s = ((w0 / 256) % 2 + (w1 / 256) % 2) % 2 + (((w0 / 512) % 2 + (w1 / 512) % 2) % 2) * 2 + (((w0 / 1024) % 2 + (w1 / 1024) % 2) % 2) * 4;
            switch (s + 1)
            {
                case 1:
                    inhabitans3 = "Slimy";
                    break;
                case 2:
                    inhabitans3 = "Bug-Eyed";
                    break;
                case 3:
                    inhabitans3 = "Horned";
                    break;
                case 4:
                    inhabitans3 = "Bony";
                    break;
                case 5:
                    inhabitans3 = "Fat";
                    break;
                case 6:
                    inhabitans3 = "Furry";
                    break;
                default:
                    inhabitans3 = "";
                    break;
            }


            return (inhabitans1 + " " + inhabitans2 + " " + inhabitans3);

        }



    }

}