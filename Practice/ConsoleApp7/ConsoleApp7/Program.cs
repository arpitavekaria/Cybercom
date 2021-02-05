using System;
using System.Threading;
using System.Diagnostics;

namespace ConsoleApp7
{
    #region ClassNumber1
    public class Number
    {
        public void Print()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }
        }

        //using ParameterizedThreadStart delegate
        public static void PrintNumber(object target)
        {
            int number = 0;
            if (int.TryParse(target.ToString(), out number))
            {
                for (int i = 1; i <= number; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
    #endregion ClassNumber1

    //--------------------------------------------------------------------------------------------------------------------

    #region ClassNumber2
    public class Number1
    {

        //using type safe manner
        int _target1;
        public Number1(int target1)
        {
            this._target1 = target1;
        }
        public void PrintNumber1()
        {
            for (int i = 1; i <=_target1; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
    #endregion ClassNumber2

    //--------------------------------------------------------------------------------------------------------------------
    
    #region ClassNumber3
    //Retrieving data from Thread function using callback method
    public class Number2
    {
        int _target;
        SumOfNumberCallback _callBackMethod;

        public Number2(int target,SumOfNumberCallback callBackMethod)
        {
            this._target = target;
            this._callBackMethod = callBackMethod;
        }

        public void PrintSumOfNumber()
        {
            int sum = 0;
            for (int i = 1; i <= _target; i++)
            {
                Console.WriteLine(i);
            }

            if (_callBackMethod != null)
                _callBackMethod(sum);
        }
    }
    #endregion ClassNumber3

    public delegate void SumOfNumberCallback(int SumOfNumber);

    class Program
    {
        static int Total = 0;
        public static void Main(string[] args)
        {

            #region ThreadStartDelegate

            //using thread start delegate
            Number num = new Number();
            Thread T1 = new Thread(num.Print);
            T1.Start();

            //---------------------------------------------------------------------------------------------------------

            //using ParameterizedThreadStart delegate
            Console.WriteLine("Please enter target number");
            object target = Console.ReadLine();
            //ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(Number.PrintNumber);
            Thread T2 = new Thread(Number.PrintNumber);
            T2.Start(target);

            //---------------------------------------------------------------------------------------------------------

            //using passing data to the Thread function in a type safe manner
            Console.WriteLine("Please enter target number");
            int target1 = Convert.ToInt32(Console.ReadLine());
            Number1 number1 = new Number1(target1);
            Thread T3 = new Thread(number1.PrintNumber1);
            T3.Start();

            #endregion ThreadStartDelegate

            //---------------------------------------------------------------------------------------------------------

            #region Callback

            //Retrieving data from Thread function using callback method
            Console.WriteLine("Please enter target number");
            int sumtarget = Convert.ToInt32(Console.ReadLine());

            SumOfNumberCallback sumOfNumberCallback = new SumOfNumberCallback(PrintSumOfNumber);

            Number2 number2 = new Number2(sumtarget, sumOfNumberCallback);
            Thread T4 = new Thread(new ThreadStart(number2.PrintSumOfNumber));
            T4.Start();

            #endregion Callback

            //---------------------------------------------------------------------------------------------------------

            #region Join-Alive

            Console.WriteLine("Starts Printing Threads");
            Thread T5 = new Thread(Program.Thread5Function);
            T5.Start();

            Thread T6 = new Thread(Program.Thread6Function);
            T6.Start();

            if(T5.Join(1000))
            { 
                Console.WriteLine("Thread5Function completed");
            }
            else
            {
                Console.WriteLine("Thread5Function not completed in 1 second");
            }

            T6.Join();
            Console.WriteLine("Thread6Function completed");

            for (int i = 0; i < 10; i++)
            {
                if (T5.IsAlive)
                {
                    Console.WriteLine("Thread5Function is still returning");
                    Thread.Sleep(300);
                }
                else
                {
                    Console.WriteLine("Thread5Function completed");
                    break;
                }
            }
            Console.WriteLine("Ends Printing Threads");

            #endregion Join-Alive

            //---------------------------------------------------------------------------------------------------------

            #region locking

            Stopwatch stopwatch = Stopwatch.StartNew();  //Stopwatch is used for deriving the time used to complete threads
            Thread thread1 = new Thread(Program.AddThousand);
            Thread thread2 = new Thread(Program.AddThousand);
            Thread thread3 = new Thread(Program.AddThousand);

            thread1.Start();
            thread2.Start();
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

            stopwatch.Stop();

            Console.WriteLine("Total ={0}", Total);
            Console.WriteLine("Time ={0}", stopwatch.ElapsedTicks); //print time

            #endregion locking

        }

        #region Callback
        public static void PrintSumOfNumber(int sum)
        {
            Console.WriteLine("Sum ={0}",sum);
        }
        #endregion Callback

        //---------------------------------------------------------------------------------------------------------

        #region Join-Alive

        public static void Thread5Function()
        {
            Console.WriteLine("Thread5Function started");
            Thread.Sleep(3000); //thread will go on sleep mode
            Console.WriteLine("Thread5Function returning");
        }

        public static void Thread6Function()
        {
            Console.WriteLine("Thread6Function started");
        }

        #endregion Join-Alive

        //---------------------------------------------------------------------------------------------------------

        #region locking

        //static object _lock = new object();
        public static void AddThousand()
        {
            //using Interlocked
            for(int i=0;i<=100000;i++)
            {
                Interlocked.Increment(ref Total);
            }

            //using lock
            //for (int i = 0; i <= 100000; i++)
            //{
            //    lock(_lock)
            //    {
            //        Total++;
            //    }
            //}
        }

        #endregion locking

        //---------------------------------------------------------------------------------------------------------
    }
}
