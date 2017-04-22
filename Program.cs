using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_6
{
    
    class Rect
    {
        private float rectA;        // Rectangle width
        private float rectB;        // Rectangle height

        public void setRect(float a, float b)       // This is the setRect for rectangle objects
        {
            rectA = a;
            rectB = b;
        }

        public void setRect(float side)             // This is the setRect for square objects
        {
            rectA = side;
            rectB = side;
        }

        public float Perimeter()       // Calculates the perimeter value of a given Rect object
        {
            float perimeter = 0f;

            perimeter = 2f * rectA + 2f * rectB;

            return perimeter;
        }

        public float Area()            // Calculates the area value of a given Rect object
        {
            float area = 0f;

            area = rectA * rectB;

            return area;
        }

        public void ShowRect()       // Shows the sizes of rectangle/square sides
        {
            if (rectA == rectB)
            {
                Console.WriteLine("\nSquare side value: " + rectA);
            }
            else
            {
                Console.WriteLine("\nRectangle width: " + rectA);
                Console.WriteLine("Rectangle height: " + rectB);
            }
        }

        static void Main(string[] args)
        {
            // Declaring temporary variables
            float temp1, temp2;

            Console.WriteLine("Program uses classes and functions to calculate square and rectangle values");

            // User inputs rectangle values
            Console.WriteLine("\nPlease enter rectangle width [cm]: ");
            temp1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Please enter rectangle height [cm]: ");
            temp2 = float.Parse(Console.ReadLine());

            // Creating the rectangle object using setRect
            Rect rectangle = new Rect();
            rectangle.setRect(temp1, temp2);
            
            // User inputs square size value
            Console.WriteLine("Please enter square size [cm]: ");
            temp1 = float.Parse(Console.ReadLine());

            // Creating the square object using setRect
            Rect square = new Rect();
            square.setRect(temp1);

            // Displaying rectangle size, perimeter and area
            rectangle.ShowRect();
            Console.WriteLine("Rectangle perimeter: " + rectangle.Perimeter());
            Console.WriteLine("Rectangle area: " + rectangle.Area());

            // Displaying square size, perimeter and area
            square.ShowRect();
            Console.WriteLine("Square perimeter: " + square.Perimeter());
            Console.WriteLine("Square area: " + square.Area());

            // Comparing the perimeter

            if (square.Perimeter().CompareTo(rectangle.Perimeter()) == 0)
                Console.WriteLine("\nPerimeters of the objects are the same");

            else if (square.Perimeter().CompareTo(rectangle.Perimeter()) == 1)
                Console.WriteLine("\nSquare perimeter is larger than rectangle perimeter");

            else Console.WriteLine("\nRectangle perimeter is larger than square perimeter");

            // Comparing the area

            if (square.Area().CompareTo(rectangle.Area()) == 0)
                Console.WriteLine("\nAreas of the objects are the same");

            else if (square.Area().CompareTo(rectangle.Area()) == 1)
                Console.WriteLine("\nSquare area is larger than rectangle area");

            else Console.WriteLine("\nRectangle area is larger than square area");

            // Await user input
            Console.Read();



        }
    }
}
