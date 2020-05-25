using System;
namespace POS.Models
{
    public class PocketBalance
    {
        public string PocketID { get; set; }
        public string PocketName { get; set; }

        public string Balance { get; set; }
        public string Type { get; set; }
        public string BalanceType { get; set; }
        public string CreateDate { get; set; }
        public string TargetDate { get; set; }

        public string TargetAmount { get; set; }

        public string isLock { get; set; }

        public string WalletUniqueCode { get; set; }




        public PocketBalance(string pocketID, string pocketName, string balance, string balanceType,
        string createDate, string targetDate, string targetAmount, string islock, string walletuniquecode)
        {
            PocketID = pocketID;
            PocketName = pocketName;
            Balance = balance;
            BalanceType = balanceType;
            CreateDate = createDate;
            TargetDate = targetDate;
            TargetAmount = targetAmount;
            isLock = islock;
            WalletUniqueCode = walletuniquecode;

        }

        /// <summary>
        /// Parameterless class definition for JSON deserialization
        /// </summary>
        public PocketBalance() { }
    }
}
