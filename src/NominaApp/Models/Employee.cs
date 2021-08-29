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
        public double NetSalary { get; set; }
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
            
        }
        private void GetIsrDiscount()
        {
            double result = Salary - (SfsDiscount - AfpDiscount);
            double limit = 34_685.00;
            if(result > limit)
            {
                if (result < 52_027.42)
                {
                    IsrDiscount = result * 0.15;
                }
                else if (result > 52_027.42 && result < 72_260.25)
                {
                    IsrDiscount = (result + 2_601.33) * 0.20; 
                }
                else if (result > 72_260.25)
                {
                    IsrDiscount = (result + 6_648.00) * 0.25;
                }
            }
        }
        private void GetTotalDiscount()
        {
            TotalDiscount = SfsDiscount + AfpDiscount + ArsDiscount + IsrDiscount;
        }
        private void GetNetSalary()
        {
            NetSalary = SfsDiscount + AfpDiscount + IsrDiscount;
        }
        
        public override string ToString() 
            => $"El empleado {LastName}, {FirstName} ocupa el puesto: {Position} con un salario: {FormatMoney(Salary)}";
    }
}