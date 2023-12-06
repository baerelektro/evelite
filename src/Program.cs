using System;

using System.Collections.Generic;

namespace EverliteData
{
    class Program

    {

        static void Main(string[] args)
        {

            

            uint w0 = 0b_0101_1010_0100_1010;
            uint w1 = 0b_0000_0010_0100_1000;
            uint w2 = 0b_1011_0111_0101_0011;
            

            List<Planet> planets = new List<Planet>();

            int index = 0;
            while (index < 256)
            {
                uint[] array = new uint[3];

                Planet planet = new Planet();


                array[0] = w0;
                array[1] = w1;
                array[2] = w2;

                uint j = 0;
                while (j < 4)
                {

                    uint temp = (w0 + w1 + w2) % 65536;
                    w0 = w1;
                    w1 = w2;
                    w2 = temp;
                    j++;
                }

                planet.random = array;
                planet.name = PlanetDescriptor.Name(array);
                planet.inhabitansname = PlanetDescriptor.Inhabitansname(array);
                uint[] position = new uint[2];
                position[0] = (array[1] / 256);
                position[1] = 128 -((array[0] / 256) / 2);
                planet.position = position;
                string[] inha = PlanetDescriptor.Inhabitans(array);
                planet.inhabitans = inha[0];
                planet.species = inha[1];
                uint[] gov = PlanetDescriptor.Government(array);
                planet.government = gov[0];
                uint[] eco  = { gov[1], gov[2]};
                planet.economy = eco;
                planet.techlevel = gov[3];
                planet.population = gov[4];
                planet.productivity = gov[5];
                planet.planetradius = gov[6];
                planet.planetarydescription = PlanetDescriptor.PlanetaryDescription(array);
                Console.WriteLine("{0}", planet.name);
                //Console.WriteLine("{0} {1}", planet.inhabitansname, planet.inhabitans);
                //Console.WriteLine("{0}", planet.species);
                //Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", planet.government, planet.economy[0], planet.economy[1], planet.techlevel, (float)planet.population/10, planet.productivity, planet.planetradius);
                //Console.WriteLine("{0} {1} {2}", planet.random[0], planet.random[1], planet.random[2]);
                //Console.WriteLine("{0} {1}", planet.position[0], planet.position[1]);
                Console.WriteLine("{0}", planet.planetarydescription);
                index++;
            }   
        
        }

    }
}