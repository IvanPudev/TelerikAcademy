using System;
using System.Linq;

namespace StudentsAndWorkers
{
    class Worker : Human
    {
        private decimal weekSalary;
        private short workHoursPerDay;
        //Constructor
        public Worker(string firstName, string lastName, decimal weekSalary, short workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.workHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            private set { this.weekSalary = value; }
        }

        public short WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            private set { this.workHoursPerDay = value; }
        }

        public decimal MoneyPerHour()
        {
            decimal moneyPerHour = 0m;
            moneyPerHour = this.WeekSalary / (this.WorkHoursPerDay * 5);
            return moneyPerHour;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}, {2:C}", this.FirstName, this.LastName, this.MoneyPerHour());
        }
    }
}
