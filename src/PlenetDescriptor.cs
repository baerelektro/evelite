using System;
using System.Collections.Generic;
using System.Text;

namespace EverliteData
{

    public class PlanetDescriptor
    {
        public static string Name(uint[] seed)
        {
            String genWord = "'@@LEXEGEZACEBISOUSESARMAINDIREA'ERATENBERALAVETIEDORQUANTEISRION";
            var wordIndices = CalculateWordIndices(seed);

            var nameBuilder = new StringBuilder();
            foreach (var index in wordIndices)
            {
                nameBuilder.Append(genWord.Substring(index * 2 + 1, 2));
            }

            return nameBuilder.ToString().Replace("@", "").Replace("'", "");

        }

        private static IEnumerable<int> CalculateWordIndices(uint[] seed)
        {
            var (w0, w1, w2) = (seed[0], seed[1], seed[2]);
            var B = (w0 + w1 + w2) % 65536;
            var C = (w1 + w2 + B) % 65536;
            var D = (w2 + B + C) % 65536;

            var nameLength = (int)((w0 % 256) / 64) % 2 == 0 ? 3 : 4;

            yield return (int)(w2 / 256 % 32);
            yield return (int)(B / 256 % 32);
            yield return (int)(C / 256 % 32);
            if (nameLength == 4)
            {
                yield return (int)(D / 256 % 32);
            }
        }

        
        public static string Inhabitansname(uint[] seed)
        {
            String genWord = "'@@LEXEGEZACEBISOUSESARMAINDIREA'ERATENBERALAVETIEDORQUANTEISRION";

            var wordIndices = CalculateWordIndices(seed);

            var nameBuilder = new StringBuilder();
            foreach (var index in wordIndices)
            {
                nameBuilder.Append(genWord.Substring(index * 2 + 1, 2));
            }

            nameBuilder =  nameBuilder.Replace("@", "").Replace("'", "");

    

            String s = nameBuilder[0].ToString();

            switch (s)
            {
                case "A":
                    nameBuilder = nameBuilder.Append("N");
                    break;
                case "E":
                    nameBuilder = nameBuilder.Append("SE");
                    break;
                case "I":
                    nameBuilder = nameBuilder.Append("AN");
                    break;
                case "O":
                    nameBuilder = nameBuilder.Append("ESE");
                    break;
                case "U":
                    nameBuilder = nameBuilder.Append("AN");
                    break;
                default:
                    nameBuilder = nameBuilder.Append("IAN");
                    break;
            }

            return (nameBuilder.ToString());

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

            
            
            uint sd = (w2 + w1 / 256 * 256 + (w1 % 256 * 2) % 256 + (w1 % 256) / 128) % 65536;
            uint sd2 = (w1 / 256) * 256 + ((w1 % 256) * 2) % 256;

            int u = 0;


            while (u < 18)
            {
                int g5ColumnOffset = (int)sd / 13056;

                if (g5ColumnOffset > 3)
                {
                    g5ColumnOffset = 4;
                }
                String temp = planetarydescription;

                planetarydescription = Convert(planetarydescription, lookups, g5ColumnOffset);


                uint stemp;

                if (planetarydescription == temp)
                {
                    u++;
                    stemp = (sd2 + sd / 256 * 256 + (sd % 256 * 2) % 256 + (sd % 256) / 128) % 65536;
                    sd2 = (sd / 256) * 256 + ((sd % 256) * 2) % 256;
                    sd = stemp;
                    break;

                }

                stemp = (sd2 + sd / 256 * 256 + (sd % 256 * 2) % 256 + (sd % 256) / 128) % 65536;
                sd2 = (sd / 256) * 256 + ((sd % 256) * 2) % 256;
                sd = stemp;
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


            static string Stringpadding(uint sd, uint sd2)
            {
                String genWord = "ABOUSEITILETSTONLONUTHNOALLEXEGEZACEBISOUSESARMAINDIREA’ERATENBERALAVETIEDORQUANTEISRION";
                uint w;

                uint t1 = sd2/256%4 +1;

                uint t2 = ((sd) / 256 % 64 / 2) * 2 + 1;

                String k2 = genWord.Substring((int)t2 - 1, 2);
                
                w = (sd2 + sd / 256 * 256 + (sd % 256 * 2) % 256 + (sd % 256) / 128) % 65536;
                sd2 = (sd / 256) * 256 + ((sd % 256) * 2) % 256;
                sd = w;

                uint t3 = ((sd) / 256 % 64 / 2) * 2 + 1;
                String k3 = genWord.Substring((int)t3 - 1, 2);

                w = (sd2 + sd / 256 * 256 + (sd % 256 * 2) % 256 + (sd % 256) / 128) % 65536;
                sd2 = (sd / 256) * 256 + ((sd % 256) * 2) % 256;
                sd = w;

                uint t4 = ((sd) / 256 % 64 / 2) * 2 + 1;
                String k4 = genWord.Substring((int)t4 - 1, 2);


                w = (sd2 + sd / 256 * 256 + (sd % 256 * 2) % 256 + (sd % 256) / 128) % 65536;
                sd2 = (sd / 256) * 256 + ((sd % 256) * 2) % 256;
                sd = w;

                uint t5 = ((sd) / 256 % 64 / 2) * 2 + 1;


                String k5 = genWord.Substring((int)t5 - 1, 2);

                if (t1 < 3)
                {
                    return (k2 +  k3 +  k4 +  k5).Remove((int)t1 * 2);
                }
                else
                {
                    return (k2 + k3 + k4 + k5);
                }

            }

            
            



            planetarydescription = planetarydescription.Replace("%H", char.ToUpper(name[0]) + name.ToLower().Substring(1));
            planetarydescription = planetarydescription.Replace("%I", inhabitansname.ToLower());
            planetarydescription = planetarydescription.Replace("%R", Stringpadding(sd, sd2).ToLower());

            return planetarydescription;

        }

    }



}