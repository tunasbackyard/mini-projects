using System;

namespace BMI_Calculator
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine(categorizeBMI(calculateBMI(getMass(), getHeight())));
        }

        static int getMass()
        {
            Console.WriteLine("mass(kg):");
            return Convert.ToInt32(Console.ReadLine());
        }

        static double getHeight()
        {
            Console.WriteLine("height(m):");
            return Convert.ToDouble(Console.ReadLine()); 
        }

        static double calculateBMI(int mass, double height)
        {
            return mass / (height*height);   
        }

        static string categorizeBMI(double bmi)
        {
            if (bmi <= 18.5)
                return "underweight";
            else if (bmi <= 25)
                return "healty weight";
            else if (bmi <=30)
                return "obesity class I";
            else if (bmi <=35)
                return "obesity class II";
            else if (bmi <=40)
                return "obesity class III";
            else
                return "obesity class IV";

        }
    }
}

