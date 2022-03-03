using System;

namespace VisualProgrammingLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int n = 1;
            int[] customers = new int[] { 5, 3, 4 };
            Console.WriteLine("Tests: ");
            Console.WriteLine(HW1.QueueTime(customers, n));
            n = 2;
            int[] customers2 = new int[] { 10, 2, 3, 3, 2 };
            Console.WriteLine(HW1.QueueTime(customers2, n));
            n = 2;
            int[] customers3 = new int[] { 2, 3, 10 };
            Console.WriteLine(HW1.QueueTime(customers3, n));
            n = 3;
            int[] customers4 = new int[] { 2, 3, 10 , 11, 21, 4};
            Console.WriteLine(HW1.QueueTime(customers4, n));
            n = 3;
            int[] customers5 = new int[] { 5, 5, 5, 2};
            Console.WriteLine(HW1.QueueTime(customers5, n));

        }
    }
    public class HW1
    {
        public static long QueueTime(int[] customers, int n)
        {
            int time = 0, num = customers.Length, min = 100, max = 0, cur = 0;
            int[] queue = new int[n];
            num = num - n;
            if(num < 1)
            {
                for(int i = 0; i< customers.Length; i++)
                {
                    if (customers[i] > max) max = customers[i];
                }
                time = max;
            }
            else
            {
                for(int i = 0; i< n; i++)
                {
                    queue[i] = customers[i];
                }
                cur = n;
                do
                {
                    for(int i = 0; i < n; i++)
                    {
                        if (queue[i] < min) min = queue[i];
                    }
                    time += min;
                    for (int i = 0; i < n; i++)
                    {
                        queue[i] -= min;
                        if (queue[i] < 1 && cur < customers.Length)
                        {
                            queue[i] = customers[cur];
                            cur++;
                            num--;
                        }
                    }
                    min = 100;
                } while (num != 0);
                max = 0;
                for(int i = 0; i < n; i++)
                {
                    if (queue[i] > max) max = queue[i];
                }
                if (max != 0) time += max;
            }
            return time;
        }
    }

}
