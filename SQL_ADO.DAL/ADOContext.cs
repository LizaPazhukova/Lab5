using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_ADO.DAL
{
    public interface IADOContext : IDisposable
    {
        void CreateCommand(SqlCommand command);
        void SaveChanges();
    }
    public class ADOContext: IADOContext
    {
        private SqlConnection connection;
        private SqlTransaction transaction;

        public ADOContext(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            transaction = connection.BeginTransaction();
        }

        public void CreateCommand(SqlCommand command)
        {
            command.Connection = connection;
            command.Transaction = transaction;
        }

        public void Dispose()
        {
            if (transaction != null)
            {
                transaction.Rollback();
                transaction = null;
            }
            if (connection != null)
            {
                connection.Close();
                connection = null;
            }
        }

        public void SaveChanges()
        {
            if (transaction == null)
                throw new InvalidOperationException("Transaction has already been commited");

            transaction.Commit();

            if (connection.State == System.Data.ConnectionState.Open)
                transaction = connection.BeginTransaction();
            else
                transaction = null;
        }
    }
}
