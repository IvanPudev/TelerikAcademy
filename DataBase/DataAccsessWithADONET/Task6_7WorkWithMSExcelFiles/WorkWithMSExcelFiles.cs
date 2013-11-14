using System;
using System.Data.OleDb;
using System.Linq;

namespace Task6And7WorkWithMSExcelFiles
{
    internal class WorkWithMSExcelFiles
    {
        static void Main(string[] args)
        {
            ReadFromExcelTable();
            InsertRowInExcelFile("Pesho Goshev", 12);
            ReadFromExcelTable();
        }

        private static void ReadFromExcelTable()
        {
            OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data Source=..\..\ScoreTable.xlsx;Extended Properties=""Excel 12.0 XML;HDR=Yes""");
            connection.Open();
            using (connection)
            {
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", connection);

                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string name = (string)reader["Name"];
                    double score = (double)reader["Score"];
                    Console.WriteLine("Name: {0} - Score: {1}", name, score);
                }
            }
        }

        private static void InsertRowInExcelFile( string name, double score)
        {
            OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data Source=..\..\ScoreTable.xlsx;Extended Properties=""Excel 12.0 XML;HDR=Yes""");
            connection.Open();
            using (connection)
            {
                OleDbCommand cmd = new OleDbCommand("INSERT INTO [Sheet1$] (Name, Score) VALUES (@name, @score)", connection);

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@score", score);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
