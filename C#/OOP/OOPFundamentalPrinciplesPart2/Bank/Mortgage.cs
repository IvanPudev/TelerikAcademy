using System;
using System.Linq;

namespace Bank
{
    public class Mortgage : Account
    {
        public Mortgage(Customer customer, decimal interest, int months)
        {
            this.Customer = customer;
            this.InterestPerMonth = interest;
            this.MonthCount = months;
        }

        public override decimal CalcIntrestAmount()
        {
            if (Customer is Individual)
            {
                decimal interest = (this.MonthCount - 6) * this.balance * this.InterestPerMonth / 100;
                if (interest > 0)
                {
                    return interest;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                if (this.MonthCount <= 12)
                {
                    decimal interest = this.MonthCount * this.Balance * this.InterestPerMonth / 200;
                    return interest;
                }
                else
                {
                    decimal interest = 12 * this.Balance * this.InterestPerMonth / 200 +
                        (this.MonthCount - 12) * this.Balance * this.InterestPerMonth / 100;
                    return interest;
                }
            }
        }
    }
}
