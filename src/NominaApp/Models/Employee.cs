using NominaApp.Utils;

namespace NominaApp.Models
{
    public class Employee : Format
    {
        public Employee()
        {
            
        }
        public Employee(int id, string firstName, string lastName, string position, double salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Position = position;
            Salary = salary;
            GetSfsDiscount();
            GetAfpDiscount();
            GetArsDiscount();
            GetIsrDiscount();
            GetTotalDiscount();
            GetNetSalary();
        }
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Position { get; private set; }
        public double Salary { get; private set; }
        public double SfsDiscount { get; private set; }
        public double AfpDiscount { get; private set; }
        public double ArsDiscount { get; private set; }
        public double IsrDiscount { get; private set; }
        public double TotalDiscount { get; private set; }
        public double NetSalary { get; private set; }
        
        private void GetSfsDiscount()
        {
            double result = Salary * 3.04;
            double limit = 4098.53;
            SfsDiscount = result > limit ? Salary * 0.0304
                                         : Salary;
        }
        private void GetAfpDiscount()
        {
            double result = Salary * 0.0287;
            double limit = 7738.67;
            AfpDiscount = result > limit ? Salary
                                         : Salary  * 0.0287;
        }
        private void GetArsDiscount()
        {
            ArsDiscount = (Salary / 12) * 0.10;
        }
        private void GetIsrDiscount()
        {
            double result = (Salary - (SfsDiscount + AfpDiscount)) * 12;
            double limit = 624_329.01;
            if (result > limit)
            {
                IsrDiscount = (((result - limit) * 0.20) + 31_216.00)  / 12;
            }
        }
        private void GetTotalDiscount()
        {
            TotalDiscount = SfsDiscount + AfpDiscount + ArsDiscount + IsrDiscount;
        }
        private void GetNetSalary()
        {
            NetSalary = Salary - (SfsDiscount + AfpDiscount + IsrDiscount);
        }

        public override string ToString() 
            => $"El empleado {LastName}, {FirstName} ocupa el puesto: {Position} con un salario: {FormatMoney(Salary)}";
    }
}