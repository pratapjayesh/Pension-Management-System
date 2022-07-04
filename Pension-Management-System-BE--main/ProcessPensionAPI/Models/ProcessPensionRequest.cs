using System.ComponentModel.DataAnnotations;

namespace ProcessPensionAPI.Models
{
    public class ProcessPensionRequest
    {
        public string AadhaarNumber { get; set; }
        public double PensionAmount { get; set; }
        public int BankCharge { get; set; }
    }

    public enum UserDefinedStatusCode
    {
        [Display(Name = "Pension Disbursement Success")]
        Success = 10,
        [Display(Name = "Pension amount calculated is wrong, Please redo calculation")]
        Fail = 21
    }

    public class ProcessPensionResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
