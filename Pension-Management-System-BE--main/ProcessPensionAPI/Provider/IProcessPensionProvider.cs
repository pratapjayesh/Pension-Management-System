using ProcessPensionAPI.Models;

namespace ProcessPensionAPI.Provider
{
    public interface IProcessPensionProvider
    {
        public PensionDetail PensionDetail(string aadhaarNumber);

        public string ProcessPension(ProcessPensionRequest request);
    }
}
