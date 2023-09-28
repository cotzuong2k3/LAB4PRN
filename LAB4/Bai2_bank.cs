using System;

namespace LAB4
{
    internal class Bai2_bank
    {
        public delegate void BalanceChangedEventHandler(decimal newBalance);


        public class Account
        {
            public event BalanceChangedEventHandler BalanceChanged;

            private decimal balance;

            public decimal Balance
            {
                get { return balance; }
                set
                {
                    balance = value;
                    OnBalanceChanged(balance);
                }
            }

            protected virtual void OnBalanceChanged(decimal newBalance)
            {
                BalanceChanged?.Invoke(newBalance);
            }

        }

        public class Program
        {
            static void Main()
            {
                Account account = new Account();
                account.BalanceChanged += HandleBalanceChanged;


                decimal transactionAmount = 100.00M;
                account.Balance += transactionAmount;

                transactionAmount = 200.00M;
                account.Balance += transactionAmount;
            }

            static void HandleBalanceChanged(decimal newBalance)
            {
                Console.WriteLine($"New account Balance: {newBalance}");
            }

        }


    }


}




