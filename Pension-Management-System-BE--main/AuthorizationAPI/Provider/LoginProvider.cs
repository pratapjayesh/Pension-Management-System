using AuthorizationAPI.Models;
using AuthorizationAPI.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AuthorizationAPI.Provider
{
    public class LoginProvider : ILoginProvider
    {
        private readonly IConfiguration _config;
        private readonly ILogger<LoginProvider> _logger;
        private readonly AuthRepository _authrepo;

        public LoginProvider(IConfiguration config, ILogger<LoginProvider> logger, AuthRepository authrepo)
        {
            _config = config;
            _logger = logger;
            _authrepo = authrepo;
        }

        public string Login(Credentials request)
        {
            string response = null;

            using (SqlConnection connection = new SqlConnection(_config["ConnectionString"]))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = _config["LoginQuery"];
                    SqlCommand command = new SqlCommand(sqlQuery, connection)
                    {
                        CommandType = CommandType.Text
                    };

                    command.Parameters.AddWithValue("@User", request.Username);
                    command.Parameters.AddWithValue("@Pass", request.Password);


                    DataTable dataTable = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                    sqlDataAdapter.Fill(dataTable);
                    int result = dataTable.Rows.Count;

                    if (result == 1)
                        response = _authrepo.GenerateJsonWebToken(request);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.ToString());
                }
            }

            return response;
        }

        public bool Registration(Credentials request)
        {
            bool response = false;

            using (SqlConnection connection = new SqlConnection(_config["ConnectionString"]))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = _config["RegistrationQuery"];
                    SqlCommand command = new SqlCommand(sqlQuery, connection)
                    {
                        CommandType = CommandType.Text
                    };

                    command.Parameters.AddWithValue("@User", request.Username);
                    command.Parameters.AddWithValue("@Pass", request.Password);

                    int result = command.ExecuteNonQuery();
                    if (result == 1)
                        response = true; 
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
