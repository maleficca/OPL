using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_6ver1
{
    class CBearing
    {
        private int m_iD;       // Bearing outer diameter
        private int m_id1;      // Bearing inner diameter
        private float m_fQdyn;  // Bearing dynamic load

        public CBearing()       // Default constructor, setting initial values
        {
            m_iD = m_id1 = 0;
            m_fQdyn = 0f;
        }
        public void SetValues() // User input values for each bearing
        {
            Console.WriteLine("Outer diameter: ");
            m_iD = int.Parse(Console.ReadLine());

            Console.WriteLine("Inner diameter: ");
            m_id1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Dynamic load: ");
            m_fQdyn = float.Parse(Console.ReadLine());

        }

        public void Show()  // Showing the parameters of the bearing
        {
            Console.WriteLine("Outer diameter: " + m_iD);
            Console.WriteLine("Inner diameter: " + m_id1);
            Console.WriteLine("Dynamically load: " + m_fQdyn);
        }

        static void Main(string[] args)
        {
            // Declaring variables
            int bearingNumber = 5;
            CBearing[] bearings = new CBearing[bearingNumber];

            int inDia;
            float dynL;
            
            // Loop using SetValues() to input bearing values and collect them in bearings[] array 
            for (int i = 0; i < bearingNumber; i++)
            {
                CBearing bearing = new CBearing();
                Console.WriteLine("\nPlease enter bearing {0} specification", i + 1);
                bearing.SetValues();
                bearings[i] = bearing;  
            }

            // Inputting the desired values of a bearing
            Console.WriteLine("\nPlease enter desired inner diameter: ");
            inDia = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter dynamic load: ");
            dynL = float.Parse(Console.ReadLine());

            // Loop searching for a bearing in bearings[] array with valid parameters
            foreach (CBearing x in bearings)
            {
                if (x.m_id1 >= inDia && x.m_fQdyn >= dynL)
                {
                    Console.WriteLine("\nFound matching bearing!");
                    x.Show();
                }
            }
            
            // Await user input
            Console.Read();

        }
    }
}
