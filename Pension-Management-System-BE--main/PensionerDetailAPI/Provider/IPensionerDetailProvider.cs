using PensionerDetailAPI.Model;

namespace PensionerDetailAPI.Provider
{
    public interface IPensionerDetailProvider
    {
        public PensionerDetail PensionerDetailByAadhaar(string aadhaarNumber);
    }
}
