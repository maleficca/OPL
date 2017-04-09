using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_5
{
    class Program
    {
        // The first method calculates the sum of the values in the 'tab' array
        static public float sum (float[] tab)
        {
            float sumTab = 0;

            foreach (float x in tab)
                sumTab += x;

            return sumTab;
        }

        // The second method calculates the average value of the values in the 'tab' array
        static public float mean (float[] tab)
        {
            float mean = 0;
            float sumValue = sum(tab);
            mean = sumValue / tab.Length;

            return mean;
        }

        // The third method shows all elements of the 'tab' array
        static public void showTab(float[] tab)
        {
            Console.WriteLine("Elements of the array:");
            foreach (float x in tab) Console.Write(x + " ");

        }

        static void Main(string[] args)
        {
            // Declaring variables
            int tabSize;

            // Entering the size of the array
            Console.WriteLine("Program calculates values inside an array using methods");
            Console.WriteLine("\nPlease enter the number of values in array: ");
            tabSize = int.Parse(Console.ReadLine());

            // Declaring an array with previously set size
            float[] tab = new float[tabSize];
            Console.WriteLine();

            for (int i = 0; i < tabSize; i++)
            {
                Console.Write("Element {0}: ", i + 1);
                tab[i] = float.Parse(Console.ReadLine());
            }

            // Using methods to write their results on the screen
            Console.WriteLine("\nSum of the array values: {0}", sum(tab));
            Console.WriteLine("Mean of the array values: {0}", mean(tab));
            showTab(tab);

            // Await user input
            Console.Read();


        }
    }
}
