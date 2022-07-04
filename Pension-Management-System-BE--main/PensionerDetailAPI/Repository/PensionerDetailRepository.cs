using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PensionerDetailAPI.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace PensionerDetailAPI.Repository
{
    public class PensionerDetailRepository : IPensionerDetailRepository
    {
        private readonly ILogger<PensionerDetailRepository> _logger;
        private readonly IConfiguration _configuration;

        public PensionerDetailRepository(ILogger<PensionerDetailRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public PensionerDetail PensionerDetailByAadhaar(string aadhaarNumber)
        {
            PensionerDetail pensionerDetail = GetPensionerDetail(aadhaarNumber);

            if (pensionerDetail == null)
                return null;

            return pensionerDetail;
        }

        private PensionerDetail GetPensionerDetail(string aadhaarNumber)
        {
            PensionerDetail response = null;

            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionString"]))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = _configuration["GetPensionerDetail"];
                    SqlCommand command = new SqlCommand(sqlQuery, connection)
                    {
                        CommandType = CommandType.Text
                    };

                    command.Parameters.AddWithValue("@Aadhaar", aadhaarNumber);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        response = new PensionerDetail();
                        response.Name = reader["Name"].ToString();
                        response.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]).ToString("dd/MM/yyyy");
                        response.Aadhaar = reader["Aadhaar"].ToString();
                        response.PAN = reader["PAN"].ToString();
                        response.SalaryEarned = Convert.ToInt32(reader["Salary"]);
                        response.Allowances = Convert.ToInt32(reader["Allowances"].ToString());
                        response.PensionType = (PensionTypes)Convert.ToInt32(reader["PensionType"].ToString());
                        response.BankDetail = new BankDetails()
                        {
                            BankName = reader["BankName"].ToString(),
                            AccountNumber = reader["AccountNumber"].ToString(),
                            BankType = (BankTypes)Convert.ToInt32(reader["BankType"].ToString())
                        };
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.ToString());
                }
            }

            return response;
        }
    }
}
