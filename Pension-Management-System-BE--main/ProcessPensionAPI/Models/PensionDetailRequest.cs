namespace ProcessPensionAPI.Models
{
    public class PensionDetailRequest
    {
        public string Name { get; set; }
        public string AadhaarNumber { get; set; }
        public string PAN { get; set; }
        public PensionTypes PensionType { get; set; }
    }
}
