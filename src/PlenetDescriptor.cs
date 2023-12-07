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
            var genWord = "ABOUSEITILETSTONLONUTHNOALLEXEGEZACEBISOUSESARMAINDIREA'ERATENBERALAVETIEDORQUANTEISRION";
            var wordIndices = CalculateWordIndices(seed);

            var nameBuilder = new StringBuilder();
            foreach (var index in wordIndices)
            {
                nameBuilder.Append(genWord.Substring(index * 2 + 1, 2));
            }

            var name = nameBuilder.ToString().Replace("@", "").Replace("'", "");
            return AddSuffixBasedOnLastChar(name);
        }


        private static string AddSuffixBasedOnLastChar(string name)
        {
            char lastChar = name[name.Length - 1];

            return lastChar switch
            {
                'A' => name + "N",
                'E' => name + "SE",
                'I' => name + "AN",
                'O' => name + "ESE",
                'U' => name + "AN",
                _ => name + "IAN",
            };
        }

        public static string[] Inhabitans(uint[] seed)
        {
            uint w0 = seed[0];
            uint w1 = seed[1];
            uint w2 = seed[2];
            uint B = (w0 + w1 + w2) % 65536;

            string inhabitans = GetInhabitansDescription(w0, w1, w2, B);
            string species = GetSpeciesDescription(w2);

            if (w2 % 256 < 127)
            {
                return new string[] { "Human Colonists", "Human Colonists" };
            }
            else
            {
                return new string[] { inhabitans, species };
            }
        }

        private static string GetInhabitansDescription(uint w0, uint w1, uint w2, uint B)
        {
            var builder = new StringBuilder();

            builder.Append(GetDescriptorBasedOnSeedValue((w2 / 256) / 4 % 8, new string[] { "", "Large", "Fierce", "Small" }));
            builder.Append(GetDescriptorBasedOnSeedValue((w2 / 256) / 32, new string[] { "", "Green", "Red", "Yellow", "Blue", "Black", "Harmless" }));
            builder.Append(GetDescriptorBasedOnSeedValue(((w0 / 256) % 2 + (w1 / 256) % 2) % 2 + (((w0 / 512) % 2 + (w1 / 512) % 2) % 2) * 2 + (((w0 / 1024) % 2 + (w1 / 1024) % 2) % 2) * 4, new string[] { "", "Slimy", "Bug-Eyed", "Horned", "Bony", "Fat", "Furry" }));

            return builder.ToString().Trim();
        }

        private static string GetSpeciesDescription(uint w2)
        {
            return GetDescriptorBasedOnSeedValue((w2 / 256 % 4) % 8, new string[] { "", "Rodents", "Frogs", "Lizards", "Lobsters", "Birds", "Humanoids", "Felines", "Insects" });
        }

        private static string GetDescriptorBasedOnSeedValue(uint index, string[] descriptors)
        {
            return index < descriptors.Length ? (descriptors[index] != "" ? " " + descriptors[index] : "") : "";
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