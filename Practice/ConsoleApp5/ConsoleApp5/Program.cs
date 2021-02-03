using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ConsoleApp5
{

    #region ClassEmployee

    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
    }

    #endregion ClassEmployee

    #region Indexer

    public class Indexer
    {
        // class members
        private string[] Value = new string[3];

        // Indexer declaration using this keyword
        public string this[int index]
        {
            get
            {
                return Value[index];
            }
            set
            {
                Value[index] = value;
            }
        }
    }

    #endregion Indexer
    class Program
    {
        public static void Main(string[] args)
        {

            #region Indexer
            Indexer ic = new Indexer();
                ic[0] = "Mark";
                ic[1] = "Marry";
                ic[2] = "John";
                ic[3] = "Tom";      //it will generate error index out of range

                Console.Write("Printing values\n");

                // printing values 
                Console.WriteLine("First value = {0}", ic[0]);
                Console.WriteLine("Second value = {0}", ic[1]);
                Console.WriteLine("Third value = {0}", ic[2]);

            #endregion Indexer

            //--------------------------------------------------------------------------------------------------------

            #region PartialClass

            PartialClass PC = new PartialClass(101, "abc", "hfj");
            PC.DisplayInfo();

            #endregion PartialClass

            //--------------------------------------------------------------------------------------------------------

            #region List

            Employee employee1 = new Employee()
            {
                ID = 101,
                Name = "Mark",
                Salary = 5000
            };

            Employee employee2 = new Employee()
            {
                ID = 102,
                Name = "John",
                Salary = 4000
            };
            Employee employee3 = new Employee()
            {
                ID = 118,
                Name = "Marry",
                Salary = 8000
            };

            //List of all employees
            List<Employee> listemployees = new List<Employee>();
            listemployees.Add(employee1);
            listemployees.Add(employee2);
            listemployees.Add(employee3);

            listemployees.Insert(0, employee2);                     //insert object at position 0
            Console.WriteLine(listemployees.IndexOf(employee3));    //return the index of employee3 which is 3

            //contains() method for item exists or not
            if (listemployees.Contains(employee2))
            {
                Console.WriteLine("employee2 is present");
            }
            else
            {
                Console.WriteLine("employee2 is not present");
            }

            //Exists() method for item exists on condition or not
            if (listemployees.Exists(emp => emp.Name.StartsWith("P")))
            {
                Console.WriteLine("employee2 is present");
            }
            else
            {
                Console.WriteLine("employee2 is not present");
            }

            //Find() method for find the first value matches with condition
            Employee e = listemployees.Find(emp => emp.Salary > 5000);
            Console.WriteLine("ID = {0},Name = {1}, Salary={2}", e.ID, e.Name, e.Salary);

            //FindLast() method for find the last value matches with condition
            Employee el = listemployees.FindLast(emp => emp.Salary > 5000);
            Console.WriteLine("ID = {0},Name = {1}, Salary={2}", el.ID, el.Name, el.Salary);

            //FindAll() method for find the all value matches with condition
            List<Employee> FL = listemployees.FindAll(emp => emp.Salary > 5000);
            foreach (Employee F in FL)
            {
                Console.WriteLine("ID = {0},Name = {1}, Salary={2}", F.ID, F.Name, F.Salary);
            }

            //FindIndex() method for find the index of first value matches with condition from the 1st element
            int index = listemployees.FindIndex(1, emp => emp.Salary > 5000);
            Console.WriteLine("Index = {0}", index);

            //FindIndex() method for find the index of last value matches with condition
            int indexl = listemployees.FindLastIndex(1, emp => emp.Salary > 5000);
            Console.WriteLine("Index = {0}", indexl);

            //display all employees
            foreach (Employee emp in listemployees)
            {
                Console.WriteLine("ID = {0},Name = {1}, Salary={2}", emp.ID, emp.Name, emp.Salary);
            }

            //Convert list to array
            //listemployees.ToArray();

            #endregion List

            //--------------------------------------------------------------------------------------------------------

            #region Dictionary

            // dictionary for all employee and its key and value pairs
            Dictionary<int, Employee> dictionaryEmployee = new Dictionary<int, Employee>();
            dictionaryEmployee.Add(employee1.ID, employee1);
            dictionaryEmployee.Add(employee2.ID, employee2);
            dictionaryEmployee.Add(employee3.ID, employee3);

            //getting key value from ID 118 to new employee object and print it 
            Employee employee118 = dictionaryEmployee[118];
            Console.WriteLine("ID = {0},Name = {1}, Salary={2}", employee118.ID, employee118.Name, employee118.Salary);

            //print all key value pairs of employee
            foreach (KeyValuePair<int, Employee> employeekvp in dictionaryEmployee)
            {
                Console.WriteLine("key = {0}", employeekvp.Key);//print key
                Employee kvpemp = employeekvp.Value;
                Console.WriteLine("ID = {0},Name = {1}, Salary={2}", kvpemp.ID, kvpemp.Name, kvpemp.Salary);//print value
            }

            //TryGetValue() method for retriving value at specific key
            Employee TryGetemp;
            if (dictionaryEmployee.TryGetValue(101, out TryGetemp))
            {
                Console.WriteLine("ID = {0},Name = {1}, Salary={2}", TryGetemp.ID, TryGetemp.Name, TryGetemp.Salary);
            }
            else
            {
                Console.WriteLine("key is not found");
            }

            //Count() method for total count of employee in dictionary
            Console.WriteLine("key = {0}", dictionaryEmployee.Count);
            dictionaryEmployee.Remove(101);  //to remove element from dictionary
            dictionaryEmployee.Clear();      //clear all element from dictionary

            #endregion Dictionary

            //--------------------------------------------------------------------------------------------------------

            #region OptionalParameters

            Addition(10, 20, new object[] { 20, 30 }); //using parameter array
            Add(10, 30, new int[] { 30, 40 });        //using method overloading
            Number(10, c: 20);                      //using parameter defaults
            sum(20, 30, new int[] { 30, 40 });      //optional attributes
            #endregion OptionalParameters

            //--------------------------------------------------------------------------------------------------------
        }

        #region OptionalParameters

        //optional parameter using parameter array
        public static void Addition(int FN, int SN, params object[] restOfNumber)
        {
            int result = FN + SN;
            if (restOfNumber != null)
            {
                foreach (int i in restOfNumber)
                {
                    result += i;

                }
            }
            Console.WriteLine("Sum = {0}", result);  //output =80
        }

        //optional parameter using method overloading
        public static void Add(int FN, int SN)
        {
            Add(FN, SN, null);
        }

        public static void Add(int FN, int SN, int[] restOfNumber)
        {
            int result = FN + SN;
            if (restOfNumber != null)
            {
                foreach (int i in restOfNumber)
                {
                    result += i;

                }
            }
            Console.WriteLine("Sum = {0}", result);     //output =110
        }

        //optional parameter using parameter defaults
        public static void Number(int a, int b = 10, int c = 30)
        {
            Console.WriteLine("A=" + a);   //output = 10
            Console.WriteLine("B=" + b);    //output = 10
            Console.WriteLine("C=" + c);    //output =20
        }

        //optional parameter using optional attributes
        public static void sum(int FN, int SN, [Optional] int[] restOfNumber)
        {
            int result = FN + SN;
            if (restOfNumber != null)
            {
                foreach (int i in restOfNumber)
                {
                    result += i;

                }
            }
            Console.WriteLine("Sum = {0}", result);   //output = 120
        }
        #endregion OptionalParameters
    }
}
