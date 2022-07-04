namespace PensionDisbursementAPI.Model
{
    public class ProcessPensionInput
    {
        public string AadhaarNumber { get; set; }
        public double PensionAmount { get; set; }
        public int BankCharge { get; set; }
    }
}
