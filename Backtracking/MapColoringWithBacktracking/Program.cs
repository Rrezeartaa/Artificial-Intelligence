using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapColoringWithBacktracking
{
    class Program
    {
        static int N = 5;
        static int[,] SolutionMatrix = new int[N, 3];
        static int[,] InterconnectionMatrix = new int[N, N];
        static void Main(string[] args)
        {
            InterconnectionMatrix = new int[,]
            {
                {1,1,1,1,1 },
                {1,1,1,0,0 },
                {1,1,1,1,0 },
                {1,0,1,1,1 },
                {1,0,0,1,1 }
            };
            if(PaintColor(0))
            {
                for(int i=0;i<N; i++)
                {
                    for (int j = 0; j < 3; j++)
                        Console.Write(SolutionMatrix[i, j] + " ");

                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        }

        static bool PaintColor(int region)
        {
            if (region == N)
                return true;
            for(int i=0;i<3;i++)
            {
                if(CheckPainting(region, i))
                {
                    SolutionMatrix[region, i] = 1;

                    if (PaintColor(region + 1))
                        return true;

                    SolutionMatrix[region - 1, i] = 0;
                }                
            }

            return false;
        }

        static bool CheckPainting(int region, int color)
        {
            List<int> connections = new List<int>();
            for (int i = 0; i < N; i++)
                if (InterconnectionMatrix[region, i] == 1 && i != region)
                    connections.Add(i);

            for (int i = 0; i < connections.Count; i++)
                if (SolutionMatrix[connections[i], color] == 1)
                    return false;

            return true;
        }
    }
}
