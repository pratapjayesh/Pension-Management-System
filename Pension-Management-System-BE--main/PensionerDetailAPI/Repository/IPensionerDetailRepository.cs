using PensionerDetailAPI.Model;

namespace PensionerDetailAPI.Repository
{
    public interface IPensionerDetailRepository
    {
        public PensionerDetail PensionerDetailByAadhaar(string aadhaarNumber);
    }
}
