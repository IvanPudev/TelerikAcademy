using System;
using System.Linq;

namespace Bank
{
    public abstract class Account : Interface.IDepositable
    {
        protected Customer customer;
        protected decimal balance;
        protected decimal interestPerMonth;
        protected int monthCount;

        public Customer Customer
        {
            get { return this.customer; }
            protected set { this.customer = value; }
        }

        public decimal Balance
        {
            get { return this.balance; }
        }

        public decimal InterestPerMonth
        {
            get { return this.interestPerMonth; }
            protected set { this.interestPerMonth = value; }
        }

        public int MonthCount
        {
            get { return this.monthCount; }
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentException("Months can not be less than 0.");
                }
                this.monthCount = value;
            }
        }
        // get customer type
        public string CustomerType
        {
            get
            {
                if (customer is Individual)
                {
                    return "Individual";
                }
                else
                {
                    return "Company";
                }
            }
        }
        // Deposit implementation
        public void Deposit(decimal moneyIn)
        {
            if (moneyIn < 0)
            {
                throw new System.ArgumentException("Money must be > 0!");
            }

            this.balance += moneyIn;
        }
        // virtual Method
        public virtual decimal CalcIntrestAmount()
        {
            return MonthCount * InterestPerMonth / 100;
        }
    }
}
