using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Person person = new Person();
            //person.Name = "Ahmed Rizq";
            //person.Age = 30;

            //// Call the Work method
            //person.Work();
        }
    }

    public interface IComparable<T>
    {
        int CompareTo(T other);
    }

    public interface ICloneable
    {
        object Clone();
    }

    public interface IPayable
    {
        double CalcSalary();
    }

    public abstract class Human
    {
        public string SSN { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public abstract void Work();
    }

    public class Person : Human
    {
        public override void Work()
        {
            Console.WriteLine("Person working...");
        }
    }

    public class RowadEmployee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
    }

    public class Manager : RowadEmployee, IPayable, IComparable<Manager>, ICloneable
    {
        public double Bonus { get; set; }

        public double CalcSalary()
        {
            return Salary + Bonus;
        }

        public override string ToString()
        {
            return $"Manager: ID={ID}, Name={Name}, Salary={Salary}, Bonus={Bonus}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Manager other)
            {
                return ID == other.ID && Name == other.Name && Salary == other.Salary && Bonus == other.Bonus;
            }
            return false;
        }

        public int CompareTo(Manager other)
        {
            return ID.CompareTo(other.ID);
        }

        public object Clone()
        {
            return new Manager { ID = ID, Name = Name, Salary = Salary, Bonus = Bonus };
        }
    }

    public class Employee : RowadEmployee, IPayable, IComparable<Employee>, ICloneable
    {
        public double Bonus { get; set; }
        public double Deduction { get; set; }

        public double CalcSalary()
        {
            return Salary + Bonus - Deduction;
        }

        public override string ToString()
        {
            return $"Employee: ID={ID}, Name={Name}, Salary={Salary}, Bonus={Bonus}, Deduction={Deduction}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Employee other)
            {
                return ID == other.ID && Name == other.Name && Salary == other.Salary && Bonus == other.Bonus && Deduction == other.Deduction;
            }
            return false;
        }

        public int CompareTo(Employee other)
        {
            return ID.CompareTo(other.ID);
        }

        public object Clone()
        {
            return new Employee { ID = ID, Name = Name, Salary = Salary, Bonus = Bonus, Deduction = Deduction };
        }
    }

    public class SecurityMan : RowadEmployee, IPayable, IComparable<SecurityMan>, ICloneable
    {
        public string Shift { get; set; }

        public double CalcSalary()
        {
            return Salary;
        }

        public override string ToString()
        {
            return $"SecurityMan: ID={ID}, Name={Name}, Salary={Salary}, Shift={Shift}";
        }

        public override bool Equals(object obj)
        {
            if (obj is SecurityMan other)
            {
                return ID == other.ID && Name == other.Name && Salary == other.Salary && Shift == other.Shift;
            }
            return false;
        }

        public int CompareTo(SecurityMan other)
        {
            return ID.CompareTo(other.ID);
        }

        public object Clone()
        {
            return new SecurityMan { ID = ID, Name = Name, Salary = Salary, Shift = Shift };
        }
    }

    #region Human & person by Abstraction
    //public abstract class Human
    //{
    //    public string SSN { get; set; }
    //    public string Name { get; set; }
    //    public int Age { get; set; }

    //    public abstract void Work();
    //}

    //public class Person : Human
    //{
    //    public override void Work()
    //    {
    //        Console.WriteLine("Any thing");
    //    }
    //}
    #endregion

}
