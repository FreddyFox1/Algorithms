using System;
using System.Collections.Generic;
using System.Threading;

namespace DijkstraAlgorithm
{
    /// <summary>
    /// Dijkstra's algorithm is an algorithm for finding the 
    /// shortest paths between nodes in a graph, which may represent, 
    /// for example, road networks. O(n^2)
    /// </summary>
    class Program
    {
        private const double Infinity = double.PositiveInfinity;

        private static List<string> Processed = new List<string>();
        private static Dictionary<string, Dictionary<string, double>> Graph = new Dictionary<string, Dictionary<string, double>>();
        private static Dictionary<string, double> Costs = new Dictionary<string, double>();
        private static Dictionary<string, string> Parents = new Dictionary<string, string>();

        static void Main()
        {
            FillGraph(Graph);
            FillCosts(Costs);
            FillParents(Parents);
            Console.WriteLine(FindPath(FindLowCostNode(Costs)));
            Console.ReadLine();
        }

        private static string FindPath(string node)
        {
            while (node != null)
            {
                var cost = Costs[node];
                var neighbors = Graph[node];
                foreach (var n in neighbors.Keys)
                {
                    var newCost = cost + neighbors[n];
                    if (Costs[n] > newCost)
                    {
                        Costs[n] = newCost;
                        Parents[n] = node;
                    }
                }
                Processed.Add(node);
                node = FindLowCostNode(Costs);
            }
            return (string.Join(", ", Costs));
        }

        private static void FillGraph(Dictionary<string, Dictionary<string, double>> Graph)
        {
            Graph.Add("start", new Dictionary<string, double>());
            Graph["start"].Add("a", 6);
            Graph["start"].Add("b", 2);
            Graph.Add("a", new Dictionary<string, double>());
            Graph["a"].Add("finish", 1);
            Graph.Add("b", new Dictionary<string, double>());
            Graph["b"].Add("finish", 5);
            Graph["b"].Add("a", 3);
            Graph.Add("finish", new Dictionary<string, double>());
        }

        private static void FillCosts(Dictionary<string, double> Costs)
        {
            Costs.Add("a", 6);
            Costs.Add("b", 2);
            Costs.Add("finish", Infinity);
        }
        private static void FillParents(Dictionary<string, string> Parents)
        {
            Parents.Add("a", "start");
            Parents.Add("b", "start");
            Parents.Add("in", string.Empty);
        }

        private static string FindLowCostNode(Dictionary<string, double> Costs)
        {
            var minCost = double.PositiveInfinity;
            string costNode = null;

            foreach (var node in Costs)
            {
                var cost = node.Value;
                if (cost < minCost && !Processed.Contains(node.Key))
                {
                    minCost = cost;
                    costNode = node.Key;
                }
            }
            return costNode;
        }
    }
}
