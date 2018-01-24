using System;
using System.Collections.Generic;
using System.Text;

namespace AandDS.Week10
{

    public class Graph
    {
        public int V;
        public List<int>[] adj;

        public Graph(int v)
        {
            V = v + 1;
            adj = new List<int>[v + 1];
            for (int i = 1; i < V; ++i)
                adj[i] = new List<int>();
        }

        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
            adj[w].Add(v);
        }
    }
    public class Assignments
    {
        public static int diceSum(int n, Dictionary<int, int> cache)
        {
            if (n == 0 || n == 1) return 1;
            if (n == 2) return 2;
            if (n == 3) return 4;
            if (!cache.ContainsKey(n))
                cache[n] = diceSum(n - 1, cache) + diceSum(n - 2, cache) + diceSum(n - 3, cache) + diceSum(n - 4, cache) + diceSum(n - 5, cache) + 1;

            return cache[n];
        }


        static int ROW = 5, COL = 5;

        bool IsSafe(int[,] M, int row, int col, bool[,] visited)
        {
            return (row >= 0) && (row < ROW) && (col >= 0) && (col < COL) && (M[row, col] == 1 && !visited[row, col]);
        }

        void DFS(int[,] M, int row, int col, bool[,] visited)
        {
            var rowNbr = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
            var colNbr = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };

            visited[row, col] = true;

            for (int k = 0; k < 8; ++k)
                if (IsSafe(M, row + rowNbr[k], col + colNbr[k], visited))
                    DFS(M, row + rowNbr[k], col + colNbr[k], visited);
        }

        int CountIslands(int[,] M)
        {
            bool[,] visited = new bool[ROW, COL];


            int count = 0;
            for (int i = 0; i < ROW; ++i)
                for (int j = 0; j < COL; ++j)
                    if (M[i, j] == 1 && !visited[i, j])
                    {
                        DFS(M, i, j, visited);
                        ++count;
                    }

            return count;
        }

        public static int diceSum(int n)
        {
            if (n == 0 || n == 1) return 1;
            if (n == 2) return 3;
            if (n == 3) return 4;
            return n <= 6 ? diceSum(n - 1) + 1 : diceSum(n - 1);
        }

        public static Graph PrepareGraph()
        {
            Graph g = new Graph(5);

            g.AddEdge(5, 3);
            g.AddEdge(1, 3);
            g.AddEdge(2, 4);
            g.AddEdge(3, 2);
            return g;
        }

        public static bool IsPathExists(Graph g, int s, int d)
        {

            bool[] visited = new bool[g.V];

            Queue<int> queue = new Queue<int>();

            visited[s] = true;
            queue.Enqueue(s);

            while (queue.Count != 0)
            {
                s = queue.Dequeue();

                foreach (var item in g.adj[s])
                {
                    if (item == d) return true;

                    if (!visited[item])
                    {
                        visited[item] = true;
                        queue.Enqueue(item);
                    }
                }
            }

            return false;
        }

        public static void DFS(Graph g, int s, bool[] visited)
        {
            visited[s] = true;
            for (int i = 1; i < g.adj[s].Count; ++i)
            {
                if (visited[g.adj[s][i]] == false)
                    DFS(g, g.adj[s][i], visited);
            }
        }

        public static int ConnectedComponentsCount(Graph g)
        {
            bool[] visited = new bool[g.V];
            int count = 0;
            for (int i = 1; i < g.V; i++)
            {
                if (visited[i]) continue;
                DFS(g, i, visited);
                count++;
            }

            return count;
        }

        static void multiply(int[,] a, int[,] b)
        {
            int[,] mul = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    mul[i, j] = 0;
                    for (int k = 0; k < 3; k++)
                        mul[i, j] += a[i, k] * b[k, j];
                }
            }

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    a[i, j] = mul[i, j];
        }

        static int Power(int[,] F, int n)
        {
            int[,] M = new int[,] { { 1, 1, 1 }, { 1, 0, 0 }, { 0, 1, 0 } };

            if (n == 1) return F[0, 0] + F[0, 1];
            Power(F, n / 2);
            multiply(F, F);

            if (n % 2 != 0) multiply(F, M);

            return F[0, 0] + F[0, 1];
        }

        public static int Find(int n)
        {
            int[,] F = new int[,] { { 1, 1, 1 }, { 1, 0, 0 }, { 0, 1, 0 } };
            return Power(F, n - 2);
        }
    }
}
