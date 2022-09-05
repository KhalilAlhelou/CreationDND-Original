using System;
using System.Data.SQLite;

public class SQLiteHandler
{
    public SQLiteHandler()
    {
    }
    public void initializeDB()
    {
        SQLiteConnection.CreateFile("dbCharacter.sqlite");

        SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
        m_dbConnection.Open();

        string sql = "create table race (id int, name varchar(50), desc varchar(250))";

        SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
        command.ExecuteNonQuery();

        sql = "insert into race (int, name, desc) values (1, 'elf', 'je suis un elf')";

        command = new SQLiteCommand(sql, m_dbConnection);
        command.ExecuteNonQuery();

        m_dbConnection.Close();


    }

    public void showTable(string tableName)
    {
        string cs = @"URI=dbCharacter.sqlite";

        using var con = new SQLiteConnection(cs);
        con.Open();

        string stm = "SELECT * FROM race";

        using var cmd = new SQLiteCommand(stm, con);
        using SQLiteDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetString(2)}");
        }
        Console.WriteLine("ADASDASDASD");

    }
}