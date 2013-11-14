using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2CableGuy
{
    public class CableGuy
    {
        public static void Main()
        {
            int housesNumber = 10;

            List<Edge> connections = new List<Edge>();

            InitializeNeighborhoodMap(connections);

            connections.Sort();

            int[] houses = new int[housesNumber + 1];
            int housesCount = 1;

            List<Edge> mapForCables = new List<Edge>();

            housesCount = FindMinimumSpanningTree(connections, houses, mapForCables, housesCount);
            PrintMinimumSpanningTree(mapForCables);
        }

        private static int FindMinimumSpanningTree(List<Edge> connections, int[] houses, List<Edge> map, int housesCount)
        {
            foreach (var connection in connections)
            {
                if (houses[connection.StartNode] == 0)
                {
                    if (houses[connection.EndNode] == 0)
                    {
                        houses[connection.StartNode] = houses[connection.EndNode] = housesCount;
                        housesCount++;
                    }
                    else
                    {
                        houses[connection.StartNode] = houses[connection.EndNode];
                    }

                    map.Add(connection);
                }
                else
                {
                    if (houses[connection.EndNode] == 0)
                    {
                        houses[connection.EndNode] = houses[connection.StartNode];
                        map.Add(connection);
                    }
                    else if (houses[connection.EndNode] != houses[connection.StartNode])
                    {
                        int oldTreeNumber = houses[connection.EndNode];

                        for (int i = 0; i < houses.Length; i++)
                        {
                            if (houses[i] == oldTreeNumber)
                            {
                                houses[i] = houses[connection.StartNode];
                            }
                        }

                        map.Add(connection);
                    }
                }
            }

            return housesCount;
        }

        private static void PrintMinimumSpanningTree(List<Edge> usedConnection)
        {
            int distance = 0;

            Console.WriteLine(new string('-', 42));
            foreach (var connection in usedConnection)
            {
                Console.WriteLine(connection);
                distance += connection.Weight;
            }

            Console.WriteLine(new string('-', 42));
            Console.WriteLine("Total distance to be wired {0}", distance);
            Console.WriteLine(new string('-', 42));
        }

        private static void InitializeNeighborhoodMap(List<Edge> connections)
        {
            connections.Add(new Edge(1, 3, 7));
            connections.Add(new Edge(1, 2, 6));
            connections.Add(new Edge(1, 4, 11));
            connections.Add(new Edge(2, 4, 4));
            connections.Add(new Edge(3, 4, 22));
            connections.Add(new Edge(3, 5, 9));
            connections.Add(new Edge(4, 5, 10));
            connections.Add(new Edge(5, 6, 14));
            connections.Add(new Edge(6, 7, 15));
            connections.Add(new Edge(6, 8, 20));
            connections.Add(new Edge(7, 8, 6));
            connections.Add(new Edge(7, 9, 16));
            connections.Add(new Edge(8, 9, 10));
            connections.Add(new Edge(8, 1, 35));
            connections.Add(new Edge(7, 2, 28));
            connections.Add(new Edge(9, 10, 8));
            connections.Add(new Edge(8, 10, 14));
        }
    }
}
