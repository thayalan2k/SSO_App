using System.Data.SqlClient;

namespace SSO.Repository.Interface
{
    public interface IDatabaseRepository
    {
        SqlConnection GetSSOdbConnection();
        void CloseConnection();
    }
}
