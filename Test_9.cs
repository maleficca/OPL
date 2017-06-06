using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_9
{
    class CProfile
    {
        private double m_dLength;
        private double m_dWeightPerMeter;
        private char type;

        public char ProfileType
        {
            get { return type; }
            set { type = value; }
        }

        public double Length
        {
            get { return m_dLength; }
            set { m_dLength = value; }
        }

        public double WeightPerMeter
        {
            get { return m_dWeightPerMeter; }
            set { m_dWeightPerMeter = value; }
        }

        public CProfile()
        {
            ProfileType = 'N';
            Length = 0;
            WeightPerMeter = 0;
        }

        public CProfile (double length, double weightPerMeter, char profileType)
        {
            Length = length;
            WeightPerMeter = weightPerMeter;
            ProfileType = profileType;
        }

        public double getOverallWeight()
        {
            return ((Length/1000) * WeightPerMeter);
        }
    }

    class CIBeam : CProfile
    {
        private float m_dHeight;
        private float m_dWidth;
        private float m_dThickness;

        public float Height
        {
            get { return m_dHeight; }
            set { m_dHeight = value; }
        }

        public float Width
        {
            get { return m_dWidth; }
            set { m_dWidth = value; }
        }

        public float Thickness
        {
            get { return m_dThickness; }
            set { m_dThickness = value; }
        }

        public CIBeam()
        {
            m_dHeight = m_dThickness = m_dWidth = 0f;
            ProfileType = 'B';
            
        }

        public CIBeam(float height, float width, float thickness, double length, double weightPerMeter, char profileType)
                    : base(length, weightPerMeter, profileType)
        {
            Height = height;
            Width = width;
            Thickness = thickness;
            ProfileType = 'B';
        }

        public void Show()
        {
            Console.WriteLine("\nBeam parameters: ");
            Console.WriteLine("Height: {0} mm, Width: {1} mm, Thickness: {2} mm\nWeight/Meter: {3} kg/m, Overall weight: {4} kg", Height, Width, Thickness, WeightPerMeter, getOverallWeight());
        }
    }
        class CRoundTube: CProfile
        {
            private float m_dDiameter;
            private float m_dThickness;

            public float Diameter
            {
                get { return m_dDiameter; }
                set { m_dDiameter = value; }
            }

            public float Thickness
            {
                get { return m_dThickness; }
                set { m_dThickness = value; }
            }

            public CRoundTube()
            {
                m_dDiameter = m_dThickness = 0f;
                ProfileType = 'T';
            }

            public CRoundTube(float diameter, float thickness, double length, double weightPerMeter, char profileType)
                   : base(length, weightPerMeter, profileType)
            {
                Diameter = diameter;
                Thickness = thickness;
                ProfileType = 'T';
           }

            public void Show()
            {
                Console.WriteLine("\nRound tube parameters: ");
                Console.WriteLine("Diameter: {0} mm, Thickness: {1} mm\nWeight/Meter: {2} kg/m, Overall weight: {3} kg", Diameter, Thickness, WeightPerMeter, getOverallWeight());
            }
        }
    
    class Program
    {
        static void Main(string[] args)
        {
            int profileNo;
            char profileType;
            double overallMass = 0, beamMass = 0, tubeMass = 0;
            
            Console.WriteLine("Program stores information about construction profiles");

            CIBeam exampleBeam = new CIBeam(80f, 80f, 9f, 3000, 10.7, 'B');
            CRoundTube exampleTube = new CRoundTube(42f, 3f, 2500, 2.89, 'T');

            Console.WriteLine("Available profiles: ");
            exampleBeam.Show();
            exampleTube.Show();
            
            Console.Write("\nEnter the number of profiles in your construction: ");
            profileNo = int.Parse(Console.ReadLine());

            List<CProfile> profileList = new List<CProfile>();

            do
            {
                Console.WriteLine("What profile do you need?");
                Console.Write("B - beam, T - round tube: ");
                profileType = char.Parse(Console.ReadLine());

                if (profileType == 'B' || profileType == 'b')
                {
                    profileList.Add(exampleBeam);
                    profileNo--;
                }
                else if (profileType == 'T' || profileType == 't')
                {
                    profileList.Add(exampleTube);
                    profileNo--;
                }

            } while (profileNo > 0);

            foreach (CProfile x in profileList)
            {
                if (x.ProfileType == 'B')
                {
                    overallMass += x.getOverallWeight();
                    beamMass += x.getOverallWeight();
                }
                else
                {
                    overallMass += x.getOverallWeight();
                    tubeMass += x.getOverallWeight();
                }
            }

            Console.WriteLine("\nThe mass of the construction: ");
            Console.Write("Overall: {0} kg, Beam profiles: {1} kg, Tube profiles: {2} kg", overallMass, beamMass, tubeMass);

            Console.Read();

            
        }
    }
}
