using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PensionDisbursementAPI.Model;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PensionDisbursementAPI.Repository
{
    public class PensionDisbursementRepository : IPensionDisbursementRepository
    {
        private readonly IConfiguration _configuration;

        public PensionDisbursementRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public PensionerDetail GetPensionerDetail(string aadhaarNumber)
        {
            PensionerDetail response = new PensionerDetail(); 
            string pensionDetailUrl = _configuration["PensionerDetailUrl"];

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(pensionDetailUrl);
            client.Timeout=TimeSpan.FromSeconds(30);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage message = client.GetAsync(_configuration["PensionerDetailEndPoint"] + "?" + _configuration["PensionerDetailVariable"] + aadhaarNumber).Result;
            if (message.StatusCode == HttpStatusCode.OK)
            {
                string result = message.Content.ReadAsStringAsync().Result;
                response = JsonConvert.DeserializeObject<PensionerDetail>(result);
            }
            else
                response = null;

            return response;
        }

        public int GetStatusCode(ProcessPensionInput request, PensionerDetail pensionerDetail)
        {
            int statusCode = 21;

            if (request.PensionAmount == 0 || request.BankCharge == 0 || (pensionerDetail.BankDetail.BankType == BankTypes.Public && request.BankCharge != 500) || (pensionerDetail.BankDetail.BankType == BankTypes.Private && request.BankCharge != 550))
                statusCode = 21;
            else
            {
                double rate = pensionerDetail.PensionType == PensionTypes.Self ? 0.8 : 0.5;
                double pensionValue = rate * pensionerDetail.SalaryEarned + pensionerDetail.Allowances + request.BankCharge;
             
                if (pensionValue == request.PensionAmount)
                    statusCode = 10;
            }

            return statusCode;
        }
    }
}
