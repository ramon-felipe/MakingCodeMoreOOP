using System;

namespace State
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");

            var account = new Account(OnUnfreeze);

            account.Deposit(10);
            Console.WriteLine("Balance should be 10: {0}", account.Balance);
            // balance = 10

            account.HolderVerified();
            account.Withdraw(1);
            // balance = 9
            Console.WriteLine("Balance should be 9: {0}", account.Balance);

            account.Freeze();

            account.Withdraw(2);
            Console.WriteLine("Balance should be 7: {0}", account.Balance);
            // balance = 7

            account.Deposit(3);
            Console.WriteLine("Balance should be 10: {0}", account.Balance);
            // balance = 10

            account.Close();
            account.Deposit(1);
            // balance = 10
            account.Withdraw(1);
            // balance = 10

            Console.WriteLine("Balance after close account: {0}", account.Balance);


            Console.ReadKey();
        }

        static void OnUnfreeze()
        {
            Console.WriteLine("OnUnfreeze called...");
        }
    }
}
