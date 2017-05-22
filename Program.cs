using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_8
{
    class CPoint
    {
        private float m_iX;
        private float m_iY;

        public CPoint()
        {
            m_iX = m_iY = 0f;
        }

        public float mX
        {
            get { return m_iX; }
            set { m_iX = value; }
        }

        public float mY
        {
            get { return m_iY; }
            set { m_iY = value; }
        }
    }
    
    class CCircle
    {
        private CPoint m_Center;
        private int m_iDiameter;

        public CCircle()
        {
            m_Center = new CPoint();
            m_iDiameter = 0;
        }

        public CPoint Center
        {
            get { return m_Center; }
            set { m_Center = value; }
        }

        public int Diameter
        {
            get { return m_iDiameter; }
            set { m_iDiameter = value; }
        }

        // Method for showing the parameters of CCircle object
        public void Show()
        {
            Console.WriteLine("\nCircle parameters: ");
            Console.WriteLine("Center point coordinates: {0}, {1}", m_Center.mX, m_Center.mY);
            Console.WriteLine("Circle diameter: {0}", m_iDiameter);
        }

        public static CCircle operator+ (CCircle left, int right)
        {
            left.m_iDiameter = left.m_iDiameter + right;

            return left;
        }

        public static CCircle operator+ (CCircle left, CPoint right)
        {
            left.m_Center = right;

            return left;
        }

        public static CCircle operator* (CCircle left, int right)
        {
            left.m_iDiameter = left.m_iDiameter * right;

            return left;
        }
    }

    class Program
    {
        static void Main()
        {

            // Additional variables and objects
            int addDiam, multiply = 0;
            CPoint newCoordinates = new CPoint();

            // Creating Circle1 object
            CCircle Circle1 = new CCircle();

            // Starting message
            Console.WriteLine("Program uses classes and objects to manipulate circle coordinates");

            // Entering Circle1 coordinates and diameter
            Console.WriteLine("\nPlease enter circle coordinates");
            Console.Write("x: ");
            Circle1.Center.mX = float.Parse(Console.ReadLine());
            Console.Write("y: ");
            Circle1.Center.mY = float.Parse(Console.ReadLine());
            Console.Write("Diameter: ");
            Circle1.Diameter = int.Parse(Console.ReadLine());

            // Showing Circle1 coordinates and diameter
            Circle1.Show();

            // Entering a value to add to the Circle1 diameter and showing new parameters
            Console.WriteLine("\nEnter a value you want to add to the circle diameter");
            addDiam = int.Parse(Console.ReadLine());

            Circle1 = Circle1 + addDiam;

            Circle1.Show();

            // Entering new coordinates for Circle1 and displaying them
            Console.WriteLine("\nEnter new coordinates for circle: ");
            Console.Write("x: ");
            newCoordinates.mX = float.Parse(Console.ReadLine());
            Console.Write("y: ");
            newCoordinates.mY = float.Parse(Console.ReadLine());

            Circle1 = Circle1 + newCoordinates;

            Circle1.Show();

            // Multiplying diameter of the circle and displaying new parameters
            Console.WriteLine("\nEnter the number of times circle diameter should be multiplied");
            multiply = int.Parse(Console.ReadLine());

            Circle1 = Circle1 * multiply;

            Circle1.Show();

            // Await user input
            Console.Read();


        }
    }
}

