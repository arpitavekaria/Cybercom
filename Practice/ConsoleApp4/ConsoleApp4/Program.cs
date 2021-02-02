using System;
using System.Collections.Generic;
using System.Reflection;

namespace ConsoleApp4
{
    // providing region for organization of code

    #region enum
    public class student
    {
        public string Name { get; set; }
        public Gender Gender { get; set; } // get and set enum Gender
    }

    //here Gender is enum
    public enum Gender
    {
        Unknown,
        Female,
        Male
    }

    #endregion enum

    //-------------------------------------------------------------------------------------

    #region PublicAccessmodifier
    public class Customer
{
    private int _id;
    protected int _id2;
    public int ID  // get and set value for public field
    {
        get
        {
            return _id;
        }
        set
        {
            _id = value;
        }
    }
    }
    #endregion PublicAccessmodifier

    //-------------------------------------------------------------------------------------

    #region ProtectedAccessmodifier
    public class Customer1 : Customer
{
    public int ID2  // get and set value for protected field
        {
        get
        {
            return _id2;
        }
        set
        {
            _id2 = value;
        }
    }
    public void PrintCustomer1()
    {
        Customer1 c1 = new Customer1();
        c1.ID2 = 102; //protected value assigned
        Console.WriteLine("protected ID={0}", c1.ID2);
    }
}

    #endregion ProtectedAccessmodifier

    //-------------------------------------------------------------------------------------

    #region InternalModifier
    public class AssemblyOneClass1
    {
        internal string name = "mark";
    }
    public class AssemblyOneClass2
    {
        public void PrintName()
        {
            AssemblyOneClass1 A1 = new AssemblyOneClass1();
            Console.WriteLine(A1.name);
        }
    }
    #endregion InternalModifier

    //-------------------------------------------------------------------------------------

    #region ObsoleteAttribute
    public class Calculator
    {
       [Obsolete] // use of obsolete attribute
        public static int Add(int FN,int SN)
        {
            return FN + SN; 
        }

        [Obsolete("Please use Addition(List<int> Numbers)")] // use of obsolete attribute with warning
        public static int Add2(int FN, int SN)
        {
            return FN + SN;
        }

        [Obsolete("Please use Addition(List<int> Numbers)",true)] // use of obsolete attribute with warning and true value
        public static int Add3(int FN, int SN)
        {
            return FN + SN;
        }

        public static int Addition(List<int> Numbers) //multiple addition using List
        {
            int sum = 0;
            foreach(int number in Numbers)
            {
                sum = sum + number;
            }
            return sum;
        }
    }
    #endregion ObsoleteAttribute

    //-------------------------------------------------------------------------------------

    #region Reflection
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Client()
        {
            this.Id = -1;
            this.Name = string.Empty;
        }

        public Client(int Id,string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public void PrintID()
        {
            Console.WriteLine("ID={0}", this.Id);
        }

        public void PrintName()
        {
            Console.WriteLine("Name={0}", this.Name);
        }
    }

    #endregion Reflection

    //-------------------------------------------------------------------------------------

    #region LateBinding

    public class employee
    {
        public string GetFullName(string FirstName, string LastName)
        {
            return FirstName + " " + LastName;
        }
    }

    #endregion LateBinding

    //-------------------------------------------------------------------------------------

    #region generics
    public class Equal<T>
    {
        public static bool AreEqaul(T Value1,T Value2)
        {
            return Value1.Equals(Value2);
        }
    }
    #endregion generics

    //-------------------------------------------------------------------------------------

    #region ToStringAndEqual

    public class DemoOverride
    {
        public string DemoName1 { get; set; }
        public string DemoName2 { get; set; }

        public override string ToString() // overriding ToString() method
        {
            return this.DemoName1 + "" + this.DemoName2;
        }

        public override bool Equals(object obj)     // overriding Equals() method
        {
            if (obj == null)
            {
                return false;
            }
            else if (!(obj is DemoOverride))
            {
                return false;
            }
            else
                return this.DemoName1 == ((DemoOverride)obj).DemoName1
                    && this.DemoName2 == ((DemoOverride)obj).DemoName2;
        }

        public override int GetHashCode()           // overriding GetHashCode() method
        {
            return this.DemoName1.GetHashCode() ^ this.DemoName2.GetHashCode();
        }
    }

    #endregion ToStringAndEqual

    //-----------------------------------------------------------------------------------------------------------
    class Program
    {
        
        public static void Main(string[] args)
        {
            #region ToStringAndEqual

            int num = 50;
            Console.WriteLine(num.ToString()); //ToString()

            DemoOverride D = new DemoOverride();
            D.DemoName1 = "DemoName1";
            D.DemoName2 = "DemoName2";
            Console.WriteLine(D.ToString()); //ToString()

            DemoOverride D1 = new DemoOverride();
            D1.DemoName1 = "DemoName1";
            D1.DemoName2 = "DemoName2";

            Console.WriteLine(D.Equals(D1));  //Equals()
            #endregion ToStringAndEqual

            //-------------------------------------------------------------------------------------

            #region generics
            bool Equal = Equal<int>.AreEqaul(20, 20); //using generics

            if (Equal)
                Console.WriteLine("Equal");
            else
                Console.WriteLine("Not Equal");
            #endregion generics

            //-------------------------------------------------------------------------------------

            #region LateBinding

            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            Type employeeType = executingAssembly.GetType("ConsoleApp4.employee");
            object employeeInstance = Activator.CreateInstance(employeeType);
            MethodInfo getFullName = employeeType.GetMethod("GetFullName");

            string[] parameters = new string[2];
            parameters[0] = "Tom";
            parameters[1] = "Tech";

            string fullName = (string)getFullName.Invoke(employeeInstance, parameters);
            Console.WriteLine("Full Name = {0}", fullName);

            #endregion LateBinding

            //-------------------------------------------------------------------------------------

            #region Reflection

            Type T = typeof(Client);

            Console.WriteLine("Full Name={0}", T.FullName);
            Console.WriteLine("Only Name={0}", T.Name);
            Console.WriteLine("Only Namespace={0}", T.Namespace);
            Console.WriteLine();

            Console.WriteLine("Properties of Client"); //Properties of class
            PropertyInfo[] properties = T.GetProperties();
            foreach(PropertyInfo property in properties)
            {
                Console.WriteLine(property.PropertyType.Name + "" + property.Name);
            }
            Console.WriteLine();

            Console.WriteLine("Methods of Client"); //Method of class
            MethodInfo[] methods = T.GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.ReturnType.Name + "" + method.Name);
            }
            Console.WriteLine();

            Console.WriteLine("Constructors in Client"); //Constructor of class
            ConstructorInfo[] constructors = T.GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                Console.WriteLine(constructor.Name);
            }
            #endregion Reflection

            //-------------------------------------------------------------------------------------

            #region Attributes
            //Calculator.Add(10, 20);
            //Calculator.Add2(10, 60);
            Calculator.Addition(new List<int>() { 10, 20, 30 });
            #endregion Attributes

            //-------------------------------------------------------------------------------------

            #region AccessModifier
            Customer c = new Customer();// base class object
            c.ID = 101; // public value assign
            Console.WriteLine("public ID={0}",c.ID);

            Customer1 c2 = new Customer1();// derived class object
            c2.PrintCustomer1(); // method called from derived class
            #endregion AccessModifier

            //-------------------------------------------------------------------------------------

            #region student                         
            student[] students = new student[3];             //enum example

            students[0] = new student
            {
                Name = "sam",
                Gender = Gender.Unknown
            };
            students[1] = new student
            {
                Name = "Marry",
                Gender = Gender.Female
            };
            students[2] = new student
            {
                Name = "Mark",
                Gender = Gender.Male
            };

            foreach (student student in students)
            {
                Console.WriteLine("Name={0} && Gender={1}", student.Name, GetGender(student.Gender));
            }
            #endregion student

            //------------------------------------------------------------------------------

            #region Weekdays                    

            //enum explicit conversion

            Console.WriteLine(WeekDays.Friday); //output: Friday 
            int day = (int)WeekDays.Friday; // enum to int conversion
            Console.WriteLine(day); //output: 4 

            WeekDays wd = (WeekDays)5; // int to enum conversion
            Console.WriteLine(wd);//output: Saturday 
            #endregion Weekdays

        }

        #region enumExample
        public static string GetGender(Gender gender)
        {
            switch (gender)
            {
                case Gender.Unknown:
                    return "Unknown";
                case Gender.Female:
                    return "Female";
                case Gender.Male:
                    return "male";
                default:
                    return "Invalid";
            }
        }
        public enum WeekDays
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
        #endregion enumExample
    }
}

