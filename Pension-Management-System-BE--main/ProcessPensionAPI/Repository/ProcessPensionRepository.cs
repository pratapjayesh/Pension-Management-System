using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ProcessPensionAPI.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ProcessPensionAPI.Repository
{
    public class ProcessPensionRepository : IProcessPensionRepository
    {
        private readonly IConfiguration _configuration;

        public ProcessPensionRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public PensionerDetail GetPensionerDetail(string AadhaarNumber)
        {
            PensionerDetail response = new PensionerDetail();
            string pensionDetailUrl = _configuration["PensionerDetailUrl"];

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(pensionDetailUrl);
            client.Timeout = TimeSpan.FromSeconds(30);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage message = client.GetAsync(_configuration["PensionerDetailEndPoint"] + "?" + _configuration["PensionerDetailVariable"] + AadhaarNumber).Result;
            if (message.StatusCode == HttpStatusCode.OK)
            {
                string result = message.Content.ReadAsStringAsync().Result;
                response = JsonConvert.DeserializeObject<PensionerDetail>(result);
            }
            else
                response = null;

            return response;

        }

        public double CalculatePensionAmount(PensionerDetail request)
        {
            double amount = 0;

            if (request.PensionType == PensionTypes.Self)
                amount += (0.8 * request.SalaryEarned) + request.Allowances;
            else
                amount += (0.5 * request.SalaryEarned) + request.Allowances;

            if (request.BankDetail.BankType == BankTypes.Public)
                amount += 500;
            else
                amount += 550;

            return amount;
        }

        public int ProcessPension(ProcessPensionRequest request)
        {
            string pensionDetailUrl = _configuration["PensionDisbursementUrl"];

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(pensionDetailUrl);
            client.Timeout = TimeSpan.FromSeconds(30);
            client.DefaultRequestHeaders.Clear();
            StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            HttpResponseMessage message = client.PostAsync(_configuration["PensionDisbursementEndPoint"], content).Result;

            return Convert.ToInt32(message.Content.ReadAsStringAsync().Result);
        }
    }
}
