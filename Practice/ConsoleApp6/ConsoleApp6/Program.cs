using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ConsoleApp6
{
    #region ClassEmployee
    public class Employee : IComparable<Employee>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Type { get; set; }

        //method for sorting complex types
        public int CompareTo(Employee obj)
        {
            return this.Salary.CompareTo(obj.Salary);
        }
    }

    //Sorting name wise employee using IComparer interface
    public class SortByName : IComparer<Employee>
    {
        public int Compare(Employee x,Employee y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
    #endregion ClassEmployee

    
    class Program
    {
        public static void Main(string[] args)
        {

            #region List

            Employee employee1 = new Employee()
            {
                ID = 101,
                Name = "Mark",
                Salary = 5000,
                Type = "trainee"
            };
            Employee employee2 = new Employee()
            {
                ID = 102,
                Name = "John",
                Salary = 4000,
                Type = "trainee"
            };
            Employee employee3 = new Employee()
            {
                ID = 103,
                Name = "Marry",
                Salary = 8000,
                Type = "trainee"
            };
            Employee employee4 = new Employee()
            {
                ID = 104,
                Name = "Tom",
                Salary = 9000,
                Type = "Permenant"
            };
            Employee employee5 = new Employee()
            {
                ID = 105,
                Name = "Sam",
                Salary = 7000,
                Type = "Permenant"
            };

            //List of all employees
            List<Employee> listemployees = new List<Employee>();
            listemployees.Add(employee1);
            listemployees.Add(employee2);
            listemployees.Add(employee3);

            List<Employee> listPermenantemployees = new List<Employee>();
            listemployees.Add(employee4);
            listemployees.Add(employee5);

            //Add another list of item at the end.
            listemployees.AddRange(listPermenantemployees);
            foreach (Employee emp in listemployees)
            {
                Console.WriteLine("ID = {0},Name = {1}, Salary={2} ,Type={3}", emp.ID, emp.Name, emp.Salary, emp.Type);
            }

            //retrive list of item in a list.
            List<Employee> employees = listemployees.GetRange(0, 3);
            foreach (Employee emp in employees)
            {
                Console.WriteLine("ID = {0},Name = {1}, Salary={2} ,Type={3}", emp.ID, emp.Name, emp.Salary, emp.Type);
            }

            //insert list of item at specific index.
            listemployees.InsertRange(3, listPermenantemployees);

            //remove range of elements from list.
            listemployees.RemoveRange(3, 2);  //two paramaters - start index,no of elements tobe removed


            //sorting listemployees whose type is trainee
            listemployees.Sort();
            Console.WriteLine("Employee's salary After Shorting:");
            foreach (Employee emp in listemployees)
            {
                Console.WriteLine("Salary={0}", emp.Salary);
            }

            //Sorting name wise employee
            SortByName sortByName = new SortByName();
            listemployees.Sort(sortByName);
            Console.WriteLine("Employee's Name After Shorting:");
            foreach (Employee emp in listemployees)
            {
                Console.WriteLine("Name={0}", emp.Name);
            }

            //using lambda expresiion
            listemployees.Sort((x, y) => x.ID.CompareTo(y.ID));

            //method TrueForAll
            Console.WriteLine("All Salary greater than 4000 {0}", listemployees.TrueForAll(x => x.Salary > 4000));

            //Returns a read-only ReadOnlyCollection<Employee> wrapper for the current collection
            IReadOnlyCollection<Employee> ReadOnlyEmployees = listemployees.AsReadOnly();
            Console.WriteLine("Elements = {0}", ReadOnlyEmployees.Count);

            //Trim is Sets the capacity to the actual number of elements in the List
            listemployees.TrimExcess();
            Console.WriteLine("After trimming = {0}", listemployees.Capacity);

            #endregion List

            //---------------------------------------------------------------------------------------------------

            #region Queue

            Queue<Employee> queueEmployee = new Queue<Employee>();

            //Enqueue adds an element to the end of the Queue.
            queueEmployee.Enqueue(employee1);
            queueEmployee.Enqueue(employee2);
            queueEmployee.Enqueue(employee3);
            queueEmployee.Enqueue(employee4);
            queueEmployee.Enqueue(employee5);

            //print all employee
            foreach (Employee e in queueEmployee)
            {
                Console.WriteLine("ID={0},Name={1}", e.ID, e.Name);
            }

            //Dequeue() removes the oldest element from the start of the Queue.
            Employee e1 = queueEmployee.Dequeue();
            Console.WriteLine(e1.ID);

            //Peek() returns the oldest element that is at the start of the Queue but does not remove it from the Queue
            Employee e2 = queueEmployee.Peek();
            Console.WriteLine(e2.ID);

            //contains() determines whether an element is in the Queue
            if (queueEmployee.Contains(employee4))
            {
                Console.WriteLine("Employee 4 is present in queue");
            }
            else
            {
                Console.WriteLine("Employee 4 is not present in queue");
            }

            //Clear() removes all objects from the Queue.
            queueEmployee.Clear();
            #endregion Queue

            //---------------------------------------------------------------------------------------------------

            #region Stack

            Stack<Employee> stackEmployee = new Stack<Employee>();

            //Push adds an element to the top of the Stack.
            stackEmployee.Push(employee1);
            stackEmployee.Push(employee2);
            stackEmployee.Push(employee3);
            stackEmployee.Push(employee4);
            stackEmployee.Push(employee5);

            //print all employee
            foreach (Employee e in stackEmployee)
            {
                Console.WriteLine("ID={0},Name={1}", e.ID, e.Name);
            }

            //Pop() Removes and returns the object at the top of the Stack
            Employee e3 = stackEmployee.Pop();
            Console.WriteLine(e3.ID);

            //Peek() Returns the object at the top of the Stack without removing it.
            Employee e4 = stackEmployee.Peek();
            Console.WriteLine(e4.ID);

            //contains() determines whether an element is in the stack
            if (stackEmployee.Contains(employee4))
            {
                Console.WriteLine("Employee 4 is present in stack");
            }
            else
            {
                Console.WriteLine("Employee 4 is not present in stack");
            }

            //Clear() removes all objects from the Stack.
            stackEmployee.Clear();
            #endregion Stack

            //---------------------------------------------------------------------------------------------------

            #region sortNumber

            //sorting Numbers
            List<int> numbers = new List<int>() { 2, 8, 1, 6, 4, 7, 3, 9, 5 };

            Console.WriteLine("Numbers After Shorting:");
            numbers.Sort();
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }

            numbers.Reverse();
            Console.WriteLine("Numbers in descending order");
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }

            //sorting Numbers
            List<string> alphabets = new List<string>() { "A", "G", "Y", "E", "K" };

            Console.WriteLine("Alphabets After Shorting:");
            alphabets.Sort();
            foreach (string alpha in alphabets)
            {
                Console.WriteLine(alpha);
            }

            alphabets.Reverse();
            Console.WriteLine("Alphabets in descending order");
            foreach (string alpha in alphabets)
            {
                Console.WriteLine(alpha);
            }

            #endregion sortNumber

            //---------------------------------------------------------------------------------------------------

        }
    }
}
