using System;

//inheritance example
#region inheritance

    //base class
    public class student
    {
        //data member
        public string name;
        public string subject;

        //public method for base class
        public void setvalue(string name, string subject)
        {
            this.name = name;
            this.subject = subject;
            Console.WriteLine("My Name is " + name);
            Console.WriteLine("My Favorite Subject is  " + subject);
        }
    }

    //derived class
    public class Derived : student
    {

        // constructor of derived class 
        public Derived()
        {
            Console.WriteLine("Derived Class");
        }
    }
#endregion inheritance

//-----------------------------------------------------------------------------------------------------------------

//structure example
#region Struture
    public struct XY
    {
        public int x { get; set; }
        public int y { get; set; }

        public void Setval()
        {
            this.x = 5;
            this.y = 4;
        }
    }
#endregion Struture

//-----------------------------------------------------------------------------------------------------------------

//interface example
#region interface
public interface Vehicle
    {

        // all are abstract methods. 
        void changeGear(int a);
        void speedUp(int a);
    }

    //implement interface
    public class Bicycle : Vehicle
    {

        int speed;
        int gear;

        //implement changegear method
        public void changeGear(int newGear)
        {
            gear = newGear;
        }

        // implement speed method
        public void speedUp(int increment)
        {

            speed = speed + increment;
        }

        // display method
        public void printStates()
        {
            Console.WriteLine("speed:{0},gear:{1} ",speed,gear);
        }
    }
#endregion interface

//-----------------------------------------------------------------------------------------------------------------

//area of a square using abstract class and abstract method
#region abstract
public abstract class Areaclass
    {
        // abstract method
        public abstract int Area();
    }

    //inherited abstract class
    public class Sqaure : Areaclass
    {
        int side = 0;
        public Sqaure(int n)
        {
            side = n;
        }

        // overriding abstract method
        public override int Area()
        {
            return side * side;
        }
    }
#endregion abstract

//-----------------------------------------------------------------------------------------------------------------

//area of a square using abstract class and abstract method using get and set properties
#region abstract1
public abstract class Areaclass1
    {
        public int side1;
        public abstract int Area1 { get; set; }
    }

    public class Sqaure1 : Areaclass1
    { 

        public override int Area1
        {
            get { return side1 * side1; }
            set { side1 = value; }
        }
    }
#endregion abstract1

//-----------------------------------------------------------------------------------------------------------------

//multiple class inheritance using interfaces
#region multipleclass
    public interface IA
    {
        void Amethod();
    }
    public class A : IA
    { 
        public void Amethod()
        {
            Console.WriteLine("A");
        }
    }

    public interface IB
    {
        void Bmethod();
    }
    public class B : IB
    {
        public void Bmethod()
        {
            Console.WriteLine("B");
        }
    }

    public class AB  : IA, IB
    {
        A a = new A();
        B b = new B();
        public void Amethod()
        {
            a.Amethod();
        }
        public void Bmethod()
        {
            b.Bmethod();
        }
    }
#endregion multipleclass

//-----------------------------------------------------------------------------------------------------------------

//delegate
#region delegate

    public delegate void MyDelegate(string msg); //declaring a delegate

    public class ClassM
    {
        public static void MethodM(string message)
        {
            Console.WriteLine("Called ClassM.MethodM() with parameter: " + message);
        }
    }

    public class ClassN
    {
        public static void MethodN(string message)
        {
            Console.WriteLine("Called ClassN.MethodN() with parameter: " + message);
        }
    }
#endregion delegate

//-----------------------------------------------------------------------------------------------------------------

//multicast delegate
#region multicast delegate

    public delegate void MyMulticastDelegate(string msg); //declaring a delegate

    public class delegate1
    {
        public static void delegatemethod1(String message)
        {
            Console.WriteLine("Called delegate1.delegatemethod1() with parameter:" + message);
        }
    }

    public class delegate2
    {
        public static void delegatemethod2(String message)
        {
            Console.WriteLine("Called delegate2.delegatemethod2() with parameter:" + message);
        }
    }
#endregion multicast delegate

#region Mainmethod
class Program
    {
        public static void Main(string[] args)
        {

            //intance of derived class from inhetitance
            Derived d = new Derived();
            d.setvalue("Tom", "Science");
            Console.WriteLine("------------------------");

// -----------------------------------------------------------------------------------------------------------------
            //instance of structure
            XY demo = new XY();
            demo.Setval();
            Console.WriteLine(demo.x); //output: 5  
            Console.WriteLine(demo.y); //output: 4
            Console.WriteLine("------------------------");

// -----------------------------------------------------------------------------------------------------------------

            //instance of bicycle class and implement using interface
            Bicycle bicycle = new Bicycle();
            bicycle.changeGear(2);
            bicycle.speedUp(3);
            Console.WriteLine("Bicycle's present state");
            bicycle.printStates();
            Console.WriteLine("------------------------");

// -----------------------------------------------------------------------------------------------------------------

            //instance of class sqaure and deriving area of sqaure value using abstract class
            Sqaure s = new Sqaure(6);
            Console.WriteLine("Area = {0}", s.Area());
            Console.WriteLine("------------------------");

// -----------------------------------------------------------------------------------------------------------------

            //instance of class sqaure1 and deriving area of sqaure value using abstract class
            Sqaure1 s1 = new Sqaure1();
            s1.Area1 = 5;
            Console.WriteLine("Area1 = {0}", s1.Area1);
            Console.WriteLine("------------------------");

// -----------------------------------------------------------------------------------------------------------------

            //instance of class AB and retriving multiple class using interfaces
            AB ab = new AB();
            ab.Amethod();
            ab.Bmethod();
            Console.WriteLine("------------------------");

// -----------------------------------------------------------------------------------------------------------------

            //delegate method called
            MyDelegate del = ClassM.MethodM;
            del("MethodM display");

            del = ClassN.MethodN;
            del("MethodN display");

            del = (string msg) => Console.WriteLine("Called lambda expression: " + msg);
            del("Display using lambda expression");
            Console.WriteLine("---------------------------");

// -----------------------------------------------------------------------------------------------------------------

            //multicast delegate method example
            Console.WriteLine("--------multicast delegate----------");
            MyMulticastDelegate del1 = delegate1.delegatemethod1;
            MyMulticastDelegate del2 = delegate2.delegatemethod2;

            MyMulticastDelegate finaldel = del1 + del2; //combines del1 + del2
            finaldel("delegate");
            Console.WriteLine("**************************");

            MyMulticastDelegate del3 = (string msg) => Console.WriteLine("Called lambda expression del3: " + msg);
            finaldel += del3; //combines del1 + del2 + del3
            finaldel("delegate");
            Console.WriteLine("**************************");

            finaldel = finaldel - del2; // remove del2
            finaldel("delegate");
            Console.WriteLine("**************************");

            finaldel -= del1; // remove del1
            finaldel("delegate");
        }
    }
#endregion Mainmethod
