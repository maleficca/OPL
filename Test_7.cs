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

        // Constructor for setting the name of the controller
        public void SetName(string name)
        {
            m_sControllerName = name;
        }

        // Constructor for adding modules to the controller
        public void AddModule (int analogModulesNo, int digitalModulesNo, CIOModule analog, CIOModule digital)
        {
            int moduleNo = analogModulesNo + digitalModulesNo;

            m_aModuleArray = new CIOModule[moduleNo];

            for (int x = 0; x < moduleNo; x++)
            {
                if (x < analogModulesNo)
                {
                    m_aModuleArray[x] = analog;
                }
                else m_aModuleArray[x] = digital;
            }

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
            int noAnalog, noDigital, analogIn, analogOut, digitalIn, digitalOut = 0;
            string controllerName;

            CController controller = new CController();
            CIOModule analogModule = new CIOModule();
            CIOModule digitalModule = new CIOModule();

            // Intro message
            Console.WriteLine("Program uses classes and objects to describe controller modules");

            // Input the controller name
            Console.WriteLine("\nPlease enter the name of your controller: ");
            controllerName = Console.ReadLine();

            // Set the controller name
            controller.SetName(controllerName);

            // Input number of analog modules and number of analog inputs/outputs in each
            Console.WriteLine("\nPlease enter the number of analog modules: ");
            noAnalog = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the number of analog inputs: ");
            analogIn = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the number of analog outputs: ");
            analogOut = int.Parse(Console.ReadLine());

            // Set the analog module
            analogModule.DefineCIOModule('A', analogIn, analogOut);

            // Input number of digital modules and number of digital inputs/outputs in each
            Console.WriteLine("\nPlease enter the number of digital modules: ");
            noDigital = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the number of digital inputs: ");
            digitalIn = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the number of digital outputs: ");
            digitalOut = int.Parse(Console.ReadLine());

            // Set the analog module
            digitalModule.DefineCIOModule('D', digitalIn, digitalOut);

            // Adding modules
            controller.AddModule(noAnalog, noDigital, analogModule, digitalModule);

            // Showing information about controller and modules
            controller.Show();

            // Await user input
            Console.Read();



        }
    }
}
