using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_10
{
    public interface IStrengthParam
    {
        double GetInertiaMoment();
        double GetSectionModulus();
    }

    abstract class CProfile: IStrengthParam
    {
        private double m_dLength;  //lenght of structural [mm]
        private double m_dWeightPerMeter; //weight of structural per 1 meter [kg/m]
        private string m_sType = "unknown"; //type of structural

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

        public string StructuralType
        {
            get { return m_sType; }
            set { m_sType = value; }
        }


        public CProfile()
        {
            m_dLength = 0;
            m_dWeightPerMeter = 0;
        }

        public CProfile(double length, double weight)
        {
            Length = length;
            WeightPerMeter = weight;
        }


        public double getOverallWeight()
        {
            return (m_dLength / 1000 * m_dWeightPerMeter);
        }


        public virtual void Show()
        {
            Console.WriteLine("Profile: L={0}[mm], Weight={1}[mm]", Length, WeightPerMeter);
        }

        public virtual double GetInertiaMoment()
        {
            return 0;
        }

        public virtual double GetSectionModulus()
        {
            return 0;
        }

        public virtual double getArea()
        {
            return 0;
        }

        public virtual void Show2()
        {
            Console.WriteLine("Inertia moment: {1}, Section modulus: {2}", StructuralType, GetInertiaMoment(), GetSectionModulus());
        }

    }

    class CIBeam : CProfile
    {
        private double m_dHeight;
        private double m_dWidth;
        private double m_dThickness;


        public double Height
        {
            get { return m_dHeight; }
            set { m_dHeight = value; }
        }

        public double Width
        {
            get { return m_dWidth; }
            set { m_dWidth = value; }
        }


        public double Thickness
        {
            get { return m_dThickness; }
            set { m_dThickness = value; }
        }

        public CIBeam()
        {
            m_dHeight = 0;
            m_dWidth = 0;
            m_dThickness = 0;
            StructuralType = "I-beam";
        }


        public CIBeam(double height, double width, double thickness, double length, double weight)
            : base(length, weight)
        {
            Height = height;
            Width = width;
            Thickness = thickness;
            StructuralType = "I-beam";
        }

        public override void Show()
        {
            Console.WriteLine("I-Beam: H={0}mm, W={1}mm, Th={2}mm, L={3}mm, Weight={4}kg/m", m_dHeight, m_dWidth, m_dThickness, Length, WeightPerMeter);
        }

        public override double GetInertiaMoment()
        {
            double inertiaMoment = 0;

            inertiaMoment = ((Width * Math.Pow(Height, 3)) - (Width - Thickness) * (Math.Pow(Height - (2 * Thickness), 3))) / 12;
            inertiaMoment = Math.Round(inertiaMoment, 2);

            return inertiaMoment;
        }

        public override double GetSectionModulus()
        {
            double sectionModulus = 0;

            sectionModulus = (GetInertiaMoment()) / (Height / 2);
            sectionModulus = Math.Round(sectionModulus, 2);

            return sectionModulus;
        }

        public override double getArea()
        {
            double area = 0;

            area = (2 * Thickness * Width) + ((Height - (2 * Thickness)) * Thickness);
            area = Math.Round(area, 2);

            return area;
        }
    }


    class CRoundTube : CProfile
    {
        private double m_dDiameter;
        private double m_dThickness;


        public CRoundTube()
        {
            m_dDiameter = 0;
            m_dThickness = 0;
            StructuralType = "Tube";
        }


        public CRoundTube(double diameter, double thickness, double length, double weight)
            : base(length, weight)
        {
            Diameter = diameter;
            Thickness = thickness;
            StructuralType = "Tube";
        }


        public double Diameter
        {
            get { return m_dDiameter; }
            set { m_dDiameter = value; }
        }


        public double Thickness
        {
            get { return m_dThickness; }
            set { m_dThickness = value; }
        }


        public override void Show()
        {
            Console.WriteLine("Round Tube: D={0}mm, Th={1}mm, L={2}mm, Weight={3}kg/m", m_dDiameter, m_dThickness, Length, WeightPerMeter);
        }

        public override double GetInertiaMoment()
        {
            double inertiaMoment = 0;

            inertiaMoment = (Math.PI * (Math.Pow(Diameter, 4) - (Math.Pow(Diameter - (2 * Thickness), 4)))) / 64;
            inertiaMoment = Math.Round(inertiaMoment, 2);

            return inertiaMoment;
        }

        public override double GetSectionModulus()
        {
            double sectionModulus = 0;

            sectionModulus = GetInertiaMoment() / (Diameter / 2);
            sectionModulus = Math.Round(sectionModulus, 2);

            return sectionModulus;
        }

        public override double getArea()
        {
            double area = 0;

            area = (Math.PI * (Math.Pow(Diameter, 2) - (Math.Pow(Diameter - (2 * Thickness), 2)))) / 4;
            area = Math.Round(area, 2);

            return area;
        }
    }

 
    class Program
    {
        static void Main(string[] args)
        {
            double force = 0;
            double bendingStress = 0;
            double tensileStress = 0;

            CProfile[] objectArray = new CProfile[6];

            objectArray[0] = new CIBeam(80, 46, 4, 2500, 6);
            objectArray[1] = new CIBeam(100, 55, 5, 1500, 8.1);
            objectArray[2] = new CIBeam(120, 64, 5.5, 2000, 10.4);
            objectArray[3] = new CRoundTube(42.4, 3, 2500, 2.91);
            objectArray[4] = new CRoundTube(60.3, 3, 1500, 4.24);
            objectArray[5] = new CRoundTube(101.6, 5, 1000, 11.9);

            foreach (CProfile x in objectArray)
            {
                x.Show();
                x.Show2();
            }

            Console.Write("\nEnter the loading force: ");
            force = double.Parse(Console.ReadLine());

            double[,] stressArray = new double[6, 2];

            for (int i = 0; i < 6; i++)
            {
                bendingStress = (force * objectArray[i].Length) / objectArray[i].GetSectionModulus();
                tensileStress = force / objectArray[i].getArea();

                stressArray[i, 0] = bendingStress;
                stressArray[i, 1] = tensileStress;
            }

            Console.WriteLine("\nStress values: ");

            for (int i = 0; i < 6; i++)
            {

                Console.WriteLine("{0}, Bending stress: {1}, Tensile stress: {2}", objectArray[i].StructuralType, stressArray[i, 0], stressArray[i, 1]);

            }
            Console.Read();

        }
    }
}
