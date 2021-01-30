using System;
using System.IO;
using System.Runtime.Serialization;

//custom exception
public class UserAlreadyLogedInException : Exception
{
    public UserAlreadyLogedInException() : base() { }
    public UserAlreadyLogedInException(string message) : base(message) { }
    public UserAlreadyLogedInException(string message,Exception innerException) : base(message, innerException) { }
    public UserAlreadyLogedInException(SerializationInfo info ,StreamingContext context) : base(info, context) { }
}

class Program
    {
        public static void Main()
        {
            #region filenotfound
            StreamReader streamreader = null;
            try
            {
                streamreader = new StreamReader(@"E:\BE\11.txt");
                Console.WriteLine(streamreader.ReadToEnd());
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Please check if file {0} is exists", ex.FileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (streamreader != null)
                {
                    streamreader.Close();
                }
                Console.WriteLine("Finally blocked executed");
            }
            #endregion filenotfound

//-----------------------------------------------------------------------------------------------------------------

        #region innerException
        try
        {
            try
            {
                Console.WriteLine("Enter First Number");
                int FN = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Second Number");
                int SN = Convert.ToInt32(Console.ReadLine());

                int result = FN / SN;
                Console.WriteLine("Result is {0}", result);
            }
            catch (Exception ex)
            {
                string filePath = @"C:\Users\Arpita\Desktop\.netvideo\exceptionn.txt";
                if (File.Exists(filePath))
                {
                    StreamWriter sw = new StreamWriter(filePath);
                    sw.Write(ex.GetType().Name);
                    sw.WriteLine();
                    sw.Write(ex.Message);
                    sw.Close();
                    Console.WriteLine("There is a problem Please try again");
                }
                else
                {
                    throw new FileNotFoundException(filePath + "is not found", ex);
                }
            }
        }
        catch(Exception exe)
        {
            Console.WriteLine("Current exception ={0}", exe.GetType().Name);
            if(exe.InnerException != null)
            {
                Console.WriteLine("Inner exception = {0}", exe.InnerException.GetType().Name);
            }
        }
        #endregion innerException

//-------------------------------------------------------------------------------------------------------------------

        #region customException
        try
        {
            throw new UserAlreadyLogedInException("User Already logedIn Exception");
        }
        catch(UserAlreadyLogedInException ex)
        {
            Console.WriteLine(ex.Message);
        }
        #endregion customException

//------------------------------------------------------------------------------------------------------------------

        #region MultipleExceptionHandling
        try
        {
            Console.WriteLine("Enter First Numerator");
            int Numerator;
            bool IsNumerator = Int32.TryParse(Console.ReadLine(), out Numerator);

            if(IsNumerator)
            {
                Console.WriteLine("Enter Second Denominator");
                int Denominator;
                bool IsDenominator = Int32.TryParse(Console.ReadLine(), out Denominator);

                if(IsDenominator && Denominator != 0)
                {
                    int Result = Numerator / Denominator;
                    Console.WriteLine("Result is {0}", Result);
                }
                else
                {
                    if(Denominator == 0)
                    {
                        Console.WriteLine("Denominator is 0 not allowed");
                    }
                    else
                    {
                        Console.WriteLine("only numbers between {0} to {1} are allowed", Int32.MinValue, Int32.MaxValue);
                    }
                }

            }
            else
            {
                Console.WriteLine("only numbers between {0} to {1} are allowed", Int32.MinValue, Int32.MaxValue);
            }
        }

        // Catch block for attempt to FormatException
        catch (FormatException)
        {
            Console.WriteLine("Please enter valid exception");
        }

        // Catch block for attempt to OverflowException
        catch (OverflowException)
        {
            Console.WriteLine("only numbers between {0} to {1} are allowed",Int32.MinValue,Int32.MaxValue);
        }

        // Catch block for attempt to divide by zero 
        catch (DivideByZeroException)
        {
            Console.WriteLine("Denominator is 0 not allowed");
        }

        // Catch block for attempt any leftout Exception
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        #endregion MultipleExceptionHandling

//------------------------------------------------------------------------------------------------------------------

        #region ExceptionHandlingInArray

        int[] arr = { 19, 0, 75, 52 };

        try
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i] / arr[i + 1]);
            }
        }

        // Catch block for invalid array access 
        catch (IndexOutOfRangeException e)
        {

            Console.WriteLine("An Exception has occurred : {0}", e.Message);
        }

        // Catch block for attempt to divide by zero 
        catch (DivideByZeroException e)
        {

            Console.WriteLine("An Exception has occurred : {0}", e.Message);
        }

        // Catch block for value being out of range 
        catch (ArgumentOutOfRangeException e)
        {

            Console.WriteLine("An Exception has occurred : {0}", e.Message);
        }

        // Finally block 
        finally
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(" {0}", arr[i]);
            }
        }
        #endregion ExceptionHandlingInArray

    }
}
