using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication23
{
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
            int sum = 0, min = 0, max = 0, avg = 0, card = 0 ;
            string line;

            // Array declaration

            // Use line below to check if the Exception handling works:
            //int[] vector = null;

            int[] vector = new int[] { 3, 7, -2, -3, 1, 8, 2, 3, -5, 0 };
            
            // Throwing an exception in case of an empty array
            if (vector == null) throw new Exception();

            Console.WriteLine("Program initializes an array of a given set of numbers: ");
            foreach (int i in vector) Console.Write(i + " ");
            Console.WriteLine("\nand performs calculations using foreach loop");

            // List declaration
           
                ArrayList vectList = new ArrayList(vector);


                // Calculating the sum of values and min, max

                foreach (int x in vectList)
                {
                    sum = sum + x;

                    if (x < min) min = x;
                    if (x > max) max = x;
                }


                // Calculating the avg value

                avg = sum / vectList.Count;
                card = vectList.Count;

                // Displaying the results

                Console.WriteLine("\nmin: {0}, max: {1}, ave: {2}, sum: {3}, card: {4}", min, max, avg, sum, card);

                // Sorting in ascending and descending order

                vectList.Sort();
                line = string.Join(", ", vectList.ToArray());
                Console.WriteLine("\nElements sorted in ascending order: " + line);

                vectList.Reverse();
                line = string.Join(", ", vectList.ToArray());
                Console.WriteLine("Elements sorted in descending order: " + line);
            }

            // catch snippet returns a written line when vector array == null 
            catch (Exception)
            {
                Console.WriteLine("\nError: Array 'vector' does not contain any elements");
            }

        
            Console.Read();
            


           
        }
    }
}
