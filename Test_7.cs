using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_7
{
    //Class for every Input-Output module of the controller
    class CIOModule
    {
        private char m_cModuleType;
        private int m_iNoInputs;
        private int m_iNoOutputs;

        //Default constructor
        public CIOModule()
        {
            m_cModuleType = 'n';
            m_iNoInputs = m_iNoOutputs = 0;
        }

        // ModuleType, NoInputs and NoOutputs parameters
        public char ModuleType
        {
            get { return m_cModuleType; }
            set { m_cModuleType = value; }
        }

        public int NoInputs
        {
            get { return m_iNoInputs; }
            set { m_iNoInputs = value; }
        }

        public int NoOutputs
        {
            get { return m_iNoOutputs; }
            set { m_iNoOutputs = value; }
        }

        // Constructor for defining CIOModule parameters
        public void DefineCIOModule(char type, int inputs, int outputs)
        {
            m_cModuleType = type;
            m_iNoInputs = inputs;
            m_iNoOutputs = outputs;
        }

        // Constructor for showing module details
        public void Show()
        {
            if (m_cModuleType == 'A') Console.WriteLine("Module data: analog, inputs: " + m_iNoInputs + ", outputs: " + m_iNoOutputs);
            else if (m_cModuleType == 'D') Console.WriteLine("Module data: digital, inputs: " + m_iNoInputs + ", outputs: " + m_iNoOutputs);
            else Console.WriteLine("Invalid module data input");
        }
    }

    class CController
    {
        private string m_sControllerName;
        CIOModule[] m_aModuleArray;

        // Default constructor
        public CController()
        {
            m_sControllerName = null;
            m_aModuleArray = null;
        }

        // ControllerName parameter
        public string ControllerName
        {
            get { return m_sControllerName; }
            set { m_sControllerName = value; }
        }

        // ModuleArray parameter
        public CIOModule[] ModuleArray
        {
            get { return m_aModuleArray; }
            set { m_aModuleArray = value; }
        }

        // Method for showing the constructor and module details
        public void Show()
        {
            Console.WriteLine("\nController name: " + m_sControllerName);
            Console.WriteLine("Number of modules: " + m_aModuleArray.Length);
            Console.WriteLine();

            foreach (CIOModule x in m_aModuleArray)
            {
                x.Show();
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            // Declaring variables and objects
            int noAnalog, noDigital = 0;

            CController controller = new CController();
            CIOModule analogModule = new CIOModule();
            CIOModule digitalModule = new CIOModule();

            // Intro message
            Console.WriteLine("Program uses classes and objects to describe controller modules");

            // Input the controller name
            Console.WriteLine("\nPlease enter the name of your controller: ");
            controller.ControllerName = Console.ReadLine();

            // Input number of analog modules and number of analog inputs/outputs in each
            Console.WriteLine("\nPlease enter the number of analog modules: ");
            noAnalog = int.Parse(Console.ReadLine());

            // Setting the digital module
            analogModule.ModuleType = 'A';
            Console.WriteLine("Please enter the number of analog inputs: ");
            analogModule.NoInputs = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the number of analog outputs: ");
            analogModule.NoOutputs = int.Parse(Console.ReadLine());

            // Input number of digital modules and number of digital inputs/outputs in each
            Console.WriteLine("\nPlease enter the number of digital modules: ");
            noDigital = int.Parse(Console.ReadLine());

            // Setting the digital module
            digitalModule.ModuleType = 'D';
            Console.WriteLine("Please enter the number of digital inputs: ");
            digitalModule.NoInputs = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the number of digital outputs: ");
            digitalModule.NoOutputs = int.Parse(Console.ReadLine());

            // Adding modules
            controller.ModuleArray = new CIOModule[noAnalog+noDigital];

            for (int x = 0; x < noAnalog + noDigital; x++)
            {
                if (x < noAnalog)
                {
                    controller.ModuleArray[x] = analogModule;
                }
                else controller.ModuleArray[x] = digitalModule;
            }

            // Showing information about controller and modules
            controller.Show();

            // Await user input
            Console.Read();



        }
    }
}
