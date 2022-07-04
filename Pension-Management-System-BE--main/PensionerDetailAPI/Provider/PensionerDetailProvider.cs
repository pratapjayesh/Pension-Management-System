using PensionerDetailAPI.Model;
using PensionerDetailAPI.Repository;

namespace PensionerDetailAPI.Provider
{
    public class PensionerDetailProvider : IPensionerDetailProvider
    {
        private readonly IPensionerDetailRepository _repository;

        public PensionerDetailProvider(IPensionerDetailRepository repository)
        {
            _repository = repository;
        }

        public PensionerDetail PensionerDetailByAadhaar(string aadhaarNumber)
        {
            return _repository.PensionerDetailByAadhaar(aadhaarNumber);
        }
    }
}
