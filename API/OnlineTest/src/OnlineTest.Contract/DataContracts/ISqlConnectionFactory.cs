using System.Data;

namespace OnlineTest.Contract.DataContracts
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
