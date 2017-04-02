using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication22
{
    class Program
    {
        static void Main(string[] args)
        {
            int nLim, kLim, i;
            double wPI = 1.0, bbpPI = 0.0, wError = 0.0, bbpError = 0.0, tempError = 0.0;

            // Start of the program

            Console.WriteLine("Program calculates PI values by Wallis and BBP formula");
            Console.WriteLine("and compares which one is more accurate");
            Console.WriteLine();
           
            // Input from the user

            Console.WriteLine("Please enter nLim value: ");
            nLim = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter kLim value: ");
            kLim = int.Parse(Console.ReadLine());

            // Calculating PI value using Wallis formula and calculation error

            for (i = 1; i <= nLim; i++)
            {
                wPI = wPI * ( (4.0 * i * i) / ((4.0 * i * i) - 1.0) );
                tempError = Math.PI - wPI;
                if (tempError < 0)
                {
                    tempError *= -1.0;
                    wError += tempError * 2.0;
                }
                else wError += tempError * 2.0;
            }

            wPI = wPI * 2.0;
            wError = wError / nLim;


            // Calulating PI value using BBP formula

            for (i = 0; i <= kLim; i++)
            {
                bbpPI = bbpPI + ((1 / Math.Pow(16.0, i)) * ((4.0 / (8.0 * i + 1.0)) - (2.0 / (8.0 * i + 4.0)) - (1.0 / (8.0 * i + 5.0)) - (1.0 / (8.0 * i + 6.0))));
                tempError = Math.PI - bbpPI;
                if (tempError < 0)
                {
                    tempError *= -1.0;
                    bbpError += tempError;
                }
                else bbpError += tempError;
            }

            bbpError = bbpError / kLim;

            // Displaying the results

            Console.WriteLine("\nPI value calculated by Wallis formula: "+ wPI);
            Console.WriteLine("PI value calculated by BBP formula: "+ bbpPI);
            Console.WriteLine("Actual PI value: " + Math.PI);

            Console.WriteLine("\nAverage error of Wallis formula: " + wError);
            Console.WriteLine("Average error of BBP formula: " + bbpError);

            // In case of nLim = kLim
            if (nLim == kLim)
            {
                if (wError < bbpError) Console.WriteLine("Wallis formula calulates the PI value with higher accuracy");
                else if (bbpError < wError) Console.WriteLine("BBP formula calculates the PI value with higher accuracy");
                else if (bbpError == wError) Console.WriteLine("Both formulae calculate the PI value with the same accuracy");
            }

            // Awaiting user input
            Console.Read();

            
        }
    }
}
