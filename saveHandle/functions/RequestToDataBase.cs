using System;
using Microsoft.Data.Sqlite;
using Cosmolapy.saveHandle.structuresOfData;
using Cosmolapy.saveHandle.cryption;
using System.Collections.Generic;
using Godot;

namespace Cosmolapy.saveHandle.functions;

public static class RequestToDataBase
{
    // public static void SaveData(Dictionary<DataType, string> data)
    public static void SaveData()
    {
        
    }

    private static int UpdateDataInTable(Dictionary<DataType, string> data)
    {
        int numberOfInserted = 0;
        using (SqliteConnection connection = new SqliteConnection("DataSource=saveHandle/data/Data.db"))
        {
            connection.Open();

            SqliteCommand command = connection.CreateCommand();

            command.Connection = connection;
            
            foreach (DataType type in data.Keys)
            {
                command.CommandText = $"UPDATE DataTable SET TypeInfo='{data[type]}' WHERE Type='{type}'";

                numberOfInserted += command.ExecuteNonQuery();
            }
        }
        return numberOfInserted;
    }

    private static int InsertDataInTable(Dictionary<DataType, string> data)
    {
        int numberOfInserted = 0;
        using (SqliteConnection connection = new SqliteConnection("DataSource=saveHandle/data/Data.db"))
        {
            connection.Open();

            SqliteCommand command = connection.CreateCommand();

            command.Connection = connection;
            
            foreach (DataType type in data.Keys)
            {
                command.CommandText = $"INSERT INTO DataTable (Type, TypeInfo) VALUES ({type}, {data[type]})";

                numberOfInserted += command.ExecuteNonQuery();
            }
        }
        return numberOfInserted;
    }

    public static Dictionary<DataType, string> GetDataFromTable()
    {
        Dictionary<DataType, string> data = new Dictionary<DataType, string>();
        using (SqliteConnection connection = new SqliteConnection("DataSource=saveHandle/data/Data.db"))
        {
            connection.Open();

            SqliteCommand command = connection.CreateCommand();

            command.Connection = connection;
            command.CommandText = "SELECT * FROM DataTable";

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string type = reader.GetString(0);
                        string TypeInfo = reader.GetString(1);

                        try 
                        {
                            data[(DataType)Enum.Parse(typeof(DataType), type)] = TypeInfo;
                        }
                        catch (ArgumentException _ex)
                        {
                            GD.PrintErr(type, "", _ex);
                            DeleteDataFromTable(type);
                        }
                    }
                    return data;
                }
            }
        }
        return data;
    }

    /// <summary>
    /// Use only for name and password! Nothing more!
    /// It's slow function
    /// </summary>
    /// <param name="listofTypes"></param>
    /// <returns>Dictionary with keys you entered</returns>
    public static Dictionary<DataType, string> GetDataFromTable(List<DataType> keys)
    {
        Dictionary<DataType, string> data = new Dictionary<DataType, string>();
        using (SqliteConnection connection = new SqliteConnection("DataSource=saveHandle/data/Data.db"))
        {
            connection.Open();

            SqliteCommand command = connection.CreateCommand();

            command.Connection = connection;
            command.CommandText = "SELECT * FROM DataTable";

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string type = reader.GetString(0);
                        foreach (DataType getType in keys)
                            if (type == getType.ToString())
                            {
                                data[getType] = reader.GetString(1);
                            }
                    }
                    return data;
                }
            }
        }
        return data;
    }

    public static Dictionary<DataType, string> GetDataFromTable(DataType getType)
    {
        Dictionary<DataType, string> data = new Dictionary<DataType, string>();
        using (SqliteConnection connection = new SqliteConnection("DataSource=saveHandle/data/Data.db"))
        {
            connection.Open();

            SqliteCommand command = connection.CreateCommand();

            command.Connection = connection;
            command.CommandText = "SELECT * FROM DataTable";

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string type = reader.GetString(0);
                        if (type == getType.ToString())
                        {
                            data[getType] = reader.GetString(1);
                            break;
                        }
                    }
                    return data;
                }
            }
        }
        return data;
    }

    public static void CreateTable()
    {
        using (SqliteConnection connection = new SqliteConnection("DataSource=saveHandle/data/Data.db"))
        {
            connection.Open();

            SqliteCommand command = connection.CreateCommand();

            command.Connection = connection;
            command.CommandText = "CREATE TABLE IF NOT EXISTS DataTable (Type TEXT UNIQUE NOT NULL,TypeInfo TEXT NOT NULL)";

            command.ExecuteNonQuery();
        }
    }

    public static int DeleteDataFromTable(List<DataType> data)
    {
        int numberOfDeleted = 0;
        using (SqliteConnection connection = new SqliteConnection("DataSource=saveHandle/data/Data.db"))
        {
            connection.Open();

            SqliteCommand command = connection.CreateCommand();

            command.Connection = connection;
            
            foreach (DataType type in data)
            {
                command.CommandText = $"DELETE FROM DataTable WHERE Type='{type}'";

                numberOfDeleted += command.ExecuteNonQuery();
            }
        }
        return numberOfDeleted;
    }

    public static int DeleteDataFromTable(DataType data)
    {
        using (SqliteConnection connection = new SqliteConnection("DataSource=saveHandle/data/Data.db"))
        {
            connection.Open();

            SqliteCommand command = connection.CreateCommand();

            command.Connection = connection;

            command.CommandText = $"DELETE FROM DataTable WHERE Type='{data}'";

            return command.ExecuteNonQuery();
        }
    }

    public static int DeleteDataFromTable(string data)
    {
        using (SqliteConnection connection = new SqliteConnection("DataSource=saveHandle/data/Data.db"))
        {
            connection.Open();

            SqliteCommand command = connection.CreateCommand();

            command.Connection = connection;

            command.CommandText = $"DELETE FROM DataTable WHERE Type='{data}'";

            return command.ExecuteNonQuery();
        }
    }
}
