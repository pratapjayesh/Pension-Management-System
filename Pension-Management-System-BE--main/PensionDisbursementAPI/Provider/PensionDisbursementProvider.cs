using PensionDisbursementAPI.Model;
using PensionDisbursementAPI.Repository;

namespace PensionDisbursementAPI.Provider
{
    public class PensionDisbursementProvider : IPensionDisbursementProvider
    {
        private readonly IPensionDisbursementRepository _repository;

        public PensionDisbursementProvider(IPensionDisbursementRepository repository)
        {
            _repository = repository;
        }

        public int DisbursePension(ProcessPensionInput request)
        {
            int statusCode = 21;
            PensionerDetail pensionerDetail = _repository.GetPensionerDetail(request.AadhaarNumber);
            if (pensionerDetail != null)
            {
                int counter = 3;
                while (statusCode == 21 && counter > 0)
                { 
                    statusCode = _repository.GetStatusCode(request, pensionerDetail);
                    counter--;
                }
            }

            return statusCode;
        }
    }
}
