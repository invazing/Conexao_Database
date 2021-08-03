using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data;

namespace Conexao_Database
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    public class Access_Database
    {
        readonly string mdfFile = @"DataBase_Access.mdb";
        public DataTable Consulta(string SQL)
        {
            using (OleDbConnection connection = new OleDbConnection(string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", mdfFile)))
            {
                using (OleDbCommand selectCommand = new OleDbCommand(SQL, connection))
                {
                    connection.Open();
                    DataTable table = new DataTable();
                    OleDbDataAdapter adapter = new OleDbDataAdapter
                    {
                        SelectCommand = selectCommand
                    };
                    adapter.Fill(table);
                    return table;
                }
            }
        }
        public void Inserir(string SQL)
        {
            using (OleDbConnection connection = new OleDbConnection(string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", mdfFile)))
            {
                using (OleDbCommand insertCommand = new OleDbCommand(SQL, connection))
                {
                    connection.Open();
                    /*
                    insertCommand.Parameters.AddWithValue("@Nome", "1");
                    insertCommand.Parameters.AddWithValue("@Idade", "2");
                    insertCommand.Parameters.AddWithValue("@Info", "3");
                    */
                    insertCommand.ExecuteNonQuery();
                }
            }
        }
        public void Deletar(string SQL, int ID)
        {
            using (OleDbConnection connection = new OleDbConnection(string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", mdfFile)))
            {
                using (OleDbCommand deleteCommand = new OleDbCommand(SQL, connection))
                {
                    connection.Open();
                    deleteCommand.Parameters.AddWithValue("@ID", ID);
                    deleteCommand.ExecuteNonQuery();
                }
            }
        }
    }

    public class MYSQL
    {
        public DataTable Consulta(string SQL)
        {
            return null;
        }

        public void Insert(string SQL)
        {

        }

        public void Delete(string SQL)
        {

        }
        
    }


    public class OracleSQL
    {
        public DataTable Consulta(string SQL)
        {
            return null;
        }

        public void Insert(string SQL)
        {

        }

        public void Delete(string SQL)
        {

        }
    }
}
