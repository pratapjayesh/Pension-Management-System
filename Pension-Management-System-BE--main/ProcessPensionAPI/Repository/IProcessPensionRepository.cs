using ProcessPensionAPI.Models;

namespace ProcessPensionAPI.Repository
{
    public interface IProcessPensionRepository
    {
        public PensionerDetail GetPensionerDetail(string AadhaarNumber);
        public double CalculatePensionAmount(PensionerDetail request);
        public int ProcessPension(ProcessPensionRequest request);
    }
}
