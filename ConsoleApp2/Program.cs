using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        // Cria a classe Cidade
        public class Cidade
        {
            // Cria as variavies ID e NEXT para cada cidade
            public int ID { get; set; }
            public List<int> NEXT = new List<int>();
            
            // Iniciador da cidade que muda o seu ID
            public Cidade(int id)
            {
                ID = id;
            }

            // Funcao de callback para calcular qual a menor distancia de uma cidade para a outra
            public int GoTo(int goalCity, List<Cidade> cities, int initialDistance = 0)
            {
                // Coloca a menor distancia inicial para 6 (Não é possível alcancar)
                int smallerDistance = 6;

                // Se acharmos a cidade destino retornamos o valor atual da distância
                if (goalCity == ID)
                {
                    return initialDistance;
                }

                // Para cada possível próxima cidade:
                foreach (int nextCity in NEXT)
                {
                    // Atualizamos a variavel de distancia atual
                    int distance = initialDistance;
                    // Aumentamos distância em um(1)
                    distance++;
                    // Verificamos as próximas cidade até recebermos o ultimo return
                    int newDistance = cities[nextCity].GoTo(goalCity, cities, distance);
                    // Se a distância recebida do callback for a menor disntância possível:
                    if (newDistance < smallerDistance)
                    {
                        // Mudamos a menor distância possível
                        smallerDistance = newDistance;
                    }
                }

                // Retornamos uma cidade sem saída e a primeira chamada do callback
                return smallerDistance;
            }
        }

        // Organiza a quantidade de cidades pelo tamnaho da matrix e suas respectivas conexões
        static public int[][] SetupCities()
        {
            int[] CITIES_LAYOUT_0 = new int[6] { 0, 0, 0, 0, 0, 0 };    //#################
            int[] CITIES_LAYOUT_1 = new int[6] { 0, 0, 1, 0, 0, 0 };    //#--5-------0----#
            int[] CITIES_LAYOUT_2 = new int[6] { 0, 0, 0, 0, 1, 0 };    //#--\|-----/|----#
            int[] CITIES_LAYOUT_3 = new int[6] { 0, 0, 1, 0, 1, 0 };    //#---1->2->4-----#
            int[] CITIES_LAYOUT_4 = new int[6] { 1, 0, 0, 0, 0, 0 };    //#------|\/|-----#
            int[] CITIES_LAYOUT_5 = new int[6] { 0, 1, 0, 0, 0, 0 };    //#-------3-------#
                                                                        //#################

            int[][] MAIN_LAYOUT = new int[][] { CITIES_LAYOUT_0, CITIES_LAYOUT_1, CITIES_LAYOUT_2, CITIES_LAYOUT_3, CITIES_LAYOUT_4, CITIES_LAYOUT_5 };
            return MAIN_LAYOUT;
        }

        // Funcao geral para descobrir a menor distância de uma cidade para outra
        static public void GoFromOneCityToAnother(int initialCity, int goalCity, List<Cidade> cities)
        {
            int distance = cities[initialCity].GoTo(goalCity, cities);
            Console.Clear();
            // Verifica se foi possivel chegar na cidade(diferente de 6) ou não(igual a 6)
            if (distance != 6)
            {
                Console.WriteLine($"A distancia da cidade {initialCity} para a cidade {goalCity} é de {distance}.");
            }
            else Console.WriteLine($"Não é possivel acessar a cidade {goalCity} a partir da cidade {initialCity}.");
        }

        static void Main()
        {
            // Cria a lista de todas as cidades
            List<Cidade> cities = new List<Cidade>();
            // Cria o layout da cidade e o salva
            int[][] MAIN_LAYOUT = SetupCities();
            int index = 0;

            // Cria todas as cidades no layout com suas conexões
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
                foreach (int road in new_city.NEXT)
                {
                }
                cities.Add(new_city);
                index++;
            }

            // Rotina do meno principal
            string response = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Escolha o que fazer:");
                Console.WriteLine("(1) - Calcular a distância entre duas cidade.");
                Console.WriteLine("(2) - Sair.");
                response = Console.ReadLine();

                switch (response)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Mapa das cidades:\n\n#################\n#--5-------0----#\n#--\\|-----/|----#\n#---1->2->4-----#\n#------|\\/|-----#\n#-------3-------#\n#################\n\n");
                        Console.WriteLine("Digite a cidade de inicio:");
                        int initialCity = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite a cidade destino:");
                        int goalCity = int.Parse(Console.ReadLine());
                        GoFromOneCityToAnother(initialCity, goalCity, cities);
                        Console.ReadKey();
                        break;

                    case "2":
                        break;
                }

            } while (response != "2");
        }
    }
}
