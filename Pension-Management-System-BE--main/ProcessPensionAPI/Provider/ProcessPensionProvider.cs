using ProcessPensionAPI.Models;
using ProcessPensionAPI.Repository;

namespace ProcessPensionAPI.Provider
{
    public class ProcessPensionProvider : IProcessPensionProvider
    {
        private IProcessPensionRepository _repository;

        public ProcessPensionProvider(IProcessPensionRepository repository)
        {
            _repository = repository;
        }

        public PensionDetail PensionDetail(string aadhaarNumber)
        {
            PensionerDetail pensionerDetail = _repository.GetPensionerDetail(aadhaarNumber);

            if (pensionerDetail != null)
            {
                double pensionAmount = _repository.CalculatePensionAmount(pensionerDetail);

                PensionDetail pensionDetail = new PensionDetail()
                {
                    Name = pensionerDetail.Name,
                    DateOfBirth = pensionerDetail.DateOfBirth,
                    PAN = pensionerDetail.PAN,
                    PensionType = pensionerDetail.PensionType,
                    PensionAmount = pensionAmount
                };

                return pensionDetail;
            }
            else
                return null;
        }

        public string ProcessPension(ProcessPensionRequest request)
        {
            string message = string.Empty;
            int statusCode = _repository.ProcessPension(request);

            if ((UserDefinedStatusCode)statusCode == UserDefinedStatusCode.Success)
                message = UserDefinedStatusCode.Success.GetDisplayName();
            else
                message = UserDefinedStatusCode.Fail.GetDisplayName();

            return message;
        }
    }
}
