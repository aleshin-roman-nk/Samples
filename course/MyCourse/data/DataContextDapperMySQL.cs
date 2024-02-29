using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace MyCourse.Data
{


    public class DataContextDapperMySQL
    {
        // server=your_server_address;port=3306;database=your_database_name;user=your_username;password=your_password;"
        //private string _connectionString = "Server=localhost;Database=mycourse;port=3306;user=root;password=1111";
        private string? _connectionString;

        public DataContextDapperMySQL(IConfiguration config)
        {
            //_connectionString = config.GetConnectionString("RemoteMySqlConnection");
            _connectionString = config.GetConnectionString("LocalDockerMySqlConnection");
        }

        public IEnumerable<TData> LoadData<TData>(string sql)
        {
            IDbConnection dbConnection = new MySqlConnection(_connectionString);
            return dbConnection.Query<TData>(sql);
        }

        public TData LoadDataSingle<TData>(string sql)
        {
            IDbConnection dbConnection = new MySqlConnection(_connectionString);
            return dbConnection.QuerySingle<TData>(sql);
        }

        public bool ExecuteSql(string sql)
        {
            IDbConnection dbConnection = new MySqlConnection(_connectionString);
            return dbConnection.Execute(sql) > 0;
        }

        public bool ExecuteSqlWithParameters(string sql, object param){
            IDbConnection dbConnection = new MySqlConnection(_connectionString);
            return dbConnection.Execute(sql, param) > 0;
        }

        public int ExecuteSqlWithRows(string sql)
        {
            IDbConnection dbConnection = new MySqlConnection(_connectionString);
            return dbConnection.Execute(sql);
        }
    }
}