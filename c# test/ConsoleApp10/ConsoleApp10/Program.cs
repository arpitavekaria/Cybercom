//program 10 to 17
using System;
using System.IO;
using System.Text;

namespace ConsoleApp10
{
    #region MultilevelInheritance
    public class Grandparent
    {
        public Grandparent()
        {
            Console.WriteLine("Constructor called at run-time");
        }
        public void DisplayGrandParentsAB()
        {
            Console.WriteLine("A and B are my grandparents");
        }
    }

    public class Parents : Grandparent
    {
        public void DisplayParentsCD()
        {
            Console.WriteLine("C and D are my parents");
        }
    }

    public class Child : Parents
    {
        public void DisplayChildZ()
        {
            Console.WriteLine("I am the child Z");
        }
    }
    #endregion MultilevelInheritance

    #region VirtualMethod
    public class Person
    {
        protected string name = "John";
        protected string age = "35";
        public virtual void GetInfo()
        {
            Console.WriteLine("Name: {0}", name);
            Console.WriteLine("Age: {0}", age);
            Console.WriteLine();
        }
    }
    class Employee : Person
    {
        public string ID = "101";
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine("Employee ID: {0}", ID);
        }
    }
    class Emp : Employee
    {
        private string EmployeeSalary = "22000";
        public new void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine("Student Address: {0}", EmployeeSalary);
        }
    }
    #endregion VirtualMethod

    #region 2DArray
    public class TwoDArray
    {
        int p,q;
        int[,] a;
        int[] b;
        public TwoDArray(int x, int y)
        {
            p = x;
            q = y;
            a = new int[p,q];
            b = new int[p*q];
        }

        public void ReadArray()
        {
            for (int i = 0; i < p; i++)
            {
                for (int j = 0; j < q; j++)
                {
                    Console.WriteLine("a[{0},{1}]=", i, j);
                    a[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        public void print()
        {
            for (int i = 0; i < p; i++)
            {
                for (int j = 0; j < q; j++)
                {
                    Console.Write("{0}\t", a[i, j]);

                }
                Console.Write("\n");
            }
        }

        public void convert()
        {
            int k = 0;
            for (int i = 0; i < p; i++)
            {
                for (int j = 0; j < q; j++)
                {
                    b[k++] = a[i, j];
                }
            }
        }
        public void printoneD()
        {
            for (int i = 0; i < p * q; i++)
            {
                Console.WriteLine("{0}\t", b[i]);
            }
        }
    }
    #endregion 2DArray

    #region DivideByZeroException
    class DivNumbers
    {
        int result;

        public DivNumbers()
        {
            result = 0;
        }
        public void division(int num1, int num2)
        {
            try
            {
                result = num1 / num2;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Exception caught: {0}", e);
            }
            finally
            {
                Console.WriteLine("Result: {0}", result);
            }
        }
    }
    #endregion DivideByZeroException

    #region userdefineException
    public class InvalidAgeException : Exception
    {
        public InvalidAgeException(String message)
            : base(message)
        {

        }
    }
    #endregion userdefineException
    class Program
    {
        #region Program16
        public static void validate(int age)
        {
            if (age < 18)
            {
                throw new InvalidAgeException("Sorry, Age must be greater than 18");
            }
        }
        #endregion Program16
        public static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("9. Multilevel Inheritance");
                    Console.WriteLine("10. Multilevel Inheritance with Virtual Methods.");
                    Console.WriteLine("11. output for the given snippet code");
                    Console.WriteLine("12. Convert a 2D Array into 1D Array");
                    Console.WriteLine("13. Get Lower Bound and Upper Bound of an Array");
                    Console.WriteLine("14. DivideByZero Exception");
                    Console.WriteLine("15. This C# Program Performs Bubble Sort");
                    Console.WriteLine("16. user-defined exception");
                    Console.WriteLine("17. calculating the percentage value of given number.");
                    Console.WriteLine("1. Exit");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Enter Switch Number: ");

                    int n = Convert.ToInt32(Console.ReadLine());
                    switch (n)
                    {
                        case 9:

                            Child cd = new Child();
                            cd.DisplayChildZ();
                            cd.DisplayParentsCD();
                            cd.DisplayGrandParentsAB();

                            Console.WriteLine("please press any key to continue.....");
                            Console.ReadKey();
                            break;

                        //--------------------------------------------------------------------------------------------------------------------------------

                        case 10:
                            Employee E = new Employee();
                            E.GetInfo();
                            Emp emp = new Emp();
                            emp.GetInfo();
                            Console.WriteLine("please press any key to continue.....");
                            Console.ReadKey();
                            break;

                        //--------------------------------------------------------------------------------------------------------------------------------

                        case 11:
                            float i = 1.0f, j = 0.05f;
                            do
                            {
                                Console.WriteLine(i++ - ++j);
                            } while (i < 2.0f && j <= 2.0f);
                            Console.ReadLine();
                            Console.WriteLine("please press any key to continue.....");
                            Console.ReadKey();
                            break;

                        //--------------------------------------------------------------------------------------------------------------------------------

                        case 12:
                            TwoDArray twoDArray = new TwoDArray(2,3);
                            Console.WriteLine("Enter Elements:");
                            twoDArray.ReadArray();
                            Console.WriteLine("\t\t Given 2-D Array(Matrix) is : ");
                            twoDArray.print();
                            twoDArray.convert();
                            Console.WriteLine("\t\t Converted 1-D Array is : ");
                            twoDArray.printoneD();
                            Console.WriteLine("please press any key to continue.....");
                            Console.ReadKey();
                            break;

                        //--------------------------------------------------------------------------------------------------------------------------------

                        case 13:
                            Array intarray = Array.CreateInstance(typeof(int), 5);
                            intarray.SetValue(101, 0);
                            intarray.SetValue(102, 1);
                            intarray.SetValue(103, 2);
                            intarray.SetValue(104, 3);
                            intarray.SetValue(105, 4);

                            Console.WriteLine("Lower Bound : " + intarray.GetLowerBound(0));
                            Console.WriteLine("Upper Bound : " + intarray.GetUpperBound(0));

                            Console.WriteLine("please press any key to continue.....");
                            Console.ReadKey();
                            break;

                        //--------------------------------------------------------------------------------------------------------------------------------

                        case 14:
                            DivNumbers d = new DivNumbers();
                            d.division(25, 0);
                            Console.WriteLine("please press any key to continue.....");
                            Console.ReadKey();
                            break;

                        //--------------------------------------------------------------------------------------------------------------------------------

                        case 15:
                            int[] arr = { 78, 55, 45, 98, 13 };
                            int temp;
                            for (int y = 0; y <= arr.Length - 2; y++)
                            {
                                for (int x = 0; x <= arr.Length - 2; x++)
                                {
                                    if (arr[x] > arr[x + 1])
                                    {
                                        temp = arr[x + 1];
                                        arr[x + 1] = arr[x];
                                        arr[x] = temp;
                                    }
                                }
                            }
                            Console.WriteLine("Sorted:");
                            foreach (int p in arr)
                            {
                                Console.Write(p + " ");
                            }
                            Console.Read();
                            Console.WriteLine("please press any key to continue.....");
                            Console.ReadKey();
                            break;

                        //--------------------------------------------------------------------------------------------------------------------------------

                        case 16:
                            try
                            {
                                validate(12);
                            }
                            catch (InvalidAgeException e)
                            {
                                Console.WriteLine(e); 
                            }
                            Console.WriteLine("other code");
                            Console.WriteLine("please press any key to continue.....");
                            Console.ReadKey();
                            break;

                        case 17:
                            int number, percentage, option;
                            float result;

                        label:
                            Console.Write("\n\nEnter a number:\t");
                            number = Convert.ToInt32(Console.ReadLine());

                            Console.Write("\nEnter Percentage Value:\t");
                            percentage = Convert.ToInt32(Console.ReadLine());

                            result = (float)(number * percentage) / 100;
                            Console.WriteLine("Percentage value is:\t{0}", result);
                            Console.Write("\nCalculate again press 1. To quit press any other digit:\t");
                            option = Convert.ToInt32(Console.ReadLine());
                            if (option == 1)
                            {
                                goto label;
                            }
                            Console.WriteLine("Press Enter for quit");
                            Console.ReadLine();
                            Console.WriteLine("please press any key to continue.....");
                            Console.ReadKey();
                            break;

                        case 1:
                            System.Environment.Exit(0);
                            break;

                        //--------------------------------------------------------------------------------------------------------------------------------

                        default:
                            Console.WriteLine("Enter valid input");
                            Console.WriteLine("please press any key to continue.....");
                            Console.ReadKey();
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occure={0}", e.Message);
            }

        }

    }
}
