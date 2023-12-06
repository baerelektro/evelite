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

        public static string[] Inhabitans(uint[] seed)
        {
            String inhabitans;
            String inhabitans1;
            String inhabitans2;
            String inhabitans3;
            String basespecies;
            String species;

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

            uint k = (s + w2 / 256 % 4) % 8 + 1;
            switch (k)
            {
                case 1:
                    basespecies = "Rodents";
                    break;
                case 2:
                    basespecies = "Frogs";
                    break;
                case 3:
                    basespecies = "Lizards";
                    break;
                case 4:
                    basespecies = "Lobsters";
                    break;
                case 5:
                    basespecies = "Birds";
                    break;
                case 6:
                    basespecies = "Humanoids";
                    break;
                case 7:
                    basespecies = "Felines";
                    break;
                case 8:
                    basespecies = "Insects";
                    break;
                default:
                    basespecies = "";
                    break;
            }

            if (w2 % 256 < 127)
            {
                inhabitans = "Human Colonists";
                species = "Human Colonists";
            }
            else
            {
                inhabitans = inhabitans1 + (inhabitans1 != "" ? " " : "") + inhabitans2 + (inhabitans2 != "" ? " " : "") + inhabitans3 + (inhabitans3 != "" ? " " : "") + basespecies;
                species = basespecies;
            }

            string[] ret = { inhabitans, species };
            return (ret);

        }

        public static uint[] Government(uint[] seed)
        {

            uint w0 = seed[0];
            uint w1 = seed[1];
            uint w2 = seed[2];
            uint B = (w0 + w1 + w2) % 65536;
            uint C = (w1 + w2 + B) % 65536;
            uint D = (w2 + B + C) % 65536;


            uint government = (w1 % 256) /8 %8;
            uint economy1 = (w0 / 256) %8;
            uint economy2 = government < 2 ? economy1/4 * 4 + 2 + economy1 % 2 : economy1;
            uint techlevel = (1 - economy2/4)*4 + (1 - (economy2/2)%2)*2 + 1 - (economy2%2) + (w1/256)%4 + government/2 + government%2 + 1;
            uint population = (techlevel - 1) * 4 + government + economy2 + 1;
            uint productivity = ((1 - economy2 / 4) * 4 + (1 - ((economy2 / 2) % 2)) * 2 + (1 - economy2 % 2) + 3) * (government + 4) * population * 8;
            uint radius = (((w2 / 256) % 16) + 11) * 256 + (w1 / 256);
            uint[] ret = { government, economy1, economy2, techlevel, population, productivity, radius};
            return ret;


        }


        
        public static string PlanetaryDescription(uint[] seed)
        {
            String name = Name(seed);
            String inhabitansname = Inhabitansname(seed);
            String genWord = "@@LEXEGEZACEBISOUSESARMAINDIREA'ERATENBERALAVETIEDORQUANTEISRION";

            string[,] lookups = { { "fabled", "notable", "well known", "famous", "noted"  },
                                    { "very", "mildly", "most", "reasonably", "" },
                                    { "ancient", "[20]", "great", "vast", "pink" },
                                    { "[29] [28] plantations", "mountains", "[27]", "[19] forests", "oceans" },
                                    { "shyness", "silliness", "mating traditions", "loathing of [5]", "love for [5]" },
                                    { "food blenders", "tourists", "poetry", "discos", "[13]" },
                                    { "talking tree", "crab", "bat", "lobst", "%R" },
                                    { "beset", "plagued", "ravaged", "cursed", "scourged" },
                                    { "[21] civil war", "[26] [23] [24]s", "[26] disease", "[21] earthquakes", "[21] solar activity" },
                                    { "its [2] [3]", "the %I [23] [24]", "its inhabitants’ [25] [4]", "[32]", "its [12] [13]" },
                                    { "juice", "brandy", "water", "brew", "gargle blasters" },
                                    { "%R", "%I [24]", "%I %R", "%I [26]", "[26] %R" },
                                    { "fabulous", "exotic", "hoopy", "unusual", "exciting" },
                                    { "cuisine", "night life", "casinos", "sit coms", "[32]" },
                                    { "%H", "The planet %H", "The world %H", "This planet", "This world" },
                                    { "n unremarkable", " boring", " dull", " tedious", "revolting" },
                                    { "planet", "world", "place", "little planet", "dump" },
                                    { "wasp", "moth", "grub", "ant", "%R" },
                                    { "poet", "arts graduate", "yak", "snail", "slug" },
                                    { "tropical", "dense", "rain", "impenetrable", "exuberant" },
                                    { "funny", "weird", "unusual", "strange", "peculiar" },
                                    { "frequent", "occasional", "unpredictable", "dreadful", "deadly" },
                                    { "[1] [0] for [9]", "[1] [0] for [9] and [9]", "[7] by [8]", "[1] [0] for [9] but [7] by [8]", "a[15] [16]" },
                                    { "[26]", "mountain", "edible", "tree", "spotted" },
                                    { "[30]", "[31]", "[6]oid", "[18]", "[17]" },
                                    { "ancient", "exceptional", "eccentric", "ingrained", "[20]" },
                                    { "killer", "deadly", "evil", "lethal", "vicious" },
                                    { "parking meters", "dust clouds", "ice bergs", "rock formations", "volcanoes" },
                                    { "plant", "tulip", "banana", "corn", "%Rweed" },
                                    { "%R", "%I %R", "%I [26]", "inhabitant", "%I %R" },
                                    { "shrew", "beast", "bison", "snake", "wolf" },
                                    { "leopard", "cat", "monkey", "goat", "fish" },
                                    { "[11] [10]", "%I [30] [33]", "its [12] [31] [33]", "[34] [35]", "[11] [10]" },
                                    { "meat", "cutlet", "steak", "burgers", "soup" },
                                    { "ice", "mud", "Zero-G", "vacuum", "%I ultra" },
                                    { "hockey", "cricket", "karate", "polo", "tennis" }, };

            uint w0 = seed[0];
            uint w1 = seed[1];
            uint w2 = seed[2];
            uint B = (w0 + w1 + w2) % 65536;
            uint C = (w1 + w2 + B) % 65536;
            uint D = (w2 + B + C) % 65536;


            uint government = (w1 % 256) / 8 % 8;
            uint economy1 = (w0 / 256) % 8;
            uint economy2 = government < 2 ? economy1 / 4 * 4 + 2 + economy1 % 2 : economy1;
            uint techlevel = (1 - economy2 / 4) * 4 + (1 - (economy2 / 2) % 2) * 2 + 1 - (economy2 % 2) + (w1 / 256) % 4 + government / 2 + government % 2 + 1;
            uint population = (techlevel - 1) * 4 + government + economy2 + 1;
            uint productivity = ((1 - economy2 / 4) * 4 + (1 - ((economy2 / 2) % 2)) * 2 + (1 - economy2 % 2) + 3) * (government + 4) * population * 8;
            uint radius = (((w2 / 256) % 16) + 11) * 256 + (w1 / 256);

            String planetarydescription = "[14] is [22].";

            
            
            uint subseed = (w2 + w1 / 256 * 256 + (w1 % 256 * 2) % 256 + (w1 % 256) / 128) % 65536;
            uint subseed2 = (w1 / 256) * 256 + ((w1 % 256) * 2) % 256;

            uint u = 0;
            while (u < 22)
            {
                int g5ColumnOffset = (int)subseed / 13056;

                if (g5ColumnOffset > 3)
                {
                    g5ColumnOffset = 4;
                }

                planetarydescription = Convert(planetarydescription, lookups, g5ColumnOffset);

                uint stemp = (subseed2 + subseed / 256 * 256 + (subseed % 256 * 2) % 256 + (subseed % 256) / 128) % 65536;
                subseed2 = (subseed / 256) * 256 + ((subseed % 256) * 2) % 256;
                subseed = stemp;
                u++;
            }

            

            static string Convert(string input, string[,] lookups, int g5ColumnOffset)
            {
                // Проверка на наличие '[' в строке
                int openBracketIndex = input.IndexOf('[');
                if (openBracketIndex == -1)
                {
                    return input;
                }

                // Извлечение подстроки до '['
                string beforeBracket = input.Substring(0, openBracketIndex);

                // Поиск закрывающей скобки и извлечение числа между скобками
                int closeBracketIndex = input.IndexOf(']', openBracketIndex);
                string numberBetweenBrackets = input.Substring(openBracketIndex + 1, closeBracketIndex - openBracketIndex - 1);

                // Преобразование числа и получение значения из массива lookups
                if (!int.TryParse(numberBetweenBrackets, out int lookupIndex))
                {
                    throw new ArgumentException("Некорректное число между скобками.");
                }

                // Учитываем смещение, как в вашем Excel OFFSET
                string lookupValue = lookups[lookupIndex, g5ColumnOffset];

                // Добавление к результату оставшейся части строки после ']'
                string afterBracket = input.Substring(closeBracketIndex + 1);
                return beforeBracket + lookupValue + afterBracket;
            }



            // return planetarydescription;

            planetarydescription = planetarydescription.Replace("%H", char.ToUpper(name[0]) + name.ToLower().Substring(1));
            planetarydescription = planetarydescription.Replace("%I", inhabitansname.ToLower());
            return planetarydescription;

        }




    }

}