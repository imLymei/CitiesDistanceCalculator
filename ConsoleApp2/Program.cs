using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        public class Cidade
        {
            public int ID { get; set; }
            public List<int> NEXT = new List<int>();
            public Cidade(int id)
            {
                ID = id;
            }
        }

        static public int[][] SetupCities()
        {
            int[] CITIES_LAYOUT_0 = new int[6] { 0, 0, 0, 0, 0, 0 };
            int[] CITIES_LAYOUT_1 = new int[6] { 0, 0, 1, 0, 0, 0 };
            int[] CITIES_LAYOUT_2 = new int[6] { 0, 0, 0, 0, 1, 0 };
            int[] CITIES_LAYOUT_3 = new int[6] { 0, 0, 1, 0, 1, 0 };
            int[] CITIES_LAYOUT_4 = new int[6] { 1, 0, 0, 0, 0, 0 };
            int[] CITIES_LAYOUT_5 = new int[6] { 0, 1, 0, 0, 0, 0 };

            int[][] MAIN_LAYOUT = new int[][] { CITIES_LAYOUT_0, CITIES_LAYOUT_1, CITIES_LAYOUT_2, CITIES_LAYOUT_3, CITIES_LAYOUT_4, CITIES_LAYOUT_5 };
            return MAIN_LAYOUT;
        }

        static void Main(string[] args)
        {
            int[][] MAIN_LAYOUT = SetupCities();
            int index = 0;

            foreach (int[] city in MAIN_LAYOUT)
            {
                Cidade new_city = new Cidade(index);
                int index_road = 0;
                foreach (int road in city)
                {
                    if (road == 1)
                    {
                        new_city.NEXT.Add(index_road);
                    }
                    index_road++;
                }
                Console.WriteLine($"A cidade {index} pode ir para:");
                foreach(int road in new_city.NEXT)
                {
                    Console.WriteLine($"Cidade {road}");
                }
                index++;
            }

            Console.ReadKey();
            
        }
    }
}
