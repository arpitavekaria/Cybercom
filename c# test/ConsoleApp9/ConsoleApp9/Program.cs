//program 1 to 8 
using System;
using System.Collections.Generic;

namespace ConsoleApp9
{
    #region Palindrome
    public class Palindrome
    {
        public static bool IsPalindrome(string str)
        {
            try
            {
                string word = str.ToLower();
                string first = word.Substring(0, word.Length / 2);
                char[] arr = word.ToCharArray();
                Array.Reverse(arr);
                string temp = new string(arr);
                string second = temp.Substring(0, temp.Length / 2);
                return first.Equals(second);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
    #endregion Palindrome

    //--------------------------------------------------------------------------------------------------------------------------------

    #region TextInput
    public class TextInput
    {
        public IList<char> list = new List<char>();

        public virtual void Add(char c)
        {
            list.Add(c);
        }

        public string GetValue()
        {
            string s = "";
            foreach (char l in list)
            {
                s = s + l;
            }
            return s;
        }
    }

    public class NumericInput : TextInput
    {
        public override void Add(char c)
        {
            if (c < '0' || c > '9') { }
            else
                list.Add(c);
        }
    }
    #endregion TextInput

    //--------------------------------------------------------------------------------------------------------------------------------

    #region matrix
    public class Matrix
    {
        int row = 0;
        int col = 0;
        int[,] matrix;
        public void setMatrix()
        {
            Console.WriteLine("Enter rows:");
            row = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Columns:");
            col = Convert.ToInt32(Console.ReadLine());
            matrix = new int[row, col];

            Console.WriteLine("enter the numbers");
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    Console.Write("element - [{0},{1}] : ", r, c);
                    matrix[r, c] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        public void PrintMatrix()
        {
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    Console.Write("{0}\t", matrix[r, c]);
                }
                Console.WriteLine("\n");
            }
        }
       public int min()
        {
            int smallvalue = matrix[0, 0];
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    if (smallvalue > matrix[r, c])
                    {
                        smallvalue = matrix[r, c];
                    }
                }
            }
            return smallvalue;
        }
    }
    #endregion matrix

    //--------------------------------------------------------------------------------------------------------------------------------

    class Program
    {

        public static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("1. Palindrom Checker");
                    Console.WriteLine("2. Numeric Input");
                    Console.WriteLine("3. counts the number of 1's");
                    Console.WriteLine("5. Prints a Binary Triangle");
                    Console.WriteLine("6. find smallest value in Matrix");
                    Console.WriteLine("7. Celsius to Fahrenheit Conversion");
                    Console.WriteLine("8. Reverse a String with Predefined Function");
                    Console.WriteLine("9. Exit");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Enter Switch Number: ");

                    int n = Convert.ToInt32(Console.ReadLine());
                    switch (n)
                    {
                        case 1:
                            Console.WriteLine("Enter word for palindrom check: ");
                            string word = Console.ReadLine();
                            Console.WriteLine(Palindrome.IsPalindrome(word));
                            Console.WriteLine("please press any key to continue.....");
                            Console.ReadKey();
                            break;

//--------------------------------------------------------------------------------------------------------------------------------

                        case 2:
                            TextInput input = new NumericInput();
                            Console.WriteLine("How many character or number you want to enter: ");
                            string total = Console.ReadLine();
                            int totalChar = Convert.ToInt32(total);

                            Console.WriteLine("Enter a character or number: ");
                            for (int i = 0; i < totalChar; i++)
                            {
                                char ch = Console.ReadLine()[0];
                                input.Add(ch);
                            }
                            Console.WriteLine("Numeric value:");
                            Console.WriteLine(input.GetValue());
                            Console.WriteLine("please press any key to continue.....");
                            Console.ReadKey();
                            break;

//--------------------------------------------------------------------------------------------------------------------------------

                        case 3:
                            int limit, count = 0;
                            Console.WriteLine("Enter the Limit : ");
                            limit = Convert.ToInt32(Console.ReadLine());
                            int[] a = new int[limit];

                            Console.WriteLine("Enter the Numbers :");
                            for (int i = 0; i < limit; i++)
                            {
                                a[i] = Convert.ToInt32(Console.ReadLine());
                            }
                            foreach (int op in a)
                            {
                                if (op == 1)
                                {
                                    count++;
                                }
                            }
                            Console.WriteLine("Number of 1's in the Entered Number : ");
                            Console.WriteLine(count);
                            Console.WriteLine("please press any key to continue.....");
                            Console.ReadKey();
                            break;
                            
//--------------------------------------------------------------------------------------------------------------------------------

                        case 5:
                            int j, lastInt = 0, inputbinary;
                            Console.WriteLine("Enter the Number of Rows : ");
                            inputbinary = Convert.ToInt32(Console.ReadLine());

                            for (int i = 1; i <= inputbinary; i++)
                            {
                                for (j = 1; j <= i; j++)
                                {
                                    if (lastInt == 1)
                                    {
                                        Console.Write("0");
                                        lastInt = 0;
                                    }
                                    else if (lastInt == 0)
                                    {
                                        Console.Write("1");
                                        lastInt = 1;
                                    }
                                }
                                Console.Write("\n");
                            }
                            Console.WriteLine("please press any key to continue.....");
                            Console.ReadKey();
                            break;

//--------------------------------------------------------------------------------------------------------------------------------

                        case 6:
                            Matrix m = new Matrix();
                            m.setMatrix();
                            m.PrintMatrix();

                            Console.WriteLine("Max value ={0}", m.min());
                            Console.WriteLine("please press any key to continue.....");
                            Console.ReadKey();
                            break;

//--------------------------------------------------------------------------------------------------------------------------------

                        case 7:
                            int celsius, fahrenheit;
                            Console.WriteLine("Enter the Temperature in Celsius(°C) : ");
                            celsius = Convert.ToInt32(Console.ReadLine());

                            fahrenheit = (celsius * 9) / 5 + 32;

                            Console.WriteLine("Temperature in Fahrenheit is(°F) : " + fahrenheit);
                            Console.WriteLine("please press any key to continue.....");
                            Console.ReadKey();
                            break;

//--------------------------------------------------------------------------------------------------------------------------------

                        case 8:
                            Console.WriteLine("Enter Number of Elements you Want to Hold in the Array? ");
                            int x = Convert.ToInt32(Console.ReadLine());
                            int[] array = new int[x];
                            Console.WriteLine("\n Enter Array Elements : ");
                            for (int i = 0; i < x; i++)
                            {
                                string s1 = Console.ReadLine();
                                array[i] = Convert.ToInt32(s1);
                            }

                            Array.Reverse(array);
                            Console.WriteLine("Reversed Array : ");
                            for (int i = 0; i < x; i++)
                            {
                                Console.WriteLine("Element {0} is {1}", i + 1, array[i]);
                            }
                            Console.WriteLine("please press any key to continue.....");
                            Console.ReadKey();
                            break;

 //--------------------------------------------------------------------------------------------------------------------------------

                        case 9:
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