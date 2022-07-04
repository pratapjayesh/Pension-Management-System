using PensionDisbursementAPI.Model;

namespace PensionDisbursementAPI.Repository
{
    public interface IPensionDisbursementRepository
    {
        public PensionerDetail GetPensionerDetail(string aadhaarNumber);

        public int GetStatusCode(ProcessPensionInput request, PensionerDetail pensionerDetail);
    }
}
