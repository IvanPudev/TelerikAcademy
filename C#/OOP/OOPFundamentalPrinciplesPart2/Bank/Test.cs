using System;
using System.Linq;

namespace Bank
{
    class Test
    {
        static void Main()
        {
            Deposit account = new Deposit(new Individual("John", "Smith"), 5.9m, 10);
            account.Deposit(10000m);
            Console.WriteLine(account.CalcIntrestAmount());
            account.WithDraw(1000m);
            Console.WriteLine(account.Balance);
        }
    }
}
