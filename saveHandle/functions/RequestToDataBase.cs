using System;
using Microsoft.Data.Sqlite;
using Cosmolapy.saveHandle.structuresOfData;
using System.Collections.Generic;
using Godot;

namespace Cosmolapy.saveHandle.functions;

public static class RequestToDataBase
{
    public static void LoadData()
    {
        Dictionary<DataType, string> dataTable = GetDataFromTable();

        LoadDataInGlobal(dataTable);
    }

    public static void SaveData()
    {
        Dictionary<DataType, string> dataTable = GetDataFromTable();
        Dictionary<DataType, string> dataGlobal = CreateDataFromGlobal();
        
        if (IsTypesInTableGood(dataGlobal, dataTable))
        {
            UpdateDataInTable(dataGlobal);
        }
        else
        {
            DeleteDataFromTable(GetTypesFromTable());
            InsertDataInTable(dataGlobal);
        }
    }

    private static void LoadDataInGlobal(Dictionary<DataType, string> dataTable)
    {
        foreach (DataType key in dataTable.Keys)
        {
            switch (key)
            {
                case DataType.Wood:
                    Global.mainModel.resources.Wood = Convert.ToInt32(dataTable[key]);
                    break;
                case DataType.Iron:
                    Global.mainModel.resources.Iron = Convert.ToInt32(dataTable[key]);
                    break;
                case DataType.BioFuel:
                    Global.mainModel.resources.BioFuel = Convert.ToInt32(dataTable[key]);
                    break;
                case DataType.Honey:
                    Global.mainModel.resources.Honey = Convert.ToInt32(dataTable[key]);
                    break;
                case DataType.Name:
                    Global.playerRegistrationData.name = dataTable[key];
                    break;
                case DataType.Password:
                    Global.playerRegistrationData.password = dataTable[key];
                    break;
            }
        }
    }

    private static Dictionary<DataType, string> CreateDataFromGlobal()
    {
        Dictionary<DataType, string> data = new Dictionary<DataType, string>()
        {
            { DataType.Wood, Global.mainModel.resources.Wood.ToString() },
            { DataType.Iron, Global.mainModel.resources.Iron.ToString() },
            { DataType.BioFuel, Global.mainModel.resources.BioFuel.ToString() },
            { DataType.Honey, Global.mainModel.resources.Honey.ToString() },
            { DataType.Name, Global.playerRegistrationData.name },
            { DataType.Password, Global.playerRegistrationData.password },

        };
        return data;
    }

    private static bool IsTypesInTableGood(Dictionary<DataType, string> dataGlobal, Dictionary<DataType, string> dataTable) 
    {
        foreach (DataType type in dataGlobal.Keys)
        {
            if (!dataTable.ContainsKey(type))
            {
                return false;
            }
        }

        return true;
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

    private static List<DataType> GetTypesFromTable()
    {
        List<DataType> data = new List<DataType>();
        using (SqliteConnection connection = new SqliteConnection("DataSource=saveHandle/data/Data.db"))
        {
            connection.Open();

            SqliteCommand command = connection.CreateCommand();

            command.Connection = connection;
            command.CommandText = "SELECT Type FROM DataTable";

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string type = reader.GetString(0);
                        
                        data.Add((DataType)Enum.Parse(typeof(DataType), type));
                    }
                    return data;
                }
            }
        }
        return data;
    }

    private static Dictionary<DataType, string> GetDataFromTable()
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
                        string typeInfo = reader.GetString(1);

                        try 
                        {
                            data[(DataType)Enum.Parse(typeof(DataType), type)] = typeInfo;
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
    private static Dictionary<DataType, string> GetDataFromTable(List<DataType> keys)
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

    private static Dictionary<DataType, string> GetDataFromTable(DataType getType)
    {
        Dictionary<DataType, string> data = new Dictionary<DataType, string>();
        using (SqliteConnection connection = new SqliteConnection("DataSource=saveHandle/data/Data.db"))
        {
            connection.Open();

            SqliteCommand command = connection.CreateCommand();

            command.Connection = connection;
            command.CommandText = $"SELECT * FROM DataTable WHERE Type='{getType}'";

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

    /// <summary>
    /// Deletes all data from db. Use with understanding of what you doing
    /// </summary>
    /// <returns></returns>
    public static int DeleteDataFromTable()
    {
        using (SqliteConnection connection = new SqliteConnection("DataSource=saveHandle/data/Data.db"))
        {
            connection.Open();

            SqliteCommand command = connection.CreateCommand();

            command.Connection = connection;

            command.CommandText = $"DELETE FROM DataTable";

            return command.ExecuteNonQuery();
        }
    }

    private static int DeleteDataFromTable(List<DataType> data)
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

    private static int DeleteDataFromTable(DataType data)
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

    private static int DeleteDataFromTable(string data)
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
