using System;
using System.Linq;

namespace Bank
{
    public class Loan : Account
    {
        public Loan(Customer customer, decimal interest, int months)
        {
            this.Customer = customer;
            this.InterestPerMonth = interest;
            this.MonthCount = months;
        }

        public override decimal CalcIntrestAmount()
        {
            if (Customer is Individual)
            {
                decimal interest = (this.MonthCount - 3) * this.InterestPerMonth * this.balance / 100;
                if (interest < 0)
                {
                    return 0;
                }
                else
                {
                    return interest;
                }
            }
            else
            {
                decimal interest = (this.MonthCount - 2) * this.InterestPerMonth * this.balance / 100;
                if (interest < 0)
                {
                    return 0;
                }
                else
                {
                    return interest;
                }
            }
        }
    }
}
