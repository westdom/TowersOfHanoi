using System;

namespace TowersOfHanoi
{
    class Program
    {

        const int MAX_TOWER_HEIGHT = 10;
        const bool PRINT_TOWERS = true;
        static readonly int[,] position = GenerateInitialPosition();

        static void Main(string[] args)
        {
            PrintPosition(position);
            Tower(MAX_TOWER_HEIGHT, 0, 1, 2);
            Console.WriteLine("Finished!");
        }

        private static int[,] GenerateInitialPosition()
        {
            int[,] position = new int[3, MAX_TOWER_HEIGHT];
            for (int i = 0; i < MAX_TOWER_HEIGHT; i++)
            {
                position[0, i] = i + 1;
                position[1, i] = 0;
                position[2, i] = 0;
            }
            return position;
        }

        private static void PrintPosition(int[,] position)
        {
            if(PRINT_TOWERS)
            {
                for (int i = 0; i < MAX_TOWER_HEIGHT; i++)
                {
                    Console.Write("{0} {1} {2}", position[0, i], position[1, i], position[2, i]);
                    Console.WriteLine();
                }
            }
        }

        private static void Tower(int a, int from, int aux, int to)
        {
            if (a == 1)
            {
                Console.WriteLine("Move disc 1 from stack {0} to stack {1}", (char)(from + 65), (char)(to + 65));
                SwapDisc(from, to);
                PrintPosition(position);
                return;
            }
            else
            {
                Tower(a - 1, from, to, aux);
                Console.WriteLine("Move disc {0} from stack {1} to stack {2}", a, (char)(from + 65), (char)(to + 65));
                SwapDisc(from, to);
                PrintPosition(position);
                Tower(a - 1, aux, from, to);
            }
        }

        private static void SwapDisc(int from, int to)
        {
            int fromTopIndex = GetTopOfFromStackIndex(position, from);
            int toTopIndex = GetTopOfToStackIndex(position, to);
            position[to, toTopIndex] = position[from, fromTopIndex];
            position[from, fromTopIndex] = 0;
        }

        private static int GetTopOfFromStackIndex(int[,] position, int stack)
        {
            for (int i = 0; i < MAX_TOWER_HEIGHT; i++)
            {
                int disc = position[stack, i];
                if (disc != 0)
                {
                    return i;
                }
            }
            return 0;
        }

        private static int GetTopOfToStackIndex(int[,] position, int stack)
        {
            for (int i = 0; i < MAX_TOWER_HEIGHT; i++)
            {
                int disc = position[stack, i];
                if (disc != 0)
                {
                    return i - 1;
                }
            }
            return MAX_TOWER_HEIGHT - 1;
        }
    }
}
