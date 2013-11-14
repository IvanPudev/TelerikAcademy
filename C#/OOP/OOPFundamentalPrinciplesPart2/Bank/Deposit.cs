using System;
using System.Linq;

namespace Bank
{
    public class Deposit : Account, Interface.IWithDrawable
    {
        public Deposit(Customer customer, decimal interest, int months)
        {
            this.Customer = customer;
            this.InterestPerMonth = interest;
            this.MonthCount = months;
        }

        public void WithDraw(decimal getMoney)
        {
            if (getMoney < 0 || getMoney > this.balance)
            {
                throw new System.ArgumentException("Invalid operation. Not enough money.");
            }
            this.balance -= getMoney;
        }

        public override decimal CalcIntrestAmount()
        {
            if (balance < 1000)
            {
                return 0;
            }
            else
            {
                return base.CalcIntrestAmount();
            }
        }
    }
}
