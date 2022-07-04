using System;

namespace PensionerDetailAPI.Model
{
    public class PensionerDetail
    {
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string Aadhaar { get; set; }
        public string PAN { get; set; }
        public int SalaryEarned { get; set; }
        public int Allowances { get; set; }
        public PensionTypes PensionType { get; set; }
        public BankDetails BankDetail { get; set; }
    }

    public enum PensionTypes
    {
        Self = 1,
        Family = 2
    }

    public class BankDetails
    {
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public BankTypes BankType { get; set; }
    }

    public enum BankTypes
    {
        Public = 1,
        Private = 2
    }
}
