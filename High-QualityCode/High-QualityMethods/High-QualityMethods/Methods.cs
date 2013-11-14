using System;

namespace High_QualityMethods
{
    public class Methods
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            double halfPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(
                halfPerimeter *
                (halfPerimeter - a) *
                (halfPerimeter - b) *
                (halfPerimeter - c));

            return area;
        }

        public static string ConvertDigitToWord(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
            }

            throw new ArgumentException("Invalid number!");
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Input can not be null!");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("Array must have at least one element!");
            }

            int maxElement = int.MinValue;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        public static void PrintNumberWithPrecisionTwo(double number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        public static void PrintNumberMultipliedByHundredPercent(double number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        public static void PrintNumberWithAlignmentEight(double number)
        {
            Console.WriteLine("{0,8}", number);
        }

        public static bool CheckLineIsHorizontal(double x1, double x2)
        {
            bool isHorizontal = (x1 == x2);

            return isHorizontal;
        }

        public static bool CheckLineIsVertical(double y1, double y2)
        {
            bool isVertical = (y1 == y2);

            return isVertical;
        }

        public static double DistanceBetweenTwoPoints(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));

            return distance;
        }

        public static void Main()
        {
            Console.WriteLine(CalcTriangleArea(1, 2, 3));

            Console.WriteLine(ConvertDigitToWord(4));

            Console.WriteLine(FindMax(7, 8, 3, 2, 1, 2));

            PrintNumberWithPrecisionTwo(2.3);
            PrintNumberMultipliedByHundredPercent(0.55);
            PrintNumberWithAlignmentEight(2.30);

            bool horizontal = CheckLineIsHorizontal(3, 3);
            bool vertical = CheckLineIsVertical(-1, 1.5);
            Console.WriteLine(DistanceBetweenTwoPoints(3, -1, 3, 3.5));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student student1 = new Student() { FirstName = "Pesho", LastName = "Petrov" };
            student1.PersonalInfo = new PersonalInfo("17.02.1912", "Mursalevo");

            Student student2 = new Student() { FirstName = "Gosho", LastName = "Goshev" };
            student2.PersonalInfo = new PersonalInfo("03.11.1979", "Busmanci", "traktorist");

            Console.WriteLine("Everybody knows that it is {2}, that {0} is older than {1}.",
                student1.FirstName, student2.FirstName, student1.IsOlderThan(student2));
        }
    }
}
