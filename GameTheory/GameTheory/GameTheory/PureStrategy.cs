using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class PureStrategy
    {
        public enum objective{min,max}

        static void Main(string[] args)
        {
            
            var N = 3;
            var M = 3;
            int[,] matrix =PureStrategy.Generate_2d_array(N,M);
            PureStrategy.Display_2d_array(matrix);
            var x = PureStrategy.check_rows(matrix,objective.max);
            var y = PureStrategy.check_columns(matrix,objective.min);
            
            //CASE 1 | P1: MAX | P2: MIN |
            Console.WriteLine("Case 1\nPlayer 1: MAX Player 2: MIN\n");
            Console.WriteLine("The Best Worst-Case Scenario for Player 1(Rows) Max\n" +
                              "Row: {0}, Column: {1},Value {2}", x.row+1,x.column + 1, x.value);
            Console.WriteLine("The Best Worst-Case Scenario for Player 2(Columns) Min\n" +
                              "Row: {0}, Column: {1},Value {2}\n", y.row+1,y.column + 1, y.value);

            //CASE 1 | P1: MIN | P2: MAX |
            var x2 = PureStrategy.check_rows(matrix, objective.min);
            var y2 = PureStrategy.check_columns(matrix, objective.max);
            Console.WriteLine("\nCase 2\nPlayer 1: MIN Player 2: MAX\n");
            Console.WriteLine("The Best Worst-Case Scenario for Player 1(Rows) Max\n" +
                              "Row: {0}, Column: {1},Value {2}", x.row + 1, x.column + 1, x.value);
            Console.WriteLine("The Best Worst-Case Scenario for Player 2(Columns) Min\n" +
                              "Row: {0}, Column: {1},Value {2}\n", y.row + 1, y.column + 1, y.value);
        }

        //Checking rows depending on the
        public static Decision check_rows(int[,] matrix, objective c)
        {
            Decision ret=new Decision(0,0,999);
            List<Decision> tmp = new List<Decision>();
            List<Decision> decisions = new List<Decision>();

            for (int i = 0; i < matrix.GetUpperBound(0)+1; i++)
            {
                for (int j = 0; j < matrix.GetUpperBound(1)+1; j++)
                {
                    tmp.Add(new Decision(i,j,matrix[i,j]));
                }
                //Select first from list sorted ASCENDING == SMALLEST value
                if (c == objective.max) decisions.Add(tmp.OrderBy(item => item.value).First());
                //Select first from list sorted DESCENDING == BIGGEST value
                if (c == objective.min) decisions.Add(tmp.OrderByDescending(item => item.value).First());
                tmp.Clear();
            }
            //Select first from list sorted ASCENDING == SMALLEST value
            if (c == objective.min) ret =  decisions.OrderBy(item => item.value).First();
            //Select first from list sorted DESCENDING == BIGGEST value
            if (c == objective.max) ret = decisions.OrderByDescending(item => item.value).First();
            return ret;
        }

        public static Decision check_columns(int[,] matrix, objective c)
        {
            Decision ret = new Decision(0, 0, 999);
            List<Decision> tmp = new List<Decision>();
            List<Decision> decisions = new List<Decision>();

            for (int j = 0; j < matrix.GetUpperBound(0) + 1; j++)
            {
                for (int i = 0; i < matrix.GetUpperBound(1) + 1; i++)
                {
                    tmp.Add(new Decision(i, j, matrix[i, j]));
                }
                //Select first from list sorted ASCENDING == SMALLEST value
                if (c == objective.max) decisions.Add(tmp.OrderBy(item => item.value).First());
                //Select first from list sorted DESCENDING == BIGGEST value
                if (c == objective.min) decisions.Add(tmp.OrderByDescending(item => item.value).First());
                tmp.Clear();
            }
            //Select first from list sorted ASCENDING == SMALLEST value
            if (c == objective.min) ret = decisions.OrderBy(item => item.value).First();
            //Select first from list sorted DESCENDING == BIGGEST value
            if (c == objective.max) ret = decisions.OrderByDescending(item => item.value).First();
            return ret;
        }

        //This method checks if already choosen "The Best Worst-Case Scenario" 
        //appears in other row/column depending on Players Goal
        public static void check_if_multiple_decisions()
        {

        }

        public static int[,] Generate_2d_array(int N,int M)
        {
            Random rd = new Random();
            int[,] matrix = new int[N, M];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    matrix[i, j] = rd.Next(-10, 10);
                }
            }
            return matrix;
        }

        public static void Display_2d_array(int[,] matrix)
        {
            Console.WriteLine("-------------------------");
            for (int i = 0; i < matrix.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < matrix.GetUpperBound(1)+1; j++)
                {
                    if (matrix[i, j] >= 0) Console.Write(" ");
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------");
        }
    }
}
