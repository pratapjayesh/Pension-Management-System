using PensionDisbursementAPI.Model;

namespace PensionDisbursementAPI.Provider
{
    public interface IPensionDisbursementProvider
    {
        public int DisbursePension(ProcessPensionInput request);
    }
}
