using SSO.Model.DomainObject;
using SSO.Repository.Interface;
using System;
using System.Data.SqlClient;

namespace SSO.Repository.Implementation
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDatabaseRepository _databaseRepository;
        private readonly SqlConnection _connection;
        public AccountRepository(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
            _connection = _databaseRepository.GetSSOdbConnection();
        }

        public bool VerifyUser(UserAuthenticate model)
        {
            using (_connection)
            {
                try
                {
                    var query = "SELECT count(*) as user_exist FROM app_user WHERE Username=@username AND Password=@password";
                    SqlCommand command = new SqlCommand(query, _connection);
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@username", model.Username);
                    command.Parameters.AddWithValue("@password", model.Password);
                    _connection.Open();

                    if (command.ExecuteScalar().ToString() == "1")
                        return true;

                    return false;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    _databaseRepository.CloseConnection();
                }
            }           
        }
    }
}
