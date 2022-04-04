using System;
using System.Collections.Generic;
using System.Text;

namespace State
{
    public class Account
    {
        public decimal Balance { get; private set; }
        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; }
        
        public Action OnUnfreeze { get; }
        private Action ManageUnfreezing { get; set; }


        public Account(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;

            this.ManageUnfreezing = this.StayUnfrozen;
        }

        public void Deposit(decimal amount)
        {
            if (this.IsClosed)
                return;

            ManageUnfreezing();

            this.Balance += amount;
        }


        public void Withdraw(decimal amount)
        {
            if (!this.IsVerified || this.IsClosed)
                return;

            ManageUnfreezing();

            this.Balance -= amount;
        }

        private void StayUnfrozen()
        {
            Console.WriteLine("Not freezed");
        }

        private void Unfreeze()
        {
            this.OnUnfreeze();
            this.ManageUnfreezing = this.StayUnfrozen;

            Console.WriteLine("Unfreezed!");
        }

        public void HolderVerified()
        {
            this.IsVerified = true;
        }

        public void Close()
        {
            this.IsClosed = true;
        }

        public void Freeze()
        {
            if (this.IsClosed)
                return;
            if (!this.IsVerified)
                return;

            this.ManageUnfreezing = this.Unfreeze;
            Console.WriteLine("Freezed!");
        }
    }
}
