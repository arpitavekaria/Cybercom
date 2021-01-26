using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //-----simple read write-------
            Console.WriteLine("Hello Worlddd!");

            Console.WriteLine("Enter your name:");
            string Name = Console.ReadLine();
            Console.WriteLine("{0} is my name", Name);

            Program p = new Program();
            p.maxnumber();
            p.maxswitch();
            p.maxarray();
            p.maxdowhile();
        }

        #region maxnumber
        //-------simple if else program to find max value-------
        public void maxnumber()
        {
            int a;
            int b;

            //input numbers
            Console.WriteLine("------Now simple maximum number value program...------");
            Console.Write("Enter first number : ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second number: ");
            b = Convert.ToInt32(Console.ReadLine());

            //finding max number using if-else
            if (a > b)
                Console.WriteLine("{0} is max", a);
            else
                Console.WriteLine("{0} is max", b);
        }
        #endregion maxnumber

        #region maxswitch
        //-------------simple switch case program to find max value-----------
        public void maxswitch()
        {
            int num1;
            int num2;

            Console.WriteLine("------Now simple maximum number value program using switch case------");

            //Reading two numbers from user
            Console.WriteLine("Enter two numbers to find maximum number: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            num2 = Convert.ToInt32(Console.ReadLine());

            // Condition to check maximum number
            switch (num1 > num2)
            {
                case true:
                    Console.WriteLine("{0} is Maximum number", num1);
                    break;

                case false:
                    Console.WriteLine("{0} is Maximum number", num2);
                    break;
            }
        }
        #endregion maxswitch

        #region maxarray
        //-------simple foreach loop program to find max value using array----
        public void maxarray()
        {
            int[] a = { 23, 434, 234, 543, 350, -23, 133, 54, 3, -34, -124 };

            int max = a[0];

            Console.WriteLine("------Now simple maximum number value program using array------");
            foreach (int i in a)
            {
                if (i > max) 
                    max = i; 
            }

            Console.WriteLine("{0} is max using foreach loop..",max);

        }
        #endregion maxarray

        #region maxdowhile
        //---------simple do while loop program for max value------------
        public void maxdowhile()
        {
            int nums;
            int max = 0;

            Console.WriteLine("------Now simple maximum number value program using do while loop------");
            Console.WriteLine("Enter any number (Enter -1 to stop)");

            do
            {
                nums = Convert.ToInt32(Console.ReadLine());

                // Condition to check maximum number
                if (max < nums)
                    max = nums;

            } while (nums != -1);

            Console.WriteLine("{0} is max value",max);
        }
        #endregion maxdowhile
 
    }
}
