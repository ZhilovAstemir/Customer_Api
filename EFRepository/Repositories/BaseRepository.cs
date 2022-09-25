using System.Data.SqlClient;

namespace EFRepository.Repositories
{
    public class BaseRepository
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CustomerLib_Bekov;Integrated Security=True");
        }
    }
}
