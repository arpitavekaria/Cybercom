//program 18 to 20
using System;
using System.IO;
using System.Text;

namespace ConsoleApp11
{
    public class ADD
    {
        int x, y;
        double f;
        string s;

        public ADD(int a, double b)
        {
            x = a;
            f = b;
        }
        public ADD(int a, string b)
        {
            y = a;
            s = b;
        }

        public void show()
        {
            Console.WriteLine("1st constructor (int + float): {0} ", (x + f));
        }

        public void show1()
        {
            Console.WriteLine("2nd constructor (int + string): {0}", (s + y));
        }
    }

    class Program
    {
        public static int Fib(int n1)
        {
            if (n1 <= 2)
                return 1;
            else
                return Fib(n1 - 1) + Fib(n1 - 2);
        }
        public static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("18.Write Date and Time ");
                    Console.WriteLine("19.constructor overloading");
                    Console.WriteLine("20.Fibonacci number ");
                    Console.WriteLine("1. Exit");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Enter Switch Number: ");

                    int n = Convert.ToInt32(Console.ReadLine());
                    switch (n)
                    {
                        case 18:
                            try
                            {
                                string file = @"C:\Users\Arpita\Desktop\practice\demo1.txt";
                                FileStream fs = new FileStream(file, FileMode.Create);
                                byte[] bdata = Encoding.Default.GetBytes(DateTime.Now.ToString());
                                fs.Write(bdata, 0, bdata.Length);
                                Console.WriteLine("Data Added");
                                fs.Close();
                                string data;
                                FileStream fsread = new FileStream(file, FileMode.Open, FileAccess.Read);
                                using (StreamReader sr = new StreamReader(fsread))
                                {
                                    data = sr.ReadToEnd();
                                }
                                Console.WriteLine(data);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message.ToString());
                            }
                            Console.ReadKey();
                            Console.WriteLine("please press any key to continue.....");
                            Console.ReadKey();
                            break;

                        //--------------------------------------------------------------------------------------------------------------------------------

                        case 19:
                            ADD g = new ADD(10, 20.2);
                            g.show();
 
                            ADD q = new ADD(10, "Roll No. is ");

                            q.show1();
                            Console.WriteLine("please press any key to continue.....");
                            Console.ReadKey();
                            break;

                        //--------------------------------------------------------------------------------------------------------------------------------

                        case 20:

                            int num;
                            Console.Write("\n\nRecursive Function : To calculate the Fibonacci number of a specific term :\n");
                            Console.Write("***************\n");
                            Console.Write("Enter a number: ");
                            num = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("\nThe Fibonacci of {0} th term  is {1} \n", num, Fib(num));
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
