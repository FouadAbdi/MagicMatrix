using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicMatrix
{
    class MagicNumberConsole
    {
        public static int N;

        // N*N
        public static int MatrixCellsCount;


        public static void Main()
        {
            Console.Write("How Many Rows Or Columns Does Your Matrix(N*N) Have? ");
            N = int.Parse(Console.ReadLine());
            MatrixCellsCount = N * N;


            //Start Algorithm
            SolveMatrix(new List<int>());


            Console.WriteLine("==================      End        ===================");
            Console.ReadKey();
        }




        public static bool CheckSolveMatrix(int[,] Matrix)
        {
            List<int> Results = new List<int>();

            // Columns
            for (int i = 0; i < N; i++)
            {
                int sum = 0;
                for (int j = 0; j < N; j++)
                {
                    sum += Matrix[i, j];
                }
                Results.Add(sum);
            }


            // Rows
            for (int i = 0; i < N; i++)
            {
                int sum = 0;
                for (int j = 0; j < N; j++)
                {
                    sum += Matrix[j, i];
                }
                Results.Add(sum);
            }

            // Diameters
            int v1 = 0, v2 = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i == j)
                    {
                        //Main Diameter
                        v1 += Matrix[j, i];
                        //Secound Diameter
                        v2 += Matrix[N - i - 1, j];
                    }
                }
            }
            Results.Add(v1);
            Results.Add(v2);


            //Check Matrix Result
            int SameResult = Results.Count(a => a == Results.FirstOrDefault());


            return SameResult == Results.Count();
        }
        public static bool CheckSolveMatrix(List<int> m)
        {
            int[,] Matrix = new int[N, N];

            // Replace List To Matrix
            int counter = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Matrix[i, j] = m.ToArray()[counter];
                    counter++;
                }
            }

            return CheckSolveMatrix(Matrix);
        }
        public static void PrintMatrix(int[,] Matrix)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(Matrix[i, j].ToString().PadLeft(4));
                }
                Console.WriteLine();
            }
        }
        public static void PrintMatrix(List<int> m)
        {
            Console.WriteLine("======================");
            // Replace List To Matrix
            int counter = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(m.ToArray()[counter].ToString().PadLeft(4));

                    counter++;
                }
                Console.WriteLine();
            }
            Console.WriteLine("======================");
        }


        public static void SolveMatrix(List<int> m)
        {
            //Check Generated Matrix
            if (m.Count() == MatrixCellsCount)
            {
                // Check Solved Matrix 
                if (CheckSolveMatrix(m))
                {
                    PrintMatrix(m);
                    Console.WriteLine();
                    // Console.ReadKey();
                }

                return;
            }

            int Level = m.Count();


            // Generate New Matrix
            for (int i = 1; i <= MatrixCellsCount; i++)
            {
                //Check if i Dosen't Exist in Array
                if (!m.Contains(i))
                {
                    m.Add(i);

                    SolveMatrix(m);

                    while (m.Count() != Level)
                    {
                        //Remove Last Item (BackTrack)
                        m.RemoveAt(m.Count() - 1);
                    }
                }
            }
        }


    }

}
