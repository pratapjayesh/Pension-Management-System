namespace ProcessPensionAPI.Models
{
    public class PensionDetail
    {
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string PAN { get; set; }
        public PensionTypes PensionType { get; set; }
        public double PensionAmount { get; set; }
    }
}
